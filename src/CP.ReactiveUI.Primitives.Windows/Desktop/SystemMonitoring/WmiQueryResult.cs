// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>The detached rows and availability of one provider query.</summary>
public sealed class WmiQueryResult
{
    /// <summary>Initializes a new instance of the <see cref="WmiQueryResult"/> class.</summary>
    /// <param name="status">The status value.</param>
    /// <param name="rows">The rows value.</param>
    /// <param name="error">The error value.</param>
    internal WmiQueryResult(WmiQueryStatus status, IReadOnlyList<WmiRow> rows, string? error = null)
    {
        Status = status;
        Rows = rows;
        Error = error;
    }

    /// <summary>Gets the provider availability.</summary>
    public WmiQueryStatus Status { get; }

    /// <summary>Gets detached rows, including any rows returned before a failure.</summary>
    public IReadOnlyList<WmiRow> Rows { get; }

    /// <summary>Gets the provider failure description, when present.</summary>
    public string? Error { get; }
}
