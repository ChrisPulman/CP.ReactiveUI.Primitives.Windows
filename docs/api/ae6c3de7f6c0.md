<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.CloseMainWindow](#api-8f9ff4640cb6)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.ForId(System.Int32)](#api-4e8a5b7b3d52)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.Terminate](#api-8000a2a4dcb4)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.WithAffinity(System.IntPtr)](#api-1379ae4ec974)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.WithAffinity(System.IntPtr)](#api-099274f2ddee)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.WithPriority(System.Diagnostics.ProcessPriorityClass)](#api-84a54b4a14af)

<a id="api-8f9ff4640cb6"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.CloseMainWindow`

Requests graceful closure of the process main window.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.CloseMainWindow()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ProcessTarget.cs:66`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget receiver, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@CloseMainWindow()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-4e8a5b7b3d52"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.ForId(System.Int32)`

Binds a target to the currently running process with the specified identifier.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.ForId(int processId)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ProcessTarget.cs:33`.

- `processId` (`int`): The process identifier.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Int32 @processId, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.@ForId(@processId)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-8000a2a4dcb4"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.Terminate`

Immediately terminates the selected process without terminating descendants.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.Terminate()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ProcessTarget.cs:73`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Terminate()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1379ae4ec974"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.WithAffinity(System.IntPtr)`

Immediately sets the process affinity mask within its processor group.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.WithAffinity(System.IntPtr affinity)
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ProcessTarget.cs:52`.

- `affinity` (`System.IntPtr`): The nonzero processor mask supported by the process.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget receiver, global::System.IntPtr @affinity, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@WithAffinity(@affinity)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-099274f2ddee"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.WithAffinity(System.IntPtr)`

Immediately sets the process affinity mask within its processor group.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.WithAffinity(nint affinity)
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ProcessTarget.cs:52`.

- `affinity` (`nint`): The nonzero processor mask supported by the process.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget receiver, nint @affinity, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@WithAffinity(@affinity)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-84a54b4a14af"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.WithPriority(System.Diagnostics.ProcessPriorityClass)`

Immediately sets the process priority; access and exit errors propagate.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget.WithPriority(System.Diagnostics.ProcessPriorityClass priority)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ProcessTarget.cs:42`.

- `priority` (`System.Diagnostics.ProcessPriorityClass`): The requested priority class.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget receiver, global::System.Diagnostics.ProcessPriorityClass @priority, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@WithPriority(@priority)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```
