// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Owns a lazily opened provider and optionally caches slow inventory results.</summary>
/// <typeparam name="T">The provider snapshot type.</typeparam>
/// <param name="enabled">Whether the provider is selected.</param>
/// <param name="createSampler">Creates independent provider state.</param>
/// <param name="refreshInterval">How long a result is retained, or zero to read every cycle.</param>
internal sealed class ProviderSlot<T>(bool enabled, Func<ISystemSampler<T>> createSampler, TimeSpan refreshInterval) : IDisposable
{
    /// <summary>Serializes provider capture and resource release.</summary>
    private readonly Lock _gate = new();

    /// <summary>The lazily opened sampler.</summary>
    private ISystemSampler<T>? _sampler;

    /// <summary>The last capture result.</summary>
    private MonitoringResult<T> _result = MonitoringResult<T>.NotRequested();

    /// <summary>The earliest time for another capture.</summary>
    private DateTimeOffset _refreshAfter;

    /// <summary>Whether this slot has been disposed.</summary>
    private int _disposed;

    /// <inheritdoc />
    public void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) == 0)
        {
            lock (_gate)
            {
                _sampler?.Dispose();
                _sampler = null;
            }
        }
    }

    /// <summary>Captures the provider without letting its failure terminate unrelated providers.</summary>
    /// <param name="now">The sampling cycle time.</param>
    /// <returns>The current or cached provider result.</returns>
    internal MonitoringResult<T> Capture(DateTimeOffset now)
    {
        lock (_gate)
        {
            Throw.IfDisposed(Volatile.Read(ref _disposed) != 0, this);
            if (!enabled || now < _refreshAfter)
            {
                return _result;
            }

            _result = MonitoringResult<T>.Capture(Read);
            _refreshAfter = now.Add(refreshInterval);
            return _result;
        }
    }

    /// <summary>Opens provider state only when it is first sampled.</summary>
    /// <returns>The next provider snapshot.</returns>
    private T Read()
    {
        _sampler ??= createSampler();
        return _sampler.Capture();
    }
}
