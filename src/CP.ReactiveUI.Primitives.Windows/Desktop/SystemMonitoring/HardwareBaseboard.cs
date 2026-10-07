// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached hardware baseboard properties; null means the provider did not report a value.</summary>
public sealed class HardwareBaseboard
{
    /// <summary>Initializes a new instance of the <see cref="HardwareBaseboard"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal HardwareBaseboard(WmiRow row)
    {
        Manufacturer = row.String(nameof(Manufacturer));
        Product = row.String(nameof(Product));
        Version = row.String(nameof(Version));
        SerialNumber = row.String(nameof(SerialNumber));
    }

    /// <summary>Gets manufacturer (Manufacturer) as reported by WMI.</summary>
    public string? Manufacturer { get; }

    /// <summary>Gets product (Product) as reported by WMI.</summary>
    public string? Product { get; }

    /// <summary>Gets version (Version) as reported by WMI.</summary>
    public string? Version { get; }

    /// <summary>Gets serial number (SerialNumber) as reported by WMI.</summary>
    public string? SerialNumber { get; }
}
