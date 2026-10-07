// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies CPU instance mapping and unavailable rate handling.</summary>
public sealed class CpuMonitoringTests
{
    /// <summary>Processor groups are parsed independently of the current culture.</summary>
    /// <param name="identity">The logical processor identity.</param>
    /// <param name="expectedGroup">The expected processor group.</param>
    /// <param name="expectedProcessor">The expected group-relative processor number.</param>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    [Arguments("2,17", 2, 17)]
    public async Task ProcessorIdentity_MapsGroupAndProcessor(string identity, int expectedGroup, int expectedProcessor)
    {
        await Assert.That(CpuSampler.TryParseProcessorIdentity(identity, out var group, out var processor)).IsTrue();
        await Assert.That(group).IsEqualTo(expectedGroup);
        await Assert.That(processor).IsEqualTo(expectedProcessor);
    }

    /// <summary>Aggregate and malformed identities cannot become logical processor entries.</summary>
    /// <param name="identity">The invalid identity.</param>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    [Arguments("_Total")]
    [Arguments("0,_Total")]
    [Arguments("0")]
    [Arguments("-1,2")]
    [Arguments("0,1,2")]
    public async Task ProcessorIdentity_RejectsAggregateAndMalformed(string identity) =>
        await Assert.That(CpuSampler.TryParseProcessorIdentity(identity, out _, out _)).IsFalse();

    /// <summary>Invalid or absent rates remain unavailable.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task NormalizePercentage_PreservesUnavailable()
    {
        await Assert.That(CpuSampler.NormalizePercentage(null)).IsNull();
        await Assert.That(CpuSampler.NormalizePercentage(double.NaN)).IsNull();
        await Assert.That(CpuSampler.NormalizePercentage(double.PositiveInfinity)).IsNull();
    }

    /// <summary>Formatted percentages are bounded to a logical processor's capacity.</summary>
    /// <param name="input">The formatted percentage.</param>
    /// <param name="expected">The bounded percentage.</param>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    [Arguments(-10D, 0D)]
    [Arguments(110D, 100D)]
    [Arguments(37.5D, 37.5D)]
    public async Task NormalizePercentage_ClampsBounds(double input, double expected) =>
        await Assert.That(CpuSampler.NormalizePercentage(input)).IsEqualTo(expected);

    /// <summary>The real Windows provider discovers individual processor identities.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task Capture_DiscoversLogicalProcessors()
    {
        var sample = CpuMonitoring.Capture();
        await Assert.That(sample.LogicalProcessorCount > 0).IsTrue();
        await Assert.That(sample.LogicalProcessors.Count).IsEqualTo(sample.LogicalProcessorCount);
        foreach (var processor in sample.LogicalProcessors)
        {
            await Assert.That(processor.GroupNumber >= 0).IsTrue();
            await Assert.That(processor.ProcessorNumber >= 0).IsTrue();
        }
    }
}
