// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Tests performance-counter validation and unavailable-value semantics.</summary>
public class PerformanceCounterQueryTests
{
    /// <summary>Counter path used to construct a query.</summary>
    private const string CounterPath = @"\Processor Information(*)\% Processor Time";

    /// <summary>Path used to query a category that is not installed.</summary>
    private const string UnknownCounterPath = @"\CP.Nonexistent.Performance.Category\Unknown Counter";

    /// <summary>Path used to query process identifiers.</summary>
    private const string ProcessIdCounterPath = @"\Process(*)\ID Process";

    /// <summary>Valid counter value used by status tests.</summary>
    private const double ValidCounterValue = 42.5D;

    /// <summary>Successful counter statuses used by disposal and validation cases.</summary>
    private static readonly string[] CounterPaths = [CounterPath];

    /// <summary>Whitespace-only invalid path used by validation.</summary>
    private static readonly string[] BlankCounterPaths = [" "];

    /// <summary>Path used to query the unknown counter category.</summary>
    private static readonly string[] UnknownCounterPaths = [UnknownCounterPath];

    /// <summary>Path used to query process identifiers.</summary>
    private static readonly string[] ProcessIdCounterPaths = [ProcessIdCounterPath];

    /// <summary>Verifies valid PDH statuses preserve values.</summary>
    /// <param name="status">The native status.</param>
    /// <returns>The asynchronous assertion.</returns>
    [Test]
    [Arguments(0U)]
    [Arguments(1U)]
    public async Task ValidValue_SuccessStatus_PreservesValue(uint status) =>
        await Assert.That(PerformanceCounterQuery.ValidValue(status, ValidCounterValue)).IsEqualTo(ValidCounterValue);

    /// <summary>Verifies warmup and invalid data are absent, rather than zero.</summary>
    /// <returns>The asynchronous assertion.</returns>
    [Test]
    public async Task ValidValue_InvalidData_IsNull()
    {
        await Assert.That(PerformanceCounterQuery.ValidValue(0xC0000BBAU, 0)).IsNull();
        await Assert.That(PerformanceCounterQuery.ValidValue(0U, double.NaN)).IsNull();
        await Assert.That(PerformanceCounterQuery.ValidValue(1U, double.PositiveInfinity)).IsNull();
    }

    /// <summary>Verifies disposal before initialization never acquires native resources.</summary>
    /// <returns>The asynchronous assertion.</returns>
    [Test]
    public async Task Capture_DisposedBeforeFirstRead_Throws()
    {
        var query = new PerformanceCounterQuery(CounterPaths);
        query.Dispose();
        query.Dispose();
        await Assert.That(() => query.Capture()).Throws<ObjectDisposedException>();
    }

    /// <summary>Verifies counter lists are validated eagerly.</summary>
    /// <returns>The asynchronous assertion.</returns>
    [Test]
    public async Task ValidatePaths_EmptyOrBlank_Throws()
    {
        await Assert.That(static () => PerformanceCounterQuery.ValidatePaths([])).Throws<ArgumentException>();
        await Assert.That(static () => PerformanceCounterQuery.ValidatePaths(BlankCounterPaths)).Throws<ArgumentException>();
    }

    /// <summary>Verifies paths are snapshotted before callers can mutate their collection.</summary>
    /// <returns>The asynchronous assertion.</returns>
    [Test]
    public async Task ValidatePaths_MutableInput_CopiesPaths()
    {
        var paths = new[] { CounterPath };
        var captured = PerformanceCounterQuery.ValidatePaths(paths);
        paths[0] = string.Empty;
        await Assert.That(captured[0]).IsEqualTo(CounterPath);
    }

    /// <summary>Verifies unknown native categories preserve their failure status.</summary>
    /// <returns>The asynchronous assertion.</returns>
    [Test]
    public async Task Capture_UnknownCategory_ReturnsUnavailableStatus()
    {
        using var query = new PerformanceCounterQuery(UnknownCounterPaths);
        var samples = query.Capture();
        await Assert.That(samples.Count).IsEqualTo(1);
        await Assert.That(samples[0].Value).IsNull();
        await Assert.That(samples[0].Status > 1).IsTrue();
    }

    /// <summary>Verifies wildcard PDH formatting returns named instances when the provider is installed.</summary>
    /// <returns>The asynchronous assertion.</returns>
    [Test]
    public async Task Capture_WildcardGauge_PreservesInstanceValues()
    {
        using var query = new PerformanceCounterQuery(ProcessIdCounterPaths);
        var samples = query.Capture();
        await Assert.That(samples.Count > 0).IsTrue();
        foreach (var sample in samples)
        {
            if (sample.Status <= 1)
            {
                await Assert.That(sample.InstanceName.Length > 0).IsTrue();
                await Assert.That(sample.Value.HasValue).IsTrue();
                await Assert.That(sample.Value >= 0).IsTrue();
            }
            else
            {
                await Assert.That(sample.Value).IsNull();
            }
        }
    }
}
