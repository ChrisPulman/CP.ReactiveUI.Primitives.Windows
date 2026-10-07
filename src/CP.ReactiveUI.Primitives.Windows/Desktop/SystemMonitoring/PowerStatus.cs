// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif
/// <summary>Native SYSTEM_POWER_STATUS layout.</summary>
[StructLayout(LayoutKind.Sequential)]
internal record struct PowerStatus
{
    /// <summary>Gets or sets the native AcLineStatus field.</summary>
    internal byte AcLineStatus { get; set; }

    /// <summary>Gets or sets the native BatteryFlag field.</summary>
    internal byte BatteryFlag { get; set; }

    /// <summary>Gets or sets the native BatteryLifePercent field.</summary>
    internal byte BatteryLifePercent { get; set; }

    /// <summary>Gets or sets the native SystemStatusFlag field.</summary>
    internal byte SystemStatusFlag { get; set; }

    /// <summary>Gets or sets the native BatteryLifeTime field.</summary>
    internal uint BatteryLifeTime { get; set; }

    /// <summary>Gets or sets the native BatteryFullLifeTime field.</summary>
    internal uint BatteryFullLifeTime { get; set; }
}
