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

/// <summary>Owns one asynchronous WMI query and guards completion/cancellation callbacks.</summary>
internal sealed class WmiQueryOperation : IDisposable
{
    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    private readonly ManagementObjectSearcher _searcher;

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    private readonly ManualResetEventSlim _completed = new();

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    private readonly ManagementOperationObserver _observer = new();

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    private readonly Lock _gate = new();

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    private readonly List<WmiRow> _rows = new();

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    private bool _accepting = true;

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    private WmiQueryStatus _status;

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    private string? _error;

    /// <summary>Initializes a new instance of the <see cref="WmiQueryOperation"/> class.</summary>
    /// <param name="namespacePath">The namespacePath value.</param>
    /// <param name="wql">The wql value.</param>
    internal WmiQueryOperation(string namespacePath, string wql)
    {
        _searcher = new(namespacePath, wql);
        _observer.ObjectReady += OnObjectReady;
        _observer.Completed += OnCompleted;
    }

    /// <summary>Unsubscribes callbacks before releasing the searcher and completion signal.</summary>
    public void Dispose()
    {
        lock (_gate)
        {
            _accepting = false;
            _observer.ObjectReady -= OnObjectReady;
            _observer.Completed -= OnCompleted;
            _searcher.Dispose();
            _completed.Dispose();
        }
    }

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    /// <param name="timeout">The timeout value.</param>
    /// <returns>The captured or projected value.</returns>
    internal WmiQueryResult Execute(TimeSpan timeout)
    {
        try
        {
            _searcher.Get(_observer);
            if (!_completed.Wait(timeout))
            {
                SetFailure(WmiQueryStatus.TimedOut, "The provider query exceeded its timeout.");
                lock (_gate)
                {
                    _accepting = false;
                }

                _observer.Cancel();
            }
        }
        catch (ManagementException exception)
        {
            SetFailure(WindowsManagement.MapStatus(exception.ErrorCode), exception.Message);
        }
        catch (Exception exception) when (exception is UnauthorizedAccessException or System.Security.SecurityException)
        {
            SetFailure(WmiQueryStatus.AccessDenied, exception.Message);
        }
        catch (Exception exception) when (exception is COMException or InvalidOperationException or PlatformNotSupportedException)
        {
            SetFailure(WmiQueryStatus.Failed, exception.Message);
        }

        lock (_gate)
        {
            _accepting = false;
            return new(_status, _rows.AsReadOnly(), _error);
        }
    }

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    /// <param name="sender">The sender value.</param>
    /// <param name="args">The args value.</param>
    private void OnObjectReady(object sender, ObjectReadyEventArgs args)
    {
        using var item = args.NewObject;
        lock (_gate)
        {
            if (!_accepting)
            {
                return;
            }

            try
            {
                _rows.Add(WindowsManagement.Detach(item));
            }
            catch (Exception exception) when (exception is ManagementException or InvalidOperationException or COMException)
            {
                SetFailure(WmiQueryStatus.Failed, exception.Message);
            }
        }
    }

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    /// <param name="sender">The sender value.</param>
    /// <param name="args">The args value.</param>
    private void OnCompleted(object sender, CompletedEventArgs args)
    {
        lock (_gate)
        {
            if (!_accepting)
            {
                return;
            }

            if (args.Status != ManagementStatus.NoError)
            {
                SetFailure(WindowsManagement.MapStatus(args.Status), args.Status.ToString());
            }

            _completed.Set();
        }
    }

    /// <summary>Reads or manages WmiQueryOperation state.</summary>
    /// <param name="status">The status value.</param>
    /// <param name="error">The error value.</param>
    private void SetFailure(WmiQueryStatus status, string error)
    {
        lock (_gate)
        {
            if (_status != WmiQueryStatus.TimedOut)
            {
                _status = status;
                _error = error;
            }
        }
    }
}
