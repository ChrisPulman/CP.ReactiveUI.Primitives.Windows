// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Selects the providers sampled by a system monitor.</summary>
[Flags]
public enum MonitoringSections
{
    /// <summary>No providers.</summary>
    None = 0,

    /// <summary>Processor utilization and frequency.</summary>
    Cpu = 1,

    /// <summary>Memory and system object counts.</summary>
    Memory = 2,

    /// <summary>Process statistics.</summary>
    Processes = 4,

    /// <summary>Network interfaces and transfer rates.</summary>
    Network = 8,

    /// <summary>Volume capacity and physical disk performance.</summary>
    Storage = 16,

    /// <summary>GPU adapters, engines, and memory.</summary>
    Graphics = 32,

    /// <summary>Battery and power plan state.</summary>
    Power = 64,

    /// <summary>Hardware and operating-system inventory.</summary>
    Hardware = 128,

    /// <summary>Firmware thermal zones.</summary>
    Thermals = 256,

    /// <summary>Windows service inventory.</summary>
    Services = 512,

    /// <summary>All built-in providers.</summary>
    All = Cpu | Memory | Processes | Network | Storage | Graphics | Power | Hardware | Thermals | Services,
}
