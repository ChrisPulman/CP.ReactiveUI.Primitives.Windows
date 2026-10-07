// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Operations;

/// <summary>Represents a deferred cancellable asynchronous operation.</summary>
/// <typeparam name="T">The result type.</typeparam>
public sealed class WindowsAsyncOperation<T>
{
    /// <summary>The deferred asynchronous operation factory.</summary>
    private readonly Func<CancellationToken, Task<T>> _operation;

    /// <summary>Initializes a new instance of the <see cref="WindowsAsyncOperation{T}"/> class.</summary>
    /// <param name="operation">The deferred asynchronous operation.</param>
    internal WindowsAsyncOperation(Func<CancellationToken, Task<T>> operation) => _operation = operation;

    /// <summary>Runs the operation once without cancellation.</summary>
    /// <returns>A task containing the operation result.</returns>
    public Task<T> ExecuteAsync() => ExecuteAsync(CancellationToken.None);

    /// <summary>Runs the operation once with the supplied cancellation token.</summary>
    /// <param name="token">The cancellation token for this execution.</param>
    /// <returns>A task containing the operation result.</returns>
    public Task<T> ExecuteAsync(CancellationToken token) => _operation(token);

    /// <summary>Creates a cold observable that cancels its execution when its subscription is disposed.</summary>
    /// <returns>An observable that emits the operation result or reports its failure.</returns>
    public IObservable<T> Observe() => Signal.FromAsync(_operation);

    /// <summary>Creates a deferred asynchronous operation that transforms the result.</summary>
    /// <typeparam name="TResult">The transformed result type.</typeparam>
    /// <param name="selector">The result transformation.</param>
    /// <returns>A deferred transformed operation.</returns>
    public WindowsAsyncOperation<TResult> Select<TResult>(Func<T, TResult> selector)
    {
        Throw.IfNull(selector, nameof(selector));
        return new(async token => selector(await _operation(token).ConfigureAwait(false)));
    }

    /// <summary>Creates a deferred asynchronous operation that invokes an action for the result.</summary>
    /// <param name="action">The action to invoke after obtaining the result.</param>
    /// <returns>A deferred operation that preserves the result.</returns>
    public WindowsAsyncOperation<T> Do(Action<T> action)
    {
        Throw.IfNull(action, nameof(action));
        return new(async token =>
        {
            var result = await _operation(token).ConfigureAwait(false);
            action(result);
            return result;
        });
    }
}
