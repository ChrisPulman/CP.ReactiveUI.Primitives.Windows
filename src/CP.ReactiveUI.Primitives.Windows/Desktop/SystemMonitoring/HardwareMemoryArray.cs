// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Detached hardware memory array properties; null means the provider did not report a value.</summary>
public sealed class HardwareMemoryArray
{
    /// <summary>Initializes a new instance of the <see cref="HardwareMemoryArray"/> class.</summary>
    /// <param name="row">The row value.</param>
    internal HardwareMemoryArray(WmiRow row)
    {
        Tag = row.String(nameof(Tag));
        SlotCount = row.UInt32("MemoryDevices");
        MaximumCapacityKilobytes = row.UInt64("MaxCapacityEx");
    }

    /// <summary>Gets tag (Tag) as reported by WMI.</summary>
    public string? Tag { get; }

    /// <summary>Gets slot count (MemoryDevices) as reported by WMI.</summary>
    public uint? SlotCount { get; }

    /// <summary>Gets maximum capacity kilobytes (MaxCapacityEx) as reported by WMI.</summary>
    public ulong? MaximumCapacityKilobytes { get; }
}
