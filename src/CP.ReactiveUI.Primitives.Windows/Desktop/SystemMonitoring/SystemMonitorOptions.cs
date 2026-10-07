// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Immutable provider selection and refresh intervals.</summary>
internal sealed record SystemMonitorOptions
{
    /// <summary>The default hardware refresh delay in minutes.</summary>
    private const int HardwareRefreshMinutes = 5;

    /// <summary>The default thermal refresh delay in seconds.</summary>
    private const int ThermalRefreshSeconds = 30;

    /// <summary>Gets the selected providers.</summary>
    internal MonitoringSections Sections { get; init; }

    /// <summary>Gets the delay between cycles.</summary>
    internal TimeSpan Interval { get; init; } = TimeSpan.FromSeconds(1);

    /// <summary>Gets the hardware inventory refresh interval.</summary>
    internal TimeSpan HardwareRefreshInterval { get; init; } = TimeSpan.FromMinutes(HardwareRefreshMinutes);

    /// <summary>Gets the thermal zone refresh interval.</summary>
    internal TimeSpan ThermalRefreshInterval { get; init; } = TimeSpan.FromSeconds(ThermalRefreshSeconds);

    /// <summary>Gets the factory for subscription-owned vendor sensor providers.</summary>
    internal Func<IThermalSensorProvider>? SensorProviderFactory { get; init; }

    /// <summary>Gets the single process filter, or null to capture every accessible process.</summary>
    internal int? ProcessId { get; init; }

    /// <summary>Gets whether process parent and command-line identity should be queried.</summary>
    internal bool IncludeExtendedProcessIdentity { get; init; }
}
