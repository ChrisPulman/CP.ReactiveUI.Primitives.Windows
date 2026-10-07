<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.#ctor(System.Object,System.IntPtr)](#api-492984c7802f)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.#ctor(System.Object,System.IntPtr)](#api-b8d610bcc598)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.BeginInvoke(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg@,System.AsyncCallback,System.Object)](#api-f7862242312a)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.EndInvoke(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg@,System.IAsyncResult)](#api-4d629508e8bc)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.Invoke(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg@)](#api-28c3319a0571)

<a id="api-492984c7802f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.#ctor(System.Object,System.IntPtr)`

Creates a delegate bound to the typed callback shown in the C# example.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.MessageProc(object @object, System.IntPtr method)
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/MessageLoop.cs:19`.

- `object` (`object`): The target object captured by the delegate runtime constructor; the C# example uses a typed handler.
- `method` (`System.IntPtr`): The delegate runtime method pointer; construct the delegate from a typed handler in C#.

```csharp
internal static class ApiExample { internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc handler)  { _ = new global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc(handler.Invoke); } }
```

<a id="api-b8d610bcc598"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.#ctor(System.Object,System.IntPtr)`

Creates a delegate bound to the typed callback shown in the C# example.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.MessageProc(object @object, nint method)
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/MessageLoop.cs:19`.

- `object` (`object`): The target object captured by the delegate runtime constructor; the C# example uses a typed handler.
- `method` (`nint`): The delegate runtime method pointer; construct the delegate from a typed handler in C#.

```csharp
internal static class ApiExample { internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc handler)  { _ = new global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc(handler.Invoke); } }
```

<a id="api-f7862242312a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.BeginInvoke(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg@,System.AsyncCallback,System.Object)`

Starts the delegate asynchronous invocation with a completion callback and caller state.

```csharp
public virtual System.IAsyncResult CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.BeginInvoke(ref CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg message, System.AsyncCallback callback, object @object)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/MessageLoop.cs:19`.

- `message` (`CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg`): The message.
- `callback` (`System.AsyncCallback`): Callback invoked when the asynchronous delegate invocation completes.
- `object` (`object`): State passed to the asynchronous callback.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc receiver, ref global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg @message, global::System.AsyncCallback @callback, global::System.Object @object)
    {
        _ = receiver.@BeginInvoke(ref @message, @callback, @object);
    }
}
```

<a id="api-4d629508e8bc"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.EndInvoke(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg@,System.IAsyncResult)`

Retrieves the result of the matching asynchronous delegate invocation.

```csharp
public virtual bool CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.EndInvoke(ref CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg message, System.IAsyncResult result)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/MessageLoop.cs:19`.

- `message` (`CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg`): The message.
- `result` (`System.IAsyncResult`): The asynchronous result returned by BeginInvoke.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc receiver, ref global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg @message, global::System.IAsyncResult @result)
    {
        _ = receiver.@EndInvoke(ref @message, @result);
    }
}
```

<a id="api-28c3319a0571"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.Invoke(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg@)`

Invokes the delegate's bound callback with the supplied arguments and returns its result.

```csharp
public virtual bool CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc.Invoke(ref CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg message)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/MessageLoop.cs:19`.

- `message` (`CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg`): The message.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc receiver, ref global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg @message)
    {
        _ = receiver.@Invoke(ref @message);
    }
}
```
