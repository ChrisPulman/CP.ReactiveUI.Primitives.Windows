// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Supplies readings from an already configured vendor provider without requiring inheritance.</summary>
public interface IThermalSensorProvider
{
    /// <summary>Captures current vendor sensor readings. Implementations own and manage any native resources.</summary>
    /// <returns>Temperatures, power or fan readings with explicit units and availability.</returns>
    IReadOnlyList<ThermalSensorSample> Capture();
}
