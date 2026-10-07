<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook.#ctor(System.Windows.Interop.HwndSourceHook)](#api-e5728963216d)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook.Disposable](#api-bb11a7360ff6)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook.Hook](#api-849ee7bc0668)

<a id="api-e5728963216d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook.#ctor(System.Windows.Interop.HwndSourceHook)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook.WinProcHandlerHook(System.Windows.Interop.HwndSourceHook hook)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WinProcHandlerHook.cs:17`.

- `hook` (`System.Windows.Interop.HwndSourceHook`): HwndSourceHook.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.Windows.Interop.HwndSourceHook @hook)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook(@hook);
    }
}
```

<a id="api-bb11a7360ff6"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook.Disposable`

Gets or sets the optional disposable which is called to make a cleanup possible.

```csharp
public System.IDisposable CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook.Disposable { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WinProcHandlerHook.cs:26`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook receiver, global::System.IDisposable configurableValue)
    {
        receiver.@Disposable = configurableValue;
        _ = receiver.@Disposable;
    }
}
```

<a id="api-849ee7bc0668"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook.Hook`

Gets the actual HwndSourceHook.

```csharp
public System.Windows.Interop.HwndSourceHook CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook.Hook { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/WinProcHandlerHook.cs:23`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook receiver)
    {
        _ = receiver.@Hook;
    }
}
```
