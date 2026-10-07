// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Captures logical drive capacity and physical disk activity.</summary>
public static class StorageMonitoring
{
    /// <summary>Captures storage state; PDH rate counters may require a second sample.</summary>
    /// <returns>Drive capacities and available physical disk counters.</returns>
    public static StorageSnapshot Capture()
    {
        using var sampler = new StorageSampler();
        return sampler.Capture();
    }

    /// <summary>Observes storage snapshots immediately and at the requested interval.</summary>
    /// <param name="interval">A positive sampling interval.</param>
    /// <returns>A stream owning one native performance counter query per subscription.</returns>
    public static IObservable<StorageSnapshot> Observe(TimeSpan interval) => SystemPolling.Observe(static () => new StorageSampler(), interval);
}
