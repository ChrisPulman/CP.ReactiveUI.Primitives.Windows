<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring.Capture](#api-b1ad046249b7)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring.Observe(System.TimeSpan)](#api-579a79992e81)

<a id="api-b1ad046249b7"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring.Capture`

Captures storage state; PDH rate counters may require a second sample.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageSnapshot CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring.Capture()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/StorageMonitoring.cs:16`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageSnapshot> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring.@Capture()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-579a79992e81"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring.Observe(System.TimeSpan)`

Observes storage snapshots immediately and at the requested interval.

```csharp
public static System.IObservable<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageSnapshot> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring.Observe(System.TimeSpan interval)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/StorageMonitoring.cs:25`.

- `interval` (`System.TimeSpan`): A positive sampling interval.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.TimeSpan @interval, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageSnapshot> operationObserver)
    {
        return ((global::System.IObservable<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageSnapshot>)(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring.@Observe(@interval))).Subscribe(operationObserver);
    }
}
```
