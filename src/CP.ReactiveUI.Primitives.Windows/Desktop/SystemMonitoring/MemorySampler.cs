// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Reads the Windows system memory performance snapshot.</summary>
internal sealed
#if !NETFRAMEWORK
partial
#endif
class MemorySampler : ISystemSampler<MemorySample>
{
    /// <summary>Captures system memory information.</summary>
    /// <returns>The current memory snapshot.</returns>
    public MemorySample Capture()
    {
        var size = (uint)Marshal.SizeOf<PerformanceInformation>();
        if (NativeMethods.GetPerformanceInfo(out var information, size) == 0)
        {
            throw new NativeWin32Exception(Marshal.GetLastWin32Error());
        }

        if (information.Size != size)
        {
            throw new InvalidOperationException("Windows returned an unexpected performance information size.");
        }

        var pageSize = information.PageSize;
        return new MemorySample
        {
            Timestamp = TimeProvider.System.GetUtcNow(),
            TotalPhysicalBytes = PagesToBytes(information.PhysicalTotal, pageSize),
            AvailablePhysicalBytes = PagesToBytes(information.PhysicalAvailable, pageSize),
            CommitTotalBytes = PagesToBytes(information.CommitTotal, pageSize),
            CommitLimitBytes = PagesToBytes(information.CommitLimit, pageSize),
            CommitPeakBytes = PagesToBytes(information.CommitPeak, pageSize),
            SystemCacheBytes = PagesToBytes(information.SystemCache, pageSize),
            KernelTotalBytes = PagesToBytes(information.KernelTotal, pageSize),
            KernelPagedBytes = PagesToBytes(information.KernelPaged, pageSize),
            KernelNonPagedBytes = PagesToBytes(information.KernelNonPaged, pageSize),
            PageSizeBytes = pageSize,
            ProcessCount = information.ProcessCount,
            ThreadCount = information.ThreadCount,
            HandleCount = information.HandleCount,
        };
    }

    /// <summary>Completes this stateless sampler's lifetime.</summary>
    public void Dispose()
    {
    }

    /// <summary>Converts page counts to bytes without allowing arithmetic overflow.</summary>
    /// <param name="pages">The page count.</param>
    /// <param name="pageSize">The size of each page in bytes.</param>
    /// <returns>The byte count.</returns>
    internal static ulong PagesToBytes(ulong pages, ulong pageSize) => checked(pages * pageSize);

    /// <summary>The documented PSAPI PERFORMANCE_INFORMATION layout.</summary>
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct PerformanceInformation
    {
        /// <summary>Gets the native structure size.</summary>
        public uint Size => RawSize;

        /// <summary>Gets the native HandleCount value.</summary>
        public uint HandleCount => RawHandleCount;

        /// <summary>Gets the native ProcessCount value.</summary>
        public uint ProcessCount => RawProcessCount;

        /// <summary>Gets the native ThreadCount value.</summary>
        public uint ThreadCount => RawThreadCount;

        /// <summary>Gets the unsigned CommitTotal value.</summary>
        public ulong CommitTotal => RawCommitTotal.ToUInt64();

        /// <summary>Gets the unsigned CommitLimit value.</summary>
        public ulong CommitLimit => RawCommitLimit.ToUInt64();

        /// <summary>Gets the unsigned CommitPeak value.</summary>
        public ulong CommitPeak => RawCommitPeak.ToUInt64();

        /// <summary>Gets the unsigned PhysicalTotal value.</summary>
        public ulong PhysicalTotal => RawPhysicalTotal.ToUInt64();

        /// <summary>Gets the unsigned PhysicalAvailable value.</summary>
        public ulong PhysicalAvailable => RawPhysicalAvailable.ToUInt64();

        /// <summary>Gets the unsigned SystemCache value.</summary>
        public ulong SystemCache => RawSystemCache.ToUInt64();

        /// <summary>Gets the unsigned KernelTotal value.</summary>
        public ulong KernelTotal => RawKernelTotal.ToUInt64();

        /// <summary>Gets the unsigned KernelPaged value.</summary>
        public ulong KernelPaged => RawKernelPaged.ToUInt64();

        /// <summary>Gets the unsigned KernelNonPaged value.</summary>
        public ulong KernelNonPaged => RawKernelNonPaged.ToUInt64();

        /// <summary>Gets the unsigned PageSize value.</summary>
        public ulong PageSize => RawPageSize.ToUInt64();

        /// <summary>Gets the native structure size.</summary>
        private uint RawSize { get; }

        /// <summary>Gets the native CommitTotal page count.</summary>
        private UIntPtr RawCommitTotal { get; }

        /// <summary>Gets the native CommitLimit page count.</summary>
        private UIntPtr RawCommitLimit { get; }

        /// <summary>Gets the native CommitPeak page count.</summary>
        private UIntPtr RawCommitPeak { get; }

        /// <summary>Gets the native PhysicalTotal page count.</summary>
        private UIntPtr RawPhysicalTotal { get; }

        /// <summary>Gets the native PhysicalAvailable page count.</summary>
        private UIntPtr RawPhysicalAvailable { get; }

        /// <summary>Gets the native SystemCache page count.</summary>
        private UIntPtr RawSystemCache { get; }

        /// <summary>Gets the native KernelTotal page count.</summary>
        private UIntPtr RawKernelTotal { get; }

        /// <summary>Gets the native KernelPaged page count.</summary>
        private UIntPtr RawKernelPaged { get; }

        /// <summary>Gets the native KernelNonPaged page count.</summary>
        private UIntPtr RawKernelNonPaged { get; }

        /// <summary>Gets the native PageSize page count.</summary>
        private UIntPtr RawPageSize { get; }

        /// <summary>Gets the native HandleCount value.</summary>
        private uint RawHandleCount { get; }

        /// <summary>Gets the native ProcessCount value.</summary>
        private uint RawProcessCount { get; }

        /// <summary>Gets the native ThreadCount value.</summary>
        private uint RawThreadCount { get; }
    }

    /// <summary>Contains native memory entry points.</summary>
    private static
#if !NETFRAMEWORK
    partial
#endif
    class NativeMethods
    {
        /// <summary>Reads documented system performance information.</summary>
        /// <param name="information">The resulting native information.</param>
        /// <param name="size">The native structure size.</param>
        /// <returns>Nonzero when the operation succeeds.</returns>
#if NETFRAMEWORK
        [DllImport("psapi.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int GetPerformanceInfo(out PerformanceInformation information, uint size);
#else
        [LibraryImport("psapi.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int GetPerformanceInfo(out PerformanceInformation information, uint size);
#endif
    }
}
