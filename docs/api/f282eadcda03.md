<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter

Package: `CP.ReactiveUI.Primitives.Windows.Core`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.#ctor](#api-b06fe1669c54)
- [M:CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type)](#api-9f056c9e76f3)
- [M:CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type)](#api-ceda0faa0f7c)
- [M:CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)](#api-1f1c502c2993)
- [M:CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)](#api-4ebbcef5f500)

<a id="api-b06fe1669c54"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.#ctor`

Creates the default NativeRectTypeConverter value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.NativeRectTypeConverter()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/TypeConverters/NativeRectTypeConverter.cs:8`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter();
    }
}
```

<a id="api-9f056c9e76f3"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type)`

Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/TypeConverters/NativeRectTypeConverter.cs:11`.

- `context` (`System.ComponentModel.ITypeDescriptorContext`): An System.ComponentModel.ITypeDescriptorContext that provides a format context.
- `sourceType` (`System.Type`): A System.Type that represents the type you want to convert from.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter receiver, global::System.ComponentModel.ITypeDescriptorContext @context, global::System.Type @sourceType)
    {
        _ = receiver.@CanConvertFrom(@context, @sourceType);
    }
}
```

<a id="api-ceda0faa0f7c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type)`

Returns whether this converter can convert the object to the specified type, using the specified context.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/TypeConverters/NativeRectTypeConverter.cs:15`.

- `context` (`System.ComponentModel.ITypeDescriptorContext`): An System.ComponentModel.ITypeDescriptorContext that provides a format context.
- `destinationType` (`System.Type`): A System.Type that represents the type you want to convert to.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter receiver, global::System.ComponentModel.ITypeDescriptorContext @context, global::System.Type @destinationType)
    {
        _ = receiver.@CanConvertTo(@context, @destinationType);
    }
}
```

<a id="api-1f1c502c2993"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)`

Converts the given object to the type of this converter, using the specified context and culture information.

```csharp
public override object CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/TypeConverters/NativeRectTypeConverter.cs:19`.

- `context` (`System.ComponentModel.ITypeDescriptorContext`): An System.ComponentModel.ITypeDescriptorContext that provides a format context.
- `culture` (`System.Globalization.CultureInfo`): The System.Globalization.CultureInfo to use as the current culture.
- `value` (`object`): The System.Object to convert.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter receiver, global::System.ComponentModel.ITypeDescriptorContext @context, global::System.Globalization.CultureInfo @culture, global::System.Object @value)
    {
        _ = receiver.@ConvertFrom(@context, @culture, @value);
    }
}
```

<a id="api-4ebbcef5f500"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)`

Converts the given value object to the specified type, using the specified context and culture information.

```csharp
public override object CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/TypeConverters/NativeRectTypeConverter.cs:58`.

- `context` (`System.ComponentModel.ITypeDescriptorContext`): An System.ComponentModel.ITypeDescriptorContext that provides a format context.
- `culture` (`System.Globalization.CultureInfo`): A System.Globalization.CultureInfo. If null is passed, the current culture is assumed.
- `value` (`object`): The System.Object to convert.
- `destinationType` (`System.Type`): The System.Type to convert the parameter to.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter receiver, global::System.ComponentModel.ITypeDescriptorContext @context, global::System.Globalization.CultureInfo @culture, global::System.Object @value, global::System.Type @destinationType)
    {
        _ = receiver.@ConvertTo(@context, @culture, @value, @destinationType);
    }
}
```
