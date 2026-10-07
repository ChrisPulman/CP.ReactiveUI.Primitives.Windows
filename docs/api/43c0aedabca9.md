<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.#ctor](#api-0e7ebe5d1f73)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput)](#api-c414e341ac11)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.Equals(System.Object)](#api-3792e901efc7)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode)](#api-31ff0c057d48)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode,System.Nullable{System.UInt32})](#api-4a3f6c5dac51)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyPress(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode)](#api-430f4c64516c)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyPress(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode,System.Nullable{System.UInt32})](#api-25baf8fe722f)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode)](#api-7dfbbc67f91d)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode,System.Nullable{System.UInt32})](#api-29fb0596c357)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.GetHashCode](#api-2a4a11dc38dc)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ToString](#api-7a15670605eb)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput)](#api-3405918399ed)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput)](#api-9f9222c5dcab)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.KeyEventFlags](#api-d0fca8993c69)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ScanCode](#api-50e3b08ab028)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.Timestamp](#api-d591f6e1503b)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.VirtualKeyCode](#api-ec1ddd5cea34)

<a id="api-0e7ebe5d1f73"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.#ctor`

Creates the default KeyboardInput value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.KeyboardInput()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:15`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput();
    }
}
```

<a id="api-c414e341ac11"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput)`

Tests equality using the generated value-equality contract for KeyboardInput.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:15`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput`): The other supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput receiver, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput @other, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@other)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-3792e901efc7"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.Equals(System.Object)`

Tests equality using the generated value-equality contract for KeyboardInput.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:15`.

- `obj` (`object`): The obj supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput receiver, global::System.Object @obj, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@obj)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-31ff0c057d48"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode)`

Create a KeyboardInput for a key down.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode virtualKeyCode)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:85`.

- `virtualKeyCode` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode`): Value from VirtualKeyCodes.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode @virtualKeyCode, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.@ForKeyDown(@virtualKeyCode)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-4a3f6c5dac51"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode,System.Nullable{System.UInt32})`

Create a KeyboardInput for a key down.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode virtualKeyCode, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:91`.

- `virtualKeyCode` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode`): Value from VirtualKeyCodes.
- `timestamp` (`uint?`): The optional timestamp.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode @virtualKeyCode, global::System.UInt32? @timestamp, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.@ForKeyDown(@virtualKeyCode, @timestamp)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-430f4c64516c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyPress(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode)`

Create a KeyboardInput for a key press (up / down).

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput[] CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyPress(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode virtualKeyCode)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:70`.

- `virtualKeyCode` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode`): Value from VirtualKeyCodes.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode @virtualKeyCode, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput[]> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.@ForKeyPress(@virtualKeyCode)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-25baf8fe722f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyPress(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode,System.Nullable{System.UInt32})`

Create a KeyboardInput for a key press (up / down).

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput[] CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyPress(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode virtualKeyCode, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:76`.

- `virtualKeyCode` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode`): Value from VirtualKeyCodes.
- `timestamp` (`uint?`): The optional timestamp.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode @virtualKeyCode, global::System.UInt32? @timestamp, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput[]> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.@ForKeyPress(@virtualKeyCode, @timestamp)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-7dfbbc67f91d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode)`

Create a KeyboardInput for a key up.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode virtualKeyCode)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:100`.

- `virtualKeyCode` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode`): Value from VirtualKeyCodes.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode @virtualKeyCode, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.@ForKeyUp(@virtualKeyCode)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-29fb0596c357"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode,System.Nullable{System.UInt32})`

Create a KeyboardInput for a key up.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ForKeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode virtualKeyCode, uint? timestamp)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:106`.

- `virtualKeyCode` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode`): Value from VirtualKeyCodes.
- `timestamp` (`uint?`): The optional timestamp.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode @virtualKeyCode, global::System.UInt32? @timestamp, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.@ForKeyUp(@virtualKeyCode, @timestamp)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-2a4a11dc38dc"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.GetHashCode`

Computes a hash code consistent with the generated value-equality contract for KeyboardInput.

```csharp
public override int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput receiver, global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@GetHashCode()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-7a15670605eb"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ToString`

Formats the value using the generated KeyboardInput representation.

```csharp
public override string CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ToString()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput receiver, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToString()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-3405918399ed"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput)`

Tests whether both operands have equal component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.operator ==(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput left, CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-9f9222c5dcab"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput)`

Tests whether the operands have different component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.operator !=(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput left, CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-d0fca8993c69"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.KeyEventFlags`

Gets various aspects of a keystroke. This member can be certain combinations of the following values.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.KeyEventFlags CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.KeyEventFlags { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:59`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput receiver)
    {
        _ = receiver.@KeyEventFlags;
    }
}
```

<a id="api-50e3b08ab028"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ScanCode`

Gets a hardware scan code for the key. If KeyEventFlags specifies Unicode, ScanCode specifies a Unicode character which is to be sent to the foreground application.

```csharp
public ushort CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.ScanCode { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:56`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput receiver)
    {
        _ = receiver.@ScanCode;
    }
}
```

<a id="api-d591f6e1503b"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.Timestamp`

Gets the time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp.

```csharp
public uint CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.Timestamp { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:62`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput receiver)
    {
        _ = receiver.@Timestamp;
    }
}
```

<a id="api-ec1ddd5cea34"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.VirtualKeyCode`

Gets a virtual-key code. The code must be a value in the range 1 to 254. If the flags member specifies KEYEVENTF_UNICODE, wVk must be 0.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput.VirtualKeyCode { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/KeyboardInput.cs:50`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput receiver)
    {
        _ = receiver.@VirtualKeyCode;
    }
}
```
