// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>GPU inventory and engine/memory counters. WMI adapter indices are never used to infer LUID identity.</summary>
public sealed class GraphicsSnapshot
{
    /// <summary>Initializes a new instance of the <see cref="GraphicsSnapshot"/> class.</summary>
    /// <param name="inventory">The inventory value.</param>
    /// <param name="counters">The counters value.</param>
    internal GraphicsSnapshot(WmiQueryResult inventory, IReadOnlyList<PerformanceCounterSample> counters)
    {
        Timestamp = TimeProvider.System.GetUtcNow();
        Inventory = inventory;
        Adapters = WmiProjection.Project(inventory, static row => new GraphicsAdapter(row));
        var instances = new List<GraphicsEngineSample>(counters.Count);
        foreach (var counter in counters)
        {
            instances.Add(new(counter));
        }

        Counters = instances.AsReadOnly();
    }

    /// <summary>Gets UTC capture time.</summary>
    public DateTimeOffset Timestamp { get; }

    /// <summary>Gets WMI adapter query availability.</summary>
    public WmiQueryResult Inventory { get; }

    /// <summary>Gets WMI adapter inventory. AdapterRAM can be inaccurate, especially above four GiB.</summary>
    public IReadOnlyList<GraphicsAdapter> Adapters { get; }

    /// <summary>Gets per engine utilization percentages and dedicated/shared memory byte counters, including raw identity and PDH status.</summary>
    public IReadOnlyList<GraphicsEngineSample> Counters { get; }
}
