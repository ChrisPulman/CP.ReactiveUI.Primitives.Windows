// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Initializes or reads GraphicsSampler state.</summary>
internal sealed class GraphicsSampler : ISystemSampler<GraphicsSnapshot>
{
    /// <summary>Refresh period for adapter inventory.</summary>
    private const int InventoryCacheMinutes = 5;

    /// <summary>Initializes or reads query state.</summary>
    private static readonly string[] CounterPaths =
    [
        @"\GPU Engine(*)\Utilization Percentage",
        @"\GPU Adapter Memory(*)\Dedicated Usage",
        @"\GPU Adapter Memory(*)\Shared Usage",
        @"\GPU Process Memory(*)\Dedicated Usage",
        @"\GPU Process Memory(*)\Shared Usage",
    ];

    /// <summary>Initializes or reads inventory state.</summary>
    /// <summary>Owns the persistent GPU counter query.</summary>
    private readonly PerformanceCounterQuery _query = new(CounterPaths);

    /// <summary>Reads or manages GraphicsSampler state.</summary>
    private WmiQueryResult? _inventory;

    /// <summary>Initializes or reads refreshAfter state.</summary>
    private DateTimeOffset _refreshAfter;

    /// <summary>Initializes or reads Capture state.</summary>
    /// <returns>The captured or projected value.</returns>
    public GraphicsSnapshot Capture()
    {
        var now = TimeProvider.System.GetUtcNow();
        if (_inventory is null || now >= _refreshAfter)
        {
            _inventory = WindowsManagement.Query(@"root\cimv2", "SELECT * FROM Win32_VideoController");
            _refreshAfter = now.AddMinutes(InventoryCacheMinutes);
        }

        return new(_inventory, _query.Capture());
    }

    /// <summary>Initializes or reads Dispose state.</summary>
    public void Dispose() => _query.Dispose();
}
