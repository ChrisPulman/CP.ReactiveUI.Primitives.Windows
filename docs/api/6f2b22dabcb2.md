<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.#ctor](#api-36998c8755a6)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.Ipv4](#api-4736bcda7c44)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.Ipv6](#api-14a455c5b7ae)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.TcpConnections](#api-441f347347cb)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.TcpListeners](#api-07282a08b7de)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.Timestamp](#api-ffa13cf5a691)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.UdpListeners](#api-e719b90a9a63)

<a id="api-36998c8755a6"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.#ctor`

Creates the default NetworkConnectionsSnapshot value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.NetworkConnectionsSnapshot()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkConnectionsSnapshot.cs:12`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot();
    }
}
```

<a id="api-4736bcda7c44"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.Ipv4`

Gets the IPv4 TCP and UDP cumulative statistics.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.Ipv4 { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkConnectionsSnapshot.cs:27`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot receiver)
    {
        _ = receiver.@Ipv4;
    }
}
```

<a id="api-14a455c5b7ae"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.Ipv6`

Gets the IPv6 TCP and UDP cumulative statistics.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.Ipv6 { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkConnectionsSnapshot.cs:30`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot receiver)
    {
        _ = receiver.@Ipv6;
    }
}
```

<a id="api-441f347347cb"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.TcpConnections`

Gets the TCP connections with local and remote endpoints.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkTcpConnection> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.TcpConnections { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkConnectionsSnapshot.cs:18`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot receiver)
    {
        _ = receiver.@TcpConnections;
    }
}
```

<a id="api-07282a08b7de"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.TcpListeners`

Gets the TCP listening endpoints.

```csharp
public System.Collections.Generic.IReadOnlyList<string> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.TcpListeners { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkConnectionsSnapshot.cs:21`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot receiver)
    {
        _ = receiver.@TcpListeners;
    }
}
```

<a id="api-ffa13cf5a691"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.Timestamp`

Gets the UTC capture time.

```csharp
public System.DateTimeOffset CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.Timestamp { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkConnectionsSnapshot.cs:15`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot receiver)
    {
        _ = receiver.@Timestamp;
    }
}
```

<a id="api-e719b90a9a63"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.UdpListeners`

Gets the UDP listening endpoints.

```csharp
public System.Collections.Generic.IReadOnlyList<string> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot.UdpListeners { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkConnectionsSnapshot.cs:24`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot receiver)
    {
        _ = receiver.@UdpListeners;
    }
}
```
