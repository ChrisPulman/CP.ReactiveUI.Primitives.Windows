// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Physical disk activity from Windows performance counters; null values are unavailable.</summary>
public sealed class StorageDiskSnapshot
{
    /// <summary>Gets the Windows performance counter instance name.</summary>
    public string InstanceName { get; internal init; } = string.Empty;

    /// <summary>Gets the busy time as 100 minus percent idle time.</summary>
    public double? ActiveTimePercent { get; internal init; }

    /// <summary>Gets the disk read throughput in bytes per second.</summary>
    public double? ReadBytesPerSecond { get; internal init; }

    /// <summary>Gets the disk write throughput in bytes per second.</summary>
    public double? WriteBytesPerSecond { get; internal init; }

    /// <summary>Gets the disk read operations per second.</summary>
    public double? ReadsPerSecond { get; internal init; }

    /// <summary>Gets the disk write operations per second.</summary>
    public double? WritesPerSecond { get; internal init; }

    /// <summary>Gets the current queued disk requests.</summary>
    public double? CurrentQueueLength { get; internal init; }

    /// <summary>Gets the mean read latency in seconds.</summary>
    public double? AverageReadLatencySeconds { get; internal init; }

    /// <summary>Gets the mean write latency in seconds.</summary>
    public double? AverageWriteLatencySeconds { get; internal init; }

    /// <summary>Gets the native PDH status for each sampled counter.</summary>
    public IReadOnlyDictionary<string, uint> CounterStatuses { get; internal init; } = new Dictionary<string, uint>();
}
