<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.GetRestartCommandLineArgs](#api-fcf8078f1112)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.ObserveEndSessionMessages(System.Func{CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons,System.Boolean})](#api-7f8b1eb0309f)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.ObserveEndSessionMessages(System.Func{CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons,System.Boolean},System.Func{CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons,System.Boolean})](#api-75d4a9ef8916)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.ObserveEndSessionMessages](#api-1bfe5932574b)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RegisterForRestart(System.String)](#api-5e70d0447bd1)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RegisterForRestart(System.String,CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.ApplicationRestartFlags)](#api-a12fe0753729)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RegisterForRestart](#api-be594c217626)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.UnregisterForRestart](#api-21146c062baf)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.WasRestartRequested](#api-aa8dc889369f)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.MaxCommandLineLength](#api-ec028401db24)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RestartMaxCmdLine](#api-c033ba780a9e)

<a id="api-fcf8078f1112"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.GetRestartCommandLineArgs`

Gets the command-line arguments that were passed to the current process. Applications can use this to implement their own restart detection logic based on the specific arguments they registered via RegisterForRestart().

```csharp
public static string[] CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.GetRestartCommandLineArgs()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:102`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::System.String[]> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@GetRestartCommandLineArgs()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-7f8b1eb0309f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.ObserveEndSessionMessages(System.Func{CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons,System.Boolean})`

Creates an observable stream that listens for WM_QUERYENDSESSION and WM_ENDSESSION messages.

```csharp
public static System.IObservable<CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage> CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.ObserveEndSessionMessages(System.Func<CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons, bool> onQuerySession)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:117`.

- `onQuerySession` (`System.Func<CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons, bool>`): Handler called when a query end-session message is received.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Func<global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons, global::System.Boolean> @onQuerySession, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage> operationObserver)
    {
        return ((global::System.IObservable<global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage>)(global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@ObserveEndSessionMessages(@onQuerySession))).Subscribe(operationObserver);
    }
}
```

<a id="api-75d4a9ef8916"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.ObserveEndSessionMessages(System.Func{CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons,System.Boolean},System.Func{CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons,System.Boolean})`

Creates an observable stream that listens for WM_QUERYENDSESSION and WM_ENDSESSION messages. This allows applications to be notified when the system is about to shut down or restart.

```csharp
public static System.IObservable<CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage> CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.ObserveEndSessionMessages(System.Func<CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons, bool> onQuerySession, System.Func<CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons, bool> onEndSession)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:129`.

- `onQuerySession` (`System.Func<CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons, bool>`): Handler called when a query end-session message is received.
- `onEndSession` (`System.Func<CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons, bool>`): Handler called when an end-session message is received.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Func<global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons, global::System.Boolean> @onQuerySession, global::System.Func<global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons, global::System.Boolean> @onEndSession, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage> operationObserver)
    {
        return ((global::System.IObservable<global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage>)(global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@ObserveEndSessionMessages(@onQuerySession, @onEndSession))).Subscribe(operationObserver);
    }
}
```

<a id="api-1bfe5932574b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.ObserveEndSessionMessages`

Creates an observable stream that listens for WM_QUERYENDSESSION and WM_ENDSESSION messages. This allows applications to be notified when the system is about to shut down or restart.

```csharp
public static System.IObservable<CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage> CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.ObserveEndSessionMessages()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:112`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage> operationObserver)
    {
        return ((global::System.IObservable<global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage>)(global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@ObserveEndSessionMessages())).Subscribe(operationObserver);
    }
}
```

<a id="api-5e70d0447bd1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RegisterForRestart(System.String)`

Registers the current application for automatic restart.

```csharp
public static void CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RegisterForRestart(string commandLineArgs)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:43`.

- `commandLineArgs` (`string`): Command-line arguments to pass to the application when it is restarted.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.String @commandLineArgs, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@RegisterForRestart(@commandLineArgs)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-a12fe0753729"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RegisterForRestart(System.String,CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.ApplicationRestartFlags)`

Registers the current application for automatic restart. When the Restart Manager shuts down the application during an update, it will be automatically restarted afterwards.

```csharp
public static void CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RegisterForRestart(string commandLineArgs, CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.ApplicationRestartFlags flags)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:60`.

- `commandLineArgs` (`string`): Command-line arguments to pass to the application when it is restarted. Do not include the executable name - it will be added automatically. Maximum length is 1024 characters. Use null or empty string to clear previous registration.
- `flags` (`CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.ApplicationRestartFlags`): Flags that control when the application should NOT be restarted. Default is None, meaning the application will always be restarted.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.String @commandLineArgs, global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.ApplicationRestartFlags @flags, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@RegisterForRestart(@commandLineArgs, @flags)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-be594c217626"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RegisterForRestart`

Registers the current application for automatic restart.

```csharp
public static void CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RegisterForRestart()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:39`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@RegisterForRestart()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-21146c062baf"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.UnregisterForRestart`

Unregisters the current application from automatic restart. Call this if you no longer want the application to be restarted by Restart Manager.

```csharp
public static void CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.UnregisterForRestart()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:79`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@UnregisterForRestart()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-aa8dc889369f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.WasRestartRequested`

Checks if the current process was started by Restart Manager. This allows the application to detect if it was automatically restarted after an update.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.WasRestartRequested()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:94`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@WasRestartRequested()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-ec028401db24"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.MaxCommandLineLength`

Gets the alias for RestartMaxCmdLine for backward compatibility.

```csharp
public static int CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.MaxCommandLineLength { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:34`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@MaxCommandLineLength;
    }
}
```

<a id="api-c033ba780a9e"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RestartMaxCmdLine`

Gets the maximum length for the command line arguments, in characters.

```csharp
public static int CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.RestartMaxCmdLine { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/ApplicationRestartManager.cs:31`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager.@RestartMaxCmdLine;
    }
}
```
