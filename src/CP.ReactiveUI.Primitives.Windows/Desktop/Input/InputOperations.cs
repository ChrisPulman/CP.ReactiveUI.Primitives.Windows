// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Operations;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Input;
#endif

/// <summary>Creates deferred input commands that run once when captured or subscribed.</summary>
public static class InputOperations
{
    /// <summary>Creates a deferred mouse click command at the current position.</summary>
    /// <param name="buttons">The mouse buttons.</param>
    /// <returns>The deferred command.</returns>
    public static WindowsOperation<uint> MouseClick(MouseButtons buttons) => MouseClick(buttons, null, null);

    /// <summary>Creates a deferred mouse click command at a position.</summary>
    /// <param name="buttons">The mouse buttons.</param>
    /// <param name="location">The position.</param>
    /// <returns>The deferred command.</returns>
    public static WindowsOperation<uint> MouseClick(MouseButtons buttons, NativePoint? location) => MouseClick(buttons, location, null);

    /// <summary>Creates a deferred mouse click command.</summary>
    /// <param name="buttons">The mouse buttons.</param>
    /// <param name="location">The optional position.</param>
    /// <param name="timestamp">The optional timestamp.</param>
    /// <returns>The command reporting the number of input records sent.</returns>
    public static WindowsOperation<uint> MouseClick(MouseButtons buttons, NativePoint? location, uint? timestamp) =>
        WindowsOperation.From(() => MouseInputGenerator.MouseClick(buttons, location, timestamp));

    /// <summary>Creates a deferred mouse-down command at the current position.</summary>
    /// <param name="buttons">The mouse buttons.</param>
    /// <returns>The deferred command.</returns>
    public static WindowsOperation<uint> MouseDown(MouseButtons buttons) => MouseDown(buttons, null, null);

    /// <summary>Creates a deferred mouse-down command at a position.</summary>
    /// <param name="buttons">The mouse buttons.</param>
    /// <param name="location">The position.</param>
    /// <returns>The deferred command.</returns>
    public static WindowsOperation<uint> MouseDown(MouseButtons buttons, NativePoint? location) => MouseDown(buttons, location, null);

    /// <summary>Creates a deferred mouse-down command.</summary>
    /// <param name="buttons">The mouse buttons.</param>
    /// <param name="location">The optional position.</param>
    /// <param name="timestamp">The optional timestamp.</param>
    /// <returns>The command reporting the number of input records sent.</returns>
    public static WindowsOperation<uint> MouseDown(MouseButtons buttons, NativePoint? location, uint? timestamp) =>
        WindowsOperation.From(() => MouseInputGenerator.MouseDown(buttons, location, timestamp));

    /// <summary>Creates a deferred mouse-up command at the current position.</summary>
    /// <param name="buttons">The mouse buttons.</param>
    /// <returns>The deferred command.</returns>
    public static WindowsOperation<uint> MouseUp(MouseButtons buttons) => MouseUp(buttons, null, null);

    /// <summary>Creates a deferred mouse-up command at a position.</summary>
    /// <param name="buttons">The mouse buttons.</param>
    /// <param name="location">The position.</param>
    /// <returns>The deferred command.</returns>
    public static WindowsOperation<uint> MouseUp(MouseButtons buttons, NativePoint? location) => MouseUp(buttons, location, null);

    /// <summary>Creates a deferred mouse-up command.</summary>
    /// <param name="buttons">The mouse buttons.</param>
    /// <param name="location">The optional position.</param>
    /// <param name="timestamp">The optional timestamp.</param>
    /// <returns>The command reporting the number of input records sent.</returns>
    public static WindowsOperation<uint> MouseUp(MouseButtons buttons, NativePoint? location, uint? timestamp) =>
        WindowsOperation.From(() => MouseInputGenerator.MouseUp(buttons, location, timestamp));

    /// <summary>Creates a deferred mouse movement command.</summary>
    /// <param name="location">The position.</param>
    /// <returns>The deferred command.</returns>
    public static WindowsOperation<uint> MoveMouse(NativePoint location) => MoveMouse(location, null);

    /// <summary>Creates a deferred mouse movement command.</summary>
    /// <param name="location">The position.</param>
    /// <param name="timestamp">The optional timestamp.</param>
    /// <returns>The command reporting the number of input records sent.</returns>
    public static WindowsOperation<uint> MoveMouse(NativePoint location, uint? timestamp) =>
        WindowsOperation.From(() => MouseInputGenerator.MoveMouse(location, timestamp));

