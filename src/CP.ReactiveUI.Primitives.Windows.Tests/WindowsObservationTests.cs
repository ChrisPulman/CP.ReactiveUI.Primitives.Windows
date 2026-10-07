// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies window observation composition without native hooks or desktop changes.</summary>
public sealed class WindowsObservationTests
{
    /// <summary>The monitored synthetic window handle.</summary>
    private const int WindowHandle = 42;

    /// <summary>An unrelated synthetic window handle.</summary>
    private const int OtherWindowHandle = 43;

    /// <summary>Filters foreign windows, child elements, and non-window objects before reading state.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task ObserveChanges_FiltersBeforeReadingAndSuppressesDuplicatesAsync()
    {
        const int expectedReads = 3;
        const int expectedChanges = 2;
        using var events = new Signal<WinEventInfo>();
        var window = InteropWindowFactory.CreateFor(WindowHandle);
        var reads = 0;
        var caption = "First";
        List<string> observed = [];
        using var subscription = System.ObservableExtensions.Subscribe(
            InteropWindowObservationExtensions.ObserveChanges(window, events, WinEvents.EVENT_OBJECT_NAMECHANGE, () =>
            {
                reads++;
                return caption;
            }),
            observed.Add);

        await Assert.That(reads).IsEqualTo(0);
        events.OnNext(CreateEvent(OtherWindowHandle, WinEvents.EVENT_OBJECT_NAMECHANGE));
        events.OnNext(CreateEvent(WindowHandle, WinEvents.EVENT_OBJECT_NAMECHANGE, child: 1));
        events.OnNext(CreateEvent(WindowHandle, WinEvents.EVENT_OBJECT_LOCATIONCHANGE));
        events.OnNext(CreateEvent(WindowHandle, WinEvents.EVENT_OBJECT_NAMECHANGE, ObjectIdentifiers.Client));
        await Assert.That(reads).IsEqualTo(0);

        events.OnNext(CreateEvent(WindowHandle, WinEvents.EVENT_OBJECT_NAMECHANGE));
        events.OnNext(CreateEvent(WindowHandle, WinEvents.EVENT_OBJECT_NAMECHANGE));
        caption = "Second";
        events.OnNext(CreateEvent(WindowHandle, WinEvents.EVENT_OBJECT_NAMECHANGE));
        await Assert.That(reads).IsEqualTo(expectedReads);
        await Assert.That(observed.Count).IsEqualTo(expectedChanges);
        await Assert.That(observed[0]).IsEqualTo("First");
        await Assert.That(observed[1]).IsEqualTo("Second");
    }

    /// <summary>Stops reading changing state after the downstream subscription is disposed.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task ObserveChanges_DisposalDetachesFromSuppliedEventsAsync()
    {
        using var events = new Signal<WinEventInfo>();
        var window = InteropWindowFactory.CreateFor(WindowHandle);
        var reads = 0;
        var subscription = System.ObservableExtensions.Subscribe(
            InteropWindowObservationExtensions.ObserveChanges(window, events, WinEvents.EVENT_OBJECT_NAMECHANGE, () => ++reads),
            static _ => { });
        subscription.Dispose();
        events.OnNext(CreateEvent(WindowHandle, WinEvents.EVENT_OBJECT_NAMECHANGE));
        await Assert.That(reads).IsEqualTo(0);
    }

    /// <summary>Captures a fresh initial snapshot for each subscriber after attaching its message source.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task DisplayTopology_CapturesPerSubscriberAfterAttachingMessagesAsync()
    {
        const int subscriberCount = 2;
        var attachments = 0;
        var captures = 0;
        var detached = new StrongBox<int>();
        var captureWasAttached = true;
        var messages = Signal.CreateSafe<WindowMessage>(_ =>
        {
            attachments++;
            return Scope.Create(detached, static state => state.Value++);
        });
        List<DisplayInfo> first = [];
        List<DisplayInfo> second = [];
        var topology = DisplayTopology.ObserveChangesCore(messages, () =>
        {
            captureWasAttached &= attachments > captures;
            captures++;
            return captures == 1 ? first : second;
        });
        await Assert.That(captures).IsEqualTo(0);
        await Assert.That(attachments).IsEqualTo(0);

        List<IReadOnlyList<DisplayInfo>> observed = [];
        using (System.ObservableExtensions.Subscribe(topology, observed.Add))
        using (System.ObservableExtensions.Subscribe(topology, observed.Add))
        {
            await Assert.That(captures).IsEqualTo(subscriberCount);
            await Assert.That(captureWasAttached).IsTrue();
            await Assert.That(observed[0]).IsSameReferenceAs(first);
            await Assert.That(observed[1]).IsSameReferenceAs(second);
        }

        await Assert.That(detached.Value).IsEqualTo(subscriberCount);
    }

