// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Owns a PDH query over English counter paths, including wildcard instances.</summary>
public sealed
#if !NETFRAMEWORK
partial
#endif
class PerformanceCounterQuery : ISystemSampler<IReadOnlyList<PerformanceCounterSample>>
{
    /// <summary>The PDH buffer-size status.</summary>
    private const uint MoreData = 0x800007D2;

    /// <summary>The uncapped double format.</summary>
    private const uint Format = 0x00000200 | 0x00008000;

    /// <summary>The formatted native value size.</summary>
    private const int ValueSize = 16;

    /// <summary>The union and item status offset.</summary>
    private const int ValueOffset = 8;

    /// <summary>The array item double offset.</summary>
    private const int ItemValueOffset = 16;

    /// <summary>The maximum array-buffer attempts.</summary>
    private const int MaximumAttempts = 3;

    /// <summary>Serializes captures and disposal.</summary>
    private readonly Lock _gate = new();

    /// <summary>The snapshotted requested paths.</summary>
    private readonly string[] _paths;

    /// <summary>Native counters owned by the query.</summary>
    private readonly IntPtr[] _counters;

    /// <summary>Native counter registration statuses.</summary>
    private readonly uint[] _statuses;

    /// <summary>The lazily acquired query resource.</summary>
    private QueryHandle _query;

    /// <summary>Whether the query has been disposed.</summary>
    private bool _disposed;

    /// <summary>Initializes a new instance of the <see cref="PerformanceCounterQuery"/> class. Native resources are acquired on the first capture.</summary>
    /// <param name="englishCounterPaths">Nonempty English PDH counter paths.</param>
    public PerformanceCounterQuery(IEnumerable<string> englishCounterPaths)
    {
        _paths = ValidatePaths(englishCounterPaths);
        _counters = new IntPtr[_paths.Length];
        _statuses = new uint[_paths.Length];
    }

    /// <summary>Collects current values; rate counters may need two captures.</summary>
    /// <returns>Values and native statuses for requested counters and their instances.</returns>
    public IReadOnlyList<PerformanceCounterSample> Capture()
    {
        lock (_gate)
        {
            Throw.IfDisposed(_disposed, this);
            var results = new List<PerformanceCounterSample>();
            if (_query is null)
            {
                var openStatus = NativeMethods.PdhOpenQueryW(null, UIntPtr.Zero, out var handle);
                if (openStatus != 0)
                {
                    foreach (var path in _paths)
                    {
                        results.Add(Unavailable(path, openStatus));
                    }

                    return results.AsReadOnly();
                }

                _query = new(handle);
                for (var index = 0; index < _paths.Length; index++)
                {
                    _statuses[index] = NativeMethods.PdhAddEnglishCounterW(_query, _paths[index], UIntPtr.Zero, out _counters[index]);
                }
            }

            var collectStatus = NativeMethods.PdhCollectQueryData(_query);
            for (var index = 0; index < _paths.Length; index++)
            {
                var status = _statuses[index];
                if (status == 0 && collectStatus != 0)
                {
                    status = collectStatus;
                }

                if (status != 0)
                {
                    results.Add(Unavailable(_paths[index], status));
                    continue;
                }

                ReadCounter(_paths[index], _counters[index], results);
            }

            return results.AsReadOnly();
        }
    }

