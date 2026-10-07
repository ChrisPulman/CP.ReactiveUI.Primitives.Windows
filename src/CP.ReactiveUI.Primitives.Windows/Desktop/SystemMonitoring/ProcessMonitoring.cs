// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Diagnostics;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Read-only process inventory and independent sampled process telemetry.</summary>
public static class ProcessMonitoring
{
    /// <summary>Captures every running process.</summary>
    /// <returns>The process inventory.</returns>
    public static ProcessSnapshot Capture() => Capture(null, false);

    /// <summary>Captures one running process.</summary>
    /// <param name="processId">The process identifier.</param>
    /// <returns>The process inventory.</returns>
    public static ProcessSnapshot Capture(int processId) => Capture(processId, false);

    /// <summary>Captures processes; rates are unavailable until a subsequent observation.</summary>
    /// <param name="processId">An optional process identifier to select.</param>
    /// <param name="includeExtendedIdentity">Whether to query WMI for parent and command line identity.</param>
    /// <returns>The process inventory with unavailable fields represented by null.</returns>
    public static ProcessSnapshot Capture(int? processId, bool includeExtendedIdentity)
    {
        using var sampler = new ProcessSampler(processId, includeExtendedIdentity);
        return sampler.Capture();
    }

    /// <summary>Observes every running process.</summary>
    /// <param name="interval">The positive sampling interval.</param>
    /// <returns>The sampled process inventory.</returns>
    public static IObservable<ProcessSnapshot> Observe(TimeSpan interval) => Observe(interval, null, false);

    /// <summary>Observes one running process.</summary>
    /// <param name="interval">The positive sampling interval.</param>
    /// <param name="processId">The process identifier.</param>
    /// <returns>The sampled process inventory.</returns>
    public static IObservable<ProcessSnapshot> Observe(TimeSpan interval, int processId) => Observe(interval, processId, false);

    /// <summary>Observes processes with a separate delta baseline for each subscription.</summary>
    /// <param name="interval">The positive sampling interval.</param>
    /// <param name="processId">An optional process identifier to select.</param>
    /// <param name="includeExtendedIdentity">Whether to query WMI for parent and command line identity.</param>
    /// <returns>The sampled process inventory.</returns>
    public static IObservable<ProcessSnapshot> Observe(TimeSpan interval, int? processId, bool includeExtendedIdentity) =>
        SystemPolling.Observe(() => new ProcessSampler(processId, includeExtendedIdentity), interval);
}
