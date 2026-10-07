// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Owns the state and resources for one monitoring subscription.</summary>
/// <typeparam name="T">The snapshot type.</typeparam>
internal interface ISystemSampler<out T> : IDisposable
{
    /// <summary>Captures the next snapshot.</summary>
    /// <returns>The captured snapshot.</returns>
    T Capture();
}
