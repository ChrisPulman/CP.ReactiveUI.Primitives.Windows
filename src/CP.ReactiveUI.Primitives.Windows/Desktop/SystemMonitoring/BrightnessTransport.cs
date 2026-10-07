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

/// <summary>The transport exposing a brightness control.</summary>
public enum BrightnessTransport
{
    /// <summary>The WMI internal panel provider.</summary>
    Wmi,

    /// <summary>The DDC/CI physical monitor provider.</summary>
    DdcCi,
}
