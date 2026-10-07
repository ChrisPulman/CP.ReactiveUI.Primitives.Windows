// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Captures CPU utilization and frequency across Windows processor groups.</summary>
public static class CpuMonitoring
{
    /// <summary>Captures CPU information. Rate counters need a second observation to become available.</summary>
    /// <returns>The current CPU sample.</returns>
    public static CpuSample Capture()
    {
        using var sampler = new CpuSampler();
        return sampler.Capture();
    }

    /// <summary>Observes CPU information with independent counter history per subscription.</summary>
    /// <param name="interval">The positive polling interval.</param>
    /// <returns>A stream of CPU samples.</returns>
    public static IObservable<CpuSample> Observe(TimeSpan interval) =>
        SystemPolling.Observe(static () => new CpuSampler(), interval);
}
