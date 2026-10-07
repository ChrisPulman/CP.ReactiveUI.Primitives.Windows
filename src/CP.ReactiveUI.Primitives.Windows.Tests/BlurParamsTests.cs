// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies exact blur parameter equality.</summary>
public sealed class BlurParamsTests
{
    /// <summary>Verifies special floating-point values retain value equality.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task EqualsPreservesSpecialValuesAsync()
    {
        var nan = BlurParams.Create(float.NaN, true);
        var positiveInfinity = BlurParams.Create(float.PositiveInfinity, true);
        var zero = BlurParams.Create(0F, true);

        await Assert.That(nan.Equals(BlurParams.Create(float.NaN, true))).IsTrue();
        await Assert.That(nan.Equals(zero)).IsFalse();
        await Assert.That(positiveInfinity.Equals(BlurParams.Create(float.PositiveInfinity, true))).IsTrue();
        await Assert.That(positiveInfinity.Equals(BlurParams.Create(float.NegativeInfinity, true))).IsFalse();
        await Assert.That(zero.Equals(BlurParams.Create(-0F, true))).IsTrue();
        await Assert.That(zero.Equals(BlurParams.Create(float.Epsilon, true))).IsFalse();
        await Assert.That(zero.Equals(BlurParams.Create(0F, false))).IsFalse();
    }
}
