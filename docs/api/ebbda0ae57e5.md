<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.#ctor](#api-a632ec15877f)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard)](#api-92c5cf963b02)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.Equals(System.Object)](#api-c4b2f0657405)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.GetHashCode](#api-c15f665e1702)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.ToString](#api-c85fc572ea45)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard)](#api-9b9d3b950ddb)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard)](#api-2b925ba910c7)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.KeyboardMode](#api-beb5fa8f9215)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.NumberOfFunctionKeys](#api-35120dd83ef7)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.NumberOfIndicators](#api-866e336e1d75)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.NumberOfKeysTotal](#api-aa3ffadd07fb)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.SubType](#api-348d5aa2129b)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.Type](#api-6f1f9d8a647a)

<a id="api-a632ec15877f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.#ctor`

Creates the default RawInputDeviceInfoKeyboard value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.RawInputDeviceInfoKeyboard()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:16`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard();
    }
}
```

<a id="api-92c5cf963b02"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard)`

Tests equality using the generated value-equality contract for RawInputDeviceInfoKeyboard.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:16`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard`): The other supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard receiver, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard @other, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@other)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-c4b2f0657405"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.Equals(System.Object)`

Tests equality using the generated value-equality contract for RawInputDeviceInfoKeyboard.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:16`.

- `obj` (`object`): The obj supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard receiver, global::System.Object @obj, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@obj)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-c15f665e1702"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.GetHashCode`

Computes a hash code consistent with the generated value-equality contract for RawInputDeviceInfoKeyboard.

```csharp
public override int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:16`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard receiver, global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@GetHashCode()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-c85fc572ea45"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.ToString`

Formats the value using the generated RawInputDeviceInfoKeyboard representation.

```csharp
public override string CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.ToString()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:16`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard receiver, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToString()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-9b9d3b950ddb"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard)`

Tests whether both operands have equal component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.operator ==(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard left, CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:16`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-2b925ba910c7"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard)`

Tests whether the operands have different component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.operator !=(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard left, CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:16`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-beb5fa8f9215"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.KeyboardMode`

Gets the scan code mode.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.KeyboardMode { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:25`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard receiver)
    {
        _ = receiver.@KeyboardMode;
    }
}
```

<a id="api-35120dd83ef7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.NumberOfFunctionKeys`

Gets the number of function keys on the keyboard.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.NumberOfFunctionKeys { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:28`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard receiver)
    {
        _ = receiver.@NumberOfFunctionKeys;
    }
}
```

<a id="api-866e336e1d75"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.NumberOfIndicators`

Gets the number of LED indicators on the keyboard.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.NumberOfIndicators { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:31`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard receiver)
    {
        _ = receiver.@NumberOfIndicators;
    }
}
```

<a id="api-aa3ffadd07fb"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.NumberOfKeysTotal`

Gets the total number of keys on the keyboard.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.NumberOfKeysTotal { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:34`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard receiver)
    {
        _ = receiver.@NumberOfKeysTotal;
    }
}
```

<a id="api-348d5aa2129b"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.SubType`

Gets the subtype of the keyboard.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.SubType { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:22`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard receiver)
    {
        _ = receiver.@SubType;
    }
}
```

<a id="api-6f1f9d8a647a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.Type`

Gets the type of the keyboard.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard.Type { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceInfoKeyboard.cs:19`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard receiver)
    {
        _ = receiver.@Type;
    }
}
```
