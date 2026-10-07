// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached hardware physical disk properties; null means the provider did not report a value.</summary>
public sealed class HardwarePhysicalDisk
{
    /// <summary>Initializes a new instance of the <see cref="HardwarePhysicalDisk"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal HardwarePhysicalDisk(WmiRow row)
    {
        DeviceId = row.String(nameof(DeviceId));
        FriendlyName = row.String(nameof(FriendlyName));
        SerialNumber = row.String(nameof(SerialNumber));
        UniqueId = row.String(nameof(UniqueId));
        SizeBytes = row.UInt64(nameof(Size));
        BusTypeCode = row.UInt32("BusType");
        MediaTypeCode = row.UInt32("MediaType");
        HealthStatusCode = row.UInt32("HealthStatus");
        SpindleSpeedRpm = row.UInt32("SpindleSpeed");
    }

    /// <summary>Gets device id (DeviceId) as reported by WMI.</summary>
    public string? DeviceId { get; }

    /// <summary>Gets friendly name (FriendlyName) as reported by WMI.</summary>
    public string? FriendlyName { get; }

    /// <summary>Gets serial number (SerialNumber) as reported by WMI.</summary>
    public string? SerialNumber { get; }

    /// <summary>Gets unique id (UniqueId) as reported by WMI.</summary>
    public string? UniqueId { get; }

    /// <summary>Gets size bytes (Size) as reported by WMI.</summary>
    public ulong? SizeBytes { get; }

    /// <summary>Gets bus type code (BusType) as reported by WMI.</summary>
    public uint? BusTypeCode { get; }

    /// <summary>Gets media type code (MediaType) as reported by WMI.</summary>
    public uint? MediaTypeCode { get; }

    /// <summary>Gets health status code (HealthStatus) as reported by WMI.</summary>
    public uint? HealthStatusCode { get; }

    /// <summary>Gets spindle speed rpm (SpindleSpeed) as reported by WMI.</summary>
    public uint? SpindleSpeedRpm { get; }
}
