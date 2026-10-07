// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies raw-input callback failures and subscription ownership without native input.</summary>
public sealed class RawInputMonitorTests
{
    /// <summary>The synthetic message-window handle.</summary>
    private const long WindowHandle = 42;

    /// <summary>The native invalid-parameter error reported by registration failures.</summary>
    private const int RegistrationErrorCode = 87;

    /// <summary>Forwards registration failures and disposes both sources, including synchronous assignment.</summary>
    /// <param name="synchronous">Whether the handle is supplied during subscription.</param>
    /// <returns>The assertion task.</returns>
    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task Observe_RegistrationFailureDetachesBothSourcesAsync(bool synchronous)
    {
        var source = new MessageSource();
        source.Handles.InitialValue = synchronous ? WindowHandle : 0;
        var expected = new Win32Exception(RegistrationErrorCode);
        Exception actual = null;
        var stopped = 0;
        using var subscription = RawInputMonitor.CreateObservation(
            source,
            WindowsMessages.WM_INPUT,
            _ => throw expected,
            static _ => new RawInputEventArgs(),
            () => stopped++).Subscribe(static _ => { }, error => actual = error);
        if (!synchronous)
        {
            source.Handles.Observer.OnNext(WindowHandle);
        }

        await Assert.That(ReferenceEquals(actual, expected)).IsTrue();
        await Assert.That(source.MessagesStream.Disposals).IsEqualTo(1);
        await Assert.That(source.Handles.Disposals).IsEqualTo(1);
        await Assert.That(stopped).IsEqualTo(1);
    }

    /// <summary>Forwards read exceptions and prevents native work after termination.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Observe_ReadFailureRejectsLateCallbacksAsync()
    {
        var source = new MessageSource();
        var expected = new Win32Exception(RegistrationErrorCode);
        var reads = 0;
        var registrations = 0;
        var errors = 0;
        Exception actual = null;
        using var subscription = RawInputMonitor.CreateObservation<RawInputEventArgs>(
            source,
            WindowsMessages.WM_INPUT,
            _ => registrations++,
            _ =>
            {
                reads++;
                throw expected;
            },
            static () => { }).Subscribe(static _ => { }, error =>
            {
                actual = error;
                errors++;
            });
        source.MessagesStream.Observer.OnNext(CreateMessage());
        source.MessagesStream.Observer.OnNext(CreateMessage());
        source.Handles.Observer.OnNext(WindowHandle);
        source.MessagesStream.Observer.OnError(expected);
        await Assert.That(ReferenceEquals(actual, expected)).IsTrue();
        await Assert.That(errors).IsEqualTo(1);
        await Assert.That(reads).IsEqualTo(1);
        await Assert.That(registrations).IsEqualTo(0);
        await Assert.That(source.MessagesStream.Disposals).IsEqualTo(1);
        await Assert.That(source.Handles.Disposals).IsEqualTo(1);
    }

    /// <summary>Releases a source returned after synchronous completion and skips registration attachment.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Observe_SynchronousCompletionDisposesLateAssignmentAsync()
    {
        var source = new MessageSource();
        source.MessagesStream.OnSubscribe = static observer => observer.OnCompleted();
        var completed = 0;
        using var subscription = RawInputMonitor.CreateObservation(
            source,
            WindowsMessages.WM_INPUT,
            static _ => { },
            static _ => new RawInputEventArgs(),
            static () => { }).Subscribe(static _ => { }, static _ => { }, () => completed++);
        await Assert.That(completed).IsEqualTo(1);
        await Assert.That(source.MessagesStream.Disposals).IsEqualTo(1);
        await Assert.That(source.Handles.Subscriptions).IsEqualTo(0);
    }

    /// <summary>Disposal prevents captured callbacks from registering or reading input.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Observe_DisposalRejectsCapturedCallbacksAsync()
    {
        var source = new MessageSource();
        var registrations = 0;
        var reads = 0;
        var stopped = 0;
        var subscription = RawInputMonitor.CreateObservation(
            source,
            WindowsMessages.WM_INPUT,
            _ => registrations++,
            _ =>
            {
                reads++;
                return new RawInputEventArgs();
            },
            () => stopped++).Subscribe(static _ => { }, static _ => { });
        subscription.Dispose();
        subscription.Dispose();
        source.Handles.Observer.OnNext(WindowHandle);
        source.MessagesStream.Observer.OnNext(CreateMessage());
        await Assert.That(registrations).IsEqualTo(0);
        await Assert.That(reads).IsEqualTo(0);
        await Assert.That(stopped).IsEqualTo(1);
        await Assert.That(source.MessagesStream.Disposals).IsEqualTo(1);
        await Assert.That(source.Handles.Disposals).IsEqualTo(1);
    }

