// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Battery and power scheme state reported by Windows.</summary>
public sealed class PowerSample
{
    /// <summary>Gets the capture time.</summary>
    public DateTimeOffset Timestamp { get; internal init; }

    /// <summary>Gets the external power connection.</summary>
    public PowerConnection Connection { get; internal init; }

    /// <summary>Gets native battery flags, or null if unknown. Bit 128 indicates no battery.</summary>
    public byte? BatteryFlags { get; internal init; }

    /// <summary>Gets remaining charge percentage, or null if unknown.</summary>
    public byte? BatteryChargePercent { get; internal init; }

    /// <summary>Gets remaining battery lifetime, or null if unknown.</summary>
    public TimeSpan? BatteryLifeRemaining { get; internal init; }

    /// <summary>Gets full battery lifetime, or null if unknown.</summary>
    public TimeSpan? BatteryFullLifetime { get; internal init; }

    /// <summary>Gets whether Windows battery saver is enabled.</summary>
    public bool IsEnergySaverEnabled { get; internal init; }

    /// <summary>Gets the active power scheme identifier.</summary>
    public Guid ActivePlanId { get; internal init; }

    /// <summary>Gets the known battery state flags, or null if Windows reports unknown state.</summary>
    public PowerBatteryFlags? BatteryState => BatteryFlags.HasValue ? (PowerBatteryFlags)BatteryFlags.Value : null;

    /// <summary>Gets whether a battery is present, or null if Windows reports unknown state.</summary>
    public bool? HasBattery => BatteryState.HasValue ? (BatteryState.Value & PowerBatteryFlags.NoBattery) == 0 : null;

    /// <summary>Gets whether the battery is charging, or null if Windows reports unknown state.</summary>
    public bool? IsCharging => BatteryState.HasValue ? (BatteryState.Value & PowerBatteryFlags.Charging) != 0 : null;
}
