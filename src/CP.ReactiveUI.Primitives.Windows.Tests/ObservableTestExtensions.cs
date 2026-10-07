// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Tests Observable Test Extensions behavior.</summary>
internal static class ObservableTestExtensions
{
    /// <summary>Groups observable test extension members.</summary>
    /// <typeparam name="T">The observed value type.</typeparam>
    /// <param name="source">The observable source.</param>
    extension<T>(IObservable<T> source)
    {
        /// <summary>Subscribes to only the next-notification callback.</summary>
        /// <param name="onNext">The callback invoked for each next notification.</param>
        /// <returns>The active subscription.</returns>
        internal IDisposable SubscribeOnNext(Action<T> onNext) =>
            source.Subscribe(new ActionObserver<T>(onNext));
    }

    /// <summary>Forwards next notifications to a supplied callback.</summary>
    /// <typeparam name="T">The observed value type.</typeparam>
    /// <param name="onNext">The callback invoked for each next notification.</param>
    private sealed class ActionObserver<T>(Action<T> onNext) : IObserver<T>
    {
        /// <inheritdoc />
        public void OnCompleted()
        {
        }

        /// <inheritdoc />
        public void OnError(Exception error)
        {
        }

        /// <inheritdoc />
        public void OnNext(T value) => onNext(value);
    }
}
