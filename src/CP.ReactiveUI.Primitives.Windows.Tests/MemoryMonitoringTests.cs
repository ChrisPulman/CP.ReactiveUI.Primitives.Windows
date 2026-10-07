// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies memory page conversion and real Windows capture.</summary>
public sealed class MemoryMonitoringTests
{
    /// <summary>Page count used by the conversion fixture.</summary>
    private const ulong PageCount = 3;

    /// <summary>Page size used by the conversion fixture.</summary>
    private const ulong PageSize = 4096;

    /// <summary>Expected bytes for the conversion fixture.</summary>
    private const ulong ExpectedBytes = 12_288;

    /// <summary>Multiplier that overflows the largest page count.</summary>
    private const ulong OverflowingPageSize = 2;

    /// <summary>Total physical memory in the calculated sample.</summary>
    private const ulong TotalPhysicalBytes = 400;

    /// <summary>Available physical memory in the calculated sample.</summary>
    private const ulong AvailablePhysicalBytes = 100;

    /// <summary>Expected used physical memory in the calculated sample.</summary>
    private const ulong ExpectedUsedPhysicalBytes = 300;

    /// <summary>Expected load percentage in the calculated sample.</summary>
    private const double ExpectedMemoryLoadPercent = 75D;

    /// <summary>Page counts are converted using the reported page size.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task PagesToBytes_UsesPageSize() =>
        await Assert.That(MemorySampler.PagesToBytes(PageCount, PageSize)).IsEqualTo(ExpectedBytes);

    /// <summary>Impossible page byte counts fail explicitly rather than wrapping.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task PagesToBytes_RejectsOverflow() =>
        await Assert.That(static () => MemorySampler.PagesToBytes(ulong.MaxValue, OverflowingPageSize)).Throws<OverflowException>();

    /// <summary>Physical usage and percentage are calculated from the same snapshot.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task MemorySample_ComputesUsage()
    {
        var sample = new MemorySample { TotalPhysicalBytes = TotalPhysicalBytes, AvailablePhysicalBytes = AvailablePhysicalBytes };
        await Assert.That(sample.UsedPhysicalBytes).IsEqualTo(ExpectedUsedPhysicalBytes);
        await Assert.That(sample.MemoryLoadPercent).IsEqualTo(ExpectedMemoryLoadPercent);
        await Assert.That(new MemorySample().MemoryLoadPercent).IsEqualTo(0D);
    }

    /// <summary>The real Windows API reports plausible physical memory and process counts.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task Capture_ReportsSystemMemory()
    {
        var sample = MemoryMonitoring.Capture();
        await Assert.That(sample.TotalPhysicalBytes != 0).IsTrue();
        await Assert.That(sample.AvailablePhysicalBytes <= sample.TotalPhysicalBytes).IsTrue();
        await Assert.That(sample.PageSizeBytes != 0).IsTrue();
        await Assert.That(sample.CommitTotalBytes <= sample.CommitLimitBytes).IsTrue();
        await Assert.That(sample.ProcessCount != 0).IsTrue();
        await Assert.That(sample.ThreadCount >= sample.ProcessCount).IsTrue();
    }
}
