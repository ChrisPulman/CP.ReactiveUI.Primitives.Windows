// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Composes providers without opening resources or changing operating-system settings.</summary>
public sealed class SystemMonitorBuilder
{
    /// <summary>The provider configuration.</summary>
    private readonly SystemMonitorOptions _options;

    /// <summary>Initializes a new instance of the <see cref="SystemMonitorBuilder"/> class.</summary>
    internal SystemMonitorBuilder()
        : this(new SystemMonitorOptions())
    {
    }

    /// <summary>Initializes a new instance of the <see cref="SystemMonitorBuilder"/> class.</summary>
    /// <param name="options">The provider configuration.</param>
    private SystemMonitorBuilder(SystemMonitorOptions options) => _options = options;

    /// <summary>Gets the selected providers.</summary>
    public MonitoringSections Sections => _options.Sections;

    /// <summary>Gets the delay between completed sampling cycles.</summary>
    public TimeSpan Interval => _options.Interval;

    /// <summary>Selects processor counters.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithCpu() => WithSections(MonitoringSections.Cpu);

    /// <summary>Selects memory and object counts.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithMemory() => WithSections(MonitoringSections.Memory);

    /// <summary>Selects process counters without expensive identity queries.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithProcesses() => WithSections(MonitoringSections.Processes);

    /// <summary>Selects counters for a single process.</summary>
    /// <param name="processId">The positive process identifier.</param>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithProcesses(int processId)
    {
#if NETFRAMEWORK
        if (processId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(processId));
        }
#else
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(processId);
#endif

        return new(_options with { Sections = _options.Sections | MonitoringSections.Processes, ProcessId = processId });
    }

    /// <summary>Selects process counters with WMI parent and command-line enrichment on every cycle.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithExtendedProcessIdentity() =>
        new(_options with { Sections = _options.Sections | MonitoringSections.Processes, IncludeExtendedProcessIdentity = true });

    /// <summary>Selects network interface rates.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithNetwork() => WithSections(MonitoringSections.Network);

    /// <summary>Selects volume capacity and disk performance.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithStorage() => WithSections(MonitoringSections.Storage);

    /// <summary>Selects GPU counters and cached adapter inventory.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithGraphics() => WithSections(MonitoringSections.Graphics);

    /// <summary>Selects battery and power plan state.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithPower() => WithSections(MonitoringSections.Power);

    /// <summary>Selects hardware inventory refreshed at most every five minutes.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithHardware() => WithSections(MonitoringSections.Hardware);

    /// <summary>Selects optional thermal zones refreshed at most every thirty seconds.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithThermals() => WithSections(MonitoringSections.Thermals);

    /// <summary>Selects firmware zones and vendor sensors created separately for each subscription.</summary>
    /// <param name="createProvider">Creates a provider; the monitor disposes it if it implements IDisposable.</param>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithThermals(Func<IThermalSensorProvider> createProvider)
    {
        Throw.IfNull(createProvider);
        return new(_options with { Sections = _options.Sections | MonitoringSections.Thermals, SensorProviderFactory = createProvider });
    }

    /// <summary>Selects Windows service inventory refreshed at most every thirty seconds.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithServices() => WithSections(MonitoringSections.Services);

    /// <summary>Removes providers without modifying this configuration.</summary>
    /// <param name="sections">The providers to exclude.</param>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithoutSections(MonitoringSections sections)
    {
        if ((sections & ~MonitoringSections.All) != 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sections));
        }

        return new(_options with { Sections = _options.Sections & ~sections });
    }

    /// <summary>Selects every built-in provider, with slow inventory and thermal refreshes.</summary>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithAll() => WithSections(MonitoringSections.All);

    /// <summary>Adds providers to this configuration.</summary>
    /// <param name="sections">The providers to include.</param>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder WithSections(MonitoringSections sections)
    {
        if ((sections & ~MonitoringSections.All) != 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sections));
        }

        return new(_options with { Sections = _options.Sections | sections });
    }

    /// <summary>Sets the delay after a completed sampling cycle; slow reads never overlap.</summary>
    /// <param name="interval">A positive delay of at least one millisecond.</param>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder Every(TimeSpan interval)
    {
        SystemPolling.ValidateInterval(interval);
        return new(_options with { Interval = interval });
    }

    /// <summary>Sets how frequently hardware inventory may be refreshed.</summary>
    /// <param name="interval">The positive refresh interval.</param>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder RefreshHardwareEvery(TimeSpan interval)
    {
        SystemPolling.ValidateInterval(interval);
        return new(_options with { HardwareRefreshInterval = interval });
    }

    /// <summary>Sets how frequently thermal zones may be refreshed.</summary>
    /// <param name="interval">The positive refresh interval.</param>
    /// <returns>A new configuration.</returns>
    public SystemMonitorBuilder RefreshThermalsEvery(TimeSpan interval)
    {
        SystemPolling.ValidateInterval(interval);
        return new(_options with { ThermalRefreshInterval = interval });
    }

    /// <summary>Creates a cold stream with separate resources, caches, and rate history for each subscription.</summary>
    /// <returns>Snapshots on the thread pool; use ObserveOn to marshal them to a UI.</returns>
    public IObservable<SystemSnapshot> Observe() =>
        SystemPolling.Observe(() => new SystemSnapshotSampler(_options), _options.Interval);

    /// <summary>Captures one snapshot. Rate counters may be unavailable until a later sample.</summary>
    /// <returns>A snapshot with independent provider outcomes.</returns>
    public SystemSnapshot Capture()
    {
        using var sampler = new SystemSnapshotSampler(_options);
        return sampler.Capture();
    }
}
