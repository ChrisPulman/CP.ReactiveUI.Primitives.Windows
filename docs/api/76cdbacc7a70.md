<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.#ctor](#api-c663154dbf6f)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpConnectionsAccepted](#api-68ad5946cc42)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpConnectionsInitiated](#api-1e227f04364c)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpCurrentConnections](#api-f9f7608d768e)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpErrorsReceived](#api-443d784a8473)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpFailedConnectionAttempts](#api-beceb11c3b9c)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpSegmentsReceived](#api-4b24817c3ac6)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpSegmentsResent](#api-71796bf34a42)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpSegmentsSent](#api-a3d9d51591f5)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpDatagramsReceived](#api-5551bd4202f8)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpDatagramsSent](#api-1705ada5c844)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpIncomingDiscarded](#api-4391db33a9c6)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpIncomingErrors](#api-8277b8f75863)

<a id="api-c663154dbf6f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.#ctor`

Creates the default NetworkProtocolStatistics value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.NetworkProtocolStatistics()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:12`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics();
    }
}
```

<a id="api-68ad5946cc42"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpConnectionsAccepted`

Gets the cumulative accepted TCP connections.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpConnectionsAccepted { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:21`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@TcpConnectionsAccepted;
    }
}
```

<a id="api-1e227f04364c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpConnectionsInitiated`

Gets the cumulative initiated TCP connections.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpConnectionsInitiated { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:18`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@TcpConnectionsInitiated;
    }
}
```

<a id="api-f9f7608d768e"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpCurrentConnections`

Gets the current established TCP connections.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpCurrentConnections { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:15`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@TcpCurrentConnections;
    }
}
```

<a id="api-443d784a8473"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpErrorsReceived`

Gets the cumulative TCP receive errors.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpErrorsReceived { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:27`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@TcpErrorsReceived;
    }
}
```

<a id="api-beceb11c3b9c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpFailedConnectionAttempts`

Gets the cumulative failed TCP connection attempts.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpFailedConnectionAttempts { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:24`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@TcpFailedConnectionAttempts;
    }
}
```

<a id="api-4b24817c3ac6"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpSegmentsReceived`

Gets the cumulative received TCP segments.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpSegmentsReceived { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:30`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@TcpSegmentsReceived;
    }
}
```

<a id="api-71796bf34a42"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpSegmentsResent`

Gets the cumulative retransmitted TCP segments.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpSegmentsResent { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:36`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@TcpSegmentsResent;
    }
}
```

<a id="api-a3d9d51591f5"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpSegmentsSent`

Gets the cumulative sent TCP segments.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.TcpSegmentsSent { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:33`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@TcpSegmentsSent;
    }
}
```

<a id="api-5551bd4202f8"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpDatagramsReceived`

Gets the cumulative received UDP datagrams.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpDatagramsReceived { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:39`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@UdpDatagramsReceived;
    }
}
```

<a id="api-1705ada5c844"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpDatagramsSent`

Gets the cumulative sent UDP datagrams.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpDatagramsSent { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:42`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@UdpDatagramsSent;
    }
}
```

<a id="api-4391db33a9c6"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpIncomingDiscarded`

Gets the cumulative discarded incoming UDP datagrams.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpIncomingDiscarded { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:45`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@UdpIncomingDiscarded;
    }
}
```

<a id="api-8277b8f75863"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpIncomingErrors`

Gets the cumulative incoming UDP errors.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics.UdpIncomingErrors { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkProtocolStatistics.cs:48`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics receiver)
    {
        _ = receiver.@UdpIncomingErrors;
    }
}
```
