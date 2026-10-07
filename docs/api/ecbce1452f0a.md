<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx

Package: `CP.ReactiveUI.Primitives.Windows.Core`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.#ctor(System.Int32,CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect,CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect,CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.MonitorInfoFlags,System.String)](#api-dd67287da323)
- [M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.#ctor](#api-a01c1cf31275)
- [M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Create](#api-2b5f92b5b12e)
- [M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Equals(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx)](#api-a51d9fc5b001)
- [M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Equals(System.Object)](#api-bba7cad501b8)
- [M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.GetHashCode](#api-fe73459bb5de)
- [M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.op_Equality(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx,CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx)](#api-5a56d0add54c)
- [M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.op_Inequality(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx,CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx)](#api-050314308b5f)
- [P:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.DeviceName](#api-5912954266d9)
- [P:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Flags](#api-438315aa4da7)
- [P:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Monitor](#api-30d267bd4da7)
- [P:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Size](#api-503321cc5934)
- [P:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.WorkArea](#api-d699b5d0f611)

<a id="api-dd67287da323"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.#ctor(System.Int32,CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect,CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect,CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.MonitorInfoFlags,System.String)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx struct.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.MonitorInfoEx(int size, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect monitor, CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect workArea, CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.MonitorInfoFlags flags, string deviceName)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:43`.

- `size` (`int`): The size, in bytes, of the native structure.
- `monitor` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect`): The monitor rectangle in virtual-screen coordinates.
- `workArea` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect`): The monitor work-area rectangle in virtual-screen coordinates.
- `flags` (`CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.MonitorInfoFlags`): The monitor attributes.
- `deviceName` (`string`): The device name.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.Int32 @size, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect @monitor, global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect @workArea, global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.MonitorInfoFlags @flags, global::System.String @deviceName)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx(@size, @monitor, @workArea, @flags, @deviceName);
    }
}
```

<a id="api-a01c1cf31275"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.#ctor`

Creates the default MonitorInfoEx value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.MonitorInfoEx()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:13`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx();
    }
}
```

<a id="api-2b5f92b5b12e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Create`

Creates an empty monitor-information value.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Create()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:74`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.@Create();
    }
}
```

<a id="api-a51d9fc5b001"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Equals(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx)`

Indicates whether the current object is equal to another object of the same type.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Equals(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:96`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx`): An object to compare with this object.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx receiver, global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx @other)
    {
        _ = receiver.@Equals(@other);
    }
}
```

<a id="api-bba7cad501b8"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Equals(System.Object)`

Indicates whether this instance and a specified object are equal.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:104`.

- `obj` (`object`): The object to compare with the current instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx receiver, global::System.Object @obj)
    {
        _ = receiver.@Equals(@obj);
    }
}
```

<a id="api-fe73459bb5de"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.GetHashCode`

Returns the hash code for this instance.

```csharp
public override int CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:107`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx receiver)
    {
        _ = receiver.@GetHashCode();
    }
}
```

<a id="api-5a56d0add54c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.op_Equality(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx,CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx)`

Determines whether two monitor information values are equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.operator ==(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx left, CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:81`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx`): The first value.
- `right` (`CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx`): The second value.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx @left, global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-050314308b5f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.op_Inequality(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx,CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx)`

Determines whether two monitor information values are not equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.operator !=(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx left, CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:90`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx`): The first value.
- `right` (`CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx`): The second value.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx @left, global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-5912954266d9"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.DeviceName`

Gets the device name.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.DeviceName { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:70`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx receiver)
    {
        _ = receiver.@DeviceName;
    }
}
```

<a id="api-438315aa4da7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Flags`

Gets the monitor attributes.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.MonitorInfoFlags CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Flags { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:67`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx receiver)
    {
        _ = receiver.@Flags;
    }
}
```

<a id="api-30d267bd4da7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Monitor`

Gets the monitor rectangle in virtual-screen coordinates.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Monitor { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:61`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx receiver)
    {
        _ = receiver.@Monitor;
    }
}
```

<a id="api-503321cc5934"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Size`

Gets the size, in bytes, of the native structure.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.Size { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:58`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx receiver)
    {
        _ = receiver.@Size;
    }
}
```

<a id="api-d699b5d0f611"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.WorkArea`

Gets the monitor work-area rectangle in virtual-screen coordinates.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx.WorkArea { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/UserInterface/Structs/MonitorInfoEx.cs:64`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx receiver)
    {
        _ = receiver.@WorkArea;
    }
}
```
