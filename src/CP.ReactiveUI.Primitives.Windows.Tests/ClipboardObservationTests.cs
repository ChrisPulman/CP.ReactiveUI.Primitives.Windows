// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies clipboard capture ownership without accessing the system clipboard.</summary>
public sealed class ClipboardObservationTests
{
    /// <summary>The managed value captured from a synthetic update.</summary>
    private const int CapturedValue = 42;

    /// <summary>Retains unavailable clipboard values as null notifications.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Observe_UnavailableValuePublishesNullAsync()
    {
        using var updates = new Signal<int>();
        var token = new FakeToken();
        var notifications = 0;
        string observed = "previous";
        using var subscription = System.ObservableExtensions.Subscribe(
            ClipboardObservation.Observe<int, string>(updates, static _ => null, () => token),
            value =>
            {
                notifications++;
                observed = value;
            });
        updates.OnNext(1);
        await Assert.That(notifications).IsEqualTo(1);
        await Assert.That(observed).IsNull();
        await Assert.That(token.IsDisposed).IsTrue();
    }

    /// <summary>Captures on the update thread and releases access before notifying consumers.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Observe_CapturesOnCallbackThreadAndReleasesBeforeNotificationAsync()
    {
        using var updates = new Signal<int>();
        var token = new FakeToken();
        var captures = 0;
        var thread = Environment.CurrentManagedThreadId;
        var captureThread = 0;
        var disposedAtNotification = false;
        var observed = 0;
        var values = ClipboardObservation.Observe(
            updates,
            access =>
            {
                captures++;
                captureThread = Environment.CurrentManagedThreadId;
                return CapturedValue;
            },
            () => token);
        using var subscription = System.ObservableExtensions.Subscribe(values, value =>
        {
            observed = value;
            disposedAtNotification = token.IsDisposed;
        });
        await Assert.That(captures).IsEqualTo(0);
        thread = Environment.CurrentManagedThreadId;
        updates.OnNext(1);
        await Assert.That(captureThread).IsEqualTo(thread);
        await Assert.That(observed).IsEqualTo(CapturedValue);
        await Assert.That(disposedAtNotification).IsTrue();
    }

    /// <summary>Forwards read failures and detaches the update source.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Observe_CaptureFailureReleasesTokenAndDetachesAsync()
    {
        var state = new SourceState();
        var source = Signal.CreateWithState<int, SourceState>(state, static (sourceState, observer) =>
        {
            sourceState.Observer = observer;
            return Scope.Create(sourceState, static value => value.Detached++);
        });
        var token = new FakeToken();
        var failure = new InvalidOperationException("Read failed.");
        Exception received = null;
        using var subscription = System.ObservableExtensions.Subscribe(
            ClipboardObservation.Observe<int, int>(source, _ => throw failure, () => token),
            static _ => { },
            error => received = error);
        state.Observer.OnNext(1);
        await Assert.That(received).IsSameReferenceAs(failure);
        await Assert.That(token.IsDisposed).IsTrue();
        await Assert.That(state.Detached).IsEqualTo(1);
    }

    /// <summary>Releases a source returned after capture fails during synchronous subscription.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Observe_SynchronousCaptureFailureDetachesLateAssignedSourceAsync()
    {
        var state = new SourceState();
        var source = Signal.CreateWithState<int, SourceState>(state, static (sourceState, observer) =>
        {
            observer.OnNext(1);
            return Scope.Create(sourceState, static value => value.Detached++);
        });
        var token = new FakeToken();
        var failure = new InvalidOperationException("Initial read failed.");
        Exception received = null;
        using var subscription = System.ObservableExtensions.Subscribe(
            ClipboardObservation.Observe<int, int>(source, _ => throw failure, () => token),
            static _ => { },
            error => received = error);
        await Assert.That(received).IsSameReferenceAs(failure);
        await Assert.That(token.IsDisposed).IsTrue();
        await Assert.That(state.Detached).IsEqualTo(1);
    }

    /// <summary>Prevents reads after observation disposal.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Observe_DisposalStopsClipboardAccessAsync()
    {
        using var updates = new Signal<int>();
        var accesses = 0;
        var subscription = System.ObservableExtensions.Subscribe(
            ClipboardObservation.Observe(updates, static _ => 1, () =>
            {
                accesses++;
                return new FakeToken();
            }),
            static _ => { });
        subscription.Dispose();
        updates.OnNext(1);
        await Assert.That(accesses).IsEqualTo(0);
    }

    /// <summary>Tracks a synthetic update subscription and its disposal.</summary>
    private sealed class SourceState
    {
        /// <summary>Gets or sets the source's subscribed observer.</summary>
        public IObserver<int> Observer { get; set; }

        /// <summary>Gets or sets the number of source detachments.</summary>
        public int Detached { get; set; }
    }

    /// <summary>Models scoped clipboard ownership using managed state.</summary>
    private sealed class FakeToken : IClipboardAccessToken
    {
        /// <summary>Gets whether capture released clipboard ownership.</summary>
        public bool IsDisposed { get; private set; }

        /// <summary>Gets whether this token permits access.</summary>
        public bool CanAccess => !IsDisposed;

        /// <summary>Gets whether acquiring the token timed out.</summary>
        public bool IsLockTimeout => false;

        /// <summary>Gets whether opening the clipboard timed out.</summary>
        public bool IsOpenTimeout => false;

        /// <summary>Rejects access after token disposal.</summary>
        public void ThrowWhenNoAccess()
        {
            if (IsDisposed)
            {
                throw new InvalidOperationException("Token disposed.");
            }
        }

        /// <summary>Releases managed ownership.</summary>
        public void Dispose() => IsDisposed = true;
    }
}
