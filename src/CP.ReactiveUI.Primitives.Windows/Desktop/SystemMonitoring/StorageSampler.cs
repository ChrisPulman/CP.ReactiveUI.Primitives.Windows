// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.ObjectModel;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Owns disk counter history and captures drive capacities.</summary>
internal sealed class StorageSampler : ISystemSampler<StorageSnapshot>
{
    /// <summary>A complete utilization percentage.</summary>
    private const double FullPercent = 100D;

    /// <summary>The counters sampled for each disk.</summary>
    private static readonly string[] CounterPaths =
    {
        @"\PhysicalDisk(*)\% Idle Time",
        @"\PhysicalDisk(*)\Disk Read Bytes/sec",
        @"\PhysicalDisk(*)\Disk Write Bytes/sec",
        @"\PhysicalDisk(*)\Disk Reads/sec",
        @"\PhysicalDisk(*)\Disk Writes/sec",
        @"\PhysicalDisk(*)\Current Disk Queue Length",
        @"\PhysicalDisk(*)\Avg. Disk sec/Read",
        @"\PhysicalDisk(*)\Avg. Disk sec/Write",
    };

    /// <summary>The disk query, acquired lazily by its first capture.</summary>
    private readonly PerformanceCounterQuery _query = new(CounterPaths);

    /// <inheritdoc/>
    public StorageSnapshot Capture()
    {
        var drives = new List<StorageDriveSnapshot>();
        foreach (var drive in DriveInfo.GetDrives())
        {
            drives.Add(CaptureDrive(drive));
        }

        return new StorageSnapshot
        {
            Timestamp = TimeProvider.System.GetUtcNow(),
            Drives = drives.AsReadOnly(),
            PhysicalDisks = MapCounters(_query.Capture()),
        };
    }

    /// <inheritdoc/>
    public void Dispose() => _query.Dispose();

    /// <summary>Maps native counter samples to disk instances without inferring health.</summary>
    /// <param name="samples">The formatted PDH samples.</param>
    /// <returns>Disk performance snapshots with native availability statuses.</returns>
    internal static IReadOnlyList<StorageDiskSnapshot> MapCounters(IReadOnlyList<PerformanceCounterSample> samples)
    {
        var instances = new Dictionary<string, Dictionary<string, PerformanceCounterSample>>(StringComparer.OrdinalIgnoreCase);
        foreach (var sample in samples)
        {
#if NETFRAMEWORK
            if (!instances.TryGetValue(sample.InstanceName, out var counters))
            {
                counters = [with(StringComparer.OrdinalIgnoreCase)];
                instances.Add(sample.InstanceName, counters);
            }
#else
            ref var entry = ref CollectionsMarshal.GetValueRefOrAddDefault(instances, sample.InstanceName, out _);
            entry ??= [];
            var counters = entry;
#endif

            var name = sample.CounterPath.Substring(sample.CounterPath.LastIndexOf('\\') + 1);
            counters[name] = sample;
        }

        var results = new List<StorageDiskSnapshot>(instances.Count);
        foreach (var instance in instances)
        {
            var counters = instance.Value;
            var idle = Value(counters, "% Idle Time");
            var statuses = new Dictionary<string, uint>(counters.Count, StringComparer.OrdinalIgnoreCase);
            foreach (var counter in counters)
            {
                statuses.Add(counter.Key, counter.Value.Status);
            }

            results.Add(new StorageDiskSnapshot
            {
                InstanceName = instance.Key,
                ActiveTimePercent = idle.HasValue ? Math.Max(0, Math.Min(FullPercent, FullPercent - idle.Value)) : null,
                ReadBytesPerSecond = Value(counters, "Disk Read Bytes/sec"),
                WriteBytesPerSecond = Value(counters, "Disk Write Bytes/sec"),
                ReadsPerSecond = Value(counters, "Disk Reads/sec"),
                WritesPerSecond = Value(counters, "Disk Writes/sec"),
                CurrentQueueLength = Value(counters, "Current Disk Queue Length"),
                AverageReadLatencySeconds = Value(counters, "Avg. Disk sec/Read"),
                AverageWriteLatencySeconds = Value(counters, "Avg. Disk sec/Write"),
                CounterStatuses = new ReadOnlyDictionary<string, uint>(statuses),
            });
        }

        return results.AsReadOnly();
    }

    /// <summary>Reads a valid nonnegative counter value.</summary>
    /// <param name="counters">The instance counters.</param>
    /// <param name="name">The English counter name.</param>
    /// <returns>The value, or null when the counter is invalid or unavailable.</returns>
    private static double? Value(Dictionary<string, PerformanceCounterSample> counters, string name) =>
        counters.TryGetValue(name, out var counter) && counter.Status <= 1 && counter.Value >= 0 &&
        !double.IsNaN(counter.Value.Value) && !double.IsInfinity(counter.Value.Value) ? counter.Value : null;

    /// <summary>Captures capacity while tolerating removal and inaccessible media.</summary>
    /// <param name="drive">The logical drive.</param>
    /// <returns>The capacity or an explicit unavailability error.</returns>
    private static StorageDriveSnapshot CaptureDrive(DriveInfo drive)
    {
        try
        {
            var ready = drive.IsReady;
            return new StorageDriveSnapshot
            {
                Name = drive.Name,
                DriveType = drive.DriveType,
                IsReady = ready,
                VolumeLabel = ready ? drive.VolumeLabel : string.Empty,
                DriveFormat = ready ? drive.DriveFormat : string.Empty,
                TotalBytes = ready ? drive.TotalSize : null,
                AvailableFreeBytes = ready ? drive.AvailableFreeSpace : null,
                TotalFreeBytes = ready ? drive.TotalFreeSpace : null,
            };
        }
        catch (IOException exception)
        {
            return new StorageDriveSnapshot { Name = drive.Name, Error = exception.Message };
        }
        catch (UnauthorizedAccessException exception)
        {
            return new StorageDriveSnapshot { Name = drive.Name, Error = exception.Message };
        }
    }
}
