// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Net.NetworkInformation;
#if REACTIVE_TEST_SHIM
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies network counter continuity and read-only native capture.</summary>
public sealed class NetworkMonitoringTests
{
    /// <summary>Incoming bytes in the fixture.</summary>
    private const long ReceivedCounter = 200;

    /// <summary>Outgoing bytes in the fixture.</summary>
    private const long SentCounter = 100;

    /// <summary>Known receive rate for the test counter pair.</summary>
    private const double ExpectedReceiveRate = 100D;

    /// <summary>Known send rate for the test counter pair.</summary>
    private const double ExpectedSendRate = 50D;

    /// <summary>Elapsed seconds used to derive the directional rates.</summary>
    private const double RateIntervalSeconds = 2D;

    /// <summary>Verifies that receive and send deltas use elapsed seconds independently.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task CalculateRate_ContinuousCounters_UsesDirectionalDelta()
    {
        var previous = CreateInterface(0, 0);
        var current = CreateInterface(ReceivedCounter, SentCounter);
        await Assert.That(NetworkSampler.CalculateRate(previous, current, RateIntervalSeconds, true)).IsEqualTo(ExpectedReceiveRate);
        await Assert.That(NetworkSampler.CalculateRate(previous, current, RateIntervalSeconds, false)).IsEqualTo(ExpectedSendRate);
    }

    /// <summary>Verifies that a reset counter cannot become negative throughput.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task CalculateRate_ResetCounter_ReturnsUnavailable()
    {
        var previous = CreateInterface(ReceivedCounter, ReceivedCounter);
        var current = CreateInterface(0, 0);
        await Assert.That(NetworkSampler.CalculateRate(previous, current, 1, true)).IsNull();
        await Assert.That(NetworkSampler.CalculateRate(previous, current, 1, false)).IsNull();
    }

    /// <summary>Verifies identity reuse does not use the removed adapter baseline.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task CalculateRate_ReusedIdentity_ReturnsUnavailable()
    {
        var previous = CreateInterface(0, 0);
        var current = CreateInterface(ReceivedCounter, SentCounter, "different-adapter");
        await Assert.That(NetworkSampler.CalculateRate(previous, current, 1, true)).IsNull();
    }

    /// <summary>Verifies a disconnected interface does not report throughput.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task CalculateRate_DisconnectedInterface_ReturnsUnavailable()
    {
        var previous = CreateInterface(0, 0);
        var current = new NetworkInterfaceSnapshot { Id = previous.Id, MacAddress = previous.MacAddress, Status = OperationalStatus.Down };
        await Assert.That(NetworkSampler.CalculateRate(previous, current, 1, true)).IsNull();
    }

    /// <summary>Verifies nonpositive and nonfinite intervals cannot create a rate.</summary>
    /// <param name="seconds">The invalid elapsed interval.</param>
    /// <returns>The assertion task.</returns>
    [Test]
    [Arguments(0D)]
    [Arguments(-1D)]
    [Arguments(double.NaN)]
    [Arguments(double.PositiveInfinity)]
    public async Task CalculateRate_InvalidElapsedTime_ReturnsUnavailable(double seconds)
    {
        await Assert.That(NetworkSampler.CalculateRate(CreateInterface(0, 0), CreateInterface(ReceivedCounter, SentCounter), seconds, true)).IsNull();
    }

    /// <summary>Verifies native capture leaves initial rates unavailable.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Capture_FirstSnapshot_HasNoRateBaseline()
    {
        var snapshot = NetworkMonitoring.Capture();
        foreach (var adapter in snapshot.Interfaces)
        {
            await Assert.That(adapter.Id).IsNotNull();
            await Assert.That(adapter.ReceiveBytesPerSecond).IsNull();
            await Assert.That(adapter.SendBytesPerSecond).IsNull();
            await Assert.That(adapter.BytesReceived >= 0).IsTrue();
        }

        await Assert.That(snapshot.Timestamp.Offset).IsEqualTo(TimeSpan.Zero);
    }

    /// <summary>Verifies the optional connection snapshot is independently readable.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task CaptureConnections_ReadOnlyNativeSnapshot_HasProtocolCounters()
    {
        var snapshot = NetworkMonitoring.CaptureConnections();
        await Assert.That(snapshot.Ipv4.TcpSegmentsReceived >= 0).IsTrue();
        await Assert.That(snapshot.Ipv4.UdpDatagramsReceived >= 0).IsTrue();
        foreach (var connection in snapshot.TcpConnections)
        {
            await Assert.That(connection.LocalEndpoint.Length > 0).IsTrue();
            await Assert.That(connection.RemoteEndpoint.Length > 0).IsTrue();
        }
    }

    /// <summary>Creates a stable interface identity with controlled byte counters.</summary>
    /// <param name="received">The incoming counter.</param>
    /// <param name="sent">The outgoing counter.</param>
    /// <param name="physicalAddress">The physical identity.</param>
    /// <returns>The controlled sample.</returns>
    private static NetworkInterfaceSnapshot CreateInterface(long received, long sent, string physicalAddress = "adapter") => new()
    {
        Id = "interface",
        MacAddress = physicalAddress,
        Status = OperationalStatus.Up,
        BytesReceived = received,
        BytesSent = sent,
    };
}
