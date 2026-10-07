// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Describes whether a WMI provider answered a query.</summary>
public enum WmiQueryStatus
{
    /// <summary>The provider returned a complete result, possibly empty.</summary>
    Available,
    /// <summary>The namespace, class, or provider is unavailable.</summary>
    Unavailable,
    /// <summary>The current identity cannot read the provider.</summary>
    AccessDenied,
    /// <summary>The query exceeded its requested duration.</summary>
    TimedOut,
    /// <summary>The provider failed to complete the query.</summary>
    Failed,
}
