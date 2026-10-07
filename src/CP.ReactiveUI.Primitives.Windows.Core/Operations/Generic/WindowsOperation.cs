// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Operations;

/// <summary>Represents a deferred operation executed on the capturing or subscribing thread.</summary>
/// <typeparam name="T">The result type.</typeparam>
public sealed class WindowsOperation<T>
{
    /// <summary>The deferred operation factory.</summary>
    private readonly Func<T> _operation;

    /// <summary>Initializes a new instance of the <see cref="WindowsOperation{T}"/> class.</summary>
    /// <param name="operation">The deferred operation.</param>
    internal WindowsOperation(Func<T> operation) => _operation = operation;

    /// <summary>Runs the operation once and returns its result, propagating any exception to the caller.</summary>
    /// <returns>The operation result.</returns>
    public T Capture() => _operation();

    /// <summary>Creates a cold observable that runs once per subscriber and reports failures through OnError.</summary>
    /// <returns>An observable that emits the operation result and then completes.</returns>
    public IObservable<T> Observe() => Signal.Defer(() => Signal.Return(_operation()));

    /// <summary>Creates a deferred operation that transforms this operation's result.</summary>
    /// <typeparam name="TResult">The transformed result type.</typeparam>
    /// <param name="selector">The result transformation.</param>
    /// <returns>A deferred transformed operation.</returns>
    public WindowsOperation<TResult> Select<TResult>(Func<T, TResult> selector)
    {
        Throw.IfNull(selector, nameof(selector));
        return new(() => selector(_operation()));
    }

    /// <summary>Creates a deferred operation that invokes an action after obtaining this operation's result.</summary>
    /// <param name="action">The action to invoke for the result.</param>
    /// <returns>A deferred operation that preserves the result.</returns>
    public WindowsOperation<T> Do(Action<T> action)
    {
        Throw.IfNull(action, nameof(action));
        return new(() =>
        {
            var result = _operation();
            action(result);
            return result;
        });
    }
}
