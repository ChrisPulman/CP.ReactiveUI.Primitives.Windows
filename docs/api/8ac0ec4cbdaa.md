<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.#ctor](#api-2b316acbae85)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.ExtendedIdentityResult](#api-b29ce8e30af8)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.Processes](#api-2bdc40b36e96)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.Timestamp](#api-6a213150d470)

<a id="api-2b316acbae85"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.#ctor`

Creates the default ProcessSnapshot value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.ProcessSnapshot()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ProcessSnapshot.cs:15`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot();
    }
}
```

<a id="api-b29ce8e30af8"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.ExtendedIdentityResult`

Gets the optional extended identity provider result, including availability and errors.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult? CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.ExtendedIdentityResult { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ProcessSnapshot.cs:21`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot receiver)
    {
        _ = receiver.@ExtendedIdentityResult;
    }
}
```

<a id="api-2bdc40b36e96"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.Processes`

Gets the captured processes.

```csharp
public System.Collections.Generic.IReadOnlyList<CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessInfo> CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.Processes { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ProcessSnapshot.cs:24`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot receiver)
    {
        _ = receiver.@Processes;
    }
}
```

<a id="api-6a213150d470"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.Timestamp`

Gets the UTC capture time.

```csharp
public System.DateTimeOffset CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot.Timestamp { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/SystemMonitoring/ProcessSnapshot.cs:18`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot receiver)
    {
        _ = receiver.@Timestamp;
    }
}
```
