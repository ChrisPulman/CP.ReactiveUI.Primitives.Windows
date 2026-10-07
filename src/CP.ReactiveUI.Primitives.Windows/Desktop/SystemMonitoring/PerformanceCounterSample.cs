// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A formatted Windows performance counter value and its native status.</summary>
public sealed class PerformanceCounterSample
{
    /// <summary>Gets the requested English counter path.</summary>
    public string CounterPath { get; internal init; } = string.Empty;

    /// <summary>Gets the counter instance name, or an empty string for an unavailable counter.</summary>
    public string InstanceName { get; internal init; } = string.Empty;

    /// <summary>Gets the value, or null when data is unavailable or needs another sample.</summary>
    public double? Value { get; internal init; }

    /// <summary>Gets the PDH status; zero and one identify valid data.</summary>
    public uint Status { get; internal init; }
}
