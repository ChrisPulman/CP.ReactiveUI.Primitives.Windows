<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.AcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan,System.Guid,System.Guid,System.UInt32)](#api-6a706e2e004e)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ActivateOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan)](#api-f7490bbf57a6)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.AffinityOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget,System.IntPtr)](#api-fc54e92b8dea)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.AffinityOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget,System.IntPtr)](#api-40b5b1c35be5)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.CaptureOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay)](#api-b36e13c40401)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.CaptureOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemMonitorBuilder)](#api-9972c9624b5d)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.CloseMainWindowOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget)](#api-704f99726008)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.DcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan,System.Guid,System.Guid,System.UInt32)](#api-fb09f765ae1e)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.PauseOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget)](#api-628d186f277b)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.PriorityOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget,System.Diagnostics.ProcessPriorityClass)](#api-28a421d7edbe)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ReadAcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan,System.Guid,System.Guid)](#api-43a20c9a0871)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ReadDcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan,System.Guid,System.Guid)](#api-bff06ae879ae)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ResumeOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget)](#api-36c23ea70315)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.SetBrightnessOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay,System.UInt32)](#api-2a2313249323)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.SetBrightnessOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessPanel,System.Byte)](#api-649992fc58cb)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.StartModeOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget,CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceStartMode)](#api-952261994c5d)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.StartOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget)](#api-1962007fd180)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.StopOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget)](#api-b6a28aa2bcc0)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.TerminateOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget)](#api-9746e365f64b)

<a id="api-6a706e2e004e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.AcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan,System.Guid,System.Guid,System.UInt32)`

Defers persisting a power plan AC setting value.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.AcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan target, System.Guid subgroup, System.Guid setting, uint value)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:63`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan`): The power plan target.
- `subgroup` (`System.Guid`): The setting subgroup identifier.
- `setting` (`System.Guid`): The setting identifier.
- `value` (`uint`): The setting value index.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan @target, global::System.Guid @subgroup, global::System.Guid @setting, global::System.UInt32 @value, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan> operationObserver)
    {
        return (@target.@AcValueOperation(@subgroup, @setting, @value)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-f7490bbf57a6"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ActivateOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan)`

Defers activating a power plan and applying its persisted settings.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ActivateOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan target)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:82`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan`): The power plan target.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan @target, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan> operationObserver)
    {
        return (@target.@ActivateOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-fc54e92b8dea"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.AffinityOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget,System.IntPtr)`

Defers setting the selected process affinity mask.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.AffinityOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget target, System.IntPtr affinity)
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:125`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget`): The process target.
- `affinity` (`System.IntPtr`): The processor mask.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget @target, global::System.IntPtr @affinity, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget> operationObserver)
    {
        return (@target.@AffinityOperation(@affinity)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-40b5b1c35be5"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.AffinityOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget,System.IntPtr)`

Defers setting the selected process affinity mask.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.AffinityOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget target, nint affinity)
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:125`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget`): The process target.
- `affinity` (`nint`): The processor mask.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget @target, nint @affinity, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget> operationObserver)
    {
        return (@target.@AffinityOperation(@affinity)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-b36e13c40401"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.CaptureOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay)`

Defers capturing physical monitor brightness and capability.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessSample> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.CaptureOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay target)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:33`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay`): The monitor session, which must remain open through execution.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay @target, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessSample> operationObserver)
    {
        return (@target.@CaptureOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-9972c9624b5d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.CaptureOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemMonitorBuilder)`

Defers capturing one snapshot using the selected monitoring configuration.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemSnapshot> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.CaptureOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemMonitorBuilder builder)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:200`.

- `builder` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemMonitorBuilder`): The immutable monitor configuration.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemMonitorBuilder @builder, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemSnapshot> operationObserver)
    {
        return (@builder.@CaptureOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-704f99726008"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.CloseMainWindowOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget)`

Defers requesting graceful closure of the selected process main window.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<bool> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.CloseMainWindowOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget target)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:133`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget`): The process target.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget @target, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return (@target.@CloseMainWindowOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-fb09f765ae1e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.DcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan,System.Guid,System.Guid,System.UInt32)`

Defers persisting a power plan DC setting value.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.DcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan target, System.Guid subgroup, System.Guid setting, uint value)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:74`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan`): The power plan target.
- `subgroup` (`System.Guid`): The setting subgroup identifier.
- `setting` (`System.Guid`): The setting identifier.
- `value` (`uint`): The setting value index.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan @target, global::System.Guid @subgroup, global::System.Guid @setting, global::System.UInt32 @value, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan> operationObserver)
    {
        return (@target.@DcValueOperation(@subgroup, @setting, @value)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-628d186f277b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.PauseOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget)`

