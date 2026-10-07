// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached hardware disk properties; null means the provider did not report a value.</summary>
public sealed class HardwareDisk
{
    /// <summary>Initializes a new instance of the <see cref="HardwareDisk"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal HardwareDisk(WmiRow row)
    {
        DeviceId = row.String("DeviceID");
        Index = row.UInt32(nameof(Index));
        Model = row.String(nameof(Model));
        Manufacturer = row.String(nameof(Manufacturer));
        SerialNumber = row.String(nameof(SerialNumber));
        FirmwareRevision = row.String(nameof(FirmwareRevision));
        PnpDeviceId = row.String("PNPDeviceID");
        InterfaceType = row.String(nameof(InterfaceType));
        MediaType = row.String(nameof(MediaType));
        SizeBytes = row.UInt64(nameof(Size));
        BytesPerSector = row.UInt32(nameof(BytesPerSector));
        ProviderStatus = row.String("Status");
    }

    /// <summary>Gets device id (DeviceID) as reported by WMI.</summary>
    public string? DeviceId { get; }

    /// <summary>Gets index (Index) as reported by WMI.</summary>
    public uint? Index { get; }

    /// <summary>Gets model (Model) as reported by WMI.</summary>
    public string? Model { get; }

    /// <summary>Gets manufacturer (Manufacturer) as reported by WMI.</summary>
    public string? Manufacturer { get; }

    /// <summary>Gets serial number (SerialNumber) as reported by WMI.</summary>
    public string? SerialNumber { get; }

    /// <summary>Gets firmware revision (FirmwareRevision) as reported by WMI.</summary>
    public string? FirmwareRevision { get; }

    /// <summary>Gets pnp device id (PNPDeviceID) as reported by WMI.</summary>
    public string? PnpDeviceId { get; }

    /// <summary>Gets interface type (InterfaceType) as reported by WMI.</summary>
    public string? InterfaceType { get; }

    /// <summary>Gets media type (MediaType) as reported by WMI.</summary>
    public string? MediaType { get; }

    /// <summary>Gets size bytes (Size) as reported by WMI.</summary>
    public ulong? SizeBytes { get; }

    /// <summary>Gets bytes per sector (BytesPerSector) as reported by WMI.</summary>
    public uint? BytesPerSector { get; }

    /// <summary>Gets provider status (Status) as reported by WMI.</summary>
    public string? ProviderStatus { get; }
}
