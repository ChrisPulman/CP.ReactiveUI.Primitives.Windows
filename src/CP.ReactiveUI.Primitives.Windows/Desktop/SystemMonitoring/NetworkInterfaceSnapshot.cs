// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Net.NetworkInformation;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Configuration and cumulative traffic counters for one network interface.</summary>
public sealed class NetworkInterfaceSnapshot
{
    /// <summary>Gets the persistent interface identifier.</summary>
    public string Id { get; internal init; } = string.Empty;

    /// <summary>Gets the friendly interface name.</summary>
    public string Name { get; internal init; } = string.Empty;

    /// <summary>Gets the adapter description.</summary>
    public string Description { get; internal init; } = string.Empty;

    /// <summary>Gets the physical address as hexadecimal digits.</summary>
    public string MacAddress { get; internal init; } = string.Empty;

    /// <summary>Gets the adapter type.</summary>
    public NetworkInterfaceType InterfaceType { get; internal init; }

    /// <summary>Gets the link operational status.</summary>
    public OperationalStatus Status { get; internal init; }

    /// <summary>Gets the reported link speed in bits per second.</summary>
    public long LinkSpeedBitsPerSecond { get; internal init; }

    /// <summary>Gets the unicast IP addresses.</summary>
    public IReadOnlyList<string> IpAddresses { get; internal init; } = Array.Empty<string>();

    /// <summary>Gets the configured DNS server addresses.</summary>
    public IReadOnlyList<string> DnsAddresses { get; internal init; } = Array.Empty<string>();

    /// <summary>Gets the configured gateway addresses.</summary>
    public IReadOnlyList<string> GatewayAddresses { get; internal init; } = Array.Empty<string>();

    /// <summary>Gets the IPv4 DHCP configuration, or null when unavailable.</summary>
    public bool? DhcpEnabled { get; internal init; }

    /// <summary>Gets the cumulative received bytes.</summary>
    public long BytesReceived { get; internal init; }

    /// <summary>Gets the cumulative sent bytes.</summary>
    public long BytesSent { get; internal init; }

    /// <summary>Gets the cumulative received unicast packets.</summary>
    public long UnicastPacketsReceived { get; internal init; }

    /// <summary>Gets the cumulative sent unicast packets.</summary>
    public long UnicastPacketsSent { get; internal init; }

    /// <summary>Gets the cumulative received multicast and broadcast packets.</summary>
    public long NonUnicastPacketsReceived { get; internal init; }

    /// <summary>Gets the cumulative sent multicast and broadcast packets.</summary>
    public long NonUnicastPacketsSent { get; internal init; }

    /// <summary>Gets the cumulative incoming packet errors.</summary>
    public long IncomingPacketErrors { get; internal init; }

    /// <summary>Gets the cumulative outgoing packet errors.</summary>
    public long OutgoingPacketErrors { get; internal init; }

    /// <summary>Gets the cumulative discarded incoming packets.</summary>
    public long IncomingPacketsDiscarded { get; internal init; }

    /// <summary>Gets the cumulative discarded outgoing packets.</summary>
    public long OutgoingPacketsDiscarded { get; internal init; }

    /// <summary>Gets the cumulative packets with unknown protocols.</summary>
    public long IncomingUnknownProtocolPackets { get; internal init; }

    /// <summary>Gets the receive throughput, or null before a comparable pair of samples.</summary>
    public double? ReceiveBytesPerSecond { get; internal set; }

    /// <summary>Gets the send throughput, or null before a comparable pair of samples.</summary>
    public double? SendBytesPerSecond { get; internal set; }

    /// <summary>Gets the receive throughput as a percentage of link speed.</summary>
    public double? ReceiveUtilizationPercent { get; internal set; }

    /// <summary>Gets the send throughput as a percentage of link speed.</summary>
    public double? SendUtilizationPercent { get; internal set; }
}
