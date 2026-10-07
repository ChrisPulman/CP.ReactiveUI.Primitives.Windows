<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.#ctor](#api-c8ee5edc4048)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind)](#api-b3f28645990e)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.Equals(System.Object)](#api-6bc371927279)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.GetHashCode](#api-63f7a565d858)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.SetBlurRegion(System.IntPtr)](#api-31112f29662d)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.SetBlurRegion(System.IntPtr)](#api-3c47fe0f35a2)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind,CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind)](#api-b41804257652)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind,CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind)](#api-ac7a1af14d2c)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.Enable](#api-339dabfca680)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.TransitionOnMaximized](#api-55dfbff29a0c)

<a id="api-c8ee5edc4048"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.#ctor`

Creates the default DwmBlurBehind value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.DwmBlurBehind()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Composition/Structs/DwmBlurBehind.cs:16`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind();
    }
}
```

<a id="api-b3f28645990e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind)`

Indicates whether the current object is equal to another object of the same type.

```csharp
public readonly bool CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Composition/Structs/DwmBlurBehind.cs:76`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind`): An object to compare with this object.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind receiver, global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind @other, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@other)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-6bc371927279"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.Equals(System.Object)`

Indicates whether this instance and a specified object are equal.

```csharp
public override readonly bool CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Composition/Structs/DwmBlurBehind.cs:73`.

- `obj` (`object`): The object to compare with the current instance.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind receiver, global::System.Object @obj, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@obj)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-63f7a565d858"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.GetHashCode`

Returns the hash code for this instance.

```csharp
public override readonly int CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Composition/Structs/DwmBlurBehind.cs:83`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind receiver, global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@GetHashCode()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-31112f29662d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.SetBlurRegion(System.IntPtr)`

Sets the client-area region where blur behind is applied.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.SetBlurRegion(System.IntPtr blurRegion)
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Composition/Structs/DwmBlurBehind.cs:66`.

- `blurRegion` (`System.IntPtr`): The native blur region handle.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind receiver, global::System.IntPtr @blurRegion, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@SetBlurRegion(@blurRegion)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-3c47fe0f35a2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.SetBlurRegion(System.IntPtr)`

Sets the client-area region where blur behind is applied.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.SetBlurRegion(nint blurRegion)
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Composition/Structs/DwmBlurBehind.cs:66`.

- `blurRegion` (`nint`): The native blur region handle.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind receiver, nint @blurRegion, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@SetBlurRegion(@blurRegion)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-b41804257652"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind,CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind)`

Determines whether two values are equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.operator ==(CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind left, CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Composition/Structs/DwmBlurBehind.cs:56`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind`): The first value.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind`): The second value.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-ac7a1af14d2c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind,CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind)`

Determines whether two values are not equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.operator !=(CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind left, CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Composition/Structs/DwmBlurBehind.cs:62`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind`): The first value.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind`): The second value.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-339dabfca680"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.Enable`

Gets or sets a value indicating whether the window handle is registered for DWM blur behind.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.Enable { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Composition/Structs/DwmBlurBehind.cs:31`.

```csharp
internal static class ApiExample
{
    internal static void Call(ref global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind receiver, global::System.Boolean configurableValue)
    {
        receiver.@Enable = configurableValue;
        _ = receiver.@Enable;
    }
}
```

<a id="api-55dfbff29a0c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.TransitionOnMaximized`

Gets or sets a value indicating whether the window colorization transitions when maximized.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind.TransitionOnMaximized { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Composition/Structs/DwmBlurBehind.cs:42`.

```csharp
internal static class ApiExample
{
    internal static void Call(ref global::CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind receiver, global::System.Boolean configurableValue)
    {
        receiver.@TransitionOnMaximized = configurableValue;
        _ = receiver.@TransitionOnMaximized;
    }
}
```
