<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.AppVisible(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect)](#api-400816ebca03)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.GetAppLauncher](#api-0c397ab35ee8)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsApp(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)](#api-40b7674bd450)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsAppLauncher(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)](#api-13b4a562408c)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsBackgroundWin10App(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)](#api-694ffb530f9b)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsGutter(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)](#api-d0ee80b4f9cf)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsWin10App(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)](#api-06218082b6f2)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsWin8App(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)](#api-9689fba12b31)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.AppLauncher](#api-a5b2aa59a6d6)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.AppLauncher](#api-ccebfb456950)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsLauncherVisible](#api-5d3b10c5aac0)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.WindowsStoreApps](#api-728d2a08632e)

<a id="api-400816ebca03"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.AppVisible(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect)`

Check if a Windows Store App (WinRT) is visible.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.AppVisible(CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect windowBounds)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:110`.

- `windowBounds` (`CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect`): NativeRect.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect @windowBounds, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.@AppVisible(@windowBounds)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-0c397ab35ee8"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.GetAppLauncher`

Get the AppLauncher.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.GetAppLauncher()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:115`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.@GetAppLauncher()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-40b7674bd450"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsApp(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)`

Checks if the window is an App (Win8 or Win10).

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsApp(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow interopWindow)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:21`.

- `interopWindow` (`CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow`): The window to classify.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Apps;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow @interopWindow, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @interopWindow.@IsApp()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-13b4a562408c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsAppLauncher(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)`

Tests if this window is for the App-Launcher.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsAppLauncher(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow interopWindow)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:26`.

- `interopWindow` (`CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow`): The window to classify.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Apps;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow @interopWindow, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @interopWindow.@IsAppLauncher()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-694ffb530f9b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsBackgroundWin10App(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)`

Checks if the window is a background Windows 10 App.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsBackgroundWin10App(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow interopWindow)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:38`.

- `interopWindow` (`CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow`): The window to classify.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Apps;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow @interopWindow, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @interopWindow.@IsBackgroundWin10App()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d0ee80b4f9cf"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsGutter(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)`

Checks if the window is the metro gutter (sizeable separator).

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsGutter(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow interopWindow)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:30`.

- `interopWindow` (`CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow`): The window to classify.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Apps;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow @interopWindow, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @interopWindow.@IsGutter()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-06218082b6f2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsWin10App(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)`

Checks if the window is a Windows 10 App.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsWin10App(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow interopWindow)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:34`.

- `interopWindow` (`CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow`): The window to classify.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Apps;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow @interopWindow, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @interopWindow.@IsWin10App()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-9689fba12b31"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsWin8App(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow)`

Checks if the window is a Windows 8 App, not Windows 10.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsWin8App(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow interopWindow)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:45`.

- `interopWindow` (`CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow`): The window to classify.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Apps;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow @interopWindow, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @interopWindow.@IsWin8App()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-a5b2aa59a6d6"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.AppLauncher`

Gets the windowHandle for the AppLauncer.

```csharp
public static System.IntPtr CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.AppLauncher { get; }
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:85`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.@AppLauncher;
    }
}
```

<a id="api-ccebfb456950"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.AppLauncher`

Gets the windowHandle for the AppLauncer.

```csharp
public static nint CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.AppLauncher { get; }
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:85`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.@AppLauncher;
    }
}
```

<a id="api-5d3b10c5aac0"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsLauncherVisible`

Gets a value indicating whether the app-launcher is visible.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.IsLauncherVisible { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:89`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.@IsLauncherVisible;
    }
}
```

<a id="api-728d2a08632e"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.WindowsStoreApps`

Gets handles of all Windows store apps.

```csharp
public static System.Collections.Generic.IEnumerable<CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow> CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.WindowsStoreApps { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Apps/AppQueryExtensions.cs:105`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions.@WindowsStoreApps;
    }
}
```
