// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Input;
#endif

/// <summary>Matches the Windows RAWINPUTDEVICE layout at the native registration boundary.</summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly record struct NativeRawInputDevice
{
    /// <summary>The native 16-bit HID usage page.</summary>
    private readonly ushort _usagePage;

    /// <summary>The native 16-bit HID usage.</summary>
    private readonly ushort _usage;

    /// <summary>The native 32-bit registration flags.</summary>
    private readonly uint _flags;

    /// <summary>The native target window handle.</summary>
    private readonly nint _targetHwnd;

    /// <summary>Initializes a new instance of the <see cref="NativeRawInputDevice"/> struct.</summary>
    /// <param name="device">The managed raw-input registration.</param>
    internal NativeRawInputDevice(RawInputDevice device)
    {
        _usagePage = checked((ushort)device.UsagePage);
        _usage = device.Usage;
        _flags = (uint)device.Flags;
        _targetHwnd = device.ToIntPtr();
    }

    /// <summary>Gets the native HID usage page.</summary>
    internal ushort UsagePage => _usagePage;

    /// <summary>Gets the native HID usage.</summary>
    internal ushort Usage => _usage;

    /// <summary>Gets the native registration flags.</summary>
    internal uint Flags => _flags;

    /// <summary>Gets the native target window handle.</summary>
    internal nint TargetHwnd => _targetHwnd;
}
