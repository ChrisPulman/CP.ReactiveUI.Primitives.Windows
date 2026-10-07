// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies native power status sentinel interpretation.</summary>
public sealed class PowerMonitoringTests
{
    /// <summary>Unknown native battery fields remain unavailable.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task Convert_UnknownBatteryFields_RemainUnavailable()
    {
        var sample = PowerMonitoring.Convert(
            new PowerStatus
        {
            AcLineStatus = byte.MaxValue,
            BatteryFlag = byte.MaxValue,
            BatteryLifePercent = byte.MaxValue,
            BatteryLifeTime = uint.MaxValue,
            BatteryFullLifeTime = uint.MaxValue,
            },
            Guid.Empty);
        await Assert.That(sample.Connection).IsEqualTo(PowerConnection.Unknown);
        await Assert.That(sample.BatteryFlags).IsNull();
        await Assert.That(sample.BatteryChargePercent).IsNull();
        await Assert.That(sample.BatteryLifeRemaining).IsNull();
        await Assert.That(sample.BatteryFullLifetime).IsNull();
        await Assert.That(sample.HasBattery).IsNull();
        await Assert.That(sample.IsCharging).IsNull();
    }

    /// <summary>Reported charge and lifetime retain their native units.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task Convert_ReportedBatteryFields_PreserveValues()
    {
        const byte charge = 50;
        const uint seconds = 3600;
        var id = Guid.NewGuid();
        var sample = PowerMonitoring.Convert(
            new PowerStatus
        {
            AcLineStatus = 1,
            BatteryLifePercent = charge,
            BatteryFlag = (byte)PowerBatteryFlags.Charging,
            BatteryLifeTime = seconds,
            SystemStatusFlag = 1,
            },
            id);
        await Assert.That(sample.Connection).IsEqualTo(PowerConnection.Online);
        await Assert.That(sample.BatteryChargePercent).IsEqualTo(charge);
        await Assert.That(sample.BatteryLifeRemaining).IsEqualTo(TimeSpan.FromSeconds(seconds));
        await Assert.That(sample.IsEnergySaverEnabled).IsTrue();
        await Assert.That(sample.HasBattery).IsTrue();
        await Assert.That(sample.IsCharging).IsTrue();
        await Assert.That(sample.ActivePlanId).IsEqualTo(id);
    }
}
