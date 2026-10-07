// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies brightness argument validation without controlling a display.</summary>
public sealed class BrightnessPanelTests
{
    /// <summary>Invalid percentages fail before a WMI request.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task SetBrightness_InvalidPercentage_Throws() =>
        await Assert.That(static () => BrightnessPanel.ForDisplay("mock").SetBrightness(byte.MaxValue)).Throws<ArgumentOutOfRangeException>();

    /// <summary>Percentage boundaries are accepted by the pure validation seam.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ValidatePercentage_Boundaries_Accepts()
    {
        await Assert.That(static () => BrightnessPanel.ValidatePercentage(0)).ThrowsNothing();
        await Assert.That(static () => BrightnessPanel.ValidatePercentage(BrightnessPanel.MaximumPercentage)).ThrowsNothing();
    }

    /// <summary>An empty WMI instance identifier is rejected.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ForDisplay_EmptyIdentifier_Throws() =>
        await Assert.That(static () => BrightnessPanel.ForDisplay(string.Empty)).Throws<ArgumentException>();

    /// <summary>An empty logical monitor handle is rejected before native enumeration.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task OpenForMonitor_EmptyHandle_Throws() =>
        await Assert.That(static () => BrightnessDisplay.OpenForMonitor(IntPtr.Zero)).Throws<ArgumentException>();
}