    /// <summary>Creates a deferred mouse-wheel command at the current position.</summary>
    /// <param name="wheelDelta">The wheel delta.</param>
    /// <returns>The deferred command.</returns>
    public static WindowsOperation<uint> MoveMouseWheel(int wheelDelta) => MoveMouseWheel(wheelDelta, null, null);

    /// <summary>Creates a deferred mouse-wheel command at a position.</summary>
    /// <param name="wheelDelta">The wheel delta.</param>
    /// <param name="location">The position.</param>
    /// <returns>The deferred command.</returns>
    public static WindowsOperation<uint> MoveMouseWheel(int wheelDelta, NativePoint? location) => MoveMouseWheel(wheelDelta, location, null);

    /// <summary>Creates a deferred mouse-wheel command.</summary>
    /// <param name="wheelDelta">The wheel delta.</param>
    /// <param name="location">The optional position.</param>
    /// <param name="timestamp">The optional timestamp.</param>
    /// <returns>The command reporting the number of input records sent.</returns>
    public static WindowsOperation<uint> MoveMouseWheel(int wheelDelta, NativePoint? location, uint? timestamp) =>
        WindowsOperation.From(() => MouseInputGenerator.MoveMouseWheel(wheelDelta, location, timestamp));

    /// <summary>Creates a deferred key-down command.</summary>
    /// <param name="keys">The keys to press.</param>
    /// <returns>The command reporting the number of input records sent.</returns>
    public static WindowsOperation<uint> KeyDown(params VirtualKeyCode[] keys) => CreateKeyboardOperation(keys, KeyboardInputGenerator.KeyDown);

    /// <summary>Creates a deferred key-up command.</summary>
    /// <param name="keys">The keys to release.</param>
    /// <returns>The command reporting the number of input records sent.</returns>
    public static WindowsOperation<uint> KeyUp(params VirtualKeyCode[] keys) => CreateKeyboardOperation(keys, KeyboardInputGenerator.KeyUp);

    /// <summary>Creates a deferred sequence of key presses.</summary>
    /// <param name="keys">The keys to press and release in sequence.</param>
    /// <returns>The command reporting the number of input records sent.</returns>
    public static WindowsOperation<uint> KeyPresses(params VirtualKeyCode[] keys) => CreateKeyboardOperation(keys, KeyboardInputGenerator.KeyPresses);

    /// <summary>Creates a deferred key combination press.</summary>
    /// <param name="keys">The keys to press together and release.</param>
    /// <returns>The command reporting the number of input records sent.</returns>
    public static WindowsOperation<uint> KeyCombinationPress(params VirtualKeyCode[] keys) => CreateKeyboardOperation(keys, KeyboardInputGenerator.KeyCombinationPress);

    /// <summary>Creates a deferred snapshot of all raw input devices.</summary>
    /// <returns>The operation returning fully enumerated device information.</returns>
    public static WindowsOperation<RawInputDeviceInformation[]> GetAllDevices() =>
        WindowsOperation.From(static () =>
        {
            var devices = new List<RawInputDeviceInformation>();
            foreach (var device in RawInputApi.GetAllDevices())
            {
                devices.Add(device);
            }

            return devices.ToArray();
        });

    /// <summary>Creates a deferred raw input device query.</summary>
    /// <param name="handle">The device handle.</param>
    /// <returns>The operation returning the device information.</returns>
    public static WindowsOperation<RawInputDeviceInformation> GetDeviceInformation(IntPtr handle) =>
        WindowsOperation.From(() => RawInputApi.GetDeviceInformation(handle));

    /// <summary>Creates a keyboard command from a stable snapshot of its keys.</summary>
    /// <param name="keys">The keys to copy.</param>
    /// <param name="command">The immediate input command.</param>
    /// <returns>The deferred command.</returns>
    private static WindowsOperation<uint> CreateKeyboardOperation(VirtualKeyCode[] keys, Func<VirtualKeyCode[], uint> command)
    {
        Throw.IfNull(keys, nameof(keys));
        var snapshot = (VirtualKeyCode[])keys.Clone();
        return WindowsOperation.From(() => command(snapshot));
    }
}
