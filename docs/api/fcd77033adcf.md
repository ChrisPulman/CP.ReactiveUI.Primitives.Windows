<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow.TryGet\`\`1(System.String,\`\`0@)](#api-a4a44057b0f0)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow.Properties](#api-e3e6a8a2bc56)

<a id="api-a4a44057b0f0"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow.TryGet``1(System.String,``0@)`

Reads a property with its exact managed type.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow.TryGet<T>(string propertyName, out T? value)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/WmiRow.cs:33`.

- `propertyName` (`string`): The case insensitive provider property name.
- `value` (`T?`): The detached value, or the default when missing or of another type.

```csharp
internal static class ApiExample
{
    internal static void Call<T>(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow receiver, global::System.String @propertyName, out T? @value)
    {
        _ = receiver.@TryGet<T>(@propertyName, out @value);
    }
}
```

<a id="api-e3e6a8a2bc56"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow.Properties`

Gets provider property values. Arrays are detached copies; CIM objects become nested rows.

```csharp
public System.Collections.Generic.IReadOnlyDictionary<string, object?> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow.Properties { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/WmiRow.cs:26`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow receiver)
    {
        _ = receiver.@Properties;
    }
}
```
