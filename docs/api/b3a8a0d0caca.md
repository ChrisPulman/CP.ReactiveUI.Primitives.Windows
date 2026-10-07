<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.#ctor](#api-bbcedbdaf6b8)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Dispose](#api-10e235ea2ffc)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.ObserveSessionChanges](#api-4870a3a897f0)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.ObserveSessionLockChanges](#api-dec618876351)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.ObserveSessionLogonChanges](#api-f8ff31aee4d6)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Pause](#api-eaf80090d81a)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Resume](#api-446b7c4218ac)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Start](#api-cd84e0e78ee2)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Stop](#api-f3c052917e01)

<a id="api-bbcedbdaf6b8"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.#ctor`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WindowsSessionListener class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.WindowsSessionListener()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WindowsSessionListener.cs:45`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener();
    }
}
```

<a id="api-10e235ea2ffc"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Dispose`

Disposes the listener and stops listening for events.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Dispose()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WindowsSessionListener.cs:127`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Dispose()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-4870a3a897f0"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.ObserveSessionChanges`

Observes all Windows session change notifications.

```csharp
public System.IObservable<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.ObserveSessionChanges()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WindowsSessionListener.cs:70`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener receiver, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs> operationObserver)
    {
        return ((global::System.IObservable<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs>)(receiver.@ObserveSessionChanges())).Subscribe(operationObserver);
    }
}
```

<a id="api-dec618876351"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.ObserveSessionLockChanges`

Observes Windows session lock and unlock notifications.

```csharp
public System.IObservable<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.ObserveSessionLockChanges()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WindowsSessionListener.cs:78`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener receiver, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs> operationObserver)
    {
        return ((global::System.IObservable<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs>)(receiver.@ObserveSessionLockChanges())).Subscribe(operationObserver);
    }
}
```

<a id="api-f8ff31aee4d6"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.ObserveSessionLogonChanges`

Observes Windows session logon and logoff notifications.

```csharp
public System.IObservable<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.ObserveSessionLogonChanges()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WindowsSessionListener.cs:85`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener receiver, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs> operationObserver)
    {
        return ((global::System.IObservable<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs>)(receiver.@ObserveSessionLogonChanges())).Subscribe(operationObserver);
    }
}
```

<a id="api-eaf80090d81a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Pause`

Pauses listening for session change events.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Pause()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WindowsSessionListener.cs:106`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Pause()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-446b7c4218ac"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Resume`

Resumes listening for session change events after being paused.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Resume()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WindowsSessionListener.cs:109`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Resume()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-cd84e0e78ee2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Start`

Starts listening for session change events.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Start()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WindowsSessionListener.cs:91`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Start()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-f3c052917e01"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Stop`

Stops listening for session change events.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener.Stop()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WindowsSessionListener.cs:112`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Stop()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```
