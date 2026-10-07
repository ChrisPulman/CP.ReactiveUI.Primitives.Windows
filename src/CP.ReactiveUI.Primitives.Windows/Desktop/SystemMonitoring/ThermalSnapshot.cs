// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>ACPI thermal-zone readings and optional vendor sensors. Thermal zones are not CPU core temperatures.</summary>
public sealed class ThermalSnapshot
{
    /// <summary>Initializes a new instance of the <see cref="ThermalSnapshot"/> class.</summary>
    /// <param name="zones">The zones value.</param>
    /// <param name="sensors">The sensors value.</param>
    internal ThermalSnapshot(WmiQueryResult zones, IReadOnlyList<ThermalSensorSample> sensors)
    {
        Timestamp = TimeProvider.System.GetUtcNow();
        ThermalZones = zones;
        Sensors = sensors;
    }

    /// <summary>Gets UTC capture time.</summary>
    public DateTimeOffset Timestamp { get; }

    /// <summary>Gets the root/WMI thermal-zone query availability and detached raw properties.</summary>
    public WmiQueryResult ThermalZones { get; }

    /// <summary>Gets thermal-zone temperatures and vendor readings with explicit availability.</summary>
    public IReadOnlyList<ThermalSensorSample> Sensors { get; }
}
