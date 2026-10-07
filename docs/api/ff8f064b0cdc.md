<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Adapters](#api-e5ff7e286963)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Counters](#api-edef50e3dddf)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Inventory](#api-7eca30dd0fb3)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Timestamp](#api-8dd05cc7a0fc)

<a id="api-e5ff7e286963"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Adapters`

Gets WMI adapter inventory. AdapterRAM can be inaccurate, especially above four GiB.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsAdapter> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Adapters { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/GraphicsSnapshot.cs:39`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot receiver)
    {
        _ = receiver.@Adapters;
    }
}
```

<a id="api-edef50e3dddf"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Counters`

Gets per engine utilization percentages and dedicated/shared memory byte counters, including raw identity and PDH status.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsEngineSample> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Counters { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/GraphicsSnapshot.cs:42`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot receiver)
    {
        _ = receiver.@Counters;
    }
}
```

<a id="api-7eca30dd0fb3"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Inventory`

Gets WMI adapter query availability.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiQueryResult CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Inventory { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/GraphicsSnapshot.cs:36`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot receiver)
    {
        _ = receiver.@Inventory;
    }
}
```

<a id="api-8dd05cc7a0fc"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Timestamp`

Gets UTC capture time.

```csharp
public System.DateTimeOffset CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot.Timestamp { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/GraphicsSnapshot.cs:33`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot receiver)
    {
        _ = receiver.@Timestamp;
    }
}
```
