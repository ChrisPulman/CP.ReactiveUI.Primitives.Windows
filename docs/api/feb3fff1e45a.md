<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.#ctor](#api-0d4477b1efe4)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.Equals(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse)](#api-036b10a4688f)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.Equals(System.Object)](#api-1dc582d55041)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.GetHashCode](#api-5e16fd964212)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.ToString](#api-0f863dcffe64)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.op_Equality(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse)](#api-e3cdf8d7be16)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.op_Inequality(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse)](#api-24a8582b69ea)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.ButtonState](#api-ef01a6ed71b2)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.State](#api-1bae5f6d0ef0)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.WheelData](#api-c8c0729d5706)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.X](#api-b000bdb39659)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.Y](#api-42bc20bba7f5)

<a id="api-0d4477b1efe4"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.#ctor`

Creates the default RawMouse value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.RawMouse()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse();
    }
}
```

<a id="api-036b10a4688f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.Equals(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse)`

Tests equality using the generated value-equality contract for RawMouse.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.Equals(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse`): The other supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse receiver, global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse @other, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@other)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1dc582d55041"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.Equals(System.Object)`

Tests equality using the generated value-equality contract for RawMouse.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

- `obj` (`object`): The obj supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse receiver, global::System.Object @obj, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@obj)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-5e16fd964212"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.GetHashCode`

Computes a hash code consistent with the generated value-equality contract for RawMouse.

```csharp
public override int CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse receiver, global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@GetHashCode()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-0f863dcffe64"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.ToString`

Formats the value using the generated RawMouse representation.

```csharp
public override string CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.ToString()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse receiver, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToString()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-e3cdf8d7be16"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.op_Equality(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse)`

Tests whether both operands have equal component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.operator ==(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse left, CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse @left, global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-24a8582b69ea"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.op_Inequality(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse)`

Tests whether the operands have different component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.operator !=(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse left, CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse @left, global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-ef01a6ed71b2"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.ButtonState`

Gets the button state.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.MouseButtonStates CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.ButtonState { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:53`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse receiver)
    {
        _ = receiver.@ButtonState;
    }
}
```

<a id="api-1bae5f6d0ef0"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.State`

Gets the mouse state.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.MouseStates CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.State { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:50`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse receiver)
    {
        _ = receiver.@State;
    }
}
```

<a id="api-c8c0729d5706"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.WheelData`

Gets if usButtonFlags is RI_MOUSE_WHEEL, this member is a signed value that specifies the wheel delta.

```csharp
public short CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.WheelData { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:56`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse receiver)
    {
        _ = receiver.@WheelData;
    }
}
```

<a id="api-b000bdb39659"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.X`

Gets the motion in the X direction. This is signed relative motion or absolute motion, depending on the value of usFlags.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.X { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:59`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse receiver)
    {
        _ = receiver.@X;
    }
}
```

<a id="api-42bc20bba7f5"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.Y`

Gets the motion in the Y direction. This is signed relative motion or absolute motion, depending on the value of usFlags.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse.Y { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:62`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse receiver)
    {
        _ = receiver.@Y;
    }
}
```
