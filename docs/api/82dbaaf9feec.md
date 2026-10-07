<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring.Capture](#api-4d3caa9dd35b)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring.Observe(System.TimeSpan)](#api-f38176e9f30f)

<a id="api-4d3caa9dd35b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring.Capture`

Captures current power status.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerSample CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring.Capture()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/PowerMonitoring.cs:19`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerSample> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring.@Capture()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-f38176e9f30f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring.Observe(System.TimeSpan)`

Observes power status with an independent sampler per subscriber.

```csharp
public static System.IObservable<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerSample> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring.Observe(System.TimeSpan interval)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/PowerMonitoring.cs:32`.

- `interval` (`System.TimeSpan`): The positive sampling interval.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.TimeSpan @interval, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerSample> operationObserver)
    {
        return ((global::System.IObservable<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerSample>)(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring.@Observe(@interval))).Subscribe(operationObserver);
    }
}
```
