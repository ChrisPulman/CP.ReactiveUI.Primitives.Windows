// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Captures services for a polling subscription.</summary>
internal sealed class ServiceSampler : ISystemSampler<ServiceSnapshot>
{
    /// <summary>Captures the local service inventory.</summary>
    /// <returns>The service observation.</returns>
    public ServiceSnapshot Capture() => ServiceMonitoring.Capture();

    /// <summary>Releases the sampler, which retains no provider resources.</summary>
    public void Dispose()
    {
    }
}
