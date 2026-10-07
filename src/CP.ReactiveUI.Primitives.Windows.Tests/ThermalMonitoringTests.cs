// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_TEST_SHIM
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Tests ACPI unit conversion without equating thermal zones to CPU cores.</summary>
public class ThermalMonitoringTests
{
    /// <summary>Verifies ACPI tenths Kelvin convert to Celsius.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task AcpiTemperatureConvertsTenthsKelvin()
    {
        const uint Reading = 3000;
        const double Expected = 26.85D;
        const double Tolerance = 0.00001D;
        var value = ThermalMonitoring.Celsius(Reading);
        await Assert.That(value.HasValue).IsTrue();
        await Assert.That(Math.Abs(value.GetValueOrDefault() - Expected) < Tolerance).IsTrue();
    }

    /// <summary>Verifies absent and zero readings remain unavailable.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task MissingThermalTemperatureDoesNotCreateReading()
    {
        await Assert.That(ThermalMonitoring.Celsius(null)).IsNull();
        await Assert.That(ThermalMonitoring.Celsius(0)).IsNull();
    }
}
