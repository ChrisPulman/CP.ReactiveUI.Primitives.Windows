// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Known SYSTEM_POWER_STATUS battery flags.</summary>
[Flags]
public enum PowerBatteryFlags
{
    /// <summary>No reported battery condition.</summary>
    None = 0,

    /// <summary>Battery capacity exceeds 66 percent.</summary>
    High = 1,

    /// <summary>Battery capacity is below 33 percent.</summary>
    Low = 2,

    /// <summary>Battery capacity is below five percent.</summary>
    Critical = 4,

    /// <summary>The battery is charging.</summary>
    Charging = 8,

    /// <summary>No system battery is present.</summary>
    NoBattery = 128,
}
