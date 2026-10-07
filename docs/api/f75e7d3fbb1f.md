<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.BitmapIconExtensions

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.BitmapIconExtensions.SafeIconHandle(System.Drawing.Bitmap)](#api-4254f078482c)

<a id="api-4254f078482c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.BitmapIconExtensions.SafeIconHandle(System.Drawing.Bitmap)`

Gets a safe icon handle for the bitmap.

```csharp
extension(global::System.Drawing.Bitmap @bitmap) { public global::CP.ReactiveUI.Primitives.Windows.Native.Shell.SafeHandles.SafeIconHandle @SafeIconHandle { get; } }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/BitmapIconExtensions.cs:20`.

- `bitmap` (`System.Drawing.Bitmap`): The extended instance.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons;
internal static class ApiExample
{
    internal static void Call(global::System.Drawing.Bitmap @bitmap)
    {
        _ = @bitmap.@SafeIconHandle;
    }
}
```
