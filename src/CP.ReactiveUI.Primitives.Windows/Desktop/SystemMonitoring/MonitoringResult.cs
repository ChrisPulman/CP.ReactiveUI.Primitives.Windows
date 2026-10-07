// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A provider result that keeps expected failures separate from measured values.</summary>
/// <typeparam name="T">The provider snapshot type.</typeparam>
public sealed class MonitoringResult<T>
{
    /// <summary>The Windows access-denied error code.</summary>
    private const int AccessDeniedError = 5;

    /// <summary>Initializes a new instance of the <see cref="MonitoringResult{T}"/> class.</summary>
    /// <param name="status">The capture outcome.</param>
    /// <param name="value">The measured snapshot.</param>
    /// <param name="error">The failure description.</param>
    private MonitoringResult(MonitoringStatus status, T? value, string? error)
    {
        Status = status;
        Value = value;
        Error = error;
        CapturedAt = TimeProvider.System.GetUtcNow();
    }

    /// <summary>Gets the capture outcome.</summary>
    public MonitoringStatus Status { get; }

    /// <summary>Gets the snapshot, or the default value when unavailable.</summary>
    public T? Value { get; }

    /// <summary>Gets the failure description, if any.</summary>
    public string? Error { get; }

    /// <summary>Gets when this result was captured; cached results retain their original time.</summary>
    public DateTimeOffset CapturedAt { get; }

    /// <summary>Gets whether this result contains a captured snapshot.</summary>
    public bool IsAvailable => Status == MonitoringStatus.Available;

    /// <summary>Creates an unrequested result.</summary>
    /// <returns>An unrequested result.</returns>
    internal static MonitoringResult<T> NotRequested() => new(MonitoringStatus.NotRequested, default, null);

    /// <summary>Captures a provider while preserving an independent failure result.</summary>
    /// <param name="capture">The provider operation.</param>
    /// <returns>The measured value or classified failure.</returns>
    internal static MonitoringResult<T> Capture(Func<T> capture)
    {
        try
        {
            return new(MonitoringStatus.Available, capture(), null);
        }
        catch (UnauthorizedAccessException error)
        {
            return new(MonitoringStatus.AccessDenied, default, error.Message);
        }
        catch (NativeWin32Exception error)
        {
            return new(error.NativeErrorCode == AccessDeniedError ? MonitoringStatus.AccessDenied : MonitoringStatus.Failed, default, error.Message);
        }
        catch (NotSupportedException error)
        {
            return new(MonitoringStatus.Unavailable, default, error.Message);
        }
        catch (Exception error)
        {
            return new(MonitoringStatus.Failed, default, error.Message);
        }
    }
}
