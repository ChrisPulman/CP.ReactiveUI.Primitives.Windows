<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.GetAllDevices](#api-c631b36ae613)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.GetDeviceInformation(System.IntPtr)](#api-a48c360900a8)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.GetDeviceInformation(System.IntPtr)](#api-6dc2b042bbbe)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyCombinationPress(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[])](#api-27d2e3db757b)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[])](#api-e2fd248ac70e)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyPresses(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[])](#api-02b1a5b3abc5)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[])](#api-9308130757bb)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseClick(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons)](#api-9e6f50baa586)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseClick(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})](#api-2296cae4e98a)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseClick(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})](#api-1e0a3b834fd5)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons)](#api-a3e66347a98b)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})](#api-a30484564977)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})](#api-bd979ae858e0)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons)](#api-f10604af4a92)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})](#api-e38b8e240533)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})](#api-c150cd322c27)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouse(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint)](#api-20df61704ae5)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouse(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint,System.Nullable{System.UInt32})](#api-d3dfdf4ce19a)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouseWheel(System.Int32)](#api-3e2f4c87ca30)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouseWheel(System.Int32,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})](#api-f3cb42dbb3e6)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouseWheel(System.Int32,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})](#api-ca0702d26b09)

<a id="api-c631b36ae613"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.GetAllDevices`

Creates a deferred snapshot of all raw input devices.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceInformation[]> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.GetAllDevices()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:126`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceInformation[]> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@GetAllDevices()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-a48c360900a8"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.GetDeviceInformation(System.IntPtr)`

Creates a deferred raw input device query.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceInformation> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.GetDeviceInformation(System.IntPtr handle)
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:141`.

- `handle` (`System.IntPtr`): The device handle.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IntPtr @handle, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceInformation> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@GetDeviceInformation(@handle)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-6dc2b042bbbe"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.GetDeviceInformation(System.IntPtr)`

Creates a deferred raw input device query.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceInformation> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.GetDeviceInformation(nint handle)
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:141`.

- `handle` (`nint`): The device handle.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(nint @handle, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceInformation> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@GetDeviceInformation(@handle)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-27d2e3db757b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyCombinationPress(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[])`

Creates a deferred key combination press.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyCombinationPress(params CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[] keys)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:122`.

- `keys` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[]`): The keys to press together and release.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[] @keys, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@KeyCombinationPress(@keys)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-e2fd248ac70e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[])`

Creates a deferred key-down command.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyDown(params CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[] keys)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:107`.

- `keys` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[]`): The keys to press.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[] @keys, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@KeyDown(@keys)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-02b1a5b3abc5"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyPresses(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[])`

Creates a deferred sequence of key presses.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyPresses(params CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[] keys)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:117`.

- `keys` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[]`): The keys to press and release in sequence.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[] @keys, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@KeyPresses(@keys)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-9308130757bb"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[])`

Creates a deferred key-up command.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.KeyUp(params CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[] keys)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:112`.

- `keys` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[]`): The keys to release.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode[] @keys, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@KeyUp(@keys)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-9e6f50baa586"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseClick(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons)`

Creates a deferred mouse click command at the current position.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseClick(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons buttons)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:19`.

- `buttons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): The mouse buttons.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @buttons, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MouseClick(@buttons)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-2296cae4e98a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseClick(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})`

Creates a deferred mouse click command at a position.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseClick(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons buttons, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:25`.

- `buttons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): The mouse buttons.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): The position.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @buttons, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MouseClick(@buttons, @location)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1e0a3b834fd5"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseClick(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})`

Creates a deferred mouse click command.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseClick(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons buttons, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:32`.

- `buttons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): The mouse buttons.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): The optional position.
- `timestamp` (`uint?`): The optional timestamp.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @buttons, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.UInt32? @timestamp, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MouseClick(@buttons, @location, @timestamp)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-a3e66347a98b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons)`

Creates a deferred mouse-down command at the current position.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons buttons)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:38`.

- `buttons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): The mouse buttons.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @buttons, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MouseDown(@buttons)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-a30484564977"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})`

Creates a deferred mouse-down command at a position.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons buttons, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:44`.

- `buttons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): The mouse buttons.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): The position.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @buttons, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MouseDown(@buttons, @location)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-bd979ae858e0"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})`

Creates a deferred mouse-down command.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons buttons, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:51`.

- `buttons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): The mouse buttons.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): The optional position.
- `timestamp` (`uint?`): The optional timestamp.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @buttons, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.UInt32? @timestamp, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MouseDown(@buttons, @location, @timestamp)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-f10604af4a92"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons)`

Creates a deferred mouse-up command at the current position.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons buttons)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:57`.

- `buttons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): The mouse buttons.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @buttons, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MouseUp(@buttons)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-e38b8e240533"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})`

Creates a deferred mouse-up command at a position.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons buttons, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:63`.

- `buttons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): The mouse buttons.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): The position.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @buttons, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MouseUp(@buttons, @location)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-c150cd322c27"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})`

Creates a deferred mouse-up command.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons buttons, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:70`.

- `buttons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): The mouse buttons.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): The optional position.
- `timestamp` (`uint?`): The optional timestamp.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @buttons, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.UInt32? @timestamp, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MouseUp(@buttons, @location, @timestamp)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-20df61704ae5"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouse(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint)`

Creates a deferred mouse movement command.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouse(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint location)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:76`.

- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint`): The position.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint @location, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MoveMouse(@location)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d3dfdf4ce19a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouse(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint,System.Nullable{System.UInt32})`

Creates a deferred mouse movement command.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouse(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint location, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:82`.

- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint`): The position.
- `timestamp` (`uint?`): The optional timestamp.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint @location, global::System.UInt32? @timestamp, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MoveMouse(@location, @timestamp)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-3e2f4c87ca30"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouseWheel(System.Int32)`

Creates a deferred mouse-wheel command at the current position.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouseWheel(int wheelDelta)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:88`.

- `wheelDelta` (`int`): The wheel delta.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Int32 @wheelDelta, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MoveMouseWheel(@wheelDelta)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-f3cb42dbb3e6"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouseWheel(System.Int32,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})`

Creates a deferred mouse-wheel command at a position.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouseWheel(int wheelDelta, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:94`.

- `wheelDelta` (`int`): The wheel delta.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): The position.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Int32 @wheelDelta, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MoveMouseWheel(@wheelDelta, @location)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-ca0702d26b09"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouseWheel(System.Int32,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})`

Creates a deferred mouse-wheel command.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.MoveMouseWheel(int wheelDelta, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/InputOperations.cs:101`.

- `wheelDelta` (`int`): The wheel delta.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): The optional position.
- `timestamp` (`uint?`): The optional timestamp.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Int32 @wheelDelta, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.UInt32? @timestamp, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations.@MoveMouseWheel(@wheelDelta, @location, @timestamp)).Observe().Subscribe(operationObserver);
    }
}
```
