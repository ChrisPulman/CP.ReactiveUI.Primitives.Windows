// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
using System.Management;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Owns a native WMI event watcher and serializes callback delivery with disposal.</summary>
internal sealed class WmiEventSubscription : IDisposable
{
    /// <summary>Serializes callback delivery and disposal.</summary>
    private readonly Lock _gate = new();

    /// <summary>The native event watcher.</summary>
    private readonly ManagementEventWatcher _watcher;

    /// <summary>The destination observer.</summary>
    private readonly IObserver<WmiRow> _observer;

    /// <summary>Completes when native startup has returned, so cancellation cannot race it.</summary>
    private readonly TaskCompletionSource<bool> _startFinished = new(TaskCreationOptions.RunContinuationsAsynchronously);

    /// <summary>Whether no more events may be delivered.</summary>
    private bool _disposed;

    /// <summary>Whether a native event query has been submitted.</summary>
    private bool _started;

    /// <summary>Initializes a new instance of the <see cref="WmiEventSubscription"/> class.</summary>
    /// <param name="namespacePath">The provider namespace.</param>
    /// <param name="wql">The event query.</param>
    /// <param name="observer">The destination observer.</param>
    internal WmiEventSubscription(string namespacePath, string wql, IObserver<WmiRow> observer)
    {
        _watcher = new(namespacePath, wql);
        _observer = observer;
        _watcher.EventArrived += OnEvent;
        _watcher.Stopped += OnStopped;
    }

    /// <summary>Stops native event delivery and releases the watcher.</summary>
    public void Dispose()
    {
        lock (_gate)
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            _watcher.EventArrived -= OnEvent;
            _watcher.Stopped -= OnStopped;
            if (!_started)
            {
                _watcher.Dispose();
                return;
            }
        }

        // WMI cancellation can call back or stall inside COM. Unsubscription returns promptly.
        // One worker owns eventual Stop/Dispose and no callback can reach the observer again.
        _ = ReleaseAfterStart(_startFinished.Task, ReleaseWatcher);
    }

    /// <summary>Schedules native cancellation after startup has finished, outside a native callback.</summary>
    /// <param name="started">Completion of the startup call.</param>
    /// <param name="release">The resource release operation.</param>
    /// <returns>The asynchronous release operation.</returns>
    internal static Task ReleaseAfterStart(Task started, Action release) =>
        started.ContinueWith(
            static (_, state) =>
            {
                if (state is Action action)
                {
                    action();
                }
            },
            release,
            CancellationToken.None,
            TaskContinuationOptions.None,
            TaskScheduler.Default);

    /// <summary>Starts provider events or reports the native startup error.</summary>
    internal void Start()
    {
        lock (_gate)
        {
            if (_disposed)
            {
                return;
            }

            _started = true;
        }

        try
        {
            _watcher.Start();
        }
        catch (Exception exception) when (exception is ManagementException or UnauthorizedAccessException or COMException or InvalidOperationException)
        {
            lock (_gate)
            {
                if (!_disposed)
                {
                    _observer.OnError(exception);
                }
            }

            Dispose();
        }
        finally
        {
            _ = _startFinished.TrySetResult(true);
        }
    }

    /// <summary>Delivers a detached provider event.</summary>
    /// <param name="sender">The native watcher.</param>
    /// <param name="args">The provider event.</param>
    private void OnEvent(object sender, EventArrivedEventArgs args)
    {
        using var item = args.NewEvent;
        lock (_gate)
        {
            if (!_disposed)
            {
                _observer.OnNext(WindowsManagement.Detach(item));
            }
        }
    }

    /// <summary>Reports unexpected provider termination.</summary>
    /// <param name="sender">The native watcher.</param>
    /// <param name="args">The stop status.</param>
    private void OnStopped(object sender, StoppedEventArgs args)
    {
        lock (_gate)
        {
            if (!_disposed)
            {
                _observer.OnError(new ManagementException($"WMI event delivery stopped: {args.Status}."));
            }
        }

        Dispose();
    }

    /// <summary>Cancels the native subscription outside its own callback stack.</summary>
    private void ReleaseWatcher()
    {
        try
        {
            _watcher.Stop();
        }
        catch (Exception exception) when (exception is ManagementException or COMException or InvalidOperationException)
        {
            Trace.TraceError("WMI watcher cancellation failed: {0}", exception.Message);
        }
        finally
        {
            _watcher.Dispose();
        }
    }
}
