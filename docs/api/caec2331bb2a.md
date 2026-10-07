<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams

Package: `CP.ReactiveUI.Primitives.Windows.Core`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.#ctor](#api-14d4e7a67775)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.Create(System.Single,System.Boolean)](#api-6c9f057af0df)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.Equals(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams)](#api-9dca44d6f09b)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.Equals(System.Object)](#api-6f271084cb2f)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.GetHashCode](#api-7d6752fc9454)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.op_Equality(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams,CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams)](#api-e964c426b026)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.op_Inequality(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams,CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams)](#api-30a8be1eaa85)

<a id="api-14d4e7a67775"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.#ctor`

Creates the default BlurParams value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.BlurParams()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BlurParams.cs:10`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams();
    }
}
```

<a id="api-6c9f057af0df"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.Create(System.Single,System.Boolean)`

Creates blur parameters.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.Create(float radius, bool expandEdges)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BlurParams.cs:30`.

- `radius` (`float`): Real number that specifies the blur radius (the radius of the Gaussian convolution kernel) in pixels. The radius must be in the range 0 through 255. As the radius increases, the resulting bitmap becomes more blurry.
- `expandEdges` (`bool`): Boolean value that specifies whether the bitmap expands by an amount equal to the blur radius. If TRUE, the bitmap expands by an amount equal to the radius so that it can have soft edges. If FALSE, the bitmap remains the same size and the soft edges are clipped.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.Single @radius, global::System.Boolean @expandEdges)
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.@Create(@radius, @expandEdges);
    }
}
```

<a id="api-9dca44d6f09b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.Equals(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams)`

Indicates whether the current object is equal to another object of the same type.

```csharp
public readonly bool CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.Equals(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BlurParams.cs:52`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams`): An object to compare with this object.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams receiver, global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams @other)
    {
        _ = receiver.@Equals(@other);
    }
}
```

<a id="api-6f271084cb2f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.Equals(System.Object)`

Indicates whether this instance and a specified object are equal.

```csharp
public override readonly bool CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BlurParams.cs:57`.

- `obj` (`object`): The object to compare with the current instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams receiver, global::System.Object @obj)
    {
        _ = receiver.@Equals(@obj);
    }
}
```

<a id="api-7d6752fc9454"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.GetHashCode`

Returns the hash code for this instance.

```csharp
public override readonly int CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BlurParams.cs:60`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams receiver)
    {
        _ = receiver.@GetHashCode();
    }
}
```

<a id="api-e964c426b026"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.op_Equality(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams,CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams)`

Determines whether two blur parameters are equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.operator ==(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams left, CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BlurParams.cs:37`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams`): The first blur parameters.
- `right` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams`): The second blur parameters.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams @left, global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-30a8be1eaa85"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.op_Inequality(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams,CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams)`

Determines whether two blur parameters are not equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams.operator !=(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams left, CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BlurParams.cs:46`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams`): The first blur parameters.
- `right` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams`): The second blur parameters.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams @left, global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams @right)
    {
        _ = @left != @right;
    }
}
```
