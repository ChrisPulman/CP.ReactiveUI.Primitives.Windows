// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable

using CP.ReactiveUI.Primitives.Windows.Operations;
using ClipboardSubscriptionSlot = global::ReactiveUI.Primitives.Disposables.AssignmentSlot;
using OperationVoid = global::ReactiveUI.Primitives.RxVoid;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;
#endif

/// <summary>Captures clipboard values within a scoped clipboard lock on the executing thread.</summary>
public static class ClipboardObservation
{
    /// <summary>Creates a deferred clipboard read using the current thread's default clipboard access.</summary>
    /// <typeparam name="T">The fully materialized result type.</typeparam>
    /// <param name="capture">Reads a value without retaining the access token.</param>
    /// <returns>A deferred clipboard read.</returns>
    public static WindowsOperation<T> Read<T>(Func<IClipboardAccessToken, T> capture) => Read(capture, IntPtr.Zero);

    /// <summary>Creates a deferred clipboard read on the caller's thread.</summary>
    /// <typeparam name="T">The fully materialized result type.</typeparam>
    /// <param name="capture">Reads a value without retaining the token or native clipboard memory.</param>
    /// <param name="windowHandle">The window handle used to open the clipboard.</param>
    /// <returns>A deferred operation whose capture and subscription acquire and release access synchronously.</returns>
    public static WindowsOperation<T> Read<T>(Func<IClipboardAccessToken, T> capture, IntPtr windowHandle)
    {
        Throw.IfNull(capture);
        return WindowsOperation.From(() => Capture(capture, () => ClipboardNative.Access(windowHandle)));
    }

    /// <summary>Creates a deferred clipboard write using the current thread's default clipboard access.</summary>
    /// <param name="write">Writes clipboard content without retaining the access token.</param>
    /// <returns>A deferred clipboard write.</returns>
    public static WindowsOperation<OperationVoid> Write(Action<IClipboardAccessToken> write) => Write(write, IntPtr.Zero);

    /// <summary>Creates a deferred clipboard write on the caller's thread.</summary>
    /// <param name="write">Writes clipboard content without retaining the access token.</param>
    /// <param name="windowHandle">The owning window handle used to open the clipboard.</param>
    /// <returns>A deferred operation that releases access before signaling success.</returns>
    public static WindowsOperation<OperationVoid> Write(Action<IClipboardAccessToken> write, IntPtr windowHandle)
    {
        Throw.IfNull(write);
        return WindowsOperation.From(() =>
        {
            using var token = ClipboardNative.Access(windowHandle);
            token.ThrowWhenNoAccess();
            write(token);
        });
    }

    /// <summary>Captures clipboard values on update callbacks using default clipboard access.</summary>
    /// <typeparam name="T">The fully materialized result type.</typeparam>
    /// <param name="capture">Reads a value without retaining the access token.</param>
    /// <returns>An observable of captured clipboard values.</returns>
    public static IObservable<T> Observe<T>(Func<IClipboardAccessToken, T> capture) => Observe(capture, IntPtr.Zero);

    /// <summary>Captures materialized values for clipboard updates on the existing message-window callback thread.</summary>
    /// <typeparam name="T">The fully materialized result type.</typeparam>
    /// <param name="capture">Reads a value without retaining the token or native clipboard memory.</param>
    /// <param name="windowHandle">The window handle used to open the clipboard.</param>
    /// <returns>An observable that releases clipboard access before publishing each value and forwards failures.</returns>
    /// <remarks>
    /// Subscribe using the application's STA message-loop context. Scheduling downstream notifications does not move clipboard reads.
    /// The initial value follows the existing update source's subscription semantics.
    /// </remarks>
    public static IObservable<T> Observe<T>(Func<IClipboardAccessToken, T> capture, IntPtr windowHandle)
    {
        Throw.IfNull(capture);
        return Observe(ClipboardNative.ClipboardUpdateEvents, capture, () => ClipboardNative.Access(windowHandle));
    }

    /// <summary>Observes current Unicode text using default clipboard access, returning null when unavailable.</summary>
    /// <returns>An observable of clipboard text.</returns>
    public static IObservable<string?> ObserveText() => ObserveText(IntPtr.Zero);

    /// <summary>Observes current Unicode text after clipboard updates, returning null when text is unavailable.</summary>
    /// <param name="windowHandle">The window handle used to open the clipboard.</param>
    /// <returns>An observable of text captured synchronously within clipboard access.</returns>
    public static IObservable<string?> ObserveText(IntPtr windowHandle) =>
        Observe(static token => ClipboardNative.HasFormat((uint)StandardClipboardFormats.UnicodeText) ? token.GetAsUnicodeString() : null, windowHandle);

