// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;
using System.Windows.Data;

namespace CP.ReactiveUI.Primitives.Windows.Example.TaskManager;

/// <summary>Summarizes process availability while preserving full diagnostics in a tooltip.</summary>
public sealed class ProcessAvailabilityConverter : IValueConverter
{
    /// <summary>Formats either the number of unavailable fields or their detailed reasons.</summary>
    /// <param name="value">The process diagnostic strings.</param>
    /// <param name="targetType">The target binding type.</param>
    /// <param name="parameter">Details requests the complete diagnostic list.</param>
    /// <param name="culture">The binding culture.</param>
    /// <returns>The compact summary or full diagnostic text.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not IReadOnlyList<string> errors || errors.Count == 0)
        {
            return "No reported errors";
        }

        return parameter is "Details"
            ? string.Join(Environment.NewLine, errors)
            : $"{errors.Count} unavailable fields";
    }

    /// <summary>Rejects writes to the read-only diagnostic binding.</summary>
    /// <param name="value">The attempted write value.</param>
    /// <param name="targetType">The source binding type.</param>
    /// <param name="parameter">The binding parameter.</param>
    /// <param name="culture">The binding culture.</param>
    /// <returns>No value because this operation always throws.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException("Process diagnostics are read-only.");
}
