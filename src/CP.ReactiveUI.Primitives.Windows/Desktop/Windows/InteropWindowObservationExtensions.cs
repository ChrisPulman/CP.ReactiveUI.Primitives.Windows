// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Operations;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
#endif

/// <summary>Composes window queries, commands, and native change notifications.</summary>
public static class InteropWindowObservationExtensions
{
    /// <summary>Composes operations and observations for a native window.</summary>
    /// <param name="window">The window to query or modify.</param>
    extension(IInteropWindow window)
    {
        /// <summary>Filters notifications to this window's own window object.</summary>
        /// <param name="events">The event stream to filter.</param>
        /// <returns>The matching notifications.</returns>
        public IObservable<WinEventInfo> ObserveEvents(IObservable<WinEventInfo> events)
        {
            Throw.IfNull(window);
            Throw.IfNull(events);
            return events.Where(info => info.Window.Handle == window.Handle && info.IsSelf && WinEventHook.IsWindowObject(info));
        }

        /// <summary>Observes subsequent caption changes. Subscribe and dispose on one pumped thread; synchronous reads can reenter an owned window's message handler.</summary>
        /// <returns>Changed captions without an initial snapshot.</returns>
        public IObservable<string> ObserveCaptionChanges()
        {
            Throw.IfNull(window);
            return ObserveChanges(window, WinEventHook.ObserveWindowTitleChanges(), WinEvents.EVENT_OBJECT_NAMECHANGE, () => ReadCaption(window));
        }

        /// <summary>Observes subsequent bounds changes. Subscribe and dispose on the same thread with a running message pump.</summary>
        /// <returns>Changed bounds without an initial snapshot.</returns>
        public IObservable<NativeRect> ObserveBoundsChanges()
        {
            Throw.IfNull(window);
            return ObserveChanges(window, WinEventHook.ObserveWinEvents(WinEvents.EVENT_OBJECT_LOCATIONCHANGE), WinEvents.EVENT_OBJECT_LOCATIONCHANGE, () => window.GetInfo(forceUpdate: true).Bounds);
        }

        /// <summary>Creates a deferred caption query on the executing thread; synchronous reads can reenter an owned window's message handler.</summary>
        /// <returns>The composable query.</returns>
        public WindowsOperation<string> CaptionOperation()
        {
            Throw.IfNull(window);
            return WindowsOperation.From(() => ReadCaption(window));
        }

        /// <summary>Creates a deferred maximize command on the calling or subscribing thread.</summary>
        /// <returns>The composable command.</returns>
        public WindowsOperation<IInteropWindow> MaximizeOperation()
        {
            Throw.IfNull(window);
            return WindowsOperation.From(() => window.Maximize());
        }

        /// <summary>Creates a deferred minimize command on the calling or subscribing thread.</summary>
        /// <returns>The composable command.</returns>
        public WindowsOperation<IInteropWindow> MinimizeOperation()
        {
            Throw.IfNull(window);
            return WindowsOperation.From(() => window.Minimize());
        }

        /// <summary>Creates a deferred restore command on the calling or subscribing thread.</summary>
        /// <returns>The composable command.</returns>
        public WindowsOperation<IInteropWindow> RestoreOperation()
        {
            Throw.IfNull(window);
            return WindowsOperation.From(() => window.Restore());
        }

        /// <summary>Creates a deferred move command on the calling or subscribing thread.</summary>
        /// <param name="location">The target location.</param>
        /// <returns>The composable command.</returns>
        public WindowsOperation<IInteropWindow> MoveToOperation(NativePoint location)
        {
            Throw.IfNull(window);
            return WindowsOperation.From(() => window.MoveTo(location));
        }
    }

    /// <summary>Reads changing state only when a matching notification arrives.</summary>
    /// <typeparam name="T">The state type.</typeparam>
    /// <param name="window">The window to monitor.</param>
    /// <param name="events">The event source.</param>
    /// <param name="eventType">The notification to observe.</param>
    /// <param name="read">The current-state query.</param>
    /// <returns>Distinct changed values.</returns>
    internal static IObservable<T> ObserveChanges<T>(IInteropWindow window, IObservable<WinEventInfo> events, WinEvents eventType, Func<T> read)
    {
        Throw.IfNull(read);
        return window.ObserveEvents(events).Where(info => info.WinEvent == eventType).Select(_ => read()).DistinctUntilChanged();
    }

    /// <summary>Reads the native caption, including for a window owned by the callback thread.</summary>
    /// <param name="window">The window to query.</param>
    /// <returns>The current caption.</returns>
    private static string ReadCaption(IInteropWindow window)
    {
        var caption = User32Api.GetText(window.Handle);
        window.Caption = caption;
        return caption;
    }
}
