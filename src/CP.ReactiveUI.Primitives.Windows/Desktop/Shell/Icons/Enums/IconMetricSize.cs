// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums;
#endif
/// <summary>Options to specify the size of icons for LoadIconMetric and LoadIconWithScaleDown.</summary>
public enum IconMetricSize
{
    /// <summary>
    ///     Use the system small icon size (SM_CXSMICON, SM_CYSMICON).
    ///     These metrics are used for icons in window captions and small icon view.
    /// </summary>
    SmallIcon,
    /// <summary>Use the system standard icon size.</summary>
    StandardIcon,
}
