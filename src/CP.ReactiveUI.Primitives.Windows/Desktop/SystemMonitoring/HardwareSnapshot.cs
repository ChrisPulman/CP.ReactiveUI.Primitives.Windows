// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Hardware inventory with independent provider availability for each category.</summary>
public sealed class HardwareSnapshot
{
    /// <summary>Initializes a new instance of the <see cref="HardwareSnapshot"/> class.</summary>
    /// <param name="queries">The queries value.</param>
    internal HardwareSnapshot(Dictionary<string, WmiQueryResult> queries)
    {
        Timestamp = TimeProvider.System.GetUtcNow();
        Queries = new System.Collections.ObjectModel.ReadOnlyDictionary<string, WmiQueryResult>(queries);
        OperatingSystems = WmiProjection.Project(queries["Win32_OperatingSystem"], static row => new HardwareOperatingSystem(row));
        Machines = WmiProjection.Project(queries["Win32_ComputerSystem"], static row => new HardwareMachine(row));
        Processors = WmiProjection.Project(queries["Win32_Processor"], static row => new HardwareProcessor(row));
        MemoryModules = WmiProjection.Project(queries["Win32_PhysicalMemory"], static row => new HardwareMemoryModule(row));
        MemoryArrays = WmiProjection.Project(queries["Win32_PhysicalMemoryArray"], static row => new HardwareMemoryArray(row));
        Bios = WmiProjection.Project(queries["Win32_BIOS"], static row => new HardwareBios(row));
        Baseboards = WmiProjection.Project(queries["Win32_BaseBoard"], static row => new HardwareBaseboard(row));
        Disks = WmiProjection.Project(queries["Win32_DiskDrive"], static row => new HardwareDisk(row));
        PhysicalDisks = WmiProjection.Project(queries["MSFT_PhysicalDisk"], static row => new HardwarePhysicalDisk(row));
        PnpDevices = WmiProjection.Project(queries["Win32_PnPEntity"], static row => new HardwarePnpDevice(row));
    }

    /// <summary>Gets the UTC capture time.</summary>
    public DateTimeOffset Timestamp { get; }

    /// <summary>Gets query status and raw detached rows, keyed by WMI class.</summary>
    public IReadOnlyDictionary<string, WmiQueryResult> Queries { get; }

    /// <summary>Gets operating systems inventory.</summary>
    public IReadOnlyList<HardwareOperatingSystem> OperatingSystems { get; }

    /// <summary>Gets machines inventory.</summary>
    public IReadOnlyList<HardwareMachine> Machines { get; }

    /// <summary>Gets processors inventory.</summary>
    public IReadOnlyList<HardwareProcessor> Processors { get; }

    /// <summary>Gets memory modules inventory.</summary>
    public IReadOnlyList<HardwareMemoryModule> MemoryModules { get; }

    /// <summary>Gets memory arrays inventory.</summary>
    public IReadOnlyList<HardwareMemoryArray> MemoryArrays { get; }

    /// <summary>Gets bios inventory.</summary>
    public IReadOnlyList<HardwareBios> Bios { get; }

    /// <summary>Gets baseboards inventory.</summary>
    public IReadOnlyList<HardwareBaseboard> Baseboards { get; }

    /// <summary>Gets disks inventory.</summary>
    public IReadOnlyList<HardwareDisk> Disks { get; }

    /// <summary>Gets physical disks inventory.</summary>
    public IReadOnlyList<HardwarePhysicalDisk> PhysicalDisks { get; }

    /// <summary>Gets pnp devices inventory.</summary>
    public IReadOnlyList<HardwarePnpDevice> PnpDevices { get; }
}
