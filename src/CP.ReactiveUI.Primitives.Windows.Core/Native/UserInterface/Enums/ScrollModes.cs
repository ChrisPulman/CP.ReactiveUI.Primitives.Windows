// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums;

/// <summary>Scroll-modes for the WindowScroller.</summary>
public enum ScrollModes
{
    /// <summary>Send message to the window with an absolute position.</summary>
    AbsoluteWindowMessage,

    /// <summary>Send message to the window for page up or down.</summary>
    WindowsMessage,

    /// <summary>Send a mousewheel event.</summary>
    MouseWheel,

    /// <summary>Send page up or down as key press.</summary>
    KeyboardPageUpDown,
}
