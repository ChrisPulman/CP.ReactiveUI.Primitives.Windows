// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>The startup modes accepted by the Win32_Service ChangeStartMode method.</summary>
public enum ServiceStartMode
{
    /// <summary>A driver started by the operating system loader.</summary>
    Boot,
    /// <summary>A driver started during operating system initialization.</summary>
    System,
    /// <summary>A service started automatically during system startup.</summary>
    Automatic,
    /// <summary>A service started explicitly on demand.</summary>
    Manual,
    /// <summary>A service prevented from starting.</summary>
    Disabled,
}
