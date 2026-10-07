// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
using System.Management;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Initializes or reads WmiProjection state.</summary>
internal static class WmiProjection
{
    /// <summary>Initializes or reads Date state.</summary>
    /// <param name="value">The property value.</param>
    /// <returns>The captured or projected value.</returns>
    internal static DateTimeOffset? Date(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        try
        {
            return new DateTimeOffset(ManagementDateTimeConverter.ToDateTime(value));
        }
        catch (ArgumentOutOfRangeException)
        {
            return null;
        }
    }

    /// <summary>Initializes or reads Project state.</summary>
    /// <typeparam name="T">The projected value type.</typeparam>
    /// <param name="result">The result value.</param>
    /// <param name="project">The project value.</param>
    /// <returns>The captured or projected value.</returns>
    internal static IReadOnlyList<T> Project<T>(WmiQueryResult result, Func<WmiRow, T> project)
    {
        var items = new List<T>(result.Rows.Count);
        foreach (var row in result.Rows)
        {
            items.Add(project(row));
        }

        return items.AsReadOnly();
    }
}
