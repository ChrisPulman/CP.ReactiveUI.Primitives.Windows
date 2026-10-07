<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder)](#api-1bb669768995)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder,System.IntPtr)](#api-dc79483339cb)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder,System.IntPtr)](#api-d7653732e70f)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder)](#api-d3d8cd35b50d)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder,System.IntPtr)](#api-d2dcc0b0bc76)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder,System.IntPtr)](#api-b2df8e77bdf1)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder)](#api-d8171cbfdd52)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder,System.IntPtr)](#api-7ef1cc232c4b)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder,System.IntPtr)](#api-71f49a44cc5a)

<a id="api-1bb669768995"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder)`

Defers the open-file dialog until capture or subscription on the caller's STA thread.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder builder)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogOperationExtensions.cs:22`.

- `builder` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder`): The dialog configuration, read when executed.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder @builder, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> operationObserver)
    {
        return (@builder.@AsOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-dc79483339cb"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder,System.IntPtr)`

Defers the open-file dialog until capture or subscription on the caller's STA thread.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder builder, System.IntPtr ownerHandle)
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogOperationExtensions.cs:27`.

- `builder` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder`): The dialog configuration, read when executed.
- `ownerHandle` (`System.IntPtr`): The owner window handle, or zero for a top-level dialog.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder @builder, global::System.IntPtr @ownerHandle, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> operationObserver)
    {
        return (@builder.@AsOperation(@ownerHandle)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d7653732e70f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder,System.IntPtr)`

Defers the open-file dialog until capture or subscription on the caller's STA thread.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder builder, nint ownerHandle)
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogOperationExtensions.cs:27`.

- `builder` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder`): The dialog configuration, read when executed.
- `ownerHandle` (`nint`): The owner window handle, or zero for a top-level dialog.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder @builder, nint @ownerHandle, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> operationObserver)
    {
        return (@builder.@AsOperation(@ownerHandle)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d3d8cd35b50d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder)`

Defers the save-file dialog until capture or subscription on the caller's STA thread.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder builder)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogOperationExtensions.cs:51`.

- `builder` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder`): The dialog configuration, read when executed.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder @builder, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> operationObserver)
    {
        return (@builder.@AsOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d2dcc0b0bc76"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder,System.IntPtr)`

Defers the save-file dialog until capture or subscription on the caller's STA thread.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder builder, System.IntPtr ownerHandle)
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogOperationExtensions.cs:56`.

- `builder` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder`): The dialog configuration, read when executed.
- `ownerHandle` (`System.IntPtr`): The owner window handle, or zero for a top-level dialog.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder @builder, global::System.IntPtr @ownerHandle, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> operationObserver)
    {
        return (@builder.@AsOperation(@ownerHandle)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-b2df8e77bdf1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder,System.IntPtr)`

Defers the save-file dialog until capture or subscription on the caller's STA thread.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder builder, nint ownerHandle)
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogOperationExtensions.cs:56`.

- `builder` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder`): The dialog configuration, read when executed.
- `ownerHandle` (`nint`): The owner window handle, or zero for a top-level dialog.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder @builder, nint @ownerHandle, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> operationObserver)
    {
        return (@builder.@AsOperation(@ownerHandle)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d8171cbfdd52"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder)`

Defers the folder picker until capture or subscription on the caller's STA thread.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder builder)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogOperationExtensions.cs:80`.

- `builder` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder`): The dialog configuration, read when executed.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder @builder, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> operationObserver)
    {
        return (@builder.@AsOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-7ef1cc232c4b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder,System.IntPtr)`

Defers the folder picker until capture or subscription on the caller's STA thread.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder builder, System.IntPtr ownerHandle)
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogOperationExtensions.cs:85`.

- `builder` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder`): The dialog configuration, read when executed.
- `ownerHandle` (`System.IntPtr`): The owner window handle, or zero for a top-level dialog.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder @builder, global::System.IntPtr @ownerHandle, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> operationObserver)
    {
        return (@builder.@AsOperation(@ownerHandle)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-71f49a44cc5a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder,System.IntPtr)`

Defers the folder picker until capture or subscription on the caller's STA thread.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions.AsOperation(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder builder, nint ownerHandle)
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Dialogs/FileDialogOperationExtensions.cs:85`.

- `builder` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder`): The dialog configuration, read when executed.
- `ownerHandle` (`nint`): The owner window handle, or zero for a top-level dialog.

```csharp
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder @builder, nint @ownerHandle, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult> operationObserver)
    {
        return (@builder.@AsOperation(@ownerHandle)).Observe().Subscribe(operationObserver);
    }
}
```
