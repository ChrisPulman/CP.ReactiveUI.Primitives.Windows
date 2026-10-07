// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Reads hardware inventory without installing drivers or invoking provider methods.</summary>
public static class HardwareMonitoring
{
    /// <summary>The local hardware namespace.</summary>
    private const string CimNamespace = @"root\cimv2";

    /// <summary>Captures local inventory. Each unavailable class has its own result status.</summary>
    /// <returns>The detached hardware inventory.</returns>
    public static HardwareSnapshot Capture()
    {
        var queries = new Dictionary<string, WmiQueryResult>(StringComparer.OrdinalIgnoreCase)
        {
            ["Win32_OperatingSystem"] = WindowsManagement.Query(CimNamespace, "SELECT * FROM Win32_OperatingSystem"),
            ["Win32_ComputerSystem"] = WindowsManagement.Query(CimNamespace, "SELECT * FROM Win32_ComputerSystem"),
            ["Win32_Processor"] = WindowsManagement.Query(CimNamespace, "SELECT * FROM Win32_Processor"),
            ["Win32_PhysicalMemory"] = WindowsManagement.Query(CimNamespace, "SELECT * FROM Win32_PhysicalMemory"),
            ["Win32_PhysicalMemoryArray"] = WindowsManagement.Query(CimNamespace, "SELECT * FROM Win32_PhysicalMemoryArray"),
            ["Win32_BIOS"] = WindowsManagement.Query(CimNamespace, "SELECT * FROM Win32_BIOS"),
            ["Win32_BaseBoard"] = WindowsManagement.Query(CimNamespace, "SELECT * FROM Win32_BaseBoard"),
            ["Win32_DiskDrive"] = WindowsManagement.Query(CimNamespace, "SELECT * FROM Win32_DiskDrive"),
            ["MSFT_PhysicalDisk"] = WindowsManagement.Query(@"root\Microsoft\Windows\Storage", "SELECT * FROM MSFT_PhysicalDisk"),
            ["Win32_PnPEntity"] = WindowsManagement.Query(CimNamespace, "SELECT * FROM Win32_PnPEntity"),
        };
        return new(queries);
    }

    /// <summary>Observes inventory changes. Use intervals of several minutes for these provider queries.</summary>
    /// <param name="interval">The positive polling interval.</param>
    /// <returns>An observable that owns its sampler for each subscription.</returns>
    public static IObservable<HardwareSnapshot> Observe(TimeSpan interval) =>
        SystemPolling.Observe(static () => new HardwareSampler(), interval);

    /// <summary>Initializes or reads HardwareSampler state.</summary>
    private sealed class HardwareSampler : ISystemSampler<HardwareSnapshot>
    {
        /// <summary>Initializes or reads Capture state.</summary>
        /// <returns>The captured or projected value.</returns>
        public HardwareSnapshot Capture() => HardwareMonitoring.Capture();

        /// <summary>Initializes or reads Dispose state.</summary>
        public void Dispose()
        {
        }
    }
}
