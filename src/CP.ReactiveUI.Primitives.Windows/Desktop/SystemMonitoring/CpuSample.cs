// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>System CPU counters captured together.</summary>
public sealed class CpuSample
{
    /// <summary>Gets uTC capture time.</summary>
    public DateTimeOffset Timestamp { get; internal init; }

    /// <summary>Gets number of logical processor instances captured.</summary>
    public int LogicalProcessorCount { get; internal init; }

    /// <summary>Gets aggregate utilization across processor groups.</summary>
    public CpuUtilization Total { get; internal init; } = new();

    /// <summary>Gets individual logical processor measurements.</summary>
    public IReadOnlyList<LogicalProcessorSample> LogicalProcessors { get; internal init; } = Array.Empty<LogicalProcessorSample>();
}
