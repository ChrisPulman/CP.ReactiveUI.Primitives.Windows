<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Architecture](#api-003a36d3c4d1)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.CoreCount](#api-40ae347ba205)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.CurrentClockMegahertz](#api-5b0ee76d79ea)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.DeviceId](#api-0fd145d5e297)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.EnabledCoreCount](#api-4b20f8965010)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.L2CacheKilobytes](#api-8be332cfa549)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.L3CacheKilobytes](#api-3136f42774e1)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.LogicalProcessorCount](#api-f2ddb08a86de)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Manufacturer](#api-f7d16c64381f)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.MaximumClockMegahertz](#api-be03fa931389)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Name](#api-e56c8d07ec99)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.ProcessorId](#api-f691ed198f4b)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.SecondLevelAddressTranslation](#api-2e4c4ebf2418)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Socket](#api-645417aa800e)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.VirtualizationFirmwareEnabled](#api-4bfa112e7d33)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.VmMonitorModeExtensions](#api-a725c5533195)

<a id="api-003a36d3c4d1"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Architecture`

Gets architecture code (Architecture) as reported by WMI.

```csharp
public uint? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Architecture { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:68`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@Architecture;
    }
}
```

<a id="api-40ae347ba205"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.CoreCount`

Gets core count (NumberOfCores) as reported by WMI.

```csharp
public uint? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.CoreCount { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:53`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@CoreCount;
    }
}
```

<a id="api-5b0ee76d79ea"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.CurrentClockMegahertz`

Gets current clock megahertz (CurrentClockSpeed) as reported by WMI.

```csharp
public uint? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.CurrentClockMegahertz { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:65`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@CurrentClockMegahertz;
    }
}
```

<a id="api-0fd145d5e297"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.DeviceId`

Gets device id (DeviceID) as reported by WMI.

```csharp
public string? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.DeviceId { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:38`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@DeviceId;
    }
}
```

<a id="api-4b20f8965010"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.EnabledCoreCount`

Gets enabled core count (NumberOfEnabledCore) as reported by WMI.

```csharp
public uint? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.EnabledCoreCount { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:56`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@EnabledCoreCount;
    }
}
```

<a id="api-8be332cfa549"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.L2CacheKilobytes`

Gets l2 cache kilobytes (L2CacheSize) as reported by WMI.

```csharp
public uint? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.L2CacheKilobytes { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:71`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@L2CacheKilobytes;
    }
}
```

<a id="api-3136f42774e1"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.L3CacheKilobytes`

Gets l3 cache kilobytes (L3CacheSize) as reported by WMI.

```csharp
public uint? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.L3CacheKilobytes { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:74`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@L3CacheKilobytes;
    }
}
```

<a id="api-f2ddb08a86de"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.LogicalProcessorCount`

Gets logical processor count (NumberOfLogicalProcessors) as reported by WMI.

```csharp
public uint? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.LogicalProcessorCount { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:59`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@LogicalProcessorCount;
    }
}
```

<a id="api-f7d16c64381f"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Manufacturer`

Gets manufacturer (Manufacturer) as reported by WMI.

```csharp
public string? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Manufacturer { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:44`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@Manufacturer;
    }
}
```

<a id="api-be03fa931389"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.MaximumClockMegahertz`

Gets maximum clock megahertz (MaxClockSpeed) as reported by WMI.

```csharp
public uint? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.MaximumClockMegahertz { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:62`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@MaximumClockMegahertz;
    }
}
```

<a id="api-e56c8d07ec99"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Name`

Gets name (Name) as reported by WMI.

```csharp
public string? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Name { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:41`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@Name;
    }
}
```

<a id="api-f691ed198f4b"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.ProcessorId`

Gets processor id (ProcessorId) as reported by WMI.

```csharp
public string? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.ProcessorId { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:47`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@ProcessorId;
    }
}
```

<a id="api-2e4c4ebf2418"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.SecondLevelAddressTranslation`

Gets second level address translation (SecondLevelAddressTranslationExtensions) as reported by WMI.

```csharp
public bool? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.SecondLevelAddressTranslation { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:83`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@SecondLevelAddressTranslation;
    }
}
```

<a id="api-645417aa800e"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Socket`

Gets socket (SocketDesignation) as reported by WMI.

```csharp
public string? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.Socket { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:50`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@Socket;
    }
}
```

<a id="api-4bfa112e7d33"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.VirtualizationFirmwareEnabled`

Gets virtualization firmware enabled (VirtualizationFirmwareEnabled) as reported by WMI.

```csharp
public bool? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.VirtualizationFirmwareEnabled { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:77`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@VirtualizationFirmwareEnabled;
    }
}
```

<a id="api-a725c5533195"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.VmMonitorModeExtensions`

Gets vm monitor mode extensions (VMMonitorModeExtensions) as reported by WMI.

```csharp
public bool? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor.VmMonitorModeExtensions { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/HardwareProcessor.cs:80`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor receiver)
    {
        _ = receiver.@VmMonitorModeExtensions;
    }
}
```
