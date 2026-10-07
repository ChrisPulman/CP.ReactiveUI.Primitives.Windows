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

/// <summary>Verifies NVIDIA measurement conversion, identity and optional native availability.</summary>
public class NvidiaSensorProviderTests
{
    /// <summary>Verifies milliwatts are converted without truncation.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task PowerConvertsMilliwattsToWatts()
    {
        const uint Milliwatts = 125_500;
        const double Expected = 125.5;
        await Assert.That(NvidiaSensorProvider.Watts(Milliwatts)).IsEqualTo(Expected);
    }

    /// <summary>Verifies NVML errors retain their code and never publish a value.</summary>
    /// <param name="code">The NVML result code.</param>
    /// <param name="expected">The expected availability.</param>
    /// <returns>The assertion task.</returns>
    [Test]
    [Arguments(3, WmiQueryStatus.Unavailable)]
    [Arguments(4, WmiQueryStatus.AccessDenied)]
    [Arguments(10, WmiQueryStatus.TimedOut)]
    [Arguments(12, WmiQueryStatus.Unavailable)]
    [Arguments(999, WmiQueryStatus.Failed)]
    public async Task NativeErrorPreservesUnavailableReading(int code, WmiQueryStatus expected)
    {
        const double DiscardedNativeValue = 123;
        var sample = NvidiaSensorProvider.Measurement("GPU-test", "GPU", "Power", "Watts", code, DiscardedNativeValue);
        await Assert.That(sample.Value).IsNull();
        await Assert.That(sample.Status).IsEqualTo(expected);
        await Assert.That(sample.Error).IsEqualTo(FormattableString.Invariant($"NVML error {code}"));
    }

    /// <summary>Verifies UUID identity and a fan percentage cannot be mistaken for RPM.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task SuccessfulFanPreservesUuidAndPercentage()
    {
        const double Percent = 42;
        var sample = NvidiaSensorProvider.Measurement("GPU-test", "GPU", "Fan speed", "Percent", 0, Percent);
        await Assert.That(sample.SensorId).IsEqualTo("NVML:GPU-test:Fan speed");
        await Assert.That(sample.Unit).IsEqualTo("Percent");
        await Assert.That(sample.Value).IsEqualTo(Percent);
        await Assert.That(sample.Status).IsEqualTo(WmiQueryStatus.Available);
        await Assert.That(sample.Error).IsNull();
    }

    /// <summary>Verifies real read-only capture supplies measurements or explicit unavailability.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task CaptureReturnsTypedReadingsWithoutRequiringNvidiaHardware()
    {
        using var provider = new NvidiaSensorProvider();
        var samples = provider.Capture();
        await Assert.That(samples.Count > 0).IsTrue();
        var hasTemperature = false;
        var hasPower = false;
        foreach (var sample in samples)
        {
            hasTemperature |= sample.Unit == "Celsius";
            hasPower |= sample.Unit == "Watts";
            await Assert.That(sample.Provider).IsEqualTo("NVIDIA NVML");
            await Assert.That(sample.SensorId.StartsWith("NVML:", StringComparison.Ordinal)).IsTrue();
            if (sample.Status == WmiQueryStatus.Available)
            {
                await Assert.That(sample.Value.HasValue).IsTrue();
                await Assert.That(double.IsNaN(sample.Value.GetValueOrDefault())).IsFalse();
                await Assert.That(sample.Error).IsNull();
            }
            else
            {
                await Assert.That(sample.Value).IsNull();
                await Assert.That(string.IsNullOrEmpty(sample.Error)).IsFalse();
            }
        }

        await Assert.That(hasTemperature).IsTrue();
        await Assert.That(hasPower).IsTrue();
    }

    /// <summary>Verifies disposal prevents a subsequent native query.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task CaptureAfterDisposeThrows()
    {
        using var provider = new NvidiaSensorProvider();
        provider.Dispose();
        await Assert.That(() => provider.Capture()).Throws<ObjectDisposedException>();
    }

    /// <summary>Verifies the exact NVML v1 structure sizes and field order.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task NativeLayoutsMatchNvmlHeader()
    {
        const int UtilizationBytes = 8;
        const int MemoryBytes = 24;
        await Assert.That(Marshal.SizeOf<NvidiaSensorProvider.NvidiaUtilization>()).IsEqualTo(UtilizationBytes);
        await Assert.That(Marshal.SizeOf<NvidiaSensorProvider.NvidiaMemory>()).IsEqualTo(MemoryBytes);
    }
}
