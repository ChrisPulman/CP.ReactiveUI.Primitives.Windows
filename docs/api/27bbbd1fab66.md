<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.#ctor](#api-1086e7b08598)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList)](#api-2556ca841aed)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.Equals(System.Object)](#api-29064bbc3581)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.GetHashCode](#api-63b0a60e5819)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.ToIntPtr](#api-ce42d30c3c45)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.ToIntPtr](#api-1994f3ae9d45)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.ToString](#api-bf7670208a57)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList)](#api-03c16b0dc1ac)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList)](#api-dad6fa1194f8)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.RawInputDeviceType](#api-cca904a58542)

<a id="api-1086e7b08598"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.#ctor`

Creates the default RawInputDeviceList value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.RawInputDeviceList()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceList.cs:15`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList();
    }
}
```

<a id="api-2556ca841aed"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList)`

Tests equality using the generated value-equality contract for RawInputDeviceList.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceList.cs:15`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList`): The other supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList receiver, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList @other, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@other)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-29064bbc3581"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.Equals(System.Object)`

Tests equality using the generated value-equality contract for RawInputDeviceList.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceList.cs:15`.

- `obj` (`object`): The obj supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList receiver, global::System.Object @obj, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@obj)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-63b0a60e5819"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.GetHashCode`

Computes a hash code consistent with the generated value-equality contract for RawInputDeviceList.

```csharp
public override int CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceList.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList receiver, global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@GetHashCode()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-ce42d30c3c45"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.ToIntPtr`

Returns the raw input device handle.

```csharp
public System.IntPtr CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.ToIntPtr()
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceList.cs:40`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList receiver, global::System.IObserver<global::System.IntPtr> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToIntPtr()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1994f3ae9d45"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.ToIntPtr`

Returns the raw input device handle.

```csharp
public nint CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.ToIntPtr()
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceList.cs:40`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList receiver, global::System.IObserver<nint> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToIntPtr()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-bf7670208a57"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.ToString`

Formats the value using the generated RawInputDeviceList representation.

```csharp
public override string CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.ToString()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceList.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList receiver, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToString()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-03c16b0dc1ac"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList)`

Tests whether both operands have equal component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.operator ==(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList left, CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceList.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-dad6fa1194f8"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList,CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList)`

Tests whether the operands have different component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.operator !=(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList left, CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceList.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-cca904a58542"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.RawInputDeviceType`

Gets the type of device.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDeviceTypes CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList.RawInputDeviceType { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Structs/RawInputDeviceList.cs:33`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList receiver)
    {
        _ = receiver.@RawInputDeviceType;
    }
}
```
