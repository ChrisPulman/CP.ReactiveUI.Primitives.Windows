// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Native.Enums;

/// <summary>Specifies where a rectangle is adjacent to another rectangle.</summary>
public enum AdjacentTo
{
    /// <summary>The rectangles are not adjacent.</summary>
    None,

    /// <summary>The rectangle is adjacent on the left side.</summary>
    Left,

    /// <summary>The rectangle is adjacent on the right side.</summary>
    Right,

    /// <summary>The rectangle is adjacent on the top side.</summary>
    Top,

    /// <summary>The rectangle is adjacent on the bottom side.</summary>
    Bottom,
}
