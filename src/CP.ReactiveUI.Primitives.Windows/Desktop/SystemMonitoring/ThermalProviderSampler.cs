// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Owns a provider created by the fluent monitor's sensor factory.</summary>
internal sealed class ThermalProviderSampler : ISystemSampler<ThermalSnapshot>
{
    /// <summary>The subscription-specific sensor provider.</summary>
    private IThermalSensorProvider _provider;

    /// <summary>Initializes a new instance of the <see cref="ThermalProviderSampler"/> class.</summary>
    /// <param name="createProvider">Creates an independent vendor provider.</param>
    internal ThermalProviderSampler(Func<IThermalSensorProvider> createProvider) =>
        _provider = createProvider() ?? throw new InvalidOperationException("The sensor provider factory returned null.");

    /// <inheritdoc />
    public ThermalSnapshot Capture()
    {
        var provider = Volatile.Read(ref _provider);
        Throw.IfDisposed(provider is null, this);
        return ThermalMonitoring.Capture(provider);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (Interlocked.Exchange(ref _provider, null) is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