    /// <summary>Detaches the message subscription when the initial snapshot query fails.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task DisplayTopology_InitialCaptureFailureDetachesMessagesAsync()
    {
        var detached = new StrongBox<int>();
        var expected = new InvalidOperationException("Snapshot failed.");
        Exception received = null;
        var messages = Signal.CreateSafe<WindowMessage>(_ => Scope.Create(detached, static state => state.Value++));
        using var subscription = System.ObservableExtensions.Subscribe(
            DisplayTopology.ObserveChangesCore(messages, () => throw expected),
            static _ => { },
            error => received = error);

        await Assert.That(received).IsSameReferenceAs(expected);
        await Assert.That(detached.Value).IsEqualTo(1);
    }

    /// <summary>Detaches after a later snapshot fails and stops querying subsequent messages.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task DisplayTopology_LaterCaptureFailureDetachesAndStopsCaptureAsync()
    {
        const int expectedCaptures = 2;
        var captures = 0;
        var detached = new StrongBox<int>();
        var expected = new InvalidOperationException("Changed snapshot failed.");
        Exception received = null;
        IObserver<WindowMessage> sourceObserver = null;
        var messages = Signal.CreateSafe<WindowMessage>(observer =>
        {
            sourceObserver = observer;
            return Scope.Create(detached, static state => state.Value++);
        });
        List<IReadOnlyList<DisplayInfo>> observed = [];
        using var subscription = System.ObservableExtensions.Subscribe(
            DisplayTopology.ObserveChangesCore(messages, () =>
            {
                captures++;
                return captures == 1 ? [] : throw expected;
            }),
            observed.Add,
            error => received = error);
        WindowMessage changed = new(0, WindowsMessages.WM_DISPLAYCHANGE, 0, 0);
        sourceObserver.OnNext(changed);
        sourceObserver.OnNext(changed);

        await Assert.That(received).IsSameReferenceAs(expected);
        await Assert.That(detached.Value).IsEqualTo(1);
        await Assert.That(captures).IsEqualTo(expectedCaptures);
        await Assert.That(observed.Count).IsEqualTo(1);
    }

    /// <summary>Honors a source terminal notification that precedes assignment of its disposable.</summary>
    /// <param name="fail">Whether the source terminates with an error.</param>
    /// <returns>The assertion task.</returns>
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task DisplayTopology_SynchronousSourceTerminationDetachesBeforeInitialCaptureAsync(bool fail)
    {
        var captures = 0;
        var completions = 0;
        var detached = new StrongBox<int>();
        var expected = new InvalidOperationException("Source failed.");
        Exception received = null;
        var messages = Signal.CreateSafe<WindowMessage>(observer =>
        {
            if (fail)
            {
                observer.OnError(expected);
            }
            else
            {
                observer.OnCompleted();
            }

            return Scope.Create(detached, static state => state.Value++);
        });
        using var subscription = System.ObservableExtensions.Subscribe(
            DisplayTopology.ObserveChangesCore(messages, () =>
            {
                captures++;
                return [];
            }),
            static _ => { },
            error => received = error,
            () => completions++);

        await Assert.That(captures).IsEqualTo(0);
        await Assert.That(detached.Value).IsEqualTo(1);
        await Assert.That(received).IsSameReferenceAs(fail ? expected : null);
        await Assert.That(completions).IsEqualTo(fail ? 0 : 1);
    }

    /// <summary>Creates synthetic native event data without installing a hook.</summary>
    /// <param name="handle">The source window handle.</param>
    /// <param name="eventType">The event type.</param>
    /// <param name="objectIdentifier">The source object.</param>
    /// <param name="child">The child identifier.</param>
    /// <returns>The synthetic event.</returns>
    private static WinEventInfo CreateEvent(int handle, WinEvents eventType, ObjectIdentifiers objectIdentifier = ObjectIdentifiers.Window, long child = 0) =>
        WinEventInfo.Create(IntPtr.Zero, eventType, new(handle), objectIdentifier, child, 0, 0);
}
