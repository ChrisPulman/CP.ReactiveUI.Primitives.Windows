// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Creates independent, serialized monitoring subscriptions.</summary>
internal static class SystemPolling
{
    /// <summary>The maximum supported timer interval in milliseconds.</summary>
    private const double MaximumIntervalMilliseconds = uint.MaxValue - 1D;

    /// <summary>Creates a cold observable with a fresh sampler for each subscriber.</summary>
    /// <typeparam name="T">The snapshot type.</typeparam>
    /// <param name="createSampler">Creates subscription state.</param>
    /// <param name="interval">The delay between completed samples.</param>
    /// <returns>A stream sampling on the thread pool, starting immediately.</returns>
    internal static IObservable<T> Observe<T>(Func<ISystemSampler<T>> createSampler, TimeSpan interval)
    {
        Throw.IfNull(createSampler);
        ValidateInterval(interval);
        return ReactiveSignal.CreateSafe<T>(observer =>
        {
            var subscription = new PollingSubscription<T>(createSampler, observer, interval);
            subscription.Start();
            return subscription;
        });
    }

    /// <summary>Validates an interval accepted by a Windows timer.</summary>
    /// <param name="interval">The requested delay.</param>
    internal static void ValidateInterval(TimeSpan interval)
    {
        if (interval.TotalMilliseconds < 1D || interval.TotalMilliseconds > MaximumIntervalMilliseconds)
        {
            throw new ArgumentOutOfRangeException(nameof(interval), "The sampling interval must be at least one millisecond and within the Windows timer range.");
        }
    }
}
