<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.#ctor](#api-afacca375432)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse)](#api-6071046db4cf)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.Equals(System.Object)](#api-d1292030e2c1)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.GetHashCode](#api-1509cea8f349)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.ToString](#api-78f4f419f988)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse)](#api-32eb2a9ce6a4)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse)](#api-0a27e9789758)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.ButtonState](#api-c83ca520c088)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.State](#api-8a931173fc38)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.WheelData](#api-a75334ee827b)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.X](#api-90420f5c9cbf)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.Y](#api-5e2968c11912)

<a id="api-afacca375432"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.#ctor`

Creates the default RawMouse value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.RawMouse()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse();
    }
}
```

<a id="api-6071046db4cf"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse)`

Tests equality using the generated value-equality contract for RawMouse.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse`): The other supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse receiver, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse @other, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@other)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d1292030e2c1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.Equals(System.Object)`

Tests equality using the generated value-equality contract for RawMouse.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

- `obj` (`object`): The obj supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse receiver, global::System.Object @obj, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@obj)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1509cea8f349"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.GetHashCode`

Computes a hash code consistent with the generated value-equality contract for RawMouse.

```csharp
public override int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse receiver, global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@GetHashCode()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-78f4f419f988"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.ToString`

Formats the value using the generated RawMouse representation.

```csharp
public override string CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.ToString()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse receiver, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToString()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-32eb2a9ce6a4"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse)`

Tests whether both operands have equal component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.operator ==(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse left, CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-0a27e9789758"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse)`

Tests whether the operands have different component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.operator !=(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse left, CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-c83ca520c088"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.ButtonState`

Gets the button state.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtonStates CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.ButtonState { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:53`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse receiver)
    {
        _ = receiver.@ButtonState;
    }
}
```

<a id="api-8a931173fc38"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.State`

Gets the mouse state.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseStates CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.State { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:50`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse receiver)
    {
        _ = receiver.@State;
    }
}
```

<a id="api-a75334ee827b"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.WheelData`

Gets if usButtonFlags is RI_MOUSE_WHEEL, this member is a signed value that specifies the wheel delta.

```csharp
public short CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.WheelData { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:56`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse receiver)
    {
        _ = receiver.@WheelData;
    }
}
```

<a id="api-90420f5c9cbf"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.X`

Gets the motion in the X direction. This is signed relative motion or absolute motion, depending on the value of usFlags.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.X { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:59`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse receiver)
    {
        _ = receiver.@X;
    }
}
```

<a id="api-5e2968c11912"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.Y`

Gets the motion in the Y direction. This is signed relative motion or absolute motion, depending on the value of usFlags.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse.Y { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawMouse.cs:62`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse receiver)
    {
        _ = receiver.@Y;
    }
}
```
