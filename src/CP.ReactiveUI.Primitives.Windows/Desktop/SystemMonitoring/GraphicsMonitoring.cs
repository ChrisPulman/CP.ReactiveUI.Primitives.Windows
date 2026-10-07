// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Captures GPU engine and memory counters using native Windows providers.</summary>
public static class GraphicsMonitoring
{
    /// <summary>Captures GPU inventory and counters. Rate counters may require a persistent observation to become available.</summary>
    /// <returns>Adapter inventory and raw GPU engine/memory instances.</returns>
    public static GraphicsSnapshot Capture()
    {
        using var sampler = new GraphicsSampler();
        return sampler.Capture();
    }

    /// <summary>Observes GPU counters, keeping rate history and caching adapter inventory for five minutes.</summary>
    /// <param name="interval">The positive sampling interval.</param>
    /// <returns>A stream with independent native query ownership per subscription.</returns>
    public static IObservable<GraphicsSnapshot> Observe(TimeSpan interval) =>
        SystemPolling.Observe(static () => new GraphicsSampler(), interval);
}
