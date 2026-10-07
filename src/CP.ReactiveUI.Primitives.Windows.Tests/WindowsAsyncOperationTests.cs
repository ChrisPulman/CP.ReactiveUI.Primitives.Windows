// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Operations;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies asynchronous operation composition and subscription cancellation.</summary>
public sealed class WindowsAsyncOperationTests
{
    /// <summary>The number of independent executions.</summary>
    private const int PairCount = 2;

    /// <summary>The result transformation factor.</summary>
    private const int DoubleScale = 2;

    /// <summary>The untransformed operation result.</summary>
    private const int SourceValue = 3;

    /// <summary>The transformed operation result.</summary>
    private const int ScaledResult = 6;

    /// <summary>The stage identifying a failure in the action callback.</summary>
    private const int ActionFailureStage = 2;

    /// <summary>Verifies async composition stays deferred and forwards the execution token.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task ExecuteAsync_DefersCompositionAndForwardsTokenAsync()
    {
        var calls = 0;
        var actions = 0;
        var receivedToken = default(CancellationToken);
        using var cancellation = new CancellationTokenSource();
        var operation = WindowsOperation.FromTask(token =>
        {
            calls++;
            receivedToken = token;
            return Task.FromResult(SourceValue);
        }).Select(static value => value * DoubleScale).Do(_ => actions++);
        var observable = operation.Observe();

        await Assert.That(calls).IsEqualTo(0);
        await Assert.That(actions).IsEqualTo(0);
        await Assert.That(observable).IsNotNull();
        await Assert.That(await operation.ExecuteAsync(cancellation.Token)).IsEqualTo(ScaledResult);
        await Assert.That(receivedToken).IsEqualTo(cancellation.Token);
        await Assert.That(calls).IsEqualTo(1);
        await Assert.That(actions).IsEqualTo(1);
        await Assert.That(await operation.ExecuteAsync()).IsEqualTo(ScaledResult);
        await Assert.That(receivedToken).IsEqualTo(CancellationToken.None);
        await Assert.That(calls).IsEqualTo(PairCount);
        await Assert.That(actions).IsEqualTo(PairCount);
    }

    /// <summary>Verifies each subscriber starts an independent asynchronous execution.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task Observe_RunsOnceForEachSubscriberAsync()
    {
        var calls = 0;
        var observable = WindowsOperation.FromTask(_ => Task.FromResult(Interlocked.Increment(ref calls))).Observe();
        var first = new CompletionObserver<int>();
        var second = new CompletionObserver<int>();
        using var firstSubscription = observable.Subscribe(first);
        using var secondSubscription = observable.Subscribe(second);
        await first.Finished.Task;
        await second.Finished.Task;

        await Assert.That(calls).IsEqualTo(PairCount);
        await Assert.That(first.Values.Count).IsEqualTo(1);
        await Assert.That(first.Values[0]).IsEqualTo(1);
        await Assert.That(second.Values.Count).IsEqualTo(1);
        await Assert.That(second.Values[0]).IsEqualTo(PairCount);
        await Assert.That(first.Error).IsNull();
        await Assert.That(second.Error).IsNull();
    }

    /// <summary>Verifies disposal cancels only the associated subscription token.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task Observe_DisposalCancelsOnlyItsExecutionAsync()
    {
        var tokens = new List<CancellationToken>();
        var firstCancelled = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var firstResult = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
        var secondResult = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
        var observable = WindowsOperation.FromTask(token =>
        {
            tokens.Add(token);
            return tokens.Count == 1 ? firstResult.Task : secondResult.Task;
        }).Observe();
        var first = new CompletionObserver<int>();
        var second = new CompletionObserver<int>();
        using var firstSubscription = observable.Subscribe(first);
        using var secondSubscription = observable.Subscribe(second);
#if NETFRAMEWORK
        using var cancellationRegistration = tokens[0].Register(static state => { _ = ((TaskCompletionSource<bool>)state).TrySetResult(true); }, firstCancelled);
#else
        await using var cancellationRegistration = tokens[0].Register(static state => { _ = ((TaskCompletionSource<bool>)state).TrySetResult(true); }, firstCancelled);
#endif
        firstSubscription.Dispose();
        await firstCancelled.Task;

        await Assert.That(tokens[0].IsCancellationRequested).IsTrue();
        await Assert.That(tokens[1].IsCancellationRequested).IsFalse();
        firstResult.SetResult(1);
        secondResult.SetResult(PairCount);
        await second.Finished.Task;
        await Assert.That(second.Values[0]).IsEqualTo(PairCount);
    }

