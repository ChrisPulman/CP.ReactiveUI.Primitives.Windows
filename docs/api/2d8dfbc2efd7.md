<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.#ctor](#api-451d73802335)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.BytesReceived](#api-59ef5bea2780)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.BytesSent](#api-2d46fc59f281)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Description](#api-0ce1a8e435f9)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.DhcpEnabled](#api-af79eb5dc514)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.DnsAddresses](#api-b0d96f2c08a8)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.GatewayAddresses](#api-aa8a17860b9a)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Id](#api-4e5d922bc2f1)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IncomingPacketErrors](#api-4011b5f4e01a)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IncomingPacketsDiscarded](#api-5ac94d4de71f)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IncomingUnknownProtocolPackets](#api-46002035d8e2)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.InterfaceType](#api-1dec85c11074)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IpAddresses](#api-d792f87236ca)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.LinkSpeedBitsPerSecond](#api-7d96ed6a35d3)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.MacAddress](#api-0fc9b908a2c1)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Name](#api-fec578b6732a)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.NonUnicastPacketsReceived](#api-22efee7eaef4)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.NonUnicastPacketsSent](#api-5bc9d0d5bd2a)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.OutgoingPacketErrors](#api-2a6512ffc0d7)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.OutgoingPacketsDiscarded](#api-687484280d0d)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.ReceiveBytesPerSecond](#api-629335b7b05c)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.ReceiveUtilizationPercent](#api-a659c05b76a0)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.SendBytesPerSecond](#api-bbeab558dfab)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.SendUtilizationPercent](#api-9aa0320ca7e3)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Status](#api-77cccc20cf0b)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.UnicastPacketsReceived](#api-adb8a5f11f2e)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.UnicastPacketsSent](#api-6af0c38cf434)

<a id="api-451d73802335"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.#ctor`

Creates the default NetworkInterfaceSnapshot value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.NetworkInterfaceSnapshot()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:14`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot();
    }
}
```

<a id="api-59ef5bea2780"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.BytesReceived`

Gets the cumulative received bytes.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.BytesReceived { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:50`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@BytesReceived;
    }
}
```

<a id="api-2d46fc59f281"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.BytesSent`

Gets the cumulative sent bytes.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.BytesSent { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:53`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@BytesSent;
    }
}
```

<a id="api-0ce1a8e435f9"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Description`

Gets the adapter description.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Description { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:23`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@Description;
    }
}
```

<a id="api-af79eb5dc514"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.DhcpEnabled`

Gets the IPv4 DHCP configuration, or null when unavailable.

```csharp
public bool? CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.DhcpEnabled { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:47`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@DhcpEnabled;
    }
}
```

<a id="api-b0d96f2c08a8"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.DnsAddresses`

Gets the configured DNS server addresses.

```csharp
public System.Collections.Generic.IReadOnlyList<string> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.DnsAddresses { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:41`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@DnsAddresses;
    }
}
```

<a id="api-aa8a17860b9a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.GatewayAddresses`

Gets the configured gateway addresses.

```csharp
public System.Collections.Generic.IReadOnlyList<string> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.GatewayAddresses { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:44`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@GatewayAddresses;
    }
}
```

<a id="api-4e5d922bc2f1"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Id`

Gets the persistent interface identifier.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Id { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:17`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@Id;
    }
}
```

<a id="api-4011b5f4e01a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IncomingPacketErrors`

Gets the cumulative incoming packet errors.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IncomingPacketErrors { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:68`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@IncomingPacketErrors;
    }
}
```

<a id="api-5ac94d4de71f"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IncomingPacketsDiscarded`

Gets the cumulative discarded incoming packets.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IncomingPacketsDiscarded { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:74`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@IncomingPacketsDiscarded;
    }
}
```

<a id="api-46002035d8e2"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IncomingUnknownProtocolPackets`

Gets the cumulative packets with unknown protocols.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IncomingUnknownProtocolPackets { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:80`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@IncomingUnknownProtocolPackets;
    }
}
```

<a id="api-1dec85c11074"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.InterfaceType`

Gets the adapter type.

```csharp
public System.Net.NetworkInformation.NetworkInterfaceType CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.InterfaceType { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:29`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@InterfaceType;
    }
}
```

<a id="api-d792f87236ca"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IpAddresses`

Gets the unicast IP addresses.

```csharp
public System.Collections.Generic.IReadOnlyList<string> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.IpAddresses { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:38`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@IpAddresses;
    }
}
```

<a id="api-7d96ed6a35d3"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.LinkSpeedBitsPerSecond`

Gets the reported link speed in bits per second.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.LinkSpeedBitsPerSecond { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:35`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@LinkSpeedBitsPerSecond;
    }
}
```

<a id="api-0fc9b908a2c1"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.MacAddress`

Gets the physical address as hexadecimal digits.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.MacAddress { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:26`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@MacAddress;
    }
}
```

<a id="api-fec578b6732a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Name`

Gets the friendly interface name.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Name { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:20`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@Name;
    }
}
```

<a id="api-22efee7eaef4"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.NonUnicastPacketsReceived`

Gets the cumulative received multicast and broadcast packets.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.NonUnicastPacketsReceived { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:62`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@NonUnicastPacketsReceived;
    }
}
```

<a id="api-5bc9d0d5bd2a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.NonUnicastPacketsSent`

Gets the cumulative sent multicast and broadcast packets.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.NonUnicastPacketsSent { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:65`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@NonUnicastPacketsSent;
    }
}
```

<a id="api-2a6512ffc0d7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.OutgoingPacketErrors`

Gets the cumulative outgoing packet errors.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.OutgoingPacketErrors { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:71`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@OutgoingPacketErrors;
    }
}
```

<a id="api-687484280d0d"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.OutgoingPacketsDiscarded`

Gets the cumulative discarded outgoing packets.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.OutgoingPacketsDiscarded { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:77`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@OutgoingPacketsDiscarded;
    }
}
```

<a id="api-629335b7b05c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.ReceiveBytesPerSecond`

Gets the receive throughput, or null before a comparable pair of samples.

```csharp
public double? CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.ReceiveBytesPerSecond { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:83`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@ReceiveBytesPerSecond;
    }
}
```

<a id="api-a659c05b76a0"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.ReceiveUtilizationPercent`

Gets the receive throughput as a percentage of link speed.

```csharp
public double? CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.ReceiveUtilizationPercent { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:89`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@ReceiveUtilizationPercent;
    }
}
```

<a id="api-bbeab558dfab"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.SendBytesPerSecond`

Gets the send throughput, or null before a comparable pair of samples.

```csharp
public double? CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.SendBytesPerSecond { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:86`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@SendBytesPerSecond;
    }
}
```

<a id="api-9aa0320ca7e3"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.SendUtilizationPercent`

Gets the send throughput as a percentage of link speed.

```csharp
public double? CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.SendUtilizationPercent { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:92`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@SendUtilizationPercent;
    }
}
```

<a id="api-77cccc20cf0b"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Status`

Gets the link operational status.

```csharp
public System.Net.NetworkInformation.OperationalStatus CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.Status { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:32`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@Status;
    }
}
```

<a id="api-adb8a5f11f2e"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.UnicastPacketsReceived`

Gets the cumulative received unicast packets.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.UnicastPacketsReceived { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:56`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@UnicastPacketsReceived;
    }
}
```

<a id="api-6af0c38cf434"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.UnicastPacketsSent`

Gets the cumulative sent unicast packets.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot.UnicastPacketsSent { get; internal init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/NetworkInterfaceSnapshot.cs:59`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot receiver)
    {
        _ = receiver.@UnicastPacketsSent;
    }
}
```
