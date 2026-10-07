// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A dashboard snapshot with independently classified provider results.</summary>
public sealed class SystemSnapshot
{
    /// <summary>Gets the snapshot sequence number within this subscription.</summary>
    public long Sequence { get; internal init; }

    /// <summary>Gets when this sampling cycle began.</summary>
    public DateTimeOffset Timestamp { get; internal init; }

    /// <summary>Gets processor counters.</summary>
    public MonitoringResult<CpuSample> Cpu { get; internal init; } = MonitoringResult<CpuSample>.NotRequested();

    /// <summary>Gets system memory statistics.</summary>
    public MonitoringResult<MemorySample> Memory { get; internal init; } = MonitoringResult<MemorySample>.NotRequested();

    /// <summary>Gets process statistics.</summary>
    public MonitoringResult<ProcessSnapshot> Processes { get; internal init; } = MonitoringResult<ProcessSnapshot>.NotRequested();

    /// <summary>Gets network interface statistics.</summary>
    public MonitoringResult<NetworkSnapshot> Network { get; internal init; } = MonitoringResult<NetworkSnapshot>.NotRequested();

    /// <summary>Gets volume and disk statistics.</summary>
    public MonitoringResult<StorageSnapshot> Storage { get; internal init; } = MonitoringResult<StorageSnapshot>.NotRequested();

    /// <summary>Gets graphics adapter and engine statistics.</summary>
    public MonitoringResult<GraphicsSnapshot> Graphics { get; internal init; } = MonitoringResult<GraphicsSnapshot>.NotRequested();

    /// <summary>Gets battery and active power plan state.</summary>
    public MonitoringResult<PowerSample> Power { get; internal init; } = MonitoringResult<PowerSample>.NotRequested();

    /// <summary>Gets cached hardware inventory.</summary>
    public MonitoringResult<HardwareSnapshot> Hardware { get; internal init; } = MonitoringResult<HardwareSnapshot>.NotRequested();

    /// <summary>Gets cached thermal zone readings.</summary>
    public MonitoringResult<ThermalSnapshot> Thermals { get; internal init; } = MonitoringResult<ThermalSnapshot>.NotRequested();

    /// <summary>Gets cached Windows service inventory.</summary>
    public MonitoringResult<ServiceSnapshot> Services { get; internal init; } = MonitoringResult<ServiceSnapshot>.NotRequested();
}