    /// <summary>Verifies asynchronous factory and callback failures are delivered through OnError.</summary>
    /// <param name="failureStage">The factory, selector, or action stage to fail.</param>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(2)]
    public async Task Observe_FailuresNotifyErrorAsync(int failureStage)
    {
        var failure = new InvalidOperationException("async operation failed");
        var operation = WindowsOperation.FromTask(_ => failureStage == 0 ? Task.FromException<int>(failure) : Task.FromResult(1))
            .Select(value => failureStage == 1 ? throw failure : value)
            .Do(_ =>
            {
                if (failureStage == ActionFailureStage)
                {
                    throw failure;
                }
            });
        var observer = new CompletionObserver<int>();
        using var subscription = operation.Observe().Subscribe(observer);
        await observer.Finished.Task;

        await Assert.That(observer.Error).IsSameReferenceAs(failure);
        await Assert.That(observer.Values.Count).IsEqualTo(0);
        await Assert.That(observer.Completed).IsFalse();
    }

    /// <summary>Verifies a non-result asynchronous operation emits a lean void value.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task FromTaskAction_EmitsVoidAndForwardsTokenAsync()
    {
        var calls = 0;
        var receivedToken = default(CancellationToken);
        using var cancellation = new CancellationTokenSource();
        var operation = WindowsOperation.FromTask(token =>
        {
            calls++;
            receivedToken = token;
            return Task.CompletedTask;
        });

        await Assert.That(calls).IsEqualTo(0);
        await Assert.That(await operation.ExecuteAsync(cancellation.Token)).IsEqualTo(global::ReactiveUI.Primitives.RxVoid.Default);
        await Assert.That(receivedToken).IsEqualTo(cancellation.Token);
        var observer = new CompletionObserver<global::ReactiveUI.Primitives.RxVoid>();
        using var subscription = operation.Observe().Subscribe(observer);
        await observer.Finished.Task;
        await Assert.That(calls).IsEqualTo(PairCount);
        await Assert.That(observer.Values[0]).IsEqualTo(global::ReactiveUI.Primitives.RxVoid.Default);
    }

    /// <summary>Verifies null async factories and callbacks fail before execution.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task NullCallbacks_AreRejectedBeforeExecutionAsync()
    {
        var calls = 0;
        var operation = WindowsOperation.FromTask(_ => Task.FromResult(Interlocked.Increment(ref calls)));

        await Assert.That(static () => WindowsOperation.FromTask<int>(null)).Throws<ArgumentNullException>();
        await Assert.That(static () => WindowsOperation.FromTask((Func<CancellationToken, Task>)null)).Throws<ArgumentNullException>();
        await Assert.That(() => operation.Select<int>(null)).Throws<ArgumentNullException>();
        await Assert.That(() => operation.Do(null)).Throws<ArgumentNullException>();
        await Assert.That(calls).IsEqualTo(0);
    }

    /// <summary>Records asynchronous notifications and signals terminal delivery.</summary>
    /// <typeparam name="T">The result type.</typeparam>
    private sealed class CompletionObserver<T> : IObserver<T>
    {
        /// <summary>Gets the terminal notification barrier.</summary>
        public TaskCompletionSource<bool> Finished { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        /// <summary>Gets the emitted values.</summary>
        public List<T> Values { get; } = [];

        /// <summary>Gets the observed error.</summary>
        public Exception Error { get; private set; }

        /// <summary>Gets a value indicating whether completion was delivered.</summary>
        public bool Completed { get; private set; }

        /// <inheritdoc/>
        public void OnNext(T value) => Values.Add(value);

        /// <inheritdoc/>
        public void OnError(Exception error)
        {
            Error = error;
            _ = Finished.TrySetResult(true);
        }

        /// <inheritdoc/>
        public void OnCompleted()
        {
            Completed = true;
            _ = Finished.TrySetResult(true);
        }
    }
}
