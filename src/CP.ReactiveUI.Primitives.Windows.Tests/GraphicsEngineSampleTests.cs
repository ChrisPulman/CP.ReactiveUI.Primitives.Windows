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

/// <summary>Tests preservation of native GPU counter identities.</summary>
public class GraphicsEngineSampleTests
{
    /// <summary>Verifies LUID and PID are extracted independently of adapter inventory order.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task CounterInstancePreservesLuidAndPid()
    {
        const uint ProcessId = 123;
        const string Luid = "0x00000000_0x00001234";
        const string Instance = "pid_123_luid_0x00000000_0x00001234_phys_0_eng_1_engtype_3D";
        var counter = new PerformanceCounterSample { InstanceName = Instance };
        var sample = new GraphicsEngineSample(counter);
        await Assert.That(sample.AdapterLuid).IsEqualTo(Luid);
        await Assert.That(sample.ProcessId).IsEqualTo(ProcessId);
        await Assert.That(sample.Counter.InstanceName).IsEqualTo(Instance);
    }

    /// <summary>Verifies unavailable or unrecognized instances do not create guessed adapter mappings.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task UnknownCounterInstanceHasNoGuessedIdentity()
    {
        var sample = new GraphicsEngineSample(new() { InstanceName = "adapter0" });
        await Assert.That(sample.AdapterLuid).IsNull();
        await Assert.That(sample.ProcessId).IsNull();
    }
}
