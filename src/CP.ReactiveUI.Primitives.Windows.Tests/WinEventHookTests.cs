// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Tests native window-title notifications.</summary>
public class WinEventHookTests
{
    /// <summary>The maximum time allowed for native event delivery.</summary>
    private const int EventTimeoutSeconds = 5;

    /// <summary>Verifies that a native title change reaches the hook's owning message loop.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task TestWinEventHookAsync()
    {
        const string expectedCaption = "TestWinEventHook - Test";
        var ready = new TaskCompletionSource<IntPtr>(TaskCreationOptions.RunContinuationsAsynchronously);
        var notification = new TaskCompletionSource<IInteropWindow>(TaskCreationOptions.RunContinuationsAsynchronously);
        var stopped = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        System.Windows.Threading.Dispatcher? dispatcher = null;
        var thread = new Thread(() => RunMessageLoop(value => dispatcher = value, ready, notification, stopped))
        {
            IsBackground = true,
            Name = "WinEventHook test message loop",
        };
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();

        try
        {
            var handle = await AwaitWithTimeoutAsync(ready.Task);
            await Assert.That(handle).IsNotEqualTo(IntPtr.Zero);
            var ownerDispatcher = dispatcher ?? throw new InvalidOperationException("The native window owner was not initialized.");
            var titleChanged = await ownerDispatcher.InvokeAsync(() =>
            {
                if (User32Api.SetWindowText(handle, expectedCaption) == 0)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                return true;
            });
            await Assert.That(titleChanged).IsTrue();

            var observedWindow = await AwaitWithTimeoutAsync(notification.Task);

            // Caption retrieval deliberately avoids the window's owning thread.
            _ = observedWindow.Fill();
            await Assert.That(observedWindow.Handle).IsEqualTo(handle);
            await Assert.That(observedWindow.Caption).IsEqualTo(expectedCaption);
            using var currentProcess = Process.GetCurrentProcess();
            await Assert.That(observedWindow.ProcessId).IsEqualTo(currentProcess.Id);
        }
        finally
        {
            dispatcher?.BeginInvokeShutdown(System.Windows.Threading.DispatcherPriority.Send);
            await AwaitWithTimeoutAsync(stopped.Task);
        }
    }

    /// <summary>Owns the native window and event hook on a pumped STA thread.</summary>
    /// <param name="setDispatcher">Publishes the owning dispatcher before signaling readiness.</param>
    /// <param name="ready">Signals that the native message loop is processing work.</param>
    /// <param name="notification">Receives the matching native window notification.</param>
    /// <param name="stopped">Signals that the native resources have been disposed.</param>
    private static void RunMessageLoop(
        Action<System.Windows.Threading.Dispatcher> setDispatcher,
        TaskCompletionSource<IntPtr> ready,
        TaskCompletionSource<IInteropWindow> notification,
        TaskCompletionSource<bool> stopped)
    {
        try
        {
            var dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            setDispatcher(dispatcher);
            using var window = new Form { Text = "WinEventHook initial title" };
            var handle = window.Handle;

            // Out-of-context hooks deliver callbacks on the registering thread's message loop.
            using var subscription = System.ObservableExtensions.Subscribe(
                WinEventHook.ObserveWindowTitleChanges(),
                info =>
                {
                    if (info.Window.Handle != handle)
                    {
                        return;
                    }

                    _ = notification.TrySetResult(info.Window);
                },
                error => _ = notification.TrySetException(error));

            // Readiness is dispatched only after the message pump starts.
            _ = dispatcher.BeginInvoke(new Action(() => ready.TrySetResult(handle)));
            System.Windows.Threading.Dispatcher.Run();
        }
        catch (Exception exception)
        {
            _ = ready.TrySetException(exception);
            _ = notification.TrySetException(exception);
            _ = stopped.TrySetException(exception);
        }
        finally
        {
            _ = stopped.TrySetResult(true);
        }
    }

    /// <summary>Awaits native readiness, delivery, or shutdown within the bounded test deadline.</summary>
    /// <typeparam name="T">The task result type.</typeparam>
    /// <param name="task">The task to await.</param>
    /// <returns>The completed task result.</returns>
    private static async Task<T> AwaitWithTimeoutAsync<T>(Task<T> task)
    {
        using var timeoutCancellation = new CancellationTokenSource();
        var timeout = Task.Delay(TimeSpan.FromSeconds(EventTimeoutSeconds), timeoutCancellation.Token);
        if (!ReferenceEquals(await Task.WhenAny(task, timeout), task))
        {
            throw new TimeoutException("The native window operation did not complete before the timeout elapsed.");
        }

#if NET8_0_OR_GREATER
        await timeoutCancellation.CancelAsync();
#else
        timeoutCancellation.Cancel();
#endif
        return await task;
    }
}
