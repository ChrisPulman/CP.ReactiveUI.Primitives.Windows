<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot

Package: `CP.ReactiveUI.Primitives.Windows.Integrations`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.#ctor(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryRequest,System.String,System.DateTimeOffset)](#api-1f929cc41aca)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Entity](#api-a89796fe626b)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Json](#api-b5bbd23d67d8)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Name](#api-1452eed69197)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.ObservedAt](#api-e2ac84d2086c)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Query](#api-30737e442d15)

<a id="api-1f929cc41aca"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.#ctor(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryRequest,System.String,System.DateTimeOffset)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.CitrixMonitorTelemetrySnapshot(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryRequest request, string json, System.DateTimeOffset observedAt)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Telemetry/CitrixMonitorTelemetrySnapshot.cs:14`.

- `request` (`CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryRequest`): The request that produced the snapshot.
- `json` (`string`): The raw JSON response payload.
- `observedAt` (`System.DateTimeOffset`): The UTC time at which the payload was observed.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryRequest @request, global::System.String @json, global::System.DateTimeOffset @observedAt)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot(@request, @json, @observedAt);
    }
}
```

<a id="api-a89796fe626b"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Entity`

Gets the Citrix Monitor Service OData entity used for the request.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Entity { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Telemetry/CitrixMonitorTelemetrySnapshot.cs:28`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot receiver)
    {
        _ = receiver.@Entity;
    }
}
```

<a id="api-b5bbd23d67d8"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Json`

Gets the raw JSON response payload.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Json { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Telemetry/CitrixMonitorTelemetrySnapshot.cs:34`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot receiver)
    {
        _ = receiver.@Json;
    }
}
```

<a id="api-1452eed69197"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Name`

Gets the public telemetry stream name.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Name { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Telemetry/CitrixMonitorTelemetrySnapshot.cs:25`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot receiver)
    {
        _ = receiver.@Name;
    }
}
```

<a id="api-e2ac84d2086c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.ObservedAt`

Gets the UTC time at which the payload was observed.

```csharp
public System.DateTimeOffset CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.ObservedAt { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Telemetry/CitrixMonitorTelemetrySnapshot.cs:37`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot receiver)
    {
        _ = receiver.@ObservedAt;
    }
}
```

<a id="api-30737e442d15"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Query`

Gets the OData query string used for the request.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot.Query { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Telemetry/CitrixMonitorTelemetrySnapshot.cs:31`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot receiver)
    {
        _ = receiver.@Query;
    }
}
```
