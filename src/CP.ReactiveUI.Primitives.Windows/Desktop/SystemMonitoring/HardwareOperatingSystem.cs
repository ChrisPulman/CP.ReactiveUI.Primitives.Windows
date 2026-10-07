// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached hardware operating system properties; null means the provider did not report a value.</summary>
public sealed class HardwareOperatingSystem
{
    /// <summary>Initializes a new instance of the <see cref="HardwareOperatingSystem"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal HardwareOperatingSystem(WmiRow row)
    {
        Name = row.String("Caption");
        Version = row.String(nameof(Version));
        BuildNumber = row.String(nameof(BuildNumber));
        Architecture = row.String("OSArchitecture");
        LastBootTime = WmiProjection.Date(row.String("LastBootUpTime"));
        InstallTime = WmiProjection.Date(row.String("InstallDate"));
        SystemDirectory = row.String(nameof(SystemDirectory));
    }

    /// <summary>Gets name (Caption) as reported by WMI.</summary>
    public string? Name { get; }

    /// <summary>Gets version (Version) as reported by WMI.</summary>
    public string? Version { get; }

    /// <summary>Gets build number (BuildNumber) as reported by WMI.</summary>
    public string? BuildNumber { get; }

    /// <summary>Gets architecture (OSArchitecture) as reported by WMI.</summary>
    public string? Architecture { get; }

    /// <summary>Gets last boot time (LastBootUpTime) as reported by WMI.</summary>
    public DateTimeOffset? LastBootTime { get; }

    /// <summary>Gets install time (InstallDate) as reported by WMI.</summary>
    public DateTimeOffset? InstallTime { get; }

    /// <summary>Gets system directory (SystemDirectory) as reported by WMI.</summary>
    public string? SystemDirectory { get; }
}
