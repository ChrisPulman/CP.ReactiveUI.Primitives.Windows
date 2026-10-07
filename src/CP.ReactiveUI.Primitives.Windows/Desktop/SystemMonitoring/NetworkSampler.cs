// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Net.NetworkInformation;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Maintains subscription-local network counter baselines.</summary>
internal sealed class NetworkSampler : ISystemSampler<NetworkSnapshot>
{
    /// <summary>Converts bytes per second into a percentage of bits per second.</summary>
    private const double BytesToBitsPercent = 800D;

    /// <summary>The last successful sample by interface identity.</summary>
    private Dictionary<string, NetworkInterfaceSnapshot> _previous = [];

    /// <summary>The monotonic timestamp of the previous capture.</summary>
    private long _previousTimestamp;

    /// <summary>Whether this sampler has been disposed.</summary>
    private bool _disposed;

    /// <inheritdoc/>
    public NetworkSnapshot Capture()
    {
        Throw.IfDisposed(_disposed, this);

        var timestamp = Stopwatch.GetTimestamp();
        var seconds = _previousTimestamp == 0 ? 0 : (timestamp - _previousTimestamp) / (double)Stopwatch.Frequency;
        var current = new Dictionary<string, NetworkInterfaceSnapshot>(StringComparer.Ordinal);
        var errors = new List<string>();
        foreach (var adapter in NetworkInterface.GetAllNetworkInterfaces())
        {
            try
            {
                var sample = CaptureInterface(adapter);
                if (_previous.TryGetValue(sample.Id, out var previous))
                {
                    sample.ReceiveBytesPerSecond = CalculateRate(previous, sample, seconds, true);
                    sample.SendBytesPerSecond = CalculateRate(previous, sample, seconds, false);
                    sample.ReceiveUtilizationPercent = Utilization(sample.ReceiveBytesPerSecond, sample.LinkSpeedBitsPerSecond);
                    sample.SendUtilizationPercent = Utilization(sample.SendBytesPerSecond, sample.LinkSpeedBitsPerSecond);
                }

                current[sample.Id] = sample;
            }
            catch (NetworkInformationException exception)
            {
                errors.Add($"{adapter.Id}: {exception.Message}");
            }
        }

        var interfaces = new NetworkInterfaceSnapshot[current.Count];
        current.Values.CopyTo(interfaces, 0);
        _previous = current;
        _previousTimestamp = timestamp;
        return new NetworkSnapshot
        {
            Timestamp = TimeProvider.System.GetUtcNow(),
            Interfaces = Array.AsReadOnly(interfaces),
            Errors = errors.AsReadOnly(),
        };
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _disposed = true;
        _previous.Clear();
    }

    /// <summary>Calculates a rate only for a continuous identity and monotonic counter.</summary>
    /// <param name="previous">The baseline snapshot.</param>
    /// <param name="current">The current snapshot.</param>
    /// <param name="seconds">Elapsed monotonic seconds.</param>
    /// <param name="receive">Whether to calculate incoming traffic.</param>
    /// <returns>Bytes per second, or null for a discontinuity.</returns>
    internal static double? CalculateRate(NetworkInterfaceSnapshot previous, NetworkInterfaceSnapshot current, double seconds, bool receive)
    {
        if (seconds <= 0 || double.IsNaN(seconds) || double.IsInfinity(seconds) ||
            !SameInterface(previous, current))
        {
            return null;
        }

        var before = receive ? previous.BytesReceived : previous.BytesSent;
        var after = receive ? current.BytesReceived : current.BytesSent;
        return before < 0 || after < before ? null : (after - before) / seconds;
    }

    /// <summary>Checks the interface identity and operational continuity.</summary>
    /// <param name="previous">The baseline snapshot.</param>
    /// <param name="current">The current snapshot.</param>
    /// <returns>Whether the samples represent the same active link.</returns>
    private static bool SameInterface(NetworkInterfaceSnapshot previous, NetworkInterfaceSnapshot current) =>
        previous.Id == current.Id && StringComparer.Ordinal.Equals(previous.MacAddress, current.MacAddress) &&
        previous.InterfaceType == current.InterfaceType && previous.LinkSpeedBitsPerSecond == current.LinkSpeedBitsPerSecond &&
        previous.Status == OperationalStatus.Up && current.Status == OperationalStatus.Up;

    /// <summary>Converts directional throughput to link utilization.</summary>
    /// <param name="rate">Bytes per second.</param>
    /// <param name="speed">Bits per second.</param>
    /// <returns>The directional percentage when speed is known.</returns>
    private static double? Utilization(double? rate, long speed) => speed <= 0 ? null : rate * BytesToBitsPercent / speed;

    /// <summary>Copies interface metadata and counters without retaining live adapter objects.</summary>
    /// <param name="adapter">The interface to sample.</param>
    /// <returns>The interface snapshot.</returns>
    private static NetworkInterfaceSnapshot CaptureInterface(NetworkInterface adapter)
    {
        var properties = adapter.GetIPProperties();
        var statistics = adapter.GetIPStatistics();
        var addresses = new List<string>(properties.UnicastAddresses.Count);
        foreach (var address in properties.UnicastAddresses)
        {
            addresses.Add(address.Address.ToString());
        }

        var dns = new List<string>(properties.DnsAddresses.Count);
        foreach (var address in properties.DnsAddresses)
        {
            dns.Add(address.ToString());
        }

        var gateways = new List<string>(properties.GatewayAddresses.Count);
        foreach (var address in properties.GatewayAddresses)
        {
            gateways.Add(address.Address.ToString());
        }

        return new NetworkInterfaceSnapshot
        {
            Id = adapter.Id,
            Name = adapter.Name,
            Description = adapter.Description,
            MacAddress = adapter.GetPhysicalAddress().ToString(),
            InterfaceType = adapter.NetworkInterfaceType,
            Status = adapter.OperationalStatus,
            LinkSpeedBitsPerSecond = adapter.Speed,
            IpAddresses = addresses.AsReadOnly(),
            DnsAddresses = dns.AsReadOnly(),
            GatewayAddresses = gateways.AsReadOnly(),
            DhcpEnabled = adapter.Supports(NetworkInterfaceComponent.IPv4) ? properties.GetIPv4Properties()?.IsDhcpEnabled : null,
            BytesReceived = statistics.BytesReceived,
            BytesSent = statistics.BytesSent,
            UnicastPacketsReceived = statistics.UnicastPacketsReceived,
            UnicastPacketsSent = statistics.UnicastPacketsSent,
            NonUnicastPacketsReceived = statistics.NonUnicastPacketsReceived,
            NonUnicastPacketsSent = statistics.NonUnicastPacketsSent,
            IncomingPacketErrors = statistics.IncomingPacketsWithErrors,
            OutgoingPacketErrors = statistics.OutgoingPacketsWithErrors,
            IncomingPacketsDiscarded = statistics.IncomingPacketsDiscarded,
            OutgoingPacketsDiscarded = statistics.OutgoingPacketsDiscarded,
            IncomingUnknownProtocolPackets = statistics.IncomingUnknownProtocolPackets,
        };
    }
}
