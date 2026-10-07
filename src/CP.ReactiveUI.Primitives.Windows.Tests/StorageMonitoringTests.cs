// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_TEST_SHIM
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies physical disk mapping and read-only drive capture.</summary>
public sealed class StorageMonitoringTests
{
    /// <summary>The idle percentage used by the counter fixture.</summary>
    private const double IdlePercent = 75D;

    /// <summary>The corresponding active percentage.</summary>
    private const double ActivePercent = 25D;

    /// <summary>The expected disk throughput.</summary>
    private const double ReadRate = 2048D;

    /// <summary>Physical disk instance used by the fixture.</summary>
    private const string DiskInstanceName = "0 C:";

    /// <summary>Counter path used to map disk read rate data.</summary>
    private const string DiskReadCounterPath = @"\PhysicalDisk(*)\Disk Read Bytes/sec";

    /// <summary>Second physical disk instance used by the invalid counter fixture.</summary>
    private const string SecondDiskInstanceName = "1 D:";

    /// <summary>Counter status indicating invalid data.</summary>
    private const uint PrimingCounterStatus = 1;

    /// <summary>Number of disk samples expected in the invalid counter fixture.</summary>
    private const int ExpectedInvalidDiskCount = 2;

    /// <summary>A PDH invalid-data status.</summary>
    private const uint InvalidDataStatus = 0xC0000BC6;

    /// <summary>Verifies throughput, utilization, and counter statuses map to the same disk.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task MapCounters_ValidInstance_PreservesMetricsAndStatuses()
    {
        var samples = new[]
        {
            new PerformanceCounterSample { InstanceName = DiskInstanceName, CounterPath = @"\PhysicalDisk(*)\% Idle Time", Value = IdlePercent },
            new PerformanceCounterSample { InstanceName = DiskInstanceName, CounterPath = DiskReadCounterPath, Value = ReadRate, Status = PrimingCounterStatus },
        };
        var disks = StorageSampler.MapCounters(samples);
        await Assert.That(disks.Count).IsEqualTo(1);
        await Assert.That(disks[0].InstanceName).IsEqualTo(DiskInstanceName);
        await Assert.That(disks[0].ActiveTimePercent).IsEqualTo(ActivePercent);
        await Assert.That(disks[0].ReadBytesPerSecond).IsEqualTo(ReadRate);
        await Assert.That(disks[0].WriteBytesPerSecond).IsNull();
        await Assert.That(disks[0].CounterStatuses["Disk Read Bytes/sec"]).IsEqualTo(1U);
    }

    /// <summary>Verifies failed or priming counters remain unavailable, preserving native status.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task MapCounters_InvalidCounter_DoesNotInventZero()
    {
        var samples = new[]
        {
            new PerformanceCounterSample { InstanceName = DiskInstanceName, CounterPath = DiskReadCounterPath, Value = ReadRate, Status = InvalidDataStatus },
            new PerformanceCounterSample { InstanceName = SecondDiskInstanceName, CounterPath = DiskReadCounterPath },
        };
        var disks = StorageSampler.MapCounters(samples);
        await Assert.That(disks.Count).IsEqualTo(ExpectedInvalidDiskCount);
        await Assert.That(disks[0].ReadBytesPerSecond).IsNull();
        await Assert.That(disks[0].CounterStatuses["Disk Read Bytes/sec"]).IsEqualTo(InvalidDataStatus);
        await Assert.That(disks[1].ReadBytesPerSecond).IsNull();
    }

    /// <summary>Verifies invalid numerical counter values remain unavailable.</summary>
    /// <param name="value">The invalid counter value.</param>
    /// <returns>The assertion task.</returns>
    [Test]
    [Arguments(-1D)]
    [Arguments(double.NaN)]
    [Arguments(double.PositiveInfinity)]
    public async Task MapCounters_InvalidNumericalValue_ReturnsUnavailable(double value)
    {
        var sample = new PerformanceCounterSample { InstanceName = "disk", CounterPath = DiskReadCounterPath, Value = value };
        await Assert.That(StorageSampler.MapCounters([sample])[0].ReadBytesPerSecond).IsNull();
    }

    /// <summary>Verifies native capacity readings are coherent without changing drives.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Capture_ReadOnlyNativeSnapshot_HasCoherentCapacities()
    {
        var snapshot = StorageMonitoring.Capture();
        foreach (var drive in snapshot.Drives)
        {
            await Assert.That(drive.Name.Length > 0).IsTrue();
            if (drive.IsReady)
            {
                await Assert.That(drive.TotalBytes >= drive.TotalFreeBytes).IsTrue();
                await Assert.That(drive.TotalFreeBytes >= drive.AvailableFreeBytes).IsTrue();
            }
        }

        await Assert.That(snapshot.Timestamp.Offset).IsEqualTo(TimeSpan.Zero);
    }
}
