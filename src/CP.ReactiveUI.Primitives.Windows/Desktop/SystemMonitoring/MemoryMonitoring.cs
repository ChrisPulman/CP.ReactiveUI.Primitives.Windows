// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Captures system physical memory, commit usage, kernel pools, and object counts.</summary>
public static class MemoryMonitoring
{
    /// <summary>Captures current memory information.</summary>
    /// <returns>The current system memory sample.</returns>
    public static MemorySample Capture()
    {
        using var sampler = new MemorySampler();
        return sampler.Capture();
    }

    /// <summary>Observes memory information at the specified polling interval.</summary>
    /// <param name="interval">The positive polling interval.</param>
    /// <returns>A stream with an independent sampler for each subscription.</returns>
    public static IObservable<MemorySample> Observe(TimeSpan interval) =>
        SystemPolling.Observe(static () => new MemorySampler(), interval);
}
