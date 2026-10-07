// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Apps;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Apps;
#endif
/// <summary>COM contract used on Windows 8 and later to inspect Windows Store app visibility.</summary>
#if NET
[GeneratedComInterface]
[Guid("2246EA2D-CAEA-4444-A3C4-6DE827E44313")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal partial interface IAppVisibility
#else
[ComImport]
[Guid("2246EA2D-CAEA-4444-A3C4-6DE827E44313")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IAppVisibility
#endif
{
    /// <summary>Gets app visibility on the supplied monitor.</summary>
    /// <param name="monitorHandle">Monitor handle to inspect.</param>
    /// <param name="visibility">The monitor app visibility state.</param>
    /// <returns>The native HRESULT.</returns>
    [PreserveSig]
    int GetAppVisibilityOnMonitor(IntPtr monitorHandle, out MonitorAppVisibility visibility);

    /// <summary>Gets a value indicating whether the app launcher is visible.</summary>
    /// <param name="isVisible">Whether the launcher is visible.</param>
    /// <returns>The native HRESULT.</returns>
    [PreserveSig]
    int IsLauncherVisible([MarshalAs(UnmanagedType.Bool)] out bool isVisible);
}
