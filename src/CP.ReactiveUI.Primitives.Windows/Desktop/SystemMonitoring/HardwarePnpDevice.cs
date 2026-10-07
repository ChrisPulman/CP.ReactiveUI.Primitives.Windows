// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached hardware pnp device properties; null means the provider did not report a value.</summary>
public sealed class HardwarePnpDevice
{
    /// <summary>Initializes a new instance of the <see cref="HardwarePnpDevice"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal HardwarePnpDevice(WmiRow row)
    {
        DeviceId = row.String("DeviceID");
        Name = row.String(nameof(Name));
        Manufacturer = row.String(nameof(Manufacturer));
        Class = row.String("PNPClass");
        ClassGuid = row.String(nameof(ClassGuid));
        Service = row.String(nameof(Service));
        ConfigurationErrorCode = row.UInt32("ConfigManagerErrorCode");
        Present = row.Boolean(nameof(Present));
    }

    /// <summary>Gets device id (DeviceID) as reported by WMI.</summary>
    public string? DeviceId { get; }

    /// <summary>Gets name (Name) as reported by WMI.</summary>
    public string? Name { get; }

    /// <summary>Gets manufacturer (Manufacturer) as reported by WMI.</summary>
    public string? Manufacturer { get; }

    /// <summary>Gets class (PNPClass) as reported by WMI.</summary>
    public string? Class { get; }

    /// <summary>Gets class guid (ClassGuid) as reported by WMI.</summary>
    public string? ClassGuid { get; }

    /// <summary>Gets service (Service) as reported by WMI.</summary>
    public string? Service { get; }

    /// <summary>Gets configuration error code (ConfigManagerErrorCode) as reported by WMI.</summary>
    public uint? ConfigurationErrorCode { get; }

    /// <summary>Gets present (Present) as reported by WMI.</summary>
    public bool? Present { get; }
}
