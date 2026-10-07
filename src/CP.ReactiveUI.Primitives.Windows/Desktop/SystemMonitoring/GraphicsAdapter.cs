// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached graphics adapter properties; null means the provider did not report a value.</summary>
public sealed class GraphicsAdapter
{
    /// <summary>Initializes a new instance of the <see cref="GraphicsAdapter"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal GraphicsAdapter(WmiRow row)
    {
        DeviceId = row.String("DeviceID");
        Name = row.String(nameof(Name));
        PnpDeviceId = row.String("PNPDeviceID");
        ProcessorName = row.String("VideoProcessor");
        DriverVersion = row.String(nameof(DriverVersion));
        DriverDate = WmiProjection.Date(row.String(nameof(DriverDate)));
        ReportedAdapterMemoryBytes = row.UInt64("AdapterRAM");
        CurrentHorizontalResolution = row.UInt32(nameof(CurrentHorizontalResolution));
        CurrentVerticalResolution = row.UInt32(nameof(CurrentVerticalResolution));
        CurrentRefreshRateHertz = row.UInt32("CurrentRefreshRate");
    }

    /// <summary>Gets device id (DeviceID) as reported by WMI.</summary>
    public string? DeviceId { get; }

    /// <summary>Gets name (Name) as reported by WMI.</summary>
    public string? Name { get; }

    /// <summary>Gets pnp device id (PNPDeviceID) as reported by WMI.</summary>
    public string? PnpDeviceId { get; }

    /// <summary>Gets processor name (VideoProcessor) as reported by WMI.</summary>
    public string? ProcessorName { get; }

    /// <summary>Gets driver version (DriverVersion) as reported by WMI.</summary>
    public string? DriverVersion { get; }

    /// <summary>Gets driver date (DriverDate) as reported by WMI.</summary>
    public DateTimeOffset? DriverDate { get; }

    /// <summary>Gets reported adapter memory bytes (AdapterRAM) as reported by WMI.</summary>
    public ulong? ReportedAdapterMemoryBytes { get; }

    /// <summary>Gets current horizontal resolution (CurrentHorizontalResolution) as reported by WMI.</summary>
    public uint? CurrentHorizontalResolution { get; }

    /// <summary>Gets current vertical resolution (CurrentVerticalResolution) as reported by WMI.</summary>
    public uint? CurrentVerticalResolution { get; }

    /// <summary>Gets current refresh rate hertz (CurrentRefreshRate) as reported by WMI.</summary>
    public uint? CurrentRefreshRateHertz { get; }
}
