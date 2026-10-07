<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring.Capture](#api-df9fbf2fe466)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring.Observe(System.TimeSpan)](#api-456001e8e285)

<a id="api-df9fbf2fe466"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring.Capture`

Captures GPU inventory and counters. Rate counters may require a persistent observation to become available.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring.Capture()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/GraphicsMonitoring.cs:17`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring.@Capture()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-456001e8e285"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring.Observe(System.TimeSpan)`

Observes GPU counters, keeping rate history and caching adapter inventory for five minutes.

```csharp
public static System.IObservable<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring.Observe(System.TimeSpan interval)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/GraphicsMonitoring.cs:26`.

- `interval` (`System.TimeSpan`): The positive sampling interval.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.TimeSpan @interval, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot> operationObserver)
    {
        return ((global::System.IObservable<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot>)(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring.@Observe(@interval))).Subscribe(operationObserver);
    }
}
```
