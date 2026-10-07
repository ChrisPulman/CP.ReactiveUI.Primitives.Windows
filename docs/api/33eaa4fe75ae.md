<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.Capture](#api-aa6db690a3ee)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.Dispose](#api-1ff73eda9d1a)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.OpenForMonitor(System.IntPtr)](#api-161eb8aab300)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.OpenForMonitor(System.IntPtr)](#api-b91f227504a9)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.SetBrightness(System.UInt32)](#api-7d662ca98da6)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.Description](#api-2a654d8e6147)

<a id="api-aa6db690a3ee"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.Capture`

Captures capability and brightness, retaining native failure information.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessSample CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.Capture()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/BrightnessDisplay.cs:85`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay receiver, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessSample> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Capture()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1ff73eda9d1a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.Dispose`

Closes the owned physical monitor handle.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.Dispose()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/BrightnessDisplay.cs:151`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Dispose()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-161eb8aab300"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.OpenForMonitor(System.IntPtr)`

Opens physical monitors for a logical monitor. Dispose every returned session.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay[] CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.OpenForMonitor(System.IntPtr monitor)
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/BrightnessDisplay.cs:41`.

- `monitor` (`System.IntPtr`): The logical monitor handle.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IntPtr @monitor, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay[]> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.@OpenForMonitor(@monitor)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-b91f227504a9"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.OpenForMonitor(System.IntPtr)`

Opens physical monitors for a logical monitor. Dispose every returned session.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay[] CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.OpenForMonitor(nint monitor)
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/BrightnessDisplay.cs:41`.

- `monitor` (`nint`): The logical monitor handle.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(nint @monitor, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay[]> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.@OpenForMonitor(@monitor)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-7d662ca98da6"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.SetBrightness(System.UInt32)`

Immediately sets native brightness within the monitor's reported range.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.SetBrightness(uint value)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/BrightnessDisplay.cs:134`.

- `value` (`uint`): The brightness in native monitor units.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay receiver, global::System.UInt32 @value, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@SetBrightness(@value)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-2a654d8e6147"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.Description`

Gets the physical monitor description.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay.Description { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/BrightnessDisplay.cs:36`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay receiver)
    {
        _ = receiver.@Description;
    }
}
```
