// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Adapts a stateless capture function to the sampler contract.</summary>
/// <typeparam name="T">The snapshot type.</typeparam>
/// <param name="capture">The capture operation.</param>
internal sealed class DelegateSampler<T>(Func<T> capture) : ISystemSampler<T>
{
    /// <inheritdoc />
    public T Capture() => capture();

    /// <inheritdoc />
    public void Dispose()
    {
    }
}
