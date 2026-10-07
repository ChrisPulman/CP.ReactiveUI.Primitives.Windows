// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Provides a fluent entry point for Windows system monitoring.</summary>
public static class WindowsSystem
{
    /// <summary>Creates a monitor configuration with no providers selected.</summary>
    /// <returns>An immutable builder; no reads begin before capture or subscription.</returns>
    public static SystemMonitorBuilder Monitor() => new();
}
