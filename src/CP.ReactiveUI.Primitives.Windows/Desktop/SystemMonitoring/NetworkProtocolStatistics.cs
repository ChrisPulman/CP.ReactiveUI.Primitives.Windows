// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Cumulative TCP and UDP statistics for one address family.</summary>
public sealed class NetworkProtocolStatistics
{
    /// <summary>Gets the current established TCP connections.</summary>
    public long TcpCurrentConnections { get; internal init; }

    /// <summary>Gets the cumulative initiated TCP connections.</summary>
    public long TcpConnectionsInitiated { get; internal init; }

    /// <summary>Gets the cumulative accepted TCP connections.</summary>
    public long TcpConnectionsAccepted { get; internal init; }

    /// <summary>Gets the cumulative failed TCP connection attempts.</summary>
    public long TcpFailedConnectionAttempts { get; internal init; }

    /// <summary>Gets the cumulative TCP receive errors.</summary>
    public long TcpErrorsReceived { get; internal init; }

    /// <summary>Gets the cumulative received TCP segments.</summary>
    public long TcpSegmentsReceived { get; internal init; }

    /// <summary>Gets the cumulative sent TCP segments.</summary>
    public long TcpSegmentsSent { get; internal init; }

    /// <summary>Gets the cumulative retransmitted TCP segments.</summary>
    public long TcpSegmentsResent { get; internal init; }

    /// <summary>Gets the cumulative received UDP datagrams.</summary>
    public long UdpDatagramsReceived { get; internal init; }

    /// <summary>Gets the cumulative sent UDP datagrams.</summary>
    public long UdpDatagramsSent { get; internal init; }

    /// <summary>Gets the cumulative discarded incoming UDP datagrams.</summary>
    public long UdpIncomingDiscarded { get; internal init; }

    /// <summary>Gets the cumulative incoming UDP errors.</summary>
    public long UdpIncomingErrors { get; internal init; }
}
