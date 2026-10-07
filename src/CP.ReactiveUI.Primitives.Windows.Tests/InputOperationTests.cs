// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_TEST_SHIM
using DesktopInput = CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.Input;
#else
using DesktopInput = CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.Input;
#endif

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Tests deferred input commands without sending input to the desktop.</summary>
public sealed class InputOperationTests
{
    /// <summary>The fake result for a press and release.</summary>
    private const uint KeyPressResult = 2U;

    /// <summary>The number of subscriptions used to verify repeat execution.</summary>
    private const int SubscriptionCount = 2;

    /// <summary>The expected transformed input result.</summary>
    private const uint TransformedResult = 3U;

    /// <summary>The mouse command's horizontal coordinate.</summary>
    private const int MouseX = 10;

    /// <summary>The mouse command's vertical coordinate.</summary>
    private const int MouseY = 20;

    /// <summary>One mouse wheel detent.</summary>
    private const int WheelDelta = 120;

    /// <summary>Checks that keyboard commands snapshot their keys and send once per subscription.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task KeyboardCommandsAreDeferredAndSnapshotKeysAsync()
    {
        var fake = new InputCoverage2Tests.FakeNativeInputApi { SendReturn = KeyPressResult };
        var previous = NativeInput.SetApiForTesting(fake);
        try
        {
            var keys = new[] { VirtualKeyCode.KeyA };
            var operation = InputOperations.KeyPresses(keys);
            keys[0] = VirtualKeyCode.KeyB;
            var observed = new List<uint>();
            var stream = operation.Select(static count => count + 1U).Observe();
            await Assert.That(fake.SendCalls).IsEqualTo(0);
            using var first = stream.SubscribeOnNext(observed.Add);
            await Assert.That(fake.SendCalls).IsEqualTo(1);
            await Assert.That(fake.LastInputs[0].InputUnion.KeyboardInput.VirtualKeyCode).IsEqualTo(VirtualKeyCode.KeyA);
            using var second = stream.SubscribeOnNext(observed.Add);
            await Assert.That(fake.SendCalls).IsEqualTo(SubscriptionCount);
            await Assert.That(observed.Count).IsEqualTo(SubscriptionCount);
            await Assert.That(observed[0]).IsEqualTo(TransformedResult);
        }
        finally
        {
            _ = NativeInput.SetApiForTesting(previous);
        }
    }

    /// <summary>Checks that each input command sends its expected number of records.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task CommandsPreserveInputCompositionAsync()
    {
        var fake = new InputCoverage2Tests.FakeNativeInputApi { SendReturn = 1U };
        var previous = NativeInput.SetApiForTesting(fake);
        try
        {
            var commands = new[]
            {
                InputOperations.KeyDown(VirtualKeyCode.KeyA),
                InputOperations.KeyUp(VirtualKeyCode.KeyA),
                InputOperations.KeyCombinationPress(VirtualKeyCode.Control, VirtualKeyCode.KeyA),
                InputOperations.MouseClick(MouseButtons.Left),
                InputOperations.MouseDown(MouseButtons.Left),
                InputOperations.MouseUp(MouseButtons.Left),
                InputOperations.MoveMouse(new(MouseX, MouseY)),
                InputOperations.MoveMouseWheel(WheelDelta),
            };
            var expectedLengths = new[] { 1, 1, 4, 2, 1, 1, 1, 1 };
            await Assert.That(fake.SendCalls).IsEqualTo(0);
            for (var index = 0; index < commands.Length; index++)
            {
                await Assert.That(commands[index].Capture()).IsEqualTo(1U);
                await Assert.That(fake.LastInputs.Length).IsEqualTo(expectedLengths[index]);
            }

            await Assert.That(fake.SendCalls).IsEqualTo(commands.Length);
        }
        finally
        {
            _ = NativeInput.SetApiForTesting(previous);
        }
    }

    /// <summary>Checks that native input records are captured when creating the command.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task SendOperationSnapshotsInputRecordsAsync()
    {
        var fake = new InputCoverage2Tests.FakeNativeInputApi { SendReturn = 1U };
        var previous = NativeInput.SetApiForTesting(fake);
        try
        {
            var inputs = DesktopInput.CreateKeyboardInputs(KeyboardInput.ForKeyDown(VirtualKeyCode.KeyA));
            var operation = inputs.SendOperation();
            inputs[0] = default;
            await Assert.That(fake.SendCalls).IsEqualTo(0);
            await Assert.That(operation.Capture()).IsEqualTo(1U);
            await Assert.That(fake.LastInputs[0].InputUnion.KeyboardInput.VirtualKeyCode).IsEqualTo(VirtualKeyCode.KeyA);
        }
        finally
        {
            _ = NativeInput.SetApiForTesting(previous);
        }
    }
}
