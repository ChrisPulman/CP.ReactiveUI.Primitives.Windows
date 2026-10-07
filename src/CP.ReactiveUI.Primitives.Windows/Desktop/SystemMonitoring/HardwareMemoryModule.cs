// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached hardware memory module properties; null means the provider did not report a value.</summary>
public sealed class HardwareMemoryModule
{
    /// <summary>Initializes a new instance of the <see cref="HardwareMemoryModule"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal HardwareMemoryModule(WmiRow row)
    {
        DeviceLocator = row.String(nameof(DeviceLocator));
        BankLabel = row.String(nameof(BankLabel));
        CapacityBytes = row.UInt64("Capacity");
        SpeedMegahertz = row.UInt32("Speed");
        ConfiguredSpeedMegahertz = row.UInt32("ConfiguredClockSpeed");
        Manufacturer = row.String(nameof(Manufacturer));
        PartNumber = row.String(nameof(PartNumber));
        SerialNumber = row.String(nameof(SerialNumber));
        FormFactorCode = row.UInt32("FormFactor");
        MemoryTypeCode = row.UInt32("SMBIOSMemoryType");
    }

    /// <summary>Gets device locator (DeviceLocator) as reported by WMI.</summary>
    public string? DeviceLocator { get; }

    /// <summary>Gets bank label (BankLabel) as reported by WMI.</summary>
    public string? BankLabel { get; }

    /// <summary>Gets capacity bytes (Capacity) as reported by WMI.</summary>
    public ulong? CapacityBytes { get; }

    /// <summary>Gets speed megahertz (Speed) as reported by WMI.</summary>
    public uint? SpeedMegahertz { get; }

    /// <summary>Gets configured speed megahertz (ConfiguredClockSpeed) as reported by WMI.</summary>
    public uint? ConfiguredSpeedMegahertz { get; }

    /// <summary>Gets manufacturer (Manufacturer) as reported by WMI.</summary>
    public string? Manufacturer { get; }

    /// <summary>Gets part number (PartNumber) as reported by WMI.</summary>
    public string? PartNumber { get; }

    /// <summary>Gets serial number (SerialNumber) as reported by WMI.</summary>
    public string? SerialNumber { get; }

    /// <summary>Gets form factor code (FormFactor) as reported by WMI.</summary>
    public uint? FormFactorCode { get; }

    /// <summary>Gets memory type code (SMBIOSMemoryType) as reported by WMI.</summary>
    public uint? MemoryTypeCode { get; }
}
