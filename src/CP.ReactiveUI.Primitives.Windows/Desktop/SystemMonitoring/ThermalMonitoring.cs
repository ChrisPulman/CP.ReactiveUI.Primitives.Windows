// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Reads optional ACPI thermal zones and composes configured vendor sensor providers.</summary>
public static class ThermalMonitoring
{
    /// <summary>The number of tenths in one Kelvin.</summary>
    private const double TenthsPerKelvin = 10D;

    /// <summary>The Kelvin temperature at zero Celsius.</summary>
    private const double KelvinOffset = 273.15D;

    /// <summary>Captures available ACPI thermal zones.</summary>
    /// <returns>Thermal zone readings and provider availability.</returns>
    public static ThermalSnapshot Capture() => Capture(null);

    /// <summary>Captures available ACPI thermal zones and optional provider readings.</summary>
    /// <param name="provider">An optional caller-owned vendor sensor provider.</param>
    /// <returns>A snapshot preserving unavailable provider status.</returns>
    public static ThermalSnapshot Capture(IThermalSensorProvider? provider)
    {
        var zones = WindowsManagement.Query(@"root\wmi", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
        var readings = new List<ThermalSensorSample>(zones.Rows.Count);
        foreach (var zone in zones.Rows)
        {
            var value = Celsius(zone.UInt32("CurrentTemperature"));
            readings.Add(new()
            {
                SensorId = zone.String("InstanceName") ?? string.Empty,
                Name = "ACPI thermal zone",
                Provider = "MSAcpi_ThermalZoneTemperature",
                Unit = "Celsius",
                Value = value,
                Status = value.HasValue ? WmiQueryStatus.Available : WmiQueryStatus.Unavailable,
            });
        }

        if (provider is not null)
        {
            readings.AddRange(provider.Capture());
        }

        return new(zones, readings.AsReadOnly());
    }

    /// <summary>Observes ACPI thermal zones.</summary>
    /// <param name="interval">The positive sampling interval.</param>
    /// <returns>A stream of thermal zone readings and availability.</returns>
    public static IObservable<ThermalSnapshot> Observe(TimeSpan interval) => Observe(interval, null);

    /// <summary>Observes thermal zones and a caller-owned provider. Firmware may expose no thermal zones.</summary>
    /// <param name="interval">The positive sampling interval.</param>
    /// <param name="provider">An optional provider that remains owned by the caller.</param>
    /// <returns>A stream of readings with independent sampling state.</returns>
    public static IObservable<ThermalSnapshot> Observe(TimeSpan interval, IThermalSensorProvider? provider) =>
        SystemPolling.Observe(() => new ThermalSampler(provider), interval);

    /// <summary>Initializes or reads Celsius state.</summary>
    /// <param name="tenthsKelvin">The tenthsKelvin value.</param>
    /// <returns>The captured or projected value.</returns>
    internal static double? Celsius(uint? tenthsKelvin) => tenthsKelvin.HasValue && tenthsKelvin.Value != 0
        ? (tenthsKelvin.Value / TenthsPerKelvin) - KelvinOffset
        : null;

    /// <summary>Initializes or reads ThermalSampler state.</summary>
    /// <param name="provider">The provider value.</param>
    /// <returns>The captured or projected value.</returns>
    private sealed class ThermalSampler(IThermalSensorProvider? provider) : ISystemSampler<ThermalSnapshot>
    {
        /// <summary>Initializes or reads Capture state.</summary>
        /// <returns>The captured or projected value.</returns>
        public ThermalSnapshot Capture() => ThermalMonitoring.Capture(provider);

        /// <summary>Initializes or reads Dispose state.</summary>
        public void Dispose()
        {
        }
    }
}
