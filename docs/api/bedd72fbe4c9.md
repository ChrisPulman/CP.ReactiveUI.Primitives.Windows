<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>

Package: `CP.ReactiveUI.Primitives.Windows.Core`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor\`1.#ctor(System.Drawing.Bitmap)](#api-8a9c5e695fbe)
- [M:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor\`1.#ctor(System.Drawing.Bitmap,System.Boolean)](#api-7a64c86d4d17)
- [M:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor\`1.Dispose](#api-41ec4072157d)
- [M:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor\`1.GetRowSpan(System.Int32)](#api-8689aa0088c2)
- [M:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor\`1.ProcessRows(CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor{\`0}.ProcessRowDelegate{\`0})](#api-a06f90e59825)
- [P:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor\`1.Height](#api-6d38ce3c32fe)
- [P:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor\`1.PaletteSpan](#api-0610e06aec6e)
- [P:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor\`1.PixelFormat](#api-865d17dfe2d4)
- [P:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor\`1.Stride](#api-c46826675c2f)
- [P:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor\`1.Width](#api-a7d1cb4850c2)

<a id="api-8a9c5e695fbe"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor`1.#ctor(System.Drawing.Bitmap)`

Initializes a new instance of the BitmapAccessor class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.BitmapAccessor(System.Drawing.Bitmap bitmap)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/BitmapAccessor.cs:39`.

- `bitmap` (`System.Drawing.Bitmap`): The bitmap to access.

```csharp
internal static class ApiExample
{
    internal static void Call<TPixel>(global::System.Drawing.Bitmap @bitmap)
    where TPixel : struct
    {
        new global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>(@bitmap);
    }
}
```

<a id="api-7a64c86d4d17"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor`1.#ctor(System.Drawing.Bitmap,System.Boolean)`

Initializes a new instance of the BitmapAccessor class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.BitmapAccessor(System.Drawing.Bitmap bitmap, bool readOnly)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/BitmapAccessor.cs:47`.

- `bitmap` (`System.Drawing.Bitmap`): The bitmap to access.
- `readOnly` (`bool`): If true, the bitmap is locked for read-only access; otherwise, it's locked for read-write access.

```csharp
internal static class ApiExample
{
    internal static void Call<TPixel>(global::System.Drawing.Bitmap @bitmap, global::System.Boolean @readOnly)
    where TPixel : struct
    {
        new global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>(@bitmap, @readOnly);
    }
}
```

<a id="api-41ec4072157d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor`1.Dispose`

Releases the bitmap lock and frees resources. For indexed formats, applies palette changes back to the bitmap.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.Dispose()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/BitmapAccessor.cs:123`.

```csharp
internal static class ApiExample
{
    internal static void Call<TPixel>(global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel> receiver)
    where TPixel : struct
    {
        receiver.@Dispose();
    }
}
```

<a id="api-8689aa0088c2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor`1.GetRowSpan(System.Int32)`

Gets a span representing a single row of typed pixel data.

```csharp
public System.Span<TPixel> CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.GetRowSpan(int y)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/BitmapAccessor.cs:92`.

- `y` (`int`): The zero-based row index.

```csharp
internal static class ApiExample
{
    internal static void Call<TPixel>(global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel> receiver, global::System.Int32 @y)
    where TPixel : struct
    {
        _ = receiver.@GetRowSpan(@y);
    }
}
```

<a id="api-a06f90e59825"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor`1.ProcessRows(CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor{`0}.ProcessRowDelegate{`0})`

Processes all rows of the bitmap using the provided action.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.ProcessRows(CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.ProcessRowDelegate<TPixel> processRow)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/BitmapAccessor.cs:112`.

- `processRow` (`CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.ProcessRowDelegate<TPixel>`): An action that processes each row. The action receives the row index and a span of typed pixels.

```csharp
internal static class ApiExample
{
    internal static void Call<TPixel>(global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel> receiver, global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.ProcessRowDelegate<TPixel> @processRow)
    where TPixel : struct
    {
        receiver.@ProcessRows(@processRow);
    }
}
```

<a id="api-6d38ce3c32fe"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor`1.Height`

Gets the height of the bitmap in pixels.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.Height { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/BitmapAccessor.cs:72`.

```csharp
internal static class ApiExample
{
    internal static void Call<TPixel>(global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel> receiver)
    where TPixel : struct
    {
        _ = receiver.@Height;
    }
}
```

<a id="api-0610e06aec6e"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor`1.PaletteSpan`

Gets the indexed palette as a mutable span of BGRA colors.

```csharp
public System.Span<CP.ReactiveUI.Primitives.Windows.Native.Structs.PixelFormats.Bgra32> CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.PaletteSpan { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/BitmapAccessor.cs:82`.

```csharp
internal static class ApiExample
{
    internal static void Call<TPixel>(global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel> receiver)
    where TPixel : struct
    {
        _ = receiver.@PaletteSpan;
    }
}
```

<a id="api-865d17dfe2d4"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor`1.PixelFormat`

Gets the pixel format of the bitmap.

```csharp
public System.Drawing.Imaging.PixelFormat CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.PixelFormat { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/BitmapAccessor.cs:78`.

```csharp
internal static class ApiExample
{
    internal static void Call<TPixel>(global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel> receiver)
    where TPixel : struct
    {
        _ = receiver.@PixelFormat;
    }
}
```

<a id="api-c46826675c2f"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor`1.Stride`

Gets the stride (bytes per row) of the bitmap data.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.Stride { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/BitmapAccessor.cs:75`.

```csharp
internal static class ApiExample
{
    internal static void Call<TPixel>(global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel> receiver)
    where TPixel : struct
    {
        _ = receiver.@Stride;
    }
}
```

<a id="api-a7d1cb4850c2"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor`1.Width`

Gets the width of the bitmap in pixels.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.Width { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/BitmapAccessor.cs:69`.

```csharp
internal static class ApiExample
{
    internal static void Call<TPixel>(global::CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel> receiver)
    where TPixel : struct
    {
        _ = receiver.@Width;
    }
}
```
