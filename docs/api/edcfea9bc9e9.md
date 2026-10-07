<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader

Package: `CP.ReactiveUI.Primitives.Windows.Core`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.#ctor](#api-db379af82cad)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Create(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapInfoHeader)](#api-fb5b582002d5)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Create(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapV5Header)](#api-4815104dea6e)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Equals(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader)](#api-d25be310b4da)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Equals(System.Object)](#api-7a2edcdc4eee)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.GetHashCode](#api-5b6e52e4fb43)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.op_Equality(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader,CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader)](#api-190283247c8a)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.op_Inequality(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader,CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader)](#api-be11e11ff010)
- [P:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.FileType](#api-6591b3ec5932)
- [P:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.OffsetToBitmapBits](#api-f4b385c17dcf)
- [P:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Size](#api-37093b70012f)

<a id="api-db379af82cad"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.#ctor`

Creates the default BitmapFileHeader value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.BitmapFileHeader()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:9`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader();
    }
}
```

<a id="api-fb5b582002d5"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Create(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapInfoHeader)`

Create a BitmapFileHeader which needs a BitmapInfoHeader to calculate the values.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Create(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapInfoHeader bitmapInfoHeader)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:62`.

- `bitmapInfoHeader` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapInfoHeader`): The bitmap information header.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapInfoHeader @bitmapInfoHeader)
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.@Create(@bitmapInfoHeader);
    }
}
```

<a id="api-4815104dea6e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Create(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapV5Header)`

Create a BitmapFileHeader which needs a BitmapV5Header to calculate the values.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Create(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapV5Header bitmapV5Header)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:40`.

- `bitmapV5Header` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapV5Header`): The bitmap V5 header.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapV5Header @bitmapV5Header)
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.@Create(@bitmapV5Header);
    }
}
```

<a id="api-d25be310b4da"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Equals(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader)`

Indicates whether the current object is equal to another object of the same type.

```csharp
public readonly bool CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Equals(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:101`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader`): An object to compare with this object.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader receiver, global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader @other)
    {
        _ = receiver.@Equals(@other);
    }
}
```

<a id="api-7a2edcdc4eee"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Equals(System.Object)`

Indicates whether this instance and a specified object are equal.

```csharp
public override readonly bool CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:109`.

- `obj` (`object`): The object to compare with the current instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader receiver, global::System.Object @obj)
    {
        _ = receiver.@Equals(@obj);
    }
}
```

<a id="api-5b6e52e4fb43"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.GetHashCode`

Returns the hash code for this instance.

```csharp
public override readonly int CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:113`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader receiver)
    {
        _ = receiver.@GetHashCode();
    }
}
```

<a id="api-190283247c8a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.op_Equality(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader,CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader)`

Determines whether two bitmap file headers are equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.operator ==(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader left, CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:86`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader`): The left header.
- `right` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader`): The right header.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader @left, global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-be11e11ff010"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.op_Inequality(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader,CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader)`

Determines whether two bitmap file headers are not equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.operator !=(CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader left, CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:95`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader`): The left header.
- `right` (`CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader`): The second header.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader @left, global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-6591b3ec5932"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.FileType`

Gets the file type; it must be BM.

```csharp
public short CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.FileType { get; private set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:19`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader receiver)
    {
        _ = receiver.@FileType;
    }
}
```

<a id="api-f4b385c17dcf"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.OffsetToBitmapBits`

Gets the offset, in bytes, from the beginning of the BITMAPFILEHEADER structure to the bitmap bits.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.OffsetToBitmapBits { get; private set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:27`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader receiver)
    {
        _ = receiver.@OffsetToBitmapBits;
    }
}
```

<a id="api-37093b70012f"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Size`

Gets the size, in bytes, of the bitmap file.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader.Size { get; private set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/Structs/BitmapFileHeader.cs:23`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader receiver)
    {
        _ = receiver.@Size;
    }
}
```
