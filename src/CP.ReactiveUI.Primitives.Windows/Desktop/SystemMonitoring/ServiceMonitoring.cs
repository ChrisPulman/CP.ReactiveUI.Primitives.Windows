// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Captures and observes services without modifying their configuration or state.</summary>
public static class ServiceMonitoring
{
    /// <summary>Captures the local service inventory with a bounded provider query.</summary>
    /// <returns>The typed inventory and provider availability.</returns>
    public static ServiceSnapshot Capture() =>
        new(WindowsManagement.Query(@"root\cimv2", "SELECT * FROM Win32_Service"));

    /// <summary>Observes local services with a sampler owned by each subscription.</summary>
    /// <param name="interval">The positive polling interval.</param>
    /// <returns>The cold service observable.</returns>
    public static IObservable<ServiceSnapshot> Observe(TimeSpan interval) =>
        SystemPolling.Observe(static () => new ServiceSampler(), interval);
}