    /// <summary>Uses one captured provider even if message attachment replaces the global provider.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Observe_ProviderReplacementDuringAttachmentKeepsOriginalHandlesAsync()
    {
        var original = new MessageSource();
        var replacement = new MessageSource();
        IDisposable replacementScope = null;
        original.MessagesStream.OnSubscribe = _ => replacementScope = RawInputMonitor.Infrastructure.OverrideMessageSourceForTesting(replacement);
        using var originalScope = RawInputMonitor.Infrastructure.OverrideMessageSourceForTesting(original);
        try
        {
            using var subscription = RawInputMonitor.ObserveRawInput(RawInputDevices.Keyboard).Subscribe(static _ => { }, static _ => { });
            await Assert.That(original.Handles.Subscriptions).IsEqualTo(1);
            await Assert.That(replacement.Handles.Subscriptions).IsEqualTo(0);
        }
        finally
        {
            replacementScope?.Dispose();
        }
    }

    /// <summary>Forwards errors from either source and releases both subscriptions.</summary>
    /// <param name="handleSource">Whether the handle source reports the failure.</param>
    /// <returns>The assertion task.</returns>
    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task Observe_SourceFailureDetachesBothSourcesAsync(bool handleSource)
    {
        var source = new MessageSource();
        var expected = new InvalidOperationException();
        Exception actual = null;
        using var subscription = RawInputMonitor.CreateObservation(
            source,
            WindowsMessages.WM_INPUT,
            static _ => { },
            static _ => new RawInputEventArgs(),
            static () => { }).Subscribe(static _ => { }, error => actual = error);
        if (handleSource)
        {
            source.Handles.Observer.OnError(expected);
        }
        else
        {
            source.MessagesStream.Observer.OnError(expected);
        }

        await Assert.That(ReferenceEquals(actual, expected)).IsTrue();
        await Assert.That(source.MessagesStream.Disposals).IsEqualTo(1);
        await Assert.That(source.Handles.Disposals).IsEqualTo(1);
    }

    /// <summary>Releases the message source when handle attachment throws.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Observe_HandleAttachmentFailureDetachesMessagesAsync()
    {
        var source = new MessageSource();
        var expected = new InvalidOperationException();
        source.Handles.OnSubscribe = _ => throw expected;
        Exception actual = null;
        using var subscription = RawInputMonitor.CreateObservation(
            source,
            WindowsMessages.WM_INPUT,
            static _ => { },
            static _ => new RawInputEventArgs(),
            static () => { }).Subscribe(static _ => { }, error => actual = error);
        await Assert.That(ReferenceEquals(actual, expected)).IsTrue();
        await Assert.That(source.MessagesStream.Disposals).IsEqualTo(1);
    }

    /// <summary>Creates an input message without a native payload.</summary>
    /// <returns>The synthetic input message.</returns>
    private static WindowMessage CreateMessage() => new((nint)WindowHandle, WindowsMessages.WM_INPUT, 0, 0);

    /// <summary>Supplies independently controlled messages and handles.</summary>
    private sealed class MessageSource : IRawInputMessageSource
    {
        /// <inheritdoc />
        public IObservable<WindowMessage> Messages => MessagesStream;

        /// <summary>Gets the message source.</summary>
        internal CallbackSource<WindowMessage> MessagesStream { get; } = new();

        /// <summary>Gets the handle source.</summary>
        internal CallbackSource<long> Handles { get; } = new();

        /// <inheritdoc />
        public IObservable<long> ObserveHandleChanges() => Handles;
    }

    /// <summary>Retains callbacks to model an emission captured before detachment.</summary>
    /// <typeparam name="T">The callback value type.</typeparam>
    private sealed class CallbackSource<T> : IObservable<T>
    {
        /// <summary>Gets the captured observer.</summary>
        internal IObserver<T> Observer { get; private set; }

        /// <summary>Gets or sets the synchronous subscription callback.</summary>
        internal Action<IObserver<T>> OnSubscribe { get; set; }

        /// <summary>Gets or sets the initial value.</summary>
        internal T InitialValue { get; set; }

        /// <summary>Gets the disposal count.</summary>
        internal int Disposals { get; private set; }

        /// <summary>Gets the subscription count.</summary>
        internal int Subscriptions { get; private set; }

        /// <inheritdoc />
        public IDisposable Subscribe(IObserver<T> observer)
        {
            Observer = observer;
            Subscriptions++;
            OnSubscribe?.Invoke(observer);
            if (InitialValue is not null)
            {
                observer.OnNext(InitialValue);
            }

            return new ActionDisposable(() => Disposals++);
        }
    }
}
