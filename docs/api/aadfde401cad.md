<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult

Package: `CP.ReactiveUI.Primitives.Windows.Integrations`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.#ctor(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle,CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus)](#api-8dfd82a21d24)
- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.#ctor(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle,CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus,System.Int32,System.String)](#api-b9d42135bf12)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.Channel](#api-f11f6325cc89)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.Message](#api-049764f71cb4)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.NativeStatus](#api-0bd51bb2529c)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.Status](#api-e0d4e2681e88)

<a id="api-8dfd82a21d24"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.#ctor(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle,CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.CitrixVirtualChannelOpenResult(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle channel, CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus status)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelOpenResult.cs:13`.

- `channel` (`CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle`): The opened channel.
- `status` (`CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus`): The operation status.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle @channel, global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus @status)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult(@channel, @status);
    }
}
```

<a id="api-b9d42135bf12"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.#ctor(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle,CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus,System.Int32,System.String)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.CitrixVirtualChannelOpenResult(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle channel, CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus status, int nativeStatus, string message)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelOpenResult.cs:23`.

- `channel` (`CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle`): The opened channel.
- `status` (`CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus`): The operation status.
- `nativeStatus` (`int`): The optional host status code.
- `message` (`string`): The optional host status message.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle @channel, global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus @status, global::System.Int32 @nativeStatus, global::System.String @message)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult(@channel, @status, @nativeStatus, @message);
    }
}
```

<a id="api-f11f6325cc89"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.Channel`

Gets the opened channel.

```csharp
public CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.Channel { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelOpenResult.cs:32`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult receiver)
    {
        _ = receiver.@Channel;
    }
}
```

<a id="api-049764f71cb4"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.Message`

Gets the optional host status message.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.Message { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelOpenResult.cs:41`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult receiver)
    {
        _ = receiver.@Message;
    }
}
```

<a id="api-0bd51bb2529c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.NativeStatus`

Gets the optional host status code.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.NativeStatus { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelOpenResult.cs:38`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult receiver)
    {
        _ = receiver.@NativeStatus;
    }
}
```

<a id="api-e0d4e2681e88"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.Status`

Gets the operation status.

```csharp
public CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult.Status { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelOpenResult.cs:35`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult receiver)
    {
        _ = receiver.@Status;
    }
}
```
