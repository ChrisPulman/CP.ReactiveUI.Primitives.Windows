// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Operations;

/// <summary>Creates deferred Windows operations that support fluent composition and observation.</summary>
public static class WindowsOperation
{
    /// <summary>Creates a deferred asynchronous operation that returns a value.</summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="operation">The cancellable operation to run when executed or subscribed.</param>
    /// <returns>A deferred asynchronous operation.</returns>
    public static WindowsAsyncOperation<T> FromTask<T>(Func<CancellationToken, Task<T>> operation)
    {
        Throw.IfNull(operation, nameof(operation));
        return new(operation);
    }

    /// <summary>Creates a deferred asynchronous operation that signals completion with a void value.</summary>
    /// <param name="operation">The cancellable operation to run when executed or subscribed.</param>
    /// <returns>A deferred asynchronous operation.</returns>
    public static WindowsAsyncOperation<RxVoid> FromTask(Func<CancellationToken, Task> operation)
    {
        Throw.IfNull(operation, nameof(operation));
        return new(async token =>
        {
            await operation(token).ConfigureAwait(false);
            return RxVoid.Default;
        });
    }

    /// <summary>Creates a deferred operation that returns a value.</summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="operation">The operation to run when captured or subscribed.</param>
    /// <returns>A deferred operation.</returns>
    public static WindowsOperation<T> From<T>(Func<T> operation)
    {
        Throw.IfNull(operation, nameof(operation));
        return new(operation);
    }

    /// <summary>Creates a deferred operation that signals completion with a void value.</summary>
    /// <param name="operation">The operation to run when captured or subscribed.</param>
    /// <returns>A deferred operation.</returns>
    public static WindowsOperation<RxVoid> From(Action operation)
    {
        Throw.IfNull(operation, nameof(operation));
        return new(() =>
        {
            operation();
            return RxVoid.Default;
        });
    }
}
