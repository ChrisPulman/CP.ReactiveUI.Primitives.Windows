// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_TEST_SHIM
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging;
#else
using CP.ReactiveUI.Primitives.Windows.Desktop.Messaging;
#endif

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies that retired message-loop generations cannot expose stale handles.</summary>
public sealed class MessageWindowHandleStateTests
{
    /// <summary>A synthetic native window handle.</summary>
    private const int WindowHandle = 42;

    /// <summary>The expected number of zero-handle transitions.</summary>
    private const int TransitionCount = 2;

    /// <summary>Invalidates replayed handles before activating a replacement generation.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Activate_InvalidatesPreviousHandleAsync()
    {
        var changes = new List<nint>();
        var state = new MessageWindowHandleState(changes.Add);
        var first = new object();
        state.Activate(first);
        state.Publish(first, WindowHandle);
        state.Activate(new());
        await Assert.That(changes[changes.Count - 1]).IsEqualTo(IntPtr.Zero);
    }

    /// <summary>Ignores cleanup and late publications from an older generation.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task RetiredGeneration_CannotClearOrReplaceCurrentHandleAsync()
    {
        nint current = 0;
        var state = new MessageWindowHandleState(value => current = value);
        var first = new object();
        var second = new object();
        state.Activate(first);
        state.Activate(second);
        state.Publish(second, WindowHandle);
        state.Release(first);
        state.Publish(first, 0);
        await Assert.That(current).IsEqualTo((nint)WindowHandle);
    }

    /// <summary>Prevents callbacks after release and emits teardown only once.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Release_BlocksLateHandleAndIsIdempotentAsync()
    {
        var changes = new List<nint>();
        var state = new MessageWindowHandleState(changes.Add);
        var owner = new object();
        state.Activate(owner);
        state.Release(owner);
        state.Publish(owner, WindowHandle);
        state.Release(owner);
        await Assert.That(changes.Count).IsEqualTo(TransitionCount);
        await Assert.That(changes[changes.Count - 1]).IsEqualTo(IntPtr.Zero);
    }
}
