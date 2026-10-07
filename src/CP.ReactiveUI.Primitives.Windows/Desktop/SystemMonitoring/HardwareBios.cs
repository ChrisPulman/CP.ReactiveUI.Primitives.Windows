// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached hardware bios properties; null means the provider did not report a value.</summary>
public sealed class HardwareBios
{
    /// <summary>Initializes a new instance of the <see cref="HardwareBios"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal HardwareBios(WmiRow row)
    {
        Manufacturer = row.String(nameof(Manufacturer));
        Name = row.String(nameof(Name));
        Version = row.String("SMBIOSBIOSVersion");
        SerialNumber = row.String(nameof(SerialNumber));
        ReleaseTime = WmiProjection.Date(row.String("ReleaseDate"));
    }

    /// <summary>Gets manufacturer (Manufacturer) as reported by WMI.</summary>
    public string? Manufacturer { get; }

    /// <summary>Gets name (Name) as reported by WMI.</summary>
    public string? Name { get; }

    /// <summary>Gets version (SMBIOSBIOSVersion) as reported by WMI.</summary>
    public string? Version { get; }

    /// <summary>Gets serial number (SerialNumber) as reported by WMI.</summary>
    public string? SerialNumber { get; }

    /// <summary>Gets release time (ReleaseDate) as reported by WMI.</summary>
    public DateTimeOffset? ReleaseTime { get; }
}
