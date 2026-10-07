// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Net.NetworkInformation;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Captures network configuration, throughput, and optional connection tables.</summary>
public static class NetworkMonitoring
{
    /// <summary>The shared BCL address-change stream.</summary>
    private static readonly IObservable<NetworkSnapshot> AddressChanges = ReactiveSignal.CreateSafe<NetworkSnapshot>(observer =>
    {
        NetworkAddressChangedEventHandler handler = (_, _) =>
        {
            try
            {
                observer.OnNext(Capture());
            }
            catch (NetworkInformationException exception)
            {
                observer.OnError(exception);
            }
        };
        NetworkChange.NetworkAddressChanged += handler;
        return Scope.Create(handler, static registered => NetworkChange.NetworkAddressChanged -= registered);
    }).Share();

    /// <summary>The shared BCL availability-change stream.</summary>
    private static readonly IObservable<bool> AvailabilityChanges = ReactiveSignal.CreateSafe<bool>(observer =>
    {
        NetworkAvailabilityChangedEventHandler handler = (_, change) => observer.OnNext(change.IsAvailable);
        NetworkChange.NetworkAvailabilityChanged += handler;
        return Scope.Create(handler, static registered => NetworkChange.NetworkAvailabilityChanged -= registered);
    }).Share();

    /// <summary>Captures interface counters; rates require observation over time and are null.</summary>
    /// <returns>The current interface snapshot.</returns>
    public static NetworkSnapshot Capture()
    {
        using var sampler = new NetworkSampler();
        return sampler.Capture();
    }

    /// <summary>Observes interface snapshots immediately and at the requested interval.</summary>
    /// <param name="interval">A positive sampling interval.</param>
    /// <returns>A stream with independent delta state for each subscription.</returns>
    public static IObservable<NetworkSnapshot> Observe(TimeSpan interval) => SystemPolling.Observe(static () => new NetworkSampler(), interval);

    /// <summary>Observes address changes through a shared BCL event subscription.</summary>
    /// <returns>Fresh interface snapshots after address changes, with no initial emission or rate baseline.</returns>
    public static IObservable<NetworkSnapshot> ObserveAddressChanges() => AddressChanges;

    /// <summary>Observes network availability changes through a shared BCL event subscription.</summary>
    /// <returns>Availability notifications without an initial emission.</returns>
    public static IObservable<bool> ObserveAvailabilityChanges() => AvailabilityChanges;

    /// <summary>Reads TCP connections, listening endpoints, and protocol statistics on demand.</summary>
    /// <returns>A fresh snapshot of connection tables and cumulative counters.</returns>
    public static NetworkConnectionsSnapshot CaptureConnections()
    {
        var properties = IPGlobalProperties.GetIPGlobalProperties();
        var connections = properties.GetActiveTcpConnections();
        var tcp = new NetworkTcpConnection[connections.Length];
        for (var index = 0; index < connections.Length; index++)
        {
            var connection = connections[index];
            tcp[index] = new NetworkTcpConnection
            {
                LocalEndpoint = connection.LocalEndPoint.ToString(),
                RemoteEndpoint = connection.RemoteEndPoint.ToString(),
                State = connection.State,
            };
        }

        var tcpListeners = new List<string>();
        foreach (var endpoint in properties.GetActiveTcpListeners())
        {
            tcpListeners.Add(endpoint.ToString());
        }

        var udpListeners = new List<string>();
        foreach (var endpoint in properties.GetActiveUdpListeners())
        {
            udpListeners.Add(endpoint.ToString());
        }

        return new NetworkConnectionsSnapshot
        {
            Timestamp = TimeProvider.System.GetUtcNow(),
            TcpConnections = Array.AsReadOnly(tcp),
            TcpListeners = tcpListeners.AsReadOnly(),
            UdpListeners = udpListeners.AsReadOnly(),
            Ipv4 = CaptureStatistics(properties.GetTcpIPv4Statistics(), properties.GetUdpIPv4Statistics()),
            Ipv6 = CaptureStatistics(properties.GetTcpIPv6Statistics(), properties.GetUdpIPv6Statistics()),
        };
    }

    /// <summary>Copies cumulative protocol counters.</summary>
    /// <param name="tcp">The TCP statistics.</param>
    /// <param name="udp">The UDP statistics.</param>
    /// <returns>The typed counter snapshot.</returns>
    private static NetworkProtocolStatistics CaptureStatistics(TcpStatistics tcp, UdpStatistics udp) => new()
    {
        TcpCurrentConnections = tcp.CurrentConnections,
        TcpConnectionsInitiated = tcp.ConnectionsInitiated,
        TcpConnectionsAccepted = tcp.ConnectionsAccepted,
        TcpFailedConnectionAttempts = tcp.FailedConnectionAttempts,
        TcpErrorsReceived = tcp.ErrorsReceived,
        TcpSegmentsReceived = tcp.SegmentsReceived,
        TcpSegmentsSent = tcp.SegmentsSent,
        TcpSegmentsResent = tcp.SegmentsResent,
        UdpDatagramsReceived = udp.DatagramsReceived,
        UdpDatagramsSent = udp.DatagramsSent,
        UdpIncomingDiscarded = udp.IncomingDatagramsDiscarded,
        UdpIncomingErrors = udp.IncomingDatagramsWithErrors,
    };
}
