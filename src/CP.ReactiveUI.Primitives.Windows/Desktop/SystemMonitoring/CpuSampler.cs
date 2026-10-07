// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Maintains CPU performance counter sampling history.</summary>
internal sealed class CpuSampler : ISystemSampler<CpuSample>
{
    /// <summary>The maximum percentage for one logical processor.</summary>
    private const double FullUtilization = 100D;

    /// <summary>The aggregate counter instance.</summary>
    private const string TotalInstance = "_Total";

    /// <summary>English counter names in result order.</summary>
    private static readonly string[] CounterNames =
    [
        "% Processor Time", "% User Time", "% Privileged Time", "% Idle Time", "Processor Frequency",
    ];

    /// <summary>English wildcard paths shared by all subscriptions.</summary>
    private static readonly string[] CounterPaths = Array.ConvertAll(CounterNames, static name => $@"\Processor Information(*)\{name}");

    /// <summary>The subscription's performance query.</summary>
    private readonly PerformanceCounterQuery _query = new(CounterPaths);

    /// <summary>Captures processor measurements.</summary>
    /// <returns>The current CPU snapshot.</returns>
    public CpuSample Capture()
    {
        var processors = ReadProcessors(_query.Capture());
        var logical = new List<LogicalProcessorSample>();
        foreach (var processor in processors)
        {
            if (TryParseProcessorIdentity(processor.Key, out var group, out var number))
            {
                logical.Add(new LogicalProcessorSample
                {
                    InstanceName = processor.Key,
                    GroupNumber = group,
                    ProcessorNumber = number,
                    Utilization = processor.Value.ToUtilization(),
                    FrequencyMegahertz = processor.Value.Frequency,
                });
            }
        }

        logical.Sort(static (left, right) =>
        {
            var comparison = left.GroupNumber.CompareTo(right.GroupNumber);
            return comparison != 0 ? comparison : left.ProcessorNumber.CompareTo(right.ProcessorNumber);
        });
        return new CpuSample
        {
            Timestamp = TimeProvider.System.GetUtcNow(),
            LogicalProcessorCount = logical.Count,
            LogicalProcessors = logical.AsReadOnly(),
            Total = processors.TryGetValue(TotalInstance, out var total) ? total.ToUtilization() : new CpuUtilization(),
        };
    }

    /// <summary>Releases native counter resources.</summary>
    public void Dispose() => _query.Dispose();

    /// <summary>Bounds valid percentage values and preserves unavailable data.</summary>
    /// <param name="value">The formatted counter value.</param>
    /// <returns>A finite percentage or null.</returns>
    internal static double? NormalizePercentage(double? value) =>
        value is double percentage && !double.IsNaN(percentage) && !double.IsInfinity(percentage)
            ? Math.Min(FullUtilization, Math.Max(0D, percentage))
            : null;

    /// <summary>Parses a logical processor identity while rejecting aggregate instances.</summary>
    /// <param name="instance">The Windows counter identity.</param>
    /// <param name="group">The processor group.</param>
    /// <param name="processor">The group-relative processor number.</param>
    /// <returns>Whether the identity represents a logical processor.</returns>
    internal static bool TryParseProcessorIdentity(string instance, out int group, out int processor)
    {
        group = 0;
        processor = 0;
        var separator = instance.IndexOf(',');
#if NETFRAMEWORK
        return separator > 0
            && int.TryParse(instance.Remove(separator), System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out group)
            && int.TryParse(instance.Substring(separator + 1), System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out processor);
#else
        return separator > 0
            && int.TryParse(instance.AsSpan(0, separator), System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out group)
            && int.TryParse(instance.AsSpan(separator + 1), System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out processor);
#endif
    }

    /// <summary>Combines counter values by processor identity.</summary>
    /// <param name="counters">The formatted query results.</param>
    /// <returns>Values indexed by instance.</returns>
    private static Dictionary<string, ProcessorValues> ReadProcessors(IReadOnlyList<PerformanceCounterSample> counters)
    {
        var processors = new Dictionary<string, ProcessorValues>(StringComparer.Ordinal);
        foreach (var counter in counters)
        {
#if NETFRAMEWORK
            if (!processors.TryGetValue(counter.InstanceName, out var values))
            {
                values = new();
                processors.Add(counter.InstanceName, values);
            }
#else
            ref var values = ref CollectionsMarshal.GetValueRefOrAddDefault(processors, counter.InstanceName, out _);
            values ??= new();
#endif

            for (var index = 0; index < CounterPaths.Length; index++)
            {
                if (string.Equals(counter.CounterPath, CounterPaths[index], StringComparison.Ordinal))
                {
                    values.Assign(index, counter.Value);
                    break;
                }
            }
        }

        return processors;
    }

    /// <summary>Accumulates related measurements for one processor instance.</summary>
    private sealed class ProcessorValues
    {
        /// <summary>The formatted measurements in counter path order.</summary>
        private readonly double?[] _values = new double?[CounterPaths.Length];

        /// <summary>Gets the current frequency in megahertz.</summary>
        public double? Frequency => _values[CounterPaths.Length - 1] is double frequency && frequency > 0 && !double.IsInfinity(frequency) ? frequency : null;

        /// <summary>Assigns one formatted measurement.</summary>
        /// <param name="index">The counter's index in the path array.</param>
        /// <param name="value">The current counter value.</param>
        public void Assign(int index, double? value) => _values[index] = value;

        /// <summary>Builds the utilization snapshot.</summary>
        /// <returns>The current utilization rates.</returns>
        public CpuUtilization ToUtilization() => new()
        {
            TotalPercent = NormalizePercentage(_values[0]),
            UserPercent = NormalizePercentage(_values[1]),
            KernelPercent = NormalizePercentage(_values[2]),
            IdlePercent = NormalizePercentage(_values[3]),
        };
    }
}
