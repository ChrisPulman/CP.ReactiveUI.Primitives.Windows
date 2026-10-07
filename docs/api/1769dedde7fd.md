<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult.SelectedPath](#api-b64d591116b6)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult.SelectedPaths](#api-cc2af124c5f0)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult.WasCancelled](#api-81745098ce87)

<a id="api-b64d591116b6"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult.SelectedPath`

Gets the selected file or folder path, or null if the dialog was cancelled. For multi-select results, returns the first selected path.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult.SelectedPath { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogResult.cs:75`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult receiver)
    {
        _ = receiver.@SelectedPath;
    }
}
```

<a id="api-cc2af124c5f0"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult.SelectedPaths`

Gets all selected paths when the dialog was configured for multiple selection (via M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileOpenDialogBuilder.AllowMultipleSelection), or null if the dialog was cancelled or configured for single selection.

```csharp
public System.Collections.Generic.IReadOnlyList<string> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult.SelectedPaths { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogResult.cs:82`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult receiver)
    {
        _ = receiver.@SelectedPaths;
    }
}
```

<a id="api-81745098ce87"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult.WasCancelled`

Gets a value indicating whether the user dismissed the dialog without making a selection (by pressing Cancel, Escape, or the × button).

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult.WasCancelled { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogResult.cs:69`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult receiver)
    {
        _ = receiver.@WasCancelled;
    }
}
```
