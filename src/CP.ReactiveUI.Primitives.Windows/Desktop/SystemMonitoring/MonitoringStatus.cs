// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Describes the outcome of a monitoring provider.</summary>
public enum MonitoringStatus
{
    /// <summary>The provider was not selected.</summary>
    NotRequested,

    /// <summary>A snapshot was captured; its individual measurements may still be warming up.</summary>
    Available,

    /// <summary>The operating system or provider does not expose this capability.</summary>
    Unavailable,

    /// <summary>The caller lacks permission to read the capability.</summary>
    AccessDenied,

    /// <summary>The provider failed to capture a snapshot.</summary>
    Failed,
}
