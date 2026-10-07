// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums;
#endif
/// <summary>Options to specify whether folders should be in the open or closed state.</summary>
public enum FolderIconType
{
    /// <summary>Specify open folder.</summary>
    Open,
    /// <summary>Specify closed folder.</summary>
    Closed,
}
