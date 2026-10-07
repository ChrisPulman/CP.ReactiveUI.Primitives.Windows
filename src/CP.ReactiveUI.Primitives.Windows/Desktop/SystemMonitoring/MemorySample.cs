// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>System memory and object counts from Windows performance information.</summary>
public sealed class MemorySample
{
    /// <summary>The percentage scale.</summary>
    private const double PercentageScale = 100D;

    /// <summary>Gets uTC capture time.</summary>
    public DateTimeOffset Timestamp { get; internal init; }

    /// <summary>Gets total Physical Bytes.</summary>
    public ulong TotalPhysicalBytes { get; internal init; }

    /// <summary>Gets available Physical Bytes.</summary>
    public ulong AvailablePhysicalBytes { get; internal init; }

    /// <summary>Gets commit Total Bytes.</summary>
    public ulong CommitTotalBytes { get; internal init; }

    /// <summary>Gets commit Limit Bytes.</summary>
    public ulong CommitLimitBytes { get; internal init; }

    /// <summary>Gets commit Peak Bytes.</summary>
    public ulong CommitPeakBytes { get; internal init; }

    /// <summary>Gets system Cache Bytes.</summary>
    public ulong SystemCacheBytes { get; internal init; }

    /// <summary>Gets kernel Total Bytes.</summary>
    public ulong KernelTotalBytes { get; internal init; }

    /// <summary>Gets kernel Paged Bytes.</summary>
    public ulong KernelPagedBytes { get; internal init; }

    /// <summary>Gets kernel Non Paged Bytes.</summary>
    public ulong KernelNonPagedBytes { get; internal init; }

    /// <summary>Gets page Size Bytes.</summary>
    public ulong PageSizeBytes { get; internal init; }

    /// <summary>Gets process Count.</summary>
    public uint ProcessCount { get; internal init; }

    /// <summary>Gets thread Count.</summary>
    public uint ThreadCount { get; internal init; }

    /// <summary>Gets handle Count.</summary>
    public uint HandleCount { get; internal init; }

    /// <summary>Gets physical memory currently in use, in bytes.</summary>
    public ulong UsedPhysicalBytes => TotalPhysicalBytes >= AvailablePhysicalBytes ? TotalPhysicalBytes - AvailablePhysicalBytes : 0;

    /// <summary>Gets the physical memory utilization percentage.</summary>
    public double MemoryLoadPercent => TotalPhysicalBytes == 0 ? 0 : PercentageScale * UsedPhysicalBytes / TotalPhysicalBytes;
}
