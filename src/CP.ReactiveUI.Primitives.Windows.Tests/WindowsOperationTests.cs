// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Operations;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies deferred fluent operation execution and observable notification semantics.</summary>
public sealed class WindowsOperationTests
{
    /// <summary>The number of executions in a pair of subscriptions or captures.</summary>
    private const int PairCount = 2;

    /// <summary>The result transformation factor.</summary>
    private const int DoubleScale = 2;

    /// <summary>The scaled result of the second capture.</summary>
    private const int SecondScaledResult = 4;

    /// <summary>The source result used to verify transformation order.</summary>
    private const int SourceValue = 7;

    /// <summary>Verifies composition and observable creation defer all work.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task Composition_DefersWorkUntilCaptureAsync()
    {
        var calls = 0;
        var actions = 0;
        var operation = WindowsOperation.From(() => ++calls).Select(static value => value * DoubleScale).Do(_ => actions++);
        var observable = operation.Observe();

        await Assert.That(calls).IsEqualTo(0);
        await Assert.That(actions).IsEqualTo(0);
        await Assert.That(observable).IsNotNull();
        await Assert.That(operation.Capture()).IsEqualTo(PairCount);
        await Assert.That(operation.Capture()).IsEqualTo(SecondScaledResult);
        await Assert.That(calls).IsEqualTo(PairCount);
        await Assert.That(actions).IsEqualTo(PairCount);
    }

    /// <summary>Verifies every subscriber gets one result and completion on its own thread.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task Observe_ExecutesOncePerSubscriberOnCallerThreadAsync()
    {
        var calls = 0;
        var executionThread = 0;
        var observable = WindowsOperation.From(() =>
        {
            executionThread = Environment.CurrentManagedThreadId;
            return ++calls;
        }).Observe();
        var first = new RecordingObserver<int>();
        var second = new RecordingObserver<int>();
        var callerThread = Environment.CurrentManagedThreadId;
        using var firstSubscription = observable.Subscribe(first);
        using var secondSubscription = observable.Subscribe(second);

        await Assert.That(executionThread).IsEqualTo(callerThread);
        await Assert.That(calls).IsEqualTo(PairCount);
        await Assert.That(first.Values.Count).IsEqualTo(1);
        await Assert.That(first.Values[0]).IsEqualTo(1);
        await Assert.That(second.Values.Count).IsEqualTo(1);
        await Assert.That(second.Values[0]).IsEqualTo(PairCount);
        await Assert.That(first.Completions).IsEqualTo(1);
        await Assert.That(second.Completions).IsEqualTo(1);
        await Assert.That(first.Error).IsNull();
        await Assert.That(second.Error).IsNull();
    }

    /// <summary>Verifies capture throws and observation forwards the same operation failure.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task Failure_ThrowsOnCaptureAndNotifiesOnObserveAsync()
    {
        var failure = new InvalidOperationException("operation failed");
        var calls = 0;
        var operation = WindowsOperation.From<int>(() =>
        {
            calls++;
            throw failure;
        });
        await Assert.That(() => operation.Capture()).Throws<InvalidOperationException>();
        var observer = new RecordingObserver<int>();
        using var subscription = operation.Observe().Subscribe(observer);

        await Assert.That(calls).IsEqualTo(PairCount);
        await Assert.That(observer.Error).IsSameReferenceAs(failure);
        await Assert.That(observer.Values.Count).IsEqualTo(0);
        await Assert.That(observer.Completions).IsEqualTo(0);
    }

    /// <summary>Verifies fluent transformations execute in order and preserve the original source.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task SelectAndDo_ComposeInOrderWithoutMutatingSourceAsync()
    {
        var events = new List<string>();
        var source = WindowsOperation.From(() =>
        {
            events.Add("source");
            return SourceValue;
        });
        var operation = source.Select(value =>
        {
            events.Add("select");
            return value.ToString(CultureInfo.InvariantCulture);
        }).Do(events.Add);
        var observer = new RecordingObserver<string>();
        using var subscription = operation.Observe().Subscribe(observer);

        await Assert.That(observer.Values[0]).IsEqualTo("7");
        await Assert.That(string.Join(",", events)).IsEqualTo("source,select,7");
        await Assert.That(source.Capture()).IsEqualTo(SourceValue);
    }

    /// <summary>Verifies failures in either fluent callback terminate observation.</summary>
    /// <param name="selectorFails">Whether the selector or action fails.</param>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task CompositionFailure_NotifiesErrorWithoutCompletionAsync(bool selectorFails)
    {
        var failure = new InvalidOperationException("callback failed");
        var actions = 0;
        var operation = WindowsOperation.From(static () => 1).Select(value => selectorFails ? throw failure : value).Do(_ =>
        {
            actions++;
            throw failure;
        });
        var observer = new RecordingObserver<int>();
        using var subscription = operation.Observe().Subscribe(observer);

        await Assert.That(observer.Error).IsSameReferenceAs(failure);
        await Assert.That(observer.Values.Count).IsEqualTo(0);
        await Assert.That(observer.Completions).IsEqualTo(0);
        await Assert.That(actions).IsEqualTo(selectorFails ? 0 : 1);
    }

    /// <summary>Verifies action adapters defer execution and emit the lean void value.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task FromAction_DefersExecutionAndEmitsVoidAsync()
    {
        var calls = 0;
        var operation = WindowsOperation.From(() => { calls++; });
        var observer = new RecordingObserver<global::ReactiveUI.Primitives.RxVoid>();

        await Assert.That(calls).IsEqualTo(0);
        await Assert.That(operation.Capture()).IsEqualTo(global::ReactiveUI.Primitives.RxVoid.Default);
        using var subscription = operation.Observe().Subscribe(observer);
        await Assert.That(calls).IsEqualTo(PairCount);
        await Assert.That(observer.Values.Count).IsEqualTo(1);
        await Assert.That(observer.Values[0]).IsEqualTo(global::ReactiveUI.Primitives.RxVoid.Default);
        await Assert.That(observer.Completions).IsEqualTo(1);
    }

    /// <summary>Verifies invalid composition is rejected immediately without executing the source.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task NullCallbacks_AreRejectedWithoutRunningOperationAsync()
    {
        var calls = 0;
        var source = WindowsOperation.From(() => ++calls);

        await Assert.That(static () => WindowsOperation.From<int>(null)).Throws<ArgumentNullException>();
        await Assert.That(static () => WindowsOperation.From((Action)null)).Throws<ArgumentNullException>();
        await Assert.That(() => source.Select<int>(null)).Throws<ArgumentNullException>();
        await Assert.That(() => source.Do(null)).Throws<ArgumentNullException>();
        await Assert.That(calls).IsEqualTo(0);
        await Assert.That(source.Capture()).IsEqualTo(1);
    }

    /// <summary>Records synchronous operation notifications.</summary>
    /// <typeparam name="T">The result type.</typeparam>
    private sealed class RecordingObserver<T> : IObserver<T>
    {
        /// <summary>Gets the emitted values.</summary>
        public List<T> Values { get; } = [];

        /// <summary>Gets the observed error.</summary>
        public Exception Error { get; private set; }

        /// <summary>Gets the number of completion notifications.</summary>
        public int Completions { get; private set; }

        /// <inheritdoc/>
        public void OnNext(T value) => Values.Add(value);

        /// <inheritdoc/>
        public void OnError(Exception error) => Error = error;

        /// <inheritdoc/>
        public void OnCompleted() => Completions++;
    }
}
