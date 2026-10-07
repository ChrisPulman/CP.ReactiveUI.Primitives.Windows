// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
using System.Diagnostics;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A point-in-time process inventory.</summary>
public sealed class ProcessSnapshot
{
    /// <summary>Gets the UTC capture time.</summary>
    public DateTimeOffset Timestamp { get; internal set; }

    /// <summary>Gets the optional extended identity provider result, including availability and errors.</summary>
    public WmiQueryResult? ExtendedIdentityResult { get; internal set; }

    /// <summary>Gets the captured processes.</summary>
    public IReadOnlyList<ProcessInfo> Processes { get; internal set; } = Array.Empty<ProcessInfo>();
}
