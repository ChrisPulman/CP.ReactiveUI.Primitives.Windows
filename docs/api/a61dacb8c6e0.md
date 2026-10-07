<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.#ctor](#api-eed5f813d5f2)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput)](#api-7001e5a56dad)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Equals(System.Object)](#api-e635a60eb7db)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.GetHashCode](#api-1b5e040bbfab)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons)](#api-03789cf8a523)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})](#api-24cebd887ce5)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})](#api-5b059acf2cf3)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseMove(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint)](#api-613a40f7c130)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseMove(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint,System.Nullable{System.UInt32})](#api-1b121c253e54)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons)](#api-c1ddb1df7165)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})](#api-dada56a20917)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})](#api-a69bb1027125)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MoveMouseWheel(System.Int32)](#api-077629c47ec9)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MoveMouseWheel(System.Int32,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})](#api-a8a82af91b0f)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MoveMouseWheel(System.Int32,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})](#api-4905903f2031)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.ToString](#api-85cc8ecadbc3)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput)](#api-8ba8b43a02f2)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput)](#api-875877fef32b)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Dx](#api-17a67122d98d)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Dy](#api-d4f87457cc5f)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseData](#api-512eb77d5aef)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseEventFlags](#api-b6938e2bdffa)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Timestamp](#api-d27cfbd699be)

<a id="api-eed5f813d5f2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.#ctor`

Creates the default MouseInput value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseInput()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:15`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput();
    }
}
```

<a id="api-7001e5a56dad"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput)`

Tests equality using the generated value-equality contract for MouseInput.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:15`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput`): The other supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput receiver, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput @other, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@other)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-e635a60eb7db"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Equals(System.Object)`

Tests equality using the generated value-equality contract for MouseInput.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:15`.

- `obj` (`object`): The obj supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput receiver, global::System.Object @obj, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@obj)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1b5e040bbfab"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.GetHashCode`

Computes a hash code consistent with the generated value-equality contract for MouseInput.

```csharp
public override int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput receiver, global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@GetHashCode()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-03789cf8a523"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons)`

Create a MouseInput struct for a mouse button down.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons mouseButtons)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:139`.

- `mouseButtons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): MouseButtons to specify which mouse buttons.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @mouseButtons, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MouseDown(@mouseButtons)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-24cebd887ce5"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})`

Create a MouseInput struct for a mouse button down at a specific location.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons mouseButtons, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:145`.

- `mouseButtons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): MouseButtons to specify which mouse buttons.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): Where is the click located.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @mouseButtons, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MouseDown(@mouseButtons, @location)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-5b059acf2cf3"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})`

Create a MouseInput struct for a mouse button down.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons mouseButtons, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:152`.

- `mouseButtons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): MouseButtons to specify which mouse buttons.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): Where is the click located.
- `timestamp` (`uint?`): The time stamp for the event.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @mouseButtons, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.UInt32? @timestamp, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MouseDown(@mouseButtons, @location, @timestamp)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-613a40f7c130"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseMove(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint)`

Create a MouseInput struct for a mouse move.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseMove(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint location)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:123`.

- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint`): Where is the click located.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint @location, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MouseMove(@location)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1b121c253e54"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseMove(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint,System.Nullable{System.UInt32})`

Create a MouseInput struct for a mouse move.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseMove(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint location, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:129`.

- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint`): Where is the click located.
- `timestamp` (`uint?`): The time stamp for the event.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint @location, global::System.UInt32? @timestamp, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MouseMove(@location, @timestamp)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-c1ddb1df7165"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons)`

Create a MouseInput struct for a mouse button up.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons mouseButtons)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:164`.

- `mouseButtons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): MouseButtons to specify which mouse buttons.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @mouseButtons, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MouseUp(@mouseButtons)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-dada56a20917"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})`

Create a MouseInput struct for a mouse button up at a specific location.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons mouseButtons, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:170`.

- `mouseButtons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): MouseButtons to specify which mouse buttons.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): Where is the click located.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @mouseButtons, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MouseUp(@mouseButtons, @location)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-a69bb1027125"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})`

Create a MouseInput struct for a mouse button up.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons mouseButtons, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:177`.

- `mouseButtons` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons`): MouseButtons to specify which mouse buttons.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): Where is the click located.
- `timestamp` (`uint?`): The time stamp for the event.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons @mouseButtons, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.UInt32? @timestamp, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MouseUp(@mouseButtons, @location, @timestamp)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-077629c47ec9"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MoveMouseWheel(System.Int32)`

Create a MouseInput struct for a wheel move.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MoveMouseWheel(int wheelDelta)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:99`.

- `wheelDelta` (`int`): How much does the wheel move.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Int32 @wheelDelta, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MoveMouseWheel(@wheelDelta)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-a8a82af91b0f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MoveMouseWheel(System.Int32,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint})`

Create a MouseInput struct for a wheel move at a specific location.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MoveMouseWheel(int wheelDelta, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:105`.

- `wheelDelta` (`int`): How much does the wheel move.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): Location of the event.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Int32 @wheelDelta, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MoveMouseWheel(@wheelDelta, @location)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-4905903f2031"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MoveMouseWheel(System.Int32,System.Nullable{CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint},System.Nullable{System.UInt32})`

Create a MouseInput struct for a wheel move.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MoveMouseWheel(int wheelDelta, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? location, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:112`.

- `wheelDelta` (`int`): How much does the wheel move.
- `location` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint?`): Location of the event.
- `timestamp` (`uint?`): The time stamp for the event.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Int32 @wheelDelta, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint? @location, global::System.UInt32? @timestamp, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.@MoveMouseWheel(@wheelDelta, @location, @timestamp)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-85cc8ecadbc3"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.ToString`

Formats the value using the generated MouseInput representation.

```csharp
public override string CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.ToString()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput receiver, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToString()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-8ba8b43a02f2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput)`

Tests whether both operands have equal component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.operator ==(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput left, CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-875877fef32b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput)`

Tests whether the operands have different component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.operator !=(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput left, CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-17a67122d98d"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Dx`

Gets the x coordinate or movement delta.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Dx { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:79`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput receiver)
    {
        _ = receiver.@Dx;
    }
}
```

<a id="api-d4f87457cc5f"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Dy`

Gets the y coordinate or movement delta.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Dy { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:82`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput receiver)
    {
        _ = receiver.@Dy;
    }
}
```

<a id="api-512eb77d5aef"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseData`

Gets the mouse button or wheel data.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseData { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:85`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput receiver)
    {
        _ = receiver.@MouseData;
    }
}
```

<a id="api-b6938e2bdffa"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseEventFlags`

Gets the mouse event flags.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseEventFlags CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.MouseEventFlags { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:88`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput receiver)
    {
        _ = receiver.@MouseEventFlags;
    }
}
```

<a id="api-d27cfbd699be"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Timestamp`

Gets the mouse event timestamp.

```csharp
public uint CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput.Timestamp { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/MouseInput.cs:91`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput receiver)
    {
        _ = receiver.@Timestamp;
    }
}
```
