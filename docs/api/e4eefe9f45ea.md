<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor

Package: `CP.ReactiveUI.Primitives.Windows.Core`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive,System.String)](#api-7e8cae7d9733)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive,System.String,CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter)](#api-16ab1859c117)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive,System.String,ReactiveUI.Primitives.Concurrency.ISequencer)](#api-8b7d70976c60)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive,System.String,ReactiveUI.Primitives.Concurrency.ISequencer,CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter)](#api-ad57b8de2867)

<a id="api-7e8cae7d9733"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive,System.String)`

Create an observable to monitor for registry changes.

```csharp
public static System.IObservable<ReactiveUI.Primitives.RxVoid> CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive hive, string subKey)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Security/RegistryMonitor.cs:17`.

- `hive` (`Microsoft.Win32.RegistryHive`): RegistryHive
- `subKey` (`string`): string

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::Microsoft.Win32.RegistryHive @hive, global::System.String @subKey, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return ((global::System.IObservable<global::ReactiveUI.Primitives.RxVoid>)(global::CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.@ObserveChanges(@hive, @subKey))).Subscribe(operationObserver);
    }
}
```

<a id="api-16ab1859c117"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive,System.String,CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter)`

Create an observable to monitor for registry changes.

```csharp
public static System.IObservable<ReactiveUI.Primitives.RxVoid> CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive hive, string subKey, CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter filter)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Security/RegistryMonitor.cs:35`.

- `hive` (`Microsoft.Win32.RegistryHive`): RegistryHive
- `subKey` (`string`): string
- `filter` (`CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter`): Registry change filter.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::Microsoft.Win32.RegistryHive @hive, global::System.String @subKey, global::CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter @filter, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return ((global::System.IObservable<global::ReactiveUI.Primitives.RxVoid>)(global::CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.@ObserveChanges(@hive, @subKey, @filter))).Subscribe(operationObserver);
    }
}
```

<a id="api-8b7d70976c60"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive,System.String,ReactiveUI.Primitives.Concurrency.ISequencer)`

Create an observable to monitor for registry changes.

```csharp
public static System.IObservable<ReactiveUI.Primitives.RxVoid> CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive hive, string subKey, ReactiveUI.Primitives.Concurrency.ISequencer registrationScheduler)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Security/RegistryMonitor.cs:25`.

- `hive` (`Microsoft.Win32.RegistryHive`): RegistryHive
- `subKey` (`string`): string
- `registrationScheduler` (`ReactiveUI.Primitives.Concurrency.ISequencer`): Scheduler used to register the native wait callback.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::Microsoft.Win32.RegistryHive @hive, global::System.String @subKey, global::ReactiveUI.Primitives.Concurrency.ISequencer @registrationScheduler, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return ((global::System.IObservable<global::ReactiveUI.Primitives.RxVoid>)(global::CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.@ObserveChanges(@hive, @subKey, @registrationScheduler))).Subscribe(operationObserver);
    }
}
```

<a id="api-ad57b8de2867"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive,System.String,ReactiveUI.Primitives.Concurrency.ISequencer,CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter)`

Create an observable to monitor for registry changes.

```csharp
public static System.IObservable<ReactiveUI.Primitives.RxVoid> CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.ObserveChanges(Microsoft.Win32.RegistryHive hive, string subKey, ReactiveUI.Primitives.Concurrency.ISequencer registrationScheduler, CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter filter)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Security/RegistryMonitor.cs:46`.

- `hive` (`Microsoft.Win32.RegistryHive`): RegistryHive
- `subKey` (`string`): string
- `registrationScheduler` (`ReactiveUI.Primitives.Concurrency.ISequencer`): Scheduler used to register the native wait callback.
- `filter` (`CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter`): Registry change filter.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::Microsoft.Win32.RegistryHive @hive, global::System.String @subKey, global::ReactiveUI.Primitives.Concurrency.ISequencer @registrationScheduler, global::CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter @filter, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return ((global::System.IObservable<global::ReactiveUI.Primitives.RxVoid>)(global::CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor.@ObserveChanges(@hive, @subKey, @registrationScheduler, @filter))).Subscribe(operationObserver);
    }
}
```
