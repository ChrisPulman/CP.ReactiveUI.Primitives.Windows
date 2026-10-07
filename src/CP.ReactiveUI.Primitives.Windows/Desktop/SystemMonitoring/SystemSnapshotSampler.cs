// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Owns the selected providers for one dashboard subscription.</summary>
internal sealed class SystemSnapshotSampler : ISystemSampler<SystemSnapshot>
{
    /// <summary>The service inventory refresh interval in seconds.</summary>
    private const int ServiceRefreshSeconds = 30;

    /// <summary>Processor counters.</summary>
    private readonly ProviderSlot<CpuSample> _cpu;

    /// <summary>Memory statistics.</summary>
    private readonly ProviderSlot<MemorySample> _memory;

    /// <summary>Process counters.</summary>
    private readonly ProviderSlot<ProcessSnapshot> _processes;

    /// <summary>Network interface counters.</summary>
    private readonly ProviderSlot<NetworkSnapshot> _network;

    /// <summary>Disk counters.</summary>
    private readonly ProviderSlot<StorageSnapshot> _storage;

    /// <summary>GPU counters.</summary>
    private readonly ProviderSlot<GraphicsSnapshot> _graphics;

    /// <summary>Power status.</summary>
    private readonly ProviderSlot<PowerSample> _power;

    /// <summary>Cached hardware inventory.</summary>
    private readonly ProviderSlot<HardwareSnapshot> _hardware;

    /// <summary>Cached thermal zones.</summary>
    private readonly ProviderSlot<ThermalSnapshot> _thermals;

    /// <summary>Cached service inventory.</summary>
    private readonly ProviderSlot<ServiceSnapshot> _services;

    /// <summary>The snapshot sequence number.</summary>
    private long _sequence;

    /// <summary>Whether this sampler was disposed.</summary>
    private int _disposed;

    /// <summary>Initializes a new instance of the <see cref="SystemSnapshotSampler"/> class.</summary>
    /// <param name="options">The monitor configuration.</param>
    internal SystemSnapshotSampler(SystemMonitorOptions options)
    {
        var sections = options.Sections;
        _cpu = new((sections & MonitoringSections.Cpu) != 0, static () => new CpuSampler(), TimeSpan.Zero);
        _memory = new((sections & MonitoringSections.Memory) != 0, static () => new MemorySampler(), TimeSpan.Zero);
        _processes = new((sections & MonitoringSections.Processes) != 0, () => new ProcessSampler(options.ProcessId, options.IncludeExtendedProcessIdentity), TimeSpan.Zero);
        _network = new((sections & MonitoringSections.Network) != 0, static () => new NetworkSampler(), TimeSpan.Zero);
        _storage = new((sections & MonitoringSections.Storage) != 0, static () => new StorageSampler(), TimeSpan.Zero);
        _graphics = new((sections & MonitoringSections.Graphics) != 0, static () => new GraphicsSampler(), TimeSpan.Zero);
        _power = new((sections & MonitoringSections.Power) != 0, static () => new DelegateSampler<PowerSample>(PowerMonitoring.Capture), TimeSpan.Zero);
        _hardware = new((sections & MonitoringSections.Hardware) != 0, static () => new DelegateSampler<HardwareSnapshot>(HardwareMonitoring.Capture), options.HardwareRefreshInterval);
        _thermals = new((sections & MonitoringSections.Thermals) != 0, () => CreateThermalSampler(options), options.ThermalRefreshInterval);
        _services = new((sections & MonitoringSections.Services) != 0, static () => new DelegateSampler<ServiceSnapshot>(ServiceMonitoring.Capture), TimeSpan.FromSeconds(ServiceRefreshSeconds));
    }

    /// <inheritdoc />
    public SystemSnapshot Capture()
    {
        Throw.IfDisposed(Volatile.Read(ref _disposed) != 0, this);
        var now = TimeProvider.System.GetUtcNow();
        return new()
        {
            Sequence = Interlocked.Increment(ref _sequence),
            Timestamp = now,
            Cpu = _cpu.Capture(now),
            Memory = _memory.Capture(now),
            Processes = _processes.Capture(now),
            Network = _network.Capture(now),
            Storage = _storage.Capture(now),
            Graphics = _graphics.Capture(now),
            Power = _power.Capture(now),
            Hardware = _hardware.Capture(now),
            Thermals = _thermals.Capture(now),
            Services = _services.Capture(now),
        };
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) != 0)
        {
            return;
        }

        _cpu.Dispose();
        _memory.Dispose();
        _processes.Dispose();
        _network.Dispose();
        _storage.Dispose();
        _graphics.Dispose();
        _power.Dispose();
        _hardware.Dispose();
        _thermals.Dispose();
        _services.Dispose();
    }

    /// <summary>Creates a firmware-only or vendor-enriched thermal sampler.</summary>
    /// <param name="options">The provider configuration.</param>
    /// <returns>A subscription-owned sampler.</returns>
    private static ISystemSampler<ThermalSnapshot> CreateThermalSampler(SystemMonitorOptions options) =>
        options.SensorProviderFactory is { } factory
            ? new ThermalProviderSampler(factory)
            : new DelegateSampler<ThermalSnapshot>(static () => ThermalMonitoring.Capture());
}
