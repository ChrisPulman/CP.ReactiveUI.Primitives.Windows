// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached hardware machine properties; null means the provider did not report a value.</summary>
public sealed class HardwareMachine
{
    /// <summary>Initializes a new instance of the <see cref="HardwareMachine"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal HardwareMachine(WmiRow row)
    {
        Name = row.String(nameof(Name));
        Manufacturer = row.String(nameof(Manufacturer));
        Model = row.String(nameof(Model));
        SystemType = row.String(nameof(SystemType));
        HypervisorPresent = row.Boolean(nameof(HypervisorPresent));
        ProcessorSocketCount = row.UInt32("NumberOfProcessors");
        LogicalProcessorCount = row.UInt32("NumberOfLogicalProcessors");
        TotalPhysicalBytes = row.UInt64("TotalPhysicalMemory");
    }

    /// <summary>Gets name (Name) as reported by WMI.</summary>
    public string? Name { get; }

    /// <summary>Gets manufacturer (Manufacturer) as reported by WMI.</summary>
    public string? Manufacturer { get; }

    /// <summary>Gets model (Model) as reported by WMI.</summary>
    public string? Model { get; }

    /// <summary>Gets system type (SystemType) as reported by WMI.</summary>
    public string? SystemType { get; }

    /// <summary>Gets hypervisor present (HypervisorPresent) as reported by WMI.</summary>
    public bool? HypervisorPresent { get; }

    /// <summary>Gets processor socket count (NumberOfProcessors) as reported by WMI.</summary>
    public uint? ProcessorSocketCount { get; }

    /// <summary>Gets logical processor count (NumberOfLogicalProcessors) as reported by WMI.</summary>
    public uint? LogicalProcessorCount { get; }

    /// <summary>Gets total physical bytes (TotalPhysicalMemory) as reported by WMI.</summary>
    public ulong? TotalPhysicalBytes { get; }
}
