// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Service inventory and the availability of its Win32_Service query.</summary>
public sealed class ServiceSnapshot
{
    /// <summary>Initializes a new instance of the <see cref="ServiceSnapshot"/> class.</summary>
    /// <param name="query">The detached service query.</param>
    internal ServiceSnapshot(WmiQueryResult query)
    {
        Timestamp = TimeProvider.System.GetUtcNow();
        Query = query;
        Services = WmiProjection.Project(query, static row => new ServiceInfo(row));
    }

    /// <summary>Gets the UTC capture time.</summary>
    public DateTimeOffset Timestamp { get; }

    /// <summary>Gets provider availability, errors, and detached raw rows.</summary>
    public WmiQueryResult Query { get; }

    /// <summary>Gets services returned by the provider, including partial results on failure.</summary>
    public IReadOnlyList<ServiceInfo> Services { get; }
}