    /// <summary>Releases the query and all counters.</summary>
    public void Dispose()
    {
        lock (_gate)
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            _query?.Dispose();
        }
    }

    /// <summary>Snapshots and validates the counter paths.</summary>
    /// <param name="paths">The requested paths.</param>
    /// <returns>The validated copy.</returns>
    internal static string[] ValidatePaths(IEnumerable<string> paths)
    {
        Throw.IfNull(paths);
        var result = new List<string>(paths).ToArray();
        if (result.Length == 0)
        {
            throw new ArgumentException("At least one counter path is required.", nameof(paths));
        }

        foreach (var path in result)
        {
            Throw.IfNullOrWhiteSpace(path, nameof(paths));
        }

        return result;
    }

    /// <summary>Filters invalid native data and nonfinite values.</summary>
    /// <param name="status">The native counter status.</param>
    /// <param name="value">The formatted value.</param>
    /// <returns>The valid value or null.</returns>
    internal static double? ValidValue(uint status, double value) => status <= 1 && !double.IsNaN(value) && !double.IsInfinity(value) ? value : null;

    /// <summary>Creates a missing value with its native status.</summary>
    /// <param name="path">The requested path.</param>
    /// <param name="status">The native status.</param>
    /// <returns>The unavailable sample.</returns>
    private static PerformanceCounterSample Unavailable(string path, uint status) => new() { CounterPath = path, Status = status };

    /// <summary>Reads a single counter or wildcard array.</summary>
    /// <param name="path">The requested path.</param>
    /// <param name="counter">The query-owned counter.</param>
    /// <param name="results">The destination samples.</param>
    private static void ReadCounter(string path, IntPtr counter, List<PerformanceCounterSample> results)
    {
        if (path.IndexOf('*') < 0)
        {
            ReadSingleCounter(path, counter, results);
            return;
        }

        // Repeat the size probe because instances can appear between the probe and read.
        for (var attempt = 0; attempt < MaximumAttempts; attempt++)
        {
            uint size = 0;
            var status = NativeMethods.PdhGetFormattedCounterArrayW(counter, Format, ref size, out _, IntPtr.Zero);
            if (status != MoreData || size == 0)
            {
                results.Add(Unavailable(path, status));
                return;
            }

            var buffer = Marshal.AllocHGlobal(checked((int)size));
            try
            {
                status = NativeMethods.PdhGetFormattedCounterArrayW(counter, Format, ref size, out var count, buffer);
                if (status == MoreData)
                {
                    continue;
                }

                if (status != 0)
                {
                    results.Add(Unavailable(path, status));
                    return;
                }

                // Windows default packing aligns PDH_FMT_COUNTERVALUE's union to eight bytes
                // on x86 and x64. The leading name pointer therefore occupies eight bytes.
                const int itemSize = 24;
                for (var index = 0; index < count; index++)
                {
                    var item = IntPtr.Add(buffer, checked(index * itemSize));
                    var counterStatus = unchecked((uint)Marshal.ReadInt32(item, ValueOffset));
                    results.Add(new PerformanceCounterSample
                    {
                        CounterPath = path,
                        InstanceName = Marshal.PtrToStringUni(Marshal.ReadIntPtr(item)) ?? string.Empty,
                        Status = counterStatus,
                        Value = ValidValue(counterStatus, BitConverter.Int64BitsToDouble(Marshal.ReadInt64(item, ItemValueOffset))),
                    });
                }

                return;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        results.Add(Unavailable(path, MoreData));
    }

    /// <summary>Reads the formatted value of one explicit instance.</summary>
    /// <param name="path">The requested path.</param>
    /// <param name="counter">The query-owned counter.</param>
    /// <param name="results">The destination samples.</param>
    private static void ReadSingleCounter(string path, IntPtr counter, List<PerformanceCounterSample> results)
    {
        var buffer = Marshal.AllocHGlobal(ValueSize);
        try
        {
            Marshal.WriteInt64(buffer, 0);
            Marshal.WriteInt64(buffer, ValueOffset, 0);
            var status = NativeMethods.PdhGetFormattedCounterValue(counter, Format, IntPtr.Zero, buffer);
            var counterStatus = unchecked((uint)Marshal.ReadInt32(buffer));
            results.Add(new PerformanceCounterSample
            {
                CounterPath = path,
                InstanceName = InstanceFromPath(path),
                Status = counterStatus != 0 ? counterStatus : status,
                Value = status == 0 ? ValidValue(counterStatus, BitConverter.Int64BitsToDouble(Marshal.ReadInt64(buffer, ValueOffset))) : null,
            });
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    /// <summary>Extracts the explicit instance from a counter path.</summary>
    /// <param name="path">The requested path.</param>
    /// <returns>The instance name.</returns>
    private static string InstanceFromPath(string path)
    {
        var start = path.IndexOf('(');
        var end = path.LastIndexOf(')');
        return start >= 0 && end > start ? path.Substring(start + 1, end - start - 1) : string.Empty;
    }

    /// <summary>Contains native PDH entry points.</summary>
    private static
#if !NETFRAMEWORK
    partial
#endif
    class NativeMethods
    {
#if NETFRAMEWORK
        /// <summary>Invokes the native PdhOpenQueryW operation.</summary>
        /// <param name="dataSource">The native dataSource parameter.</param>
        /// <param name="userData">The native userData parameter.</param>
        /// <param name="query">The native query parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("pdh.dll", EntryPoint = "PdhOpenQueryW", ExactSpelling = true, CharSet = CharSet.Unicode)]
        internal static extern uint PdhOpenQueryW(string dataSource, UIntPtr userData, out IntPtr query);
#else
        /// <summary>Invokes the native PdhOpenQueryW operation.</summary>
        /// <param name="dataSource">The native dataSource parameter.</param>
        /// <param name="userData">The native userData parameter.</param>
        /// <param name="query">The native query parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport("pdh.dll", EntryPoint = "PdhOpenQueryW", StringMarshalling = StringMarshalling.Utf16)]
        internal static partial uint PdhOpenQueryW(string dataSource, UIntPtr userData, out IntPtr query);
#endif

#if NETFRAMEWORK
        /// <summary>Invokes the native PdhAddEnglishCounterW operation.</summary>
        /// <param name="query">The native query parameter.</param>
        /// <param name="path">The native path parameter.</param>
        /// <param name="userData">The native userData parameter.</param>
        /// <param name="counter">The native counter parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("pdh.dll", EntryPoint = "PdhAddEnglishCounterW", ExactSpelling = true, CharSet = CharSet.Unicode)]
        internal static extern uint PdhAddEnglishCounterW(QueryHandle query, string path, UIntPtr userData, out IntPtr counter);
#else
        /// <summary>Invokes the native PdhAddEnglishCounterW operation.</summary>
        /// <param name="query">The native query parameter.</param>
        /// <param name="path">The native path parameter.</param>
        /// <param name="userData">The native userData parameter.</param>
        /// <param name="counter">The native counter parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport("pdh.dll", EntryPoint = "PdhAddEnglishCounterW", StringMarshalling = StringMarshalling.Utf16)]
        internal static partial uint PdhAddEnglishCounterW(QueryHandle query, string path, UIntPtr userData, out IntPtr counter);
#endif

#if NETFRAMEWORK
        /// <summary>Invokes the native PdhCollectQueryData operation.</summary>
        /// <param name="query">The native query parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("pdh.dll", EntryPoint = "PdhCollectQueryData", ExactSpelling = true)]
        internal static extern uint PdhCollectQueryData(QueryHandle query);
#else
        /// <summary>Invokes the native PdhCollectQueryData operation.</summary>
        /// <param name="query">The native query parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport("pdh.dll", EntryPoint = "PdhCollectQueryData")]
        internal static partial uint PdhCollectQueryData(QueryHandle query);
#endif

#if NETFRAMEWORK
        /// <summary>Invokes the native PdhGetFormattedCounterValue operation.</summary>
        /// <param name="counter">The native counter parameter.</param>
        /// <param name="format">The native format parameter.</param>
        /// <param name="type">The native type parameter.</param>
        /// <param name="value">The native value parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("pdh.dll", EntryPoint = "PdhGetFormattedCounterValue", ExactSpelling = true)]
        internal static extern uint PdhGetFormattedCounterValue(IntPtr counter, uint format, IntPtr type, IntPtr value);
#else
        /// <summary>Invokes the native PdhGetFormattedCounterValue operation.</summary>
        /// <param name="counter">The native counter parameter.</param>
        /// <param name="format">The native format parameter.</param>
        /// <param name="type">The native type parameter.</param>
        /// <param name="value">The native value parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport("pdh.dll", EntryPoint = "PdhGetFormattedCounterValue")]
        internal static partial uint PdhGetFormattedCounterValue(IntPtr counter, uint format, IntPtr type, IntPtr value);
#endif

#if NETFRAMEWORK
        /// <summary>Invokes the native PdhGetFormattedCounterArrayW operation.</summary>
        /// <param name="counter">The native counter parameter.</param>
        /// <param name="format">The native format parameter.</param>
        /// <param name="size">The native size parameter.</param>
        /// <param name="count">The native count parameter.</param>
        /// <param name="items">The native items parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("pdh.dll", EntryPoint = "PdhGetFormattedCounterArrayW", ExactSpelling = true)]
        internal static extern uint PdhGetFormattedCounterArrayW(IntPtr counter, uint format, ref uint size, out uint count, IntPtr items);
#else
        /// <summary>Invokes the native PdhGetFormattedCounterArrayW operation.</summary>
        /// <param name="counter">The native counter parameter.</param>
        /// <param name="format">The native format parameter.</param>
        /// <param name="size">The native size parameter.</param>
        /// <param name="count">The native count parameter.</param>
        /// <param name="items">The native items parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport("pdh.dll", EntryPoint = "PdhGetFormattedCounterArrayW")]
        internal static partial uint PdhGetFormattedCounterArrayW(IntPtr counter, uint format, ref uint size, out uint count, IntPtr items);
#endif

#if NETFRAMEWORK
        /// <summary>Invokes the native PdhCloseQuery operation.</summary>
        /// <param name="query">The native query parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("pdh.dll", EntryPoint = "PdhCloseQuery", ExactSpelling = true)]
        internal static extern uint PdhCloseQuery(IntPtr query);
#else
        /// <summary>Invokes the native PdhCloseQuery operation.</summary>
        /// <param name="query">The native query parameter.</param>
        /// <returns>The native PDH status.</returns>
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport("pdh.dll", EntryPoint = "PdhCloseQuery")]
        internal static partial uint PdhCloseQuery(IntPtr query);
#endif
    }

    /// <summary>Closes a native query exactly once.</summary>
    private sealed class QueryHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>Initializes a new instance of the <see cref="QueryHandle"/> class.</summary>
        /// <param name="value">The owned query.</param>
        internal QueryHandle(IntPtr value)
            : base(true) => SetHandle(value);

        /// <inheritdoc/>
        protected override bool ReleaseHandle() => NativeMethods.PdhCloseQuery(handle) == 0;
    }
}
