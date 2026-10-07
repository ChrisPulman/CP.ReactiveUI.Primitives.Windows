// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
using System.Collections.ObjectModel;
using System.Globalization;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A detached WMI object whose property values require no native lifetime.</summary>
public sealed class WmiRow
{
    /// <summary>Initializes or reads properties state.</summary>
    private readonly ReadOnlyDictionary<string, object?> _properties;

    /// <summary>Initializes a new instance of the <see cref="WmiRow"/> class.</summary>
    /// <param name="properties">The detached properties.</param>
    internal WmiRow(Dictionary<string, object?> properties) => _properties = new(properties);

    /// <summary>Gets provider property values. Arrays are detached copies; CIM objects become nested rows.</summary>
    public IReadOnlyDictionary<string, object?> Properties => _properties;

    /// <summary>Reads a property with its exact managed type.</summary>
    /// <typeparam name="T">The property's managed type.</typeparam>
    /// <param name="propertyName">The case insensitive provider property name.</param>
    /// <param name="value">The detached value, or the default when missing or of another type.</param>
    /// <returns>Whether the property has the requested type.</returns>
    public bool TryGet<T>(string propertyName, out T? value)
    {
        if (_properties.TryGetValue(propertyName, out var item) && item is T typed)
        {
            value = typed;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>Reads or manages WmiRow state.</summary>
    /// <returns>The captured or projected value.</returns>
    /// <param name="name">The property name.</param>
    internal string? String(string name) => TryGet<string>(name, out var value) ? value : null;

    /// <summary>Reads or manages WmiRow state.</summary>
    /// <returns>The captured or projected value.</returns>
    /// <param name="name">The property name.</param>
    internal uint? UInt32(string name) => Number<uint>(name);

    /// <summary>Reads or manages WmiRow state.</summary>
    /// <returns>The captured or projected value.</returns>
    /// <param name="name">The property name.</param>
    internal ulong? UInt64(string name) => Number<ulong>(name);

    /// <summary>Reads or manages WmiRow state.</summary>
    /// <returns>The captured or projected value.</returns>
    /// <param name="name">The property name.</param>
    internal bool? Boolean(string name) => _properties.TryGetValue(name, out var value) && value is bool typed ? typed : null;

    /// <summary>Reads or manages WmiRow state.</summary>
    /// <typeparam name="T">The projected value type.</typeparam>
    /// <param name="name">The name value.</param>
    /// <returns>The captured or projected value.</returns>
    private T? Number<T>(string name)
        where T : struct, IConvertible
    {
        if (!_properties.TryGetValue(name, out var value) || value is null)
        {
            return null;
        }

        try
        {
            return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
        catch (Exception exception) when (exception is InvalidCastException or FormatException or OverflowException)
        {
            return null;
        }
    }
}
