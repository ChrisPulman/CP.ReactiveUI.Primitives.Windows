// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Interface configuration and traffic counters captured together.</summary>
public sealed class NetworkSnapshot
{
    /// <summary>Gets the UTC capture time.</summary>
    public DateTimeOffset Timestamp { get; internal init; }

    /// <summary>Gets the interfaces successfully sampled.</summary>
    public IReadOnlyList<NetworkInterfaceSnapshot> Interfaces { get; internal init; } = Array.Empty<NetworkInterfaceSnapshot>();

    /// <summary>Gets the interfaces that could not be sampled and their error messages.</summary>
    public IReadOnlyList<string> Errors { get; internal init; } = Array.Empty<string>();
}
