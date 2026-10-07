<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Baseboards](#api-47ef0d4daed7)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Bios](#api-289ca064bb08)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Disks](#api-f48d712585da)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Machines](#api-c39328e0f5bc)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.MemoryArrays](#api-6c0a74add50c)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.MemoryModules](#api-d9a39ecae5f0)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.OperatingSystems](#api-acf9e351fc74)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.PhysicalDisks](#api-bccb5e5dde09)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.PnpDevices](#api-f6b5ce64a1c6)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Processors](#api-ceb0f4db76c2)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Queries](#api-35dea72be6dd)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Timestamp](#api-666f94c2d5fb)

<a id="api-47ef0d4daed7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Baseboards`

Gets baseboards inventory.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareBaseboard> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Baseboards { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:58`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@Baseboards;
    }
}
```

<a id="api-289ca064bb08"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Bios`

Gets bios inventory.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareBios> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Bios { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:55`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@Bios;
    }
}
```

<a id="api-f48d712585da"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Disks`

Gets disks inventory.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareDisk> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Disks { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:61`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@Disks;
    }
}
```

<a id="api-c39328e0f5bc"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Machines`

Gets machines inventory.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMachine> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Machines { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:43`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@Machines;
    }
}
```

<a id="api-6c0a74add50c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.MemoryArrays`

Gets memory arrays inventory.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMemoryArray> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.MemoryArrays { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:52`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@MemoryArrays;
    }
}
```

<a id="api-d9a39ecae5f0"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.MemoryModules`

Gets memory modules inventory.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMemoryModule> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.MemoryModules { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:49`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@MemoryModules;
    }
}
```

<a id="api-acf9e351fc74"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.OperatingSystems`

Gets operating systems inventory.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareOperatingSystem> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.OperatingSystems { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:40`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@OperatingSystems;
    }
}
```

<a id="api-bccb5e5dde09"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.PhysicalDisks`

Gets physical disks inventory.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwarePhysicalDisk> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.PhysicalDisks { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:64`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@PhysicalDisks;
    }
}
```

<a id="api-f6b5ce64a1c6"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.PnpDevices`

Gets pnp devices inventory.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwarePnpDevice> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.PnpDevices { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:67`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@PnpDevices;
    }
}
```

<a id="api-ceb0f4db76c2"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Processors`

Gets processors inventory.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareProcessor> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Processors { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:46`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@Processors;
    }
}
```

<a id="api-35dea72be6dd"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Queries`

Gets query status and raw detached rows, keyed by WMI class.

```csharp
public System.Collections.Generic.IReadOnlyDictionary<string, CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Queries { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:37`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@Queries;
    }
}
```

<a id="api-666f94c2d5fb"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Timestamp`

Gets the UTC capture time.

```csharp
public System.DateTimeOffset CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot.Timestamp { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareSnapshot.cs:34`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot receiver)
    {
        _ = receiver.@Timestamp;
    }
}
```
