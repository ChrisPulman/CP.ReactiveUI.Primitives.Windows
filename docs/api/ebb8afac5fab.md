<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.Capture](#api-2cd43f4486a1)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.GetDisplays](#api-139eff9a2eae)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.Observe(System.TimeSpan)](#api-ce266e45f123)

<a id="api-2cd43f4486a1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.Capture`

Captures display brightness and provider failures.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSnapshot CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.Capture()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/BrightnessMonitoring.cs:24`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSnapshot> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.@Capture()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-139eff9a2eae"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.GetDisplays`

Gets the current display inventory. Capture also exposes inventory errors.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSample[] CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.GetDisplays()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/BrightnessMonitoring.cs:78`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSample[]> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.@GetDisplays()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-ce266e45f123"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.Observe(System.TimeSpan)`

Observes brightness with an independent sampler per subscription.

```csharp
public static System.IObservable<CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSnapshot> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.Observe(System.TimeSpan interval)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/BrightnessMonitoring.cs:83`.

- `interval` (`System.TimeSpan`): The positive polling interval.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.TimeSpan @interval, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSnapshot> operationObserver)
    {
        return ((global::System.IObservable<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSnapshot>)(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring.@Observe(@interval))).Subscribe(operationObserver);
    }
}
```
