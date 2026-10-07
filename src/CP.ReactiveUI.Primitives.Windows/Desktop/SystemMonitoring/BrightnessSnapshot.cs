// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
using System.Management;

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Brightness inventory including provider failures.</summary>
public sealed class BrightnessSnapshot
{
    /// <summary>Gets the capture time.</summary>
    public DateTimeOffset Timestamp { get; internal init; }

    /// <summary>Gets the displays reported by available providers.</summary>
    public BrightnessSample[] Displays { get; internal init; } = [];

    /// <summary>Gets inventory failures, including unavailable WMI providers.</summary>
    public string[] Errors { get; internal init; } = [];
}
