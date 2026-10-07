<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.#ctor(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons)](#api-c82667e7e04b)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.#ctor](#api-978888ae4918)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Deconstruct(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages@,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons@)](#api-350df53bddfb)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Equals(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage)](#api-29202cf4ba63)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Equals(System.Object)](#api-08f047a67d89)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.GetHashCode](#api-d7f77fd29e9c)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.ToString](#api-0ef76ca68322)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.op_Equality(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage)](#api-c4e6dc4b2868)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.op_Inequality(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage)](#api-754432a66bd2)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.EndSessionReason](#api-f68789323aae)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Handled](#api-67135d8790ed)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Msg](#api-693338940ab5)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Result](#api-f720e1476116)

<a id="api-c82667e7e04b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.#ctor(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons)`

Represents a message indicating that a Windows session is ending.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.EndSessionMessage(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages Msg, CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons EndSessionReason)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.

- `Msg` (`CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages`): The Windows message type associated with the session end event.
- `EndSessionReason` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons`): The reason for the session termination, specifying why the session is ending.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages @Msg, global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons @EndSessionReason)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage(@Msg, @EndSessionReason);
    }
}
```

<a id="api-978888ae4918"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.#ctor`

Creates the default EndSessionMessage value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.EndSessionMessage()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage();
    }
}
```

<a id="api-350df53bddfb"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Deconstruct(CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages@,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons@)`

Copies the value's components into the corresponding output parameters.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Deconstruct(out CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages Msg, out CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons EndSessionReason)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.

- `Msg` (`CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages`): The Windows message type associated with the session end event.
- `EndSessionReason` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons`): The reason for the session termination, specifying why the session is ending.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage receiver, out global::CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages @Msg, out global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons @EndSessionReason)
    {
        receiver.@Deconstruct(out @Msg, out @EndSessionReason);
    }
}
```

<a id="api-29202cf4ba63"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Equals(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage)`

Tests equality using the generated value-equality contract for EndSessionMessage.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Equals(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage`): The other supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage receiver, global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage @other, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@other)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-08f047a67d89"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Equals(System.Object)`

Tests equality using the generated value-equality contract for EndSessionMessage.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.

- `obj` (`object`): The obj supplied to this call.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage receiver, global::System.Object @obj, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@obj)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d7f77fd29e9c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.GetHashCode`

Computes a hash code consistent with the generated value-equality contract for EndSessionMessage.

```csharp
public override int CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage receiver, global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@GetHashCode()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-0ef76ca68322"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.ToString`

Formats the value using the generated EndSessionMessage representation.

```csharp
public override string CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.ToString()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage receiver, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToString()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-c4e6dc4b2868"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.op_Equality(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage)`

Tests whether both operands have equal component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.operator ==(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage left, CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage @left, global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-754432a66bd2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.op_Inequality(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage,CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage)`

Tests whether the operands have different component values.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.operator !=(CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage left, CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage`): The left supplied to this call.
- `right` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage`): The right supplied to this call.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage @left, global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-f68789323aae"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.EndSessionReason`

Gets or initializes the reason for the session termination, specifying why the session is ending.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.EndSessionReason { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage receiver)
    {
        _ = receiver.@EndSessionReason;
    }
}
```

<a id="api-67135d8790ed"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Handled`

Gets or sets a value indicating whether the message has been handled.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Handled { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:18`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage receiver)
    {
        _ = receiver.@Handled;
    }
}
```

<a id="api-693338940ab5"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Msg`

Gets or initializes the Windows message type associated with the session end event.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Msg { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:15`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage receiver)
    {
        _ = receiver.@Msg;
    }
}
```

<a id="api-f720e1476116"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Result`

Gets or sets the native result returned to the system.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage.Result { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Lifecycle/EndSessionMessage.cs:21`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage receiver)
    {
        _ = receiver.@Result;
    }
}
```
