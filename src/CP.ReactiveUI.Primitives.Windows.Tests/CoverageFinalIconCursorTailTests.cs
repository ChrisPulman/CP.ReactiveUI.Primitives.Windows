// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Windows.Media.Imaging;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Final deterministic coverage for icon and cursor conversion tails.</summary>
public sealed class CoverageFinalIconCursorTailTests
{
    /// <summary>Converts an owned in-memory system icon to a WPF bitmap source.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task IconExtensions_ToBitmapSource_ConvertsOwnedSystemIconAsync()
    {
        using var icon = (Icon)SystemIcons.Application.Clone();
        BitmapSource source = icon.ToBitmapSource();

        await Assert.That(source).IsNotNull();
        await Assert.That(source.PixelWidth).IsGreaterThan(Zero);
        await Assert.That(source.PixelHeight).IsGreaterThan(Zero);
    }
}
