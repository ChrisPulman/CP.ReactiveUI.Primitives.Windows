<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken)](#api-8f5983f22361)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats)](#api-1c7a5f7015b1)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.String)](#api-2e2eb866df08)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.UInt32)](#api-56a1bf9b09fe)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.String)](#api-1eb30a493a98)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.String,CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats)](#api-c69d4dfec451)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.String,System.String)](#api-908abe1dd1c7)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.String,System.UInt32)](#api-41d1cd4c4f8a)

<a id="api-8f5983f22361"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken)`

Get a string from the clipboard, this assumes you already locked the clipboard. This by default takes the CF_UNICODETEXT format, as Windows automatically converts.

```csharp
public static string CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken clipboardAccessToken)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardStringExtensions.cs:65`.

- `clipboardAccessToken` (`CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken`): The extended instance.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken @clipboardAccessToken, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @clipboardAccessToken.@GetAsUnicodeString()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1c7a5f7015b1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats)`

Get a string from the clipboard, this assumes you already locked the clipboard.

```csharp
public static string CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken clipboardAccessToken, CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats format)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardStringExtensions.cs:50`.

- `clipboardAccessToken` (`CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken`): The extended instance.
- `format` (`CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats`): StandardClipboardFormats with the clipboard format.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken @clipboardAccessToken, global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats @format, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @clipboardAccessToken.@GetAsUnicodeString(@format)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-2e2eb866df08"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.String)`

Get a string from the clipboard, this assumes you already locked the clipboard. This always takes the CF_UNICODETEXT format, as Windows automatically converts.

```csharp
public static string CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken clipboardAccessToken, string format)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardStringExtensions.cs:58`.

- `clipboardAccessToken` (`CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken`): The extended instance.
- `format` (`string`): string with the clipboard format.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken @clipboardAccessToken, global::System.String @format, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @clipboardAccessToken.@GetAsUnicodeString(@format)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-56a1bf9b09fe"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.UInt32)`

Get a string from the clipboard, this assumes you already locked the clipboard. This by default takes the CF_UNICODETEXT format, as Windows automatically converts.

```csharp
public static string CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.GetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken clipboardAccessToken, uint formatId)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardStringExtensions.cs:74`.

- `clipboardAccessToken` (`CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken`): The extended instance.
- `formatId` (`uint`): uint with the clipboard format.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken @clipboardAccessToken, global::System.UInt32 @formatId, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @clipboardAccessToken.@GetAsUnicodeString(@formatId)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1eb30a493a98"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.String)`

Place string on the clipboard, this assumes you already locked the clipboard. It uses Unicode (CF_UNICODETEXT) by default, as all other formats are automatically generated from this by Windows.

```csharp
public static void CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken clipboardAccessToken, string text)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardStringExtensions.cs:32`.

- `clipboardAccessToken` (`CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken`): The extended instance.
- `text` (`string`): string to place on the clipboard.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken @clipboardAccessToken, global::System.String @text, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @clipboardAccessToken.@SetAsUnicodeString(@text)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-c69d4dfec451"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.String,CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats)`

Place string on the clipboard, this assumes you already locked the clipboard.

```csharp
public static void CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken clipboardAccessToken, string text, CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats format)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardStringExtensions.cs:20`.

- `clipboardAccessToken` (`CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken`): The extended instance.
- `text` (`string`): string to place on the clipboard.
- `format` (`CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats`): StandardClipboardFormats with the clipboard format to use.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken @clipboardAccessToken, global::System.String @text, global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats @format, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @clipboardAccessToken.@SetAsUnicodeString(@text, @format)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-908abe1dd1c7"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.String,System.String)`

Place string on the clipboard, this assumes you already locked the clipboard.

```csharp
public static void CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken clipboardAccessToken, string text, string format)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardStringExtensions.cs:25`.

- `clipboardAccessToken` (`CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken`): The extended instance.
- `text` (`string`): string to place on the clipboard.
- `format` (`string`): string with the clipboard format to use.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken @clipboardAccessToken, global::System.String @text, global::System.String @format, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @clipboardAccessToken.@SetAsUnicodeString(@text, @format)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-41d1cd4c4f8a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken,System.String,System.UInt32)`

Place string on the clipboard, this assumes you already locked the clipboard. It uses Unicode (CF_UNICODETEXT) by default, as all other formats are automatically generated from this by Windows.

```csharp
public static void CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions.SetAsUnicodeString(CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken clipboardAccessToken, string text, uint formatId)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardStringExtensions.cs:41`.

- `clipboardAccessToken` (`CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken`): The extended instance.
- `text` (`string`): string to place on the clipboard.
- `formatId` (`uint`): uint with the clipboard format id.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken @clipboardAccessToken, global::System.String @text, global::System.UInt32 @formatId, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @clipboardAccessToken.@SetAsUnicodeString(@text, @formatId)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```
