// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached hardware processor properties; null means the provider did not report a value.</summary>
public sealed class HardwareProcessor
{
    /// <summary>Initializes a new instance of the <see cref="HardwareProcessor"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal HardwareProcessor(WmiRow row)
    {
        DeviceId = row.String("DeviceID");
        Name = row.String(nameof(Name));
        Manufacturer = row.String(nameof(Manufacturer));
        ProcessorId = row.String(nameof(ProcessorId));
        Socket = row.String("SocketDesignation");
        CoreCount = row.UInt32("NumberOfCores");
        EnabledCoreCount = row.UInt32("NumberOfEnabledCore");
        LogicalProcessorCount = row.UInt32("NumberOfLogicalProcessors");
        MaximumClockMegahertz = row.UInt32("MaxClockSpeed");
        CurrentClockMegahertz = row.UInt32("CurrentClockSpeed");
        Architecture = row.UInt32(nameof(Architecture));
        L2CacheKilobytes = row.UInt32("L2CacheSize");
        L3CacheKilobytes = row.UInt32("L3CacheSize");
        VirtualizationFirmwareEnabled = row.Boolean(nameof(VirtualizationFirmwareEnabled));
        VmMonitorModeExtensions = row.Boolean("VMMonitorModeExtensions");
        SecondLevelAddressTranslation = row.Boolean("SecondLevelAddressTranslationExtensions");
    }

    /// <summary>Gets device id (DeviceID) as reported by WMI.</summary>
    public string? DeviceId { get; }

    /// <summary>Gets name (Name) as reported by WMI.</summary>
    public string? Name { get; }

    /// <summary>Gets manufacturer (Manufacturer) as reported by WMI.</summary>
    public string? Manufacturer { get; }

    /// <summary>Gets processor id (ProcessorId) as reported by WMI.</summary>
    public string? ProcessorId { get; }

    /// <summary>Gets socket (SocketDesignation) as reported by WMI.</summary>
    public string? Socket { get; }

    /// <summary>Gets core count (NumberOfCores) as reported by WMI.</summary>
    public uint? CoreCount { get; }

    /// <summary>Gets enabled core count (NumberOfEnabledCore) as reported by WMI.</summary>
    public uint? EnabledCoreCount { get; }

    /// <summary>Gets logical processor count (NumberOfLogicalProcessors) as reported by WMI.</summary>
    public uint? LogicalProcessorCount { get; }

    /// <summary>Gets maximum clock megahertz (MaxClockSpeed) as reported by WMI.</summary>
    public uint? MaximumClockMegahertz { get; }

    /// <summary>Gets current clock megahertz (CurrentClockSpeed) as reported by WMI.</summary>
    public uint? CurrentClockMegahertz { get; }

    /// <summary>Gets architecture code (Architecture) as reported by WMI.</summary>
    public uint? Architecture { get; }

    /// <summary>Gets l2 cache kilobytes (L2CacheSize) as reported by WMI.</summary>
    public uint? L2CacheKilobytes { get; }

    /// <summary>Gets l3 cache kilobytes (L3CacheSize) as reported by WMI.</summary>
    public uint? L3CacheKilobytes { get; }

    /// <summary>Gets virtualization firmware enabled (VirtualizationFirmwareEnabled) as reported by WMI.</summary>
    public bool? VirtualizationFirmwareEnabled { get; }

    /// <summary>Gets vm monitor mode extensions (VMMonitorModeExtensions) as reported by WMI.</summary>
    public bool? VmMonitorModeExtensions { get; }

    /// <summary>Gets second level address translation (SecondLevelAddressTranslationExtensions) as reported by WMI.</summary>
    public bool? SecondLevelAddressTranslation { get; }
}
