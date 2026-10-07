// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
using System.Diagnostics;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>One process sample; null metrics indicate an unavailable value.</summary>
public sealed class ProcessInfo
{
    /// <summary>Gets the process identifier.</summary>
    public int ProcessId { get; internal set; }

    /// <summary>Gets the parent process identifier when extended identity is requested.</summary>
    public uint? ParentProcessId { get; internal set; }

    /// <summary>Gets the command line when extended identity is requested and WMI permits access.</summary>
    public string? CommandLine { get; internal set; }

    /// <summary>Gets the account name when the access token permits queries.</summary>
    public string? UserName { get; internal set; }

    /// <summary>Gets the executable name.</summary>
    public string? Name { get; internal set; }

    /// <summary>Gets the executable path when accessible.</summary>
    public string? ExecutablePath { get; internal set; }

    /// <summary>Gets the creation time used to distinguish recycled process identifiers.</summary>
    public DateTimeOffset? StartTimeUtc { get; internal set; }

    /// <summary>Gets the Windows session identifier.</summary>
    public int? SessionId { get; internal set; }

    /// <summary>Gets the cumulative processor time.</summary>
    public TimeSpan? TotalProcessorTime { get; internal set; }

    /// <summary>Gets the CPU percentage normalized across every active machine processor; null on the first sample.</summary>
    public double? CpuUsagePercent { get; internal set; }

    /// <summary>Gets the resident working set in bytes.</summary>
    public long? WorkingSetBytes { get; internal set; }

    /// <summary>Gets the private committed memory in bytes.</summary>
    public long? PrivateMemoryBytes { get; internal set; }

    /// <summary>Gets the peak working set in bytes.</summary>
    public long? PeakWorkingSetBytes { get; internal set; }

    /// <summary>Gets the thread count.</summary>
    public int? ThreadCount { get; internal set; }

    /// <summary>Gets the handle count.</summary>
    public int? HandleCount { get; internal set; }

    /// <summary>Gets the priority class.</summary>
    public ProcessPriorityClass? Priority { get; internal set; }

    /// <summary>Gets the cumulative process I/O bytes read, including device and network I/O.</summary>
    public ulong? ReadBytes { get; internal set; }

    /// <summary>Gets the cumulative process I/O bytes written, including device and network I/O.</summary>
    public ulong? WriteBytes { get; internal set; }

    /// <summary>Gets the cumulative read operation count.</summary>
    public ulong? ReadOperations { get; internal set; }

    /// <summary>Gets the cumulative write operation count.</summary>
    public ulong? WriteOperations { get; internal set; }

    /// <summary>Gets the sampled process read throughput.</summary>
    public double? ReadBytesPerSecond { get; internal set; }

    /// <summary>Gets the sampled process write throughput.</summary>
    public double? WriteBytesPerSecond { get; internal set; }

    /// <summary>Gets the cumulative hard and soft page faults.</summary>
    public uint? PageFaultCount { get; internal set; }

    /// <summary>Gets the process machine architecture.</summary>
    public string? Architecture { get; internal set; }

    /// <summary>Gets the field-specific access or exit errors.</summary>
    public IReadOnlyList<string> Errors { get; internal set; } = Array.Empty<string>();
}
