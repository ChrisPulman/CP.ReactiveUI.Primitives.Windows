<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFileExtensions

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFileExtensions.GetFileNames(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken)](#api-8af3c1062398)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFileExtensions.SetFileNames(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken,System.Collections.Generic.IEnumerable{System.String})](#api-5de03f8b835e)

<a id="api-8af3c1062398"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFileExtensions.GetFileNames(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken)`

Get a list of file-names on the clipboard.

```csharp
public static System.Collections.Generic.IEnumerable<string> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFileExtensions.GetFileNames(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken clipboardAccessToken)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardFileExtensions.cs:34`.

- `clipboardAccessToken` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken`): The extended instance.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken @clipboardAccessToken, global::System.IObserver<global::System.Collections.Generic.IEnumerable<global::System.String>> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @clipboardAccessToken.@GetFileNames()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-5de03f8b835e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFileExtensions.SetFileNames(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken,System.Collections.Generic.IEnumerable{System.String})`

Set a list of file-names on the clipboard in CF_HDROP (Drop) format.

```csharp
public static void CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFileExtensions.SetFileNames(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken clipboardAccessToken, System.Collections.Generic.IEnumerable<string> fileNames)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardFileExtensions.cs:63`.

- `clipboardAccessToken` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken`): The extended instance.
- `fileNames` (`System.Collections.Generic.IEnumerable<string>`): IEnumerable of strings with the fully-qualified file names.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken @clipboardAccessToken, global::System.Collections.Generic.IEnumerable<global::System.String> @fileNames, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @clipboardAccessToken.@SetFileNames(@fileNames)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```