    /// <summary>Composes scoped captures with an injected update source and access provider.</summary>
    /// <typeparam name="TUpdate">The update signal type.</typeparam>
    /// <typeparam name="T">The materialized result type.</typeparam>
    /// <param name="updates">The serialized update source.</param>
    /// <param name="capture">The synchronous read.</param>
    /// <param name="access">The access provider.</param>
    /// <returns>An observable of captured values.</returns>
    internal static IObservable<T> Observe<TUpdate, T>(IObservable<TUpdate> updates, Func<IClipboardAccessToken, T> capture, Func<IClipboardAccessToken> access)
    {
        Throw.IfNull(updates);
        Throw.IfNull(capture);
        Throw.IfNull(access);
        return new CaptureObservable<TUpdate, T>(updates, capture, access);
    }

    /// <summary>Materializes a clipboard value and releases its access token.</summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="capture">The synchronous read.</param>
    /// <param name="access">The access provider.</param>
    /// <returns>The captured value.</returns>
    internal static T Capture<T>(Func<IClipboardAccessToken, T> capture, Func<IClipboardAccessToken> access)
    {
        using var token = access();
        token.ThrowWhenNoAccess();
        return capture(token);
    }

    /// <summary>Owns the source subscription for each scoped clipboard reader.</summary>
    /// <typeparam name="TUpdate">The source signal type.</typeparam>
    /// <typeparam name="T">The materialized result type.</typeparam>
    /// <param name="updates">The serialized source.</param>
    /// <param name="capture">The synchronous reader.</param>
    /// <param name="access">The access provider.</param>
    private sealed class CaptureObservable<TUpdate, T>(
        IObservable<TUpdate> updates,
        Func<IClipboardAccessToken, T> capture,
        Func<IClipboardAccessToken> access) : IObservable<T>
    {
        /// <summary>Attaches a reader and assigns its source ownership.</summary>
        /// <param name="observer">The captured-value observer.</param>
        /// <returns>The source ownership scope.</returns>
        public IDisposable Subscribe(IObserver<T> observer)
        {
            Throw.IfNull(observer);
            var subscription = new CaptureObserver<TUpdate, T>(observer, capture, access);
            try
            {
                subscription.Assign(updates.Subscribe(subscription));
                return subscription;
            }
            catch
            {
                subscription.Dispose();
                throw;
            }
        }
    }

    /// <summary>Releases source ownership on capture failure, completion, or downstream disposal.</summary>
    /// <typeparam name="TUpdate">The source signal type.</typeparam>
    /// <typeparam name="T">The captured result type.</typeparam>
    /// <param name="observer">The downstream observer.</param>
    /// <param name="capture">The synchronous reader.</param>
    /// <param name="access">The access provider.</param>
    private sealed class CaptureObserver<TUpdate, T>(
        IObserver<T> observer,
        Func<IClipboardAccessToken, T> capture,
        Func<IClipboardAccessToken> access) : IObserver<TUpdate>, IDisposable
    {
        /// <summary>Owns the upstream subscription, including assignments after synchronous termination.</summary>
        private readonly ClipboardSubscriptionSlot _upstream = new();

        /// <summary>Assigns the upstream subscription after source attachment.</summary>
        /// <param name="subscription">The upstream subscription.</param>
        public void Assign(IDisposable subscription) => _upstream.Create(subscription);

        /// <summary>Reads and publishes a value after releasing clipboard access.</summary>
        /// <param name="value">The source update signal.</param>
        public void OnNext(TUpdate value)
        {
            if (_upstream.IsDisposed)
            {
                return;
            }

            T captured;
            try
            {
                captured = Capture(capture, access);
            }
            catch (Exception error)
            {
                OnError(error);
                return;
            }

            if (!_upstream.IsDisposed)
            {
                observer.OnNext(captured);
            }
        }

        /// <summary>Terminates observation and releases source ownership.</summary>
        /// <param name="error">The source or capture failure.</param>
        public void OnError(Exception error)
        {
            if (_upstream.IsDisposed)
            {
                return;
            }

            Dispose();
            observer.OnError(error);
        }

        /// <summary>Completes observation and releases source ownership.</summary>
        public void OnCompleted()
        {
            if (_upstream.IsDisposed)
            {
                return;
            }

            Dispose();
            observer.OnCompleted();
        }

        /// <summary>Releases the source subscription once.</summary>
        public void Dispose() => _upstream.Dispose();
    }
}
