// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Owns process rate baselines for one polling subscription.</summary>
internal sealed class ProcessSampler : ISystemSampler<ProcessSnapshot>
{
    /// <summary>The percentage scale.</summary>
    private const int PercentScale = 100;

    /// <summary>The bounded identity query timeout.</summary>
    private static readonly TimeSpan IdentityTimeout = TimeSpan.FromSeconds(2);

    /// <summary>The optional process selection.</summary>
    private readonly int? _processId;

    /// <summary>Whether optional WMI identity is requested.</summary>
    private readonly bool _includeExtendedIdentity;

    /// <summary>The previous samples keyed by identifier.</summary>
    private Dictionary<int, ProcessInfo> _previous = new();

    /// <summary>The previous monotonic capture time.</summary>
    private long _previousTicks;

    /// <summary>Initializes a new instance of the <see cref="ProcessSampler"/> class.</summary>
    /// <param name="processId">The optional process selection.</param>
    /// <param name="includeExtendedIdentity">Whether to query extended WMI identity.</param>
    internal ProcessSampler(int? processId = null, bool includeExtendedIdentity = false)
    {
        if (processId is <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(processId));
        }

        _processId = processId;
        _includeExtendedIdentity = includeExtendedIdentity;
    }

    /// <summary>Captures selected processes while retaining independent per-field errors.</summary>
    /// <returns>The current inventory.</returns>
    public ProcessSnapshot Capture()
    {
        var ticks = Stopwatch.GetTimestamp();
        var elapsed = _previousTicks == 0 ? 0 : (ticks - _previousTicks) / (double)Stopwatch.Frequency;
        var result = new List<ProcessInfo>();
        var next = new Dictionary<int, ProcessInfo>();
        var processes = Process.GetProcesses();
        var processorCount = checked((int)ProcessNative.NativeMethods.GetActiveProcessorCount(ushort.MaxValue));
        foreach (var process in processes)
        {
            using (process)
            {
                var id = process.Id;
                if (_processId.HasValue && id != _processId.Value)
                {
                    continue;
                }

                var sample = Read(process);
                if (_previous.TryGetValue(id, out var previous))
                {
                    ApplyRates(sample, previous, elapsed, processorCount);
                }

                result.Add(sample);
                next[id] = sample;
            }
        }

        var identity = _includeExtendedIdentity ? EnrichIdentity(next) : null;
        _previous = next;
        _previousTicks = ticks;
        return new() { Timestamp = TimeProvider.System.GetUtcNow(), Processes = result.AsReadOnly(), ExtendedIdentityResult = identity };
    }

    /// <summary>Releases the retained managed baselines.</summary>
    public void Dispose() => _previous.Clear();

    /// <summary>Calculates valid deltas only for the same process lifetime.</summary>
    /// <param name="current">The destination sample.</param>
    /// <param name="previous">The previous sample.</param>
    /// <param name="elapsedSeconds">The positive monotonic elapsed time.</param>
    /// <param name="processorCount">The active processor count across all groups.</param>
    internal static void ApplyRates(ProcessInfo current, ProcessInfo previous, double elapsedSeconds, int processorCount)
    {
        if (current.ProcessId != previous.ProcessId || !current.StartTimeUtc.HasValue || current.StartTimeUtc != previous.StartTimeUtc || elapsedSeconds <= 0 || processorCount <= 0)
        {
            return;
        }

        if (current.TotalProcessorTime.HasValue && previous.TotalProcessorTime.HasValue)
        {
            var delta = (current.TotalProcessorTime.Value - previous.TotalProcessorTime.Value).TotalSeconds;
            if (delta >= 0)
            {
                current.CpuUsagePercent = Math.Min(PercentScale, delta * PercentScale / elapsedSeconds / processorCount);
            }
        }

        current.ReadBytesPerSecond = Rate(current.ReadBytes, previous.ReadBytes, elapsedSeconds);
        current.WriteBytesPerSecond = Rate(current.WriteBytes, previous.WriteBytes, elapsedSeconds);
    }

    /// <summary>Reads one field while retaining access and process-exit errors.</summary>
    /// <typeparam name="T">The field value type.</typeparam>
    /// <param name="read">The field getter.</param>
    /// <param name="field">The field name.</param>
    /// <param name="errors">The error destination.</param>
    /// <returns>The field or its default when unavailable.</returns>
    internal static T? ReadField<T>(Func<T> read, string field, List<string> errors)
    {
        try
        {
            return read();
        }
        catch (Exception exception) when (exception is Win32Exception or InvalidOperationException or NotSupportedException or EntryPointNotFoundException
            or UnauthorizedAccessException or System.Security.SecurityException or ArgumentException)
        {
            errors.Add($"{field}: {exception.Message}");
            return default;
        }
    }

    /// <summary>Adds optional WMI parent and command-line identity without crossing process lifetimes.</summary>
    /// <param name="samples">The samples to enrich.</param>
    /// <returns>The provider result.</returns>
    private static WmiQueryResult EnrichIdentity(Dictionary<int, ProcessInfo> samples)
    {
        var identity = WindowsManagement.Query("root\\cimv2", "SELECT ProcessId, ParentProcessId, CommandLine, CreationDate FROM Win32_Process", IdentityTimeout);
        foreach (var row in identity.Rows)
        {
            var id = row.UInt32("ProcessId");
            if (id.HasValue && id.Value <= int.MaxValue && samples.TryGetValue((int)id.Value, out var sample) && sample.StartTimeUtc.HasValue)
            {
                var creation = row.String("CreationDate");
                var errors = new List<string>(sample.Errors);
                var created = creation is null ? null : ReadField<DateTimeOffset?>(
                    () => System.Management.ManagementDateTimeConverter.ToDateTime(creation).ToUniversalTime(),
                    nameof(ProcessInfo.StartTimeUtc),
                    errors);
                sample.Errors = errors.AsReadOnly();

                // WMI DMTF timestamps preserve microseconds; native creation times preserve 100 ns ticks.
                const int TicksPerMicrosecond = 10;
                if (created.HasValue && created.Value.UtcDateTime.Ticks / TicksPerMicrosecond == sample.StartTimeUtc.Value.UtcDateTime.Ticks / TicksPerMicrosecond)
                {
                    sample.ParentProcessId = row.UInt32("ParentProcessId");
                    sample.CommandLine = row.String("CommandLine");
                }
            }
        }

        return identity;
    }

    /// <summary>Computes a monotonic counter rate.</summary>
    /// <param name="current">The current counter.</param>
    /// <param name="previous">The previous counter.</param>
    /// <param name="elapsed">Elapsed seconds.</param>
    /// <returns>The rate or null for an unavailable or reset counter.</returns>
    private static double? Rate(ulong? current, ulong? previous, double elapsed) =>
        current.HasValue && previous.HasValue && current.Value >= previous.Value ? (current.Value - previous.Value) / elapsed : null;

    /// <summary>Reads process fields without making one denied field fail the inventory.</summary>
    /// <param name="process">The process to inspect.</param>
    /// <returns>The typed process sample.</returns>
    private static ProcessInfo Read(Process process)
    {
        var errors = new List<string>();
        var sample = new ProcessInfo
        {
            ProcessId = process.Id,
            Name = ReadField(() => process.ProcessName, nameof(ProcessInfo.Name), errors),
            ExecutablePath = ReadField(() => process.MainModule?.FileName, nameof(ProcessInfo.ExecutablePath), errors),
            StartTimeUtc = ReadField<DateTimeOffset?>(() => process.StartTime.ToUniversalTime(), nameof(ProcessInfo.StartTimeUtc), errors),
            SessionId = ReadField<int?>(() => process.SessionId, nameof(ProcessInfo.SessionId), errors),
            TotalProcessorTime = ReadField<TimeSpan?>(() => process.TotalProcessorTime, nameof(ProcessInfo.TotalProcessorTime), errors),
            WorkingSetBytes = ReadField<long?>(() => process.WorkingSet64, nameof(ProcessInfo.WorkingSetBytes), errors),
            PrivateMemoryBytes = ReadField<long?>(() => process.PrivateMemorySize64, nameof(ProcessInfo.PrivateMemoryBytes), errors),
            PeakWorkingSetBytes = ReadField<long?>(() => process.PeakWorkingSet64, nameof(ProcessInfo.PeakWorkingSetBytes), errors),
            ThreadCount = ReadField<int?>(() => process.Threads.Count, nameof(ProcessInfo.ThreadCount), errors),
            HandleCount = ReadField<int?>(() => process.HandleCount, nameof(ProcessInfo.HandleCount), errors),
            Priority = ReadField<ProcessPriorityClass?>(() => process.PriorityClass, nameof(ProcessInfo.Priority), errors),
        };

        _ = ReadField(() => ReadNative(process, sample, errors), "Native telemetry", errors);
        sample.UserName = ReadField(() => ReadUser(process), nameof(ProcessInfo.UserName), errors);

        sample.Errors = errors.AsReadOnly();
        return sample;
    }

    /// <summary>Reads the documented I/O, memory, and architecture counters.</summary>
    /// <param name="process">The process whose handle is used.</param>
    /// <param name="sample">The destination sample.</param>
    /// <param name="errors">The field error destination.</param>
    /// <returns>Whether native capture completed.</returns>
    private static bool ReadNative(Process process, ProcessInfo sample, List<string> errors)
    {
        using var queryHandle = ProcessQueryHandle.Open(process.Id);
        var handle = queryHandle;
        if (ProcessNative.NativeMethods.GetProcessIoCounters(handle, out var io) != 0)
        {
            sample.ReadBytes = io.ReadBytes;
            sample.WriteBytes = io.WriteBytes;
            sample.ReadOperations = io.ReadOperations;
            sample.WriteOperations = io.WriteOperations;
        }
        else
        {
            errors.Add($"I/O counters: {new Win32Exception(Marshal.GetLastWin32Error()).Message}");
        }

        if (ProcessNative.NativeMethods.GetProcessMemoryInfo(handle, out var memory, checked((uint)Marshal.SizeOf<ProcessNative.MemoryCounters>())) != 0)
        {
            sample.PageFaultCount = memory.PageFaultCount;
        }
        else
        {
            errors.Add($"Page faults: {new Win32Exception(Marshal.GetLastWin32Error()).Message}");
        }

        if (ProcessNative.NativeMethods.IsWow64Process2(handle, out var machine, out var native) != 0)
        {
            sample.Architecture = (machine == 0 ? native : machine) switch
            {
                0x014c => "x86",
                0x8664 => "x64",
                0xaa64 => "arm64",
                0x01c4 => "arm",
                _ => "unknown",
            };
        }
        else
        {
            errors.Add($"Architecture: {new Win32Exception(Marshal.GetLastWin32Error()).Message}");
        }

        return true;
    }

    /// <summary>Reads the process account through a query-only access token.</summary>
    /// <param name="process">The process to inspect.</param>
    /// <returns>The account name.</returns>
    private static string ReadUser(Process process)
    {
        const uint TokenQuery = 0x0008;
        using var queryHandle = ProcessQueryHandle.Open(process.Id);
        if (ProcessNative.NativeMethods.OpenProcessToken(queryHandle, TokenQuery, out var token) == 0)
        {
            var error = Marshal.GetLastWin32Error();
            throw new Win32Exception(error);
        }

        try
        {
            using var identity = new WindowsIdentity(token);
            return identity.Name;
        }
        finally
        {
            _ = ProcessNative.NativeMethods.CloseHandle(token);
        }
    }
}
