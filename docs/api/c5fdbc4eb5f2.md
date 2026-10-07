<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.#ctor](#api-be0a41ce5db7)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Error](#api-d1d04cab23f7)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Name](#api-9057b7714baa)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Provider](#api-a439c64d6f1c)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.SensorId](#api-ed483f4c6df7)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Status](#api-abdd109d3a4b)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Unit](#api-65a7de918574)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Value](#api-6a5ae858caf5)

<a id="api-be0a41ce5db7"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.#ctor`

Creates the default ThermalSensorSample value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.ThermalSensorSample()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ThermalSensorSample.cs:13`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample();
    }
}
```

<a id="api-d1d04cab23f7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Error`

Gets optional provider failure detail.

```csharp
public string? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Error { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ThermalSensorSample.cs:34`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample receiver)
    {
        _ = receiver.@Error;
    }
}
```

<a id="api-9057b7714baa"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Name`

Gets the sensor description, including whether it represents a thermal zone, CPU core or device.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Name { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ThermalSensorSample.cs:19`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample receiver)
    {
        _ = receiver.@Name;
    }
}
```

<a id="api-a439c64d6f1c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Provider`

Gets the provider name.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Provider { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ThermalSensorSample.cs:22`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample receiver)
    {
        _ = receiver.@Provider;
    }
}
```

<a id="api-ed483f4c6df7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.SensorId`

Gets the provider's stable sensor identity.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.SensorId { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ThermalSensorSample.cs:16`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample receiver)
    {
        _ = receiver.@SensorId;
    }
}
```

<a id="api-abdd109d3a4b"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Status`

Gets provider availability.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiQueryStatus CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Status { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ThermalSensorSample.cs:31`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample receiver)
    {
        _ = receiver.@Status;
    }
}
```

<a id="api-65a7de918574"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Unit`

Gets the measured unit, such as Celsius, Watts or RPM.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Unit { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ThermalSensorSample.cs:25`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample receiver)
    {
        _ = receiver.@Unit;
    }
}
```

<a id="api-6a5ae858caf5"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Value`

Gets the reported value, or null when unavailable.

```csharp
public double? CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample.Value { get; init; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ThermalSensorSample.cs:28`.


Configuration: supply this init-only property in an object initializer when creating the containing instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample receiver)
    {
        _ = receiver.@Value;
    }
}
```
