<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeExtensions

Package: `CP.ReactiveUI.Primitives.Windows.Core`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeExtensions.ChangeHeight(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize,System.Int32)](#api-958452de201f)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeExtensions.ChangeWidth(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize,System.Int32)](#api-05f66dc2d812)

<a id="api-958452de201f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeExtensions.ChangeHeight(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize,System.Int32)`

Create a new NativeSize, from the supplied one, using the specified height.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeExtensions.ChangeHeight(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize size, int height)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Extensions/NativeSizeExtensions.cs:22`.

- `size` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize`): The target value.
- `height` (`int`): int

```csharp
using CP.ReactiveUI.Primitives.Windows.Native.Extensions;
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize @size, global::System.Int32 @height)
    {
        _ = @size.@ChangeHeight(@height);
    }
}
```

<a id="api-05f66dc2d812"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeExtensions.ChangeWidth(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize,System.Int32)`

Create a new NativeSize, from the supplied one, using the specified width.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeExtensions.ChangeWidth(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize size, int width)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Extensions/NativeSizeExtensions.cs:17`.

- `size` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize`): The target value.
- `width` (`int`): int

```csharp
using CP.ReactiveUI.Primitives.Windows.Native.Extensions;
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize @size, global::System.Int32 @width)
    {
        _ = @size.@ChangeWidth(@width);
    }
}
```
