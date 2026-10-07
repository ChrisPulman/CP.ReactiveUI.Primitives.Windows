// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Owns a timer and sampler and prevents overlapping reads or notifications after disposal.</summary>
/// <typeparam name="T">The snapshot type.</typeparam>
/// <param name="createSampler">Creates the sampler on the first tick.</param>
/// <param name="observer">Receives snapshots.</param>
/// <param name="interval">The delay after a completed sample.</param>
internal sealed class PollingSubscription<T>(Func<ISystemSampler<T>> createSampler, IObserver<T> observer, TimeSpan interval) : IDisposable
{
    /// <summary>Serializes sampler access and disposal.</summary>
    private readonly Lock _gate = new();

    /// <summary>The sampler owned by this subscription.</summary>
    private ISystemSampler<T> _sampler;

    /// <summary>The one-shot timer.</summary>
    private Timer _timer;

    /// <summary>Whether disposal was requested.</summary>
    private int _disposed;

    /// <inheritdoc />
    public void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) != 0)
        {
            return;
        }

        lock (_gate)
        {
            _timer?.Dispose();
            _sampler?.Dispose();
            _sampler = null;
        }
    }

    /// <summary>Starts asynchronous sampling.</summary>
    internal void Start()
    {
        lock (_gate)
        {
            if (Volatile.Read(ref _disposed) != 0)
            {
                return;
            }

            _timer = new(static state => ((PollingSubscription<T>)state).Tick(), this, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            _ = _timer.Change(TimeSpan.Zero, Timeout.InfiniteTimeSpan);
        }
    }

    /// <summary>Captures one sample and schedules only after it completes.</summary>
    internal void Tick()
    {
        lock (_gate)
        {
            if (Volatile.Read(ref _disposed) != 0)
            {
                return;
            }

            try
            {
                _sampler ??= createSampler();
                var sample = _sampler.Capture();
                if (Volatile.Read(ref _disposed) == 0)
                {
                    observer.OnNext(sample);
                }
            }
            catch (Exception error)
            {
                Dispose();
                observer.OnError(error);
                return;
            }

            if (Volatile.Read(ref _disposed) == 0)
            {
                _timer?.Change(interval, Timeout.InfiniteTimeSpan);
            }
        }
    }
}
