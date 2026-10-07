// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Measurements for one processor group and logical processor.</summary>
public sealed class LogicalProcessorSample
{
    /// <summary>Gets windows performance counter instance identity.</summary>
    public string InstanceName { get; internal init; } = string.Empty;

    /// <summary>Gets processor group number.</summary>
    public int GroupNumber { get; internal init; }

    /// <summary>Gets logical processor number within its group.</summary>
    public int ProcessorNumber { get; internal init; }

    /// <summary>Gets processor utilization rates.</summary>
    public CpuUtilization Utilization { get; internal init; } = new();

    /// <summary>Gets current frequency in megahertz when supported.</summary>
    public double? FrequencyMegahertz { get; internal init; }
}
