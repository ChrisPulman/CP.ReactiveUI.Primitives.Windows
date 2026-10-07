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

/// <summary>A display's reported brightness and support state.</summary>
public sealed class BrightnessSample
{
    /// <summary>Gets the provider's display identifier.</summary>
    public string Id { get; internal set; } = string.Empty;

    /// <summary>Gets the display description.</summary>
    public string Description { get; internal init; } = string.Empty;

    /// <summary>Gets the brightness transport.</summary>
    public BrightnessTransport Transport { get; internal init; }

    /// <summary>Gets whether the provider reports brightness support.</summary>
    public bool IsSupported { get; internal init; }

    /// <summary>Gets the current brightness in native units, or null if unavailable.</summary>
    public uint? Current { get; internal init; }

    /// <summary>Gets the minimum native brightness, or null if unavailable.</summary>
    public uint? Minimum { get; internal init; }

    /// <summary>Gets the maximum native brightness, or null if unavailable.</summary>
    public uint? Maximum { get; internal init; }

    /// <summary>Gets the provider error or unsupported reason.</summary>
    public string? Error { get; internal init; }
}
