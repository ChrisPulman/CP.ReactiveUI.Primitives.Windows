// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>The reported external power connection.</summary>
public enum PowerConnection
{
    /// <summary>Battery power.</summary>
    Offline = 0,

    /// <summary>External power.</summary>
    Online = 1,

    /// <summary>The connection is unknown.</summary>
    Unknown = 255,
}
