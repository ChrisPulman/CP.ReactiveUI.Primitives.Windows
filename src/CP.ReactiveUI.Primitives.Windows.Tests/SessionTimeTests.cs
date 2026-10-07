// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies exact session timestamp equality.</summary>
public sealed class SessionTimeTests
{
    /// <summary>Verifies timestamp equality retains special floating-point values.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task EqualsPreservesSpecialValuesAsync()
    {
        var value = new SessionTime(double.NaN, double.PositiveInfinity, double.NegativeInfinity, 0D, -0D);
        var equal = new SessionTime(double.NaN, double.PositiveInfinity, double.NegativeInfinity, -0D, 0D);
        var different = new SessionTime(double.NaN, double.PositiveInfinity, double.NegativeInfinity, double.Epsilon, 0D);

        await Assert.That(value.Equals(equal)).IsTrue();
        await Assert.That(value.GetHashCode()).IsEqualTo(equal.GetHashCode());
        await Assert.That(value.Equals(different)).IsFalse();
    }
}