Defers submitting a service pause request.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.PauseOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget target)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:170`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget`): The service target.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget @target, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult> operationObserver)
    {
        return (@target.@PauseOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-28a421d7edbe"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.PriorityOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget,System.Diagnostics.ProcessPriorityClass)`

Defers setting the selected process priority.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.PriorityOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget target, System.Diagnostics.ProcessPriorityClass priority)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:116`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget`): The process target.
- `priority` (`System.Diagnostics.ProcessPriorityClass`): The requested priority class.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget @target, global::System.Diagnostics.ProcessPriorityClass @priority, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget> operationObserver)
    {
        return (@target.@PriorityOperation(@priority)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-43a20c9a0871"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ReadAcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan,System.Guid,System.Guid)`

Defers reading a power plan AC setting value.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ReadAcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan target, System.Guid subgroup, System.Guid setting)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:92`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan`): The power plan target.
- `subgroup` (`System.Guid`): The setting subgroup identifier.
- `setting` (`System.Guid`): The setting identifier.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan @target, global::System.Guid @subgroup, global::System.Guid @setting, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (@target.@ReadAcValueOperation(@subgroup, @setting)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-bff06ae879ae"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ReadDcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan,System.Guid,System.Guid)`

Defers reading a power plan DC setting value.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<uint> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ReadDcValueOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan target, System.Guid subgroup, System.Guid setting)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:102`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan`): The power plan target.
- `subgroup` (`System.Guid`): The setting subgroup identifier.
- `setting` (`System.Guid`): The setting identifier.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan @target, global::System.Guid @subgroup, global::System.Guid @setting, global::System.IObserver<global::System.UInt32> operationObserver)
    {
        return (@target.@ReadDcValueOperation(@subgroup, @setting)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-36c23ea70315"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ResumeOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget)`

Defers submitting a service resume request.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.ResumeOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget target)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:178`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget`): The service target.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget @target, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult> operationObserver)
    {
        return (@target.@ResumeOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-2a2313249323"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.SetBrightnessOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay,System.UInt32)`

Defers setting physical monitor brightness within its reported range.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.SetBrightnessOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay target, uint value)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:25`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay`): The monitor session, which must remain open through execution.
- `value` (`uint`): The brightness in native monitor units.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay @target, global::System.UInt32 @value, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay> operationObserver)
    {
        return (@target.@SetBrightnessOperation(@value)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-649992fc58cb"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.SetBrightnessOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessPanel,System.Byte)`

Defers requesting internal panel brightness.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessPanel> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.SetBrightnessOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessPanel target, byte percentage)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:47`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessPanel`): The panel target.
- `percentage` (`byte`): The brightness percentage from 0 through 100.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessPanel @target, global::System.Byte @percentage, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessPanel> operationObserver)
    {
        return (@target.@SetBrightnessOperation(@percentage)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-952261994c5d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.StartModeOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget,CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceStartMode)`

Defers submitting a service startup configuration change.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.StartModeOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget target, CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceStartMode mode)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:187`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget`): The service target.
- `mode` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceStartMode`): The provider startup mode.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget @target, global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceStartMode @mode, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult> operationObserver)
    {
        return (@target.@StartModeOperation(@mode)).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1962007fd180"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.StartOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget)`

Defers submitting a service startup request.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.StartOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget target)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:154`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget`): The service target.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget @target, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult> operationObserver)
    {
        return (@target.@StartOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-b6a28aa2bcc0"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.StopOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget)`

Defers submitting a service shutdown request.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.StopOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget target)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:162`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget`): The service target.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget @target, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult> operationObserver)
    {
        return (@target.@StopOperation()).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-9746e365f64b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.TerminateOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget)`

Defers terminating the selected process without terminating descendants.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<ReactiveUI.Primitives.RxVoid> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions.TerminateOperation(CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget target)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/MonitoringOperationExtensions.cs:141`.

- `target` (`CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget`): The process target.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget @target, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return (@target.@TerminateOperation()).Observe().Subscribe(operationObserver);
    }
}
```
