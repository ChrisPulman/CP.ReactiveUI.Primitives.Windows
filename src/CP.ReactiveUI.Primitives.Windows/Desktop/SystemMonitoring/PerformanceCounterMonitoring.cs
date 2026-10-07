// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Observes English Windows performance counters.</summary>
public static class PerformanceCounterMonitoring
{
    /// <summary>Observes formatted values with an independent PDH query per subscriber.</summary>
    /// <param name="englishCounterPaths">English PDH paths, including wildcard instance paths.</param>
    /// <param name="interval">The positive polling interval.</param>
    /// <returns>Counter samples; unavailable and initial rate values have null values.</returns>
    public static IObservable<IReadOnlyList<PerformanceCounterSample>> Observe(IEnumerable<string> englishCounterPaths, TimeSpan interval)
    {
        var paths = PerformanceCounterQuery.ValidatePaths(englishCounterPaths);
        return SystemPolling.Observe(() => new PerformanceCounterQuery(paths), interval);
    }
}
