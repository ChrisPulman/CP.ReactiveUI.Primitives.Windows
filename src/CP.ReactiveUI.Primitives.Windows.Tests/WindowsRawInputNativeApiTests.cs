// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies native raw-input registration layout and managed descriptor conversion.</summary>
public sealed class WindowsRawInputNativeApiTests
{
    /// <summary>The number of bytes occupied by usage page, usage, and flags before the native handle.</summary>
    private const int NativeHandleOffset = 8;

    /// <summary>The byte offset of the 16-bit usage field.</summary>
    private const int NativeUsageOffset = 2;

    /// <summary>The byte offset of the 32-bit registration flags.</summary>
    private const int NativeFlagsOffset = 4;

    /// <summary>The synthetic message-window handle used by conversion assertions.</summary>
    private static readonly IntPtr WindowHandle = new(42);

    /// <summary>Matches Win32 RAWINPUTDEVICE field widths, offsets, and architecture-dependent size.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task RegistrationLayout_MatchesWindowsAbiAsync()
    {
        await Assert.That(Marshal.SizeOf<NativeRawInputDevice>()).IsEqualTo(NativeHandleOffset + IntPtr.Size);
        await Assert.That(Marshal.OffsetOf<NativeRawInputDevice>("_usagePage").ToInt32()).IsEqualTo(0);
        await Assert.That(Marshal.OffsetOf<NativeRawInputDevice>("_usage").ToInt32()).IsEqualTo(NativeUsageOffset);
        await Assert.That(Marshal.OffsetOf<NativeRawInputDevice>("_flags").ToInt32()).IsEqualTo(NativeFlagsOffset);
        await Assert.That(Marshal.OffsetOf<NativeRawInputDevice>("_targetHwnd").ToInt32()).IsEqualTo(NativeHandleOffset);
    }

    /// <summary>Maps managed registration values without changing the public managed descriptor layout.</summary>
    /// <param name="deviceType">The managed device usage to convert.</param>
    /// <returns>The assertion task.</returns>
    [Test]
    [Arguments(RawInputDevices.Keyboard)]
    [Arguments(RawInputDevices.ConsumerAudioControl)]
    public async Task RegistrationConversion_PreservesDeviceFieldsAsync(RawInputDevices deviceType)
    {
        var managed = RawInputApi.CreateRawInputDevice(WindowHandle, deviceType, RawInputDeviceFlags.InputSink | RawInputDeviceFlags.DeviceNotify);
        var native = new NativeRawInputDevice(managed);
        await Assert.That(native.UsagePage).IsEqualTo((ushort)managed.UsagePage);
        await Assert.That(native.Usage).IsEqualTo(managed.Usage);
        await Assert.That(native.Flags).IsEqualTo((uint)managed.Flags);
        await Assert.That(native.TargetHwnd).IsEqualTo(managed.ToIntPtr());
        await Assert.That(Marshal.SizeOf<RawInputDevice>()).IsGreaterThan(Marshal.SizeOf<NativeRawInputDevice>());
    }
}
