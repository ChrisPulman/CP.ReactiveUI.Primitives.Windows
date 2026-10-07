<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult.Error](#api-e52d9c805445)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult.Rows](#api-33a31647469d)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult.Status](#api-f1cfce51b913)

<a id="api-e52d9c805445"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult.Error`

Gets the provider failure description, when present.

```csharp
public string? CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult.Error { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/WmiQueryResult.cs:33`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult receiver)
    {
        _ = receiver.@Error;
    }
}
```

<a id="api-33a31647469d"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult.Rows`

Gets detached rows, including any rows returned before a failure.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiRow> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult.Rows { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/WmiQueryResult.cs:30`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult receiver)
    {
        _ = receiver.@Rows;
    }
}
```

<a id="api-f1cfce51b913"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult.Status`

Gets the provider availability.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryStatus CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult.Status { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/WmiQueryResult.cs:27`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult receiver)
    {
        _ = receiver.@Status;
    }
}
```
