// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_TEST_SHIM
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Tests exact typed WMI values and null-preserving inventory projections.</summary>
public class WmiRowTests
{
    /// <summary>Verifies absent numeric values remain null rather than becoming zero.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task ProjectionMissingValuesRemainNull()
    {
        var row = new WmiRow(new(StringComparer.OrdinalIgnoreCase) { ["Name"] = null });
        var processor = new HardwareProcessor(row);
        await Assert.That(processor.CoreCount).IsNull();
        await Assert.That(processor.VirtualizationFirmwareEnabled).IsNull();
        await Assert.That(processor.MaximumClockMegahertz).IsNull();
    }

    /// <summary>Verifies case insensitive exact-type access and unsigned capacity preservation.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task ReadTypedValuesPreservesUnsignedCapacity()
    {
        const ulong Capacity = 68_719_476_736;
        const string CapacityProperty = "Capacity";
        var row = new WmiRow(new(StringComparer.OrdinalIgnoreCase)
        {
            [CapacityProperty] = Capacity,
        });
        await Assert.That(row.TryGet<ulong>(CapacityProperty.ToLowerInvariant(), out var value)).IsTrue();
        await Assert.That(value).IsEqualTo(Capacity);
        await Assert.That(row.TryGet<string>(CapacityProperty, out _)).IsFalse();
        await Assert.That(new HardwareMemoryModule(row).CapacityBytes).IsEqualTo(Capacity);
    }

    /// <summary>Verifies CIM numeric widths can be projected into the documented inventory width.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task ProjectionConvertsCimUnsignedWidths()
    {
        const ushort MemoryType = 34;
        var row = new WmiRow(new(StringComparer.OrdinalIgnoreCase)
        {
            ["SMBIOSMemoryType"] = MemoryType,
        });
        await Assert.That(new HardwareMemoryModule(row).MemoryTypeCode).IsEqualTo((uint)MemoryType);
    }
}
