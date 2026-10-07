// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Provides BrightnessMonitorHandle operations.</summary>
internal sealed class BrightnessMonitorHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    /// <summary>Initializes a new instance of the <see cref = "BrightnessMonitorHandle"/> class.</summary>
    /// <param name="value">The native value.</param>
    internal BrightnessMonitorHandle(IntPtr value)
        : base(true) => SetHandle(value);

    /// <summary>Provides ReleaseHandle operations.</summary>
    /// <returns>The operation result.</returns>
    protected override bool ReleaseHandle() => BrightnessNativeMethods.NativeMethods.DestroyPhysicalMonitor(handle) != 0;
}
