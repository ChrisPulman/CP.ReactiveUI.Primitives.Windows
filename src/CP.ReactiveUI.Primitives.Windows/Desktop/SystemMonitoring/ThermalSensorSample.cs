// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A provider-specific temperature, power, or fan reading with explicit availability and unit.</summary>
public sealed class ThermalSensorSample
{
    /// <summary>Gets the provider's stable sensor identity.</summary>
    public string SensorId { get; init; } = string.Empty;

    /// <summary>Gets the sensor description, including whether it represents a thermal zone, CPU core or device.</summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the provider name.</summary>
    public string Provider { get; init; } = string.Empty;

    /// <summary>Gets the measured unit, such as Celsius, Watts or RPM.</summary>
    public string Unit { get; init; } = string.Empty;

    /// <summary>Gets the reported value, or null when unavailable.</summary>
    public double? Value { get; init; }

    /// <summary>Gets provider availability.</summary>
    public WmiQueryStatus Status { get; init; }

    /// <summary>Gets optional provider failure detail.</summary>
    public string? Error { get; init; }
}
