// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Processor utilization percentages; rate values are unavailable before the second sample.</summary>
public sealed class CpuUtilization
{
    /// <summary>Gets processor busy time, from zero to one hundred.</summary>
    public double? TotalPercent { get; internal init; }

    /// <summary>Gets time executing user code.</summary>
    public double? UserPercent { get; internal init; }

    /// <summary>Gets privileged execution time, excluding idle time.</summary>
    public double? KernelPercent { get; internal init; }

    /// <summary>Gets idle execution time.</summary>
    public double? IdlePercent { get; internal init; }
}
