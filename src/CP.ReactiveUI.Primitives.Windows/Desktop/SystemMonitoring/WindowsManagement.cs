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

/// <summary>Runs read-only WQL queries against local Windows management providers.</summary>
public static class WindowsManagement
{
    /// <summary>Reads or manages WindowsManagement state.</summary>
    private const int DefaultTimeoutSeconds = 10;

    /// <summary>Reads or manages WindowsManagement state.</summary>
    private const int MaximumTimeoutMinutes = 5;

    /// <summary>Runs a query with a ten second completion timeout.</summary>
    /// <param name="namespacePath">A local WMI root namespace.</param>
    /// <param name="wql">The read-only SELECT query.</param>
    /// <returns>The detached rows and provider availability.</returns>
    public static WmiQueryResult Query(string namespacePath, string wql) =>
        Query(namespacePath, wql, TimeSpan.FromSeconds(DefaultTimeoutSeconds));

    /// <summary>Runs a query and cancels its asynchronous enumeration when its completion timeout expires.</summary>
    /// <param name="namespacePath">A local WMI namespace, such as root\\cimv2.</param>
    /// <param name="wql">The SELECT query. Methods and provider writes are not invoked.</param>
    /// <param name="timeout">A positive completion timeout of at most five minutes.</param>
    /// <returns>The rows and availability. WMI connection establishment uses the provider's own connection timeout.</returns>
    public static WmiQueryResult Query(string namespacePath, string wql, TimeSpan timeout)
    {
        Throw.IfNullOrWhiteSpace(namespacePath);
        Throw.IfNullOrWhiteSpace(wql);
        if (timeout <= TimeSpan.Zero || timeout > TimeSpan.FromMinutes(MaximumTimeoutMinutes))
        {
            throw new ArgumentOutOfRangeException(nameof(timeout));
        }

        ValidateNamespace(namespacePath);

        using var operation = new WmiQueryOperation(namespacePath, wql);
        return operation.Execute(timeout);
    }

    /// <summary>Observes provider events such as process, service, or device lifecycle changes using an event WQL query.</summary>
    /// <param name="namespacePath">The local provider namespace.</param>
    /// <param name="wql">An event SELECT query, including WITHIN when required by its event class.</param>
    /// <returns>A cold observable that owns its native watcher and emits detached event rows.</returns>
    public static IObservable<WmiRow> ObserveChanges(string namespacePath, string wql)
    {
        Throw.IfNullOrWhiteSpace(namespacePath);
        Throw.IfNullOrWhiteSpace(wql);
        ValidateNamespace(namespacePath);
        return ReactiveSignal.CreateSafe<WmiRow>(observer =>
        {
            var subscription = new WmiEventSubscription(namespacePath, wql, observer);
            subscription.Start();
            return subscription;
        });
    }

    /// <summary>Reads or manages WindowsManagement state.</summary>
    /// <param name="item">The item value.</param>
    /// <returns>The captured or projected value.</returns>
    internal static WmiRow Detach(ManagementBaseObject item)
    {
        var properties = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
        foreach (PropertyData property in item.Properties)
        {
            properties[property.Name] = DetachValue(property.Value);
        }

        return new(properties);
    }

    /// <summary>Reads or manages WindowsManagement state.</summary>
    /// <param name="status">The status value.</param>
    /// <returns>The captured or projected value.</returns>
    internal static WmiQueryStatus MapStatus(ManagementStatus status) => status switch
    {
        ManagementStatus.AccessDenied => WmiQueryStatus.AccessDenied,
        ManagementStatus.InvalidClass or ManagementStatus.InvalidNamespace or ManagementStatus.NotFound or ManagementStatus.ProviderNotFound => WmiQueryStatus.Unavailable,
        ManagementStatus.Timedout => WmiQueryStatus.TimedOut,
        _ => WmiQueryStatus.Failed,
    };

    /// <summary>Reads or manages WindowsManagement state.</summary>
    /// <param name="value">The property value.</param>
    /// <returns>The captured or projected value.</returns>
    private static object? DetachValue(object? value)
    {
        if (value is ManagementBaseObject nested)
        {
            using (nested)
            {
                return Detach(nested);
            }
        }

        if (value is Array array)
        {
            var elementType = array.GetType().GetElementType();
            if (elementType is not null && !typeof(ManagementBaseObject).IsAssignableFrom(elementType) && elementType != typeof(object))
            {
                return array.Clone();
            }

            var copy = new object?[array.Length];
            for (var index = 0; index < copy.Length; index++)
            {
                copy[index] = DetachValue(array.GetValue(index));
            }

            return copy;
        }

        return value;
    }

    /// <summary>Rejects remote namespaces so the convenience surface cannot connect to another machine.</summary>
    /// <param name="namespacePath">The requested namespace.</param>
    private static void ValidateNamespace(string namespacePath)
    {
        if (!namespacePath.Replace('/', '\\').StartsWith("root\\", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("A local root namespace is required.", nameof(namespacePath));
        }
    }
}
