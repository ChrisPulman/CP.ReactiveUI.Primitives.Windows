<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs.#ctor(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WtsSessionChangeEvents,System.Int32)](#api-ce56aa22ba9c)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs.EventType](#api-61626ab21804)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs.SessionId](#api-5c85a693376b)

<a id="api-ce56aa22ba9c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs.#ctor(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WtsSessionChangeEvents,System.Int32)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs.SessionChangeEventArgs(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WtsSessionChangeEvents eventType, int sessionId)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/SessionChangeEventArgs.cs:16`.

- `eventType` (`CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WtsSessionChangeEvents`): The type of session change.
- `sessionId` (`int`): The session ID.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WtsSessionChangeEvents @eventType, global::System.Int32 @sessionId)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs(@eventType, @sessionId);
    }
}
```

<a id="api-61626ab21804"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs.EventType`

Gets the type of session change that occurred.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WtsSessionChangeEvents CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs.EventType { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/SessionChangeEventArgs.cs:23`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs receiver)
    {
        _ = receiver.@EventType;
    }
}
```

<a id="api-5c85a693376b"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs.SessionId`

Gets the session ID that was affected.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs.SessionId { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Messaging/SessionChangeEventArgs.cs:26`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs receiver)
    {
        _ = receiver.@SessionId;
    }
}
```
