<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.#ctor(System.Boolean)](#api-2c6b17328826)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.#ctor(System.String)](#api-ea0edf805c14)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.#ctor(System.String,System.Boolean)](#api-08f3b89d9049)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.#ctor](#api-060cc155a346)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Cancel](#api-01898ca0885c)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Dispose](#api-0598ed7f5545)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.ObserveSignals(System.TimeSpan)](#api-b42ee77524da)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.ObserveSignals](#api-0cf165c718f5)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetAt(System.DateTimeOffset)](#api-3c3a76167241)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetAt(System.DateTimeOffset,System.Boolean)](#api-ba483ad6bd2d)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetOnce(System.TimeSpan)](#api-86b78031f9b4)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetOnce(System.TimeSpan,System.Boolean)](#api-b6e7a409f3b1)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetPeriodic(System.TimeSpan,System.Int32)](#api-d0c3a08a0d8c)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetPeriodic(System.TimeSpan,System.Int32,System.Boolean)](#api-0ec0a5977ef2)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Wait(System.TimeSpan)](#api-e191b019a5bd)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Wait](#api-c59aa5a0808f)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync(System.Threading.CancellationToken)](#api-bc86c7e0bd78)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync(System.TimeSpan)](#api-b704cf8c97e8)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync(System.TimeSpan,System.Threading.CancellationToken)](#api-b2c1586edde5)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync](#api-fd2fb128d43f)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.IsValid](#api-12b53312d180)

<a id="api-2c6b17328826"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.#ctor(System.Boolean)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitableTimer(bool manualReset)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:54`.

- `manualReset` (`bool`): If true, creates a manual-reset notification timer. If false, creates a synchronization timer.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.Boolean @manualReset)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer(@manualReset);
    }
}
```

<a id="api-ea0edf805c14"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.#ctor(System.String)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitableTimer(string name)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:61`.

- `name` (`string`): The name of the timer.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.String @name)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer(@name);
    }
}
```

<a id="api-08f3b89d9049"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.#ctor(System.String,System.Boolean)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitableTimer(string name, bool manualReset)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:72`.

- `name` (`string`): The name of the timer.
- `manualReset` (`bool`): If true, creates a manual-reset notification timer. If false, creates a synchronization timer.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.String @name, global::System.Boolean @manualReset)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer(@name, @manualReset);
    }
}
```

<a id="api-060cc155a346"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.#ctor`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitableTimer()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:44`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer();
    }
}
```

<a id="api-01898ca0885c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Cancel`

Cancels the timer so it no longer fires.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Cancel()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:146`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Cancel()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-0598ed7f5545"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Dispose`

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Dispose()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:234`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Dispose()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-b42ee77524da"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.ObserveSignals(System.TimeSpan)`

Observes each waitable timer signal until the subscription is disposed or a wait times out.

```csharp
public System.IObservable<System.DateTimeOffset> CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.ObserveSignals(System.TimeSpan timeout)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:195`.

- `timeout` (`System.TimeSpan`): Maximum time to wait between timer signals.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.TimeSpan @timeout, global::System.IObserver<global::System.DateTimeOffset> operationObserver)
    {
        return ((global::System.IObservable<global::System.DateTimeOffset>)(receiver.@ObserveSignals(@timeout))).Subscribe(operationObserver);
    }
}
```

<a id="api-0cf165c718f5"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.ObserveSignals`

Observes each waitable timer signal until the subscription is disposed.

```csharp
public System.IObservable<System.DateTimeOffset> CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.ObserveSignals()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:190`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.IObserver<global::System.DateTimeOffset> operationObserver)
    {
        return ((global::System.IObservable<global::System.DateTimeOffset>)(receiver.@ObserveSignals())).Subscribe(operationObserver);
    }
}
```

<a id="api-3c3a76167241"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetAt(System.DateTimeOffset)`

Sets the timer to fire at the specified absolute UTC time.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetAt(System.DateTimeOffset dueTime)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:107`.

- `dueTime` (`System.DateTimeOffset`): The UTC time at which the timer should fire.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.DateTimeOffset @dueTime, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@SetAt(@dueTime)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-ba483ad6bd2d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetAt(System.DateTimeOffset,System.Boolean)`

Sets the timer to fire at the specified absolute UTC time.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetAt(System.DateTimeOffset dueTime, bool wakeSystem)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:116`.

- `dueTime` (`System.DateTimeOffset`): The UTC time at which the timer should fire.
- `wakeSystem` (`bool`): If true, the system will be woken from sleep or hibernation when the timer fires. Requires the SE_SYSTEMTIME_NAME privilege.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.DateTimeOffset @dueTime, global::System.Boolean @wakeSystem, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@SetAt(@dueTime, @wakeSystem)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-86b78031f9b4"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetOnce(System.TimeSpan)`

Sets the timer to fire once after the specified delay.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetOnce(System.TimeSpan delay)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:88`.

- `delay` (`System.TimeSpan`): The delay before the timer fires.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.TimeSpan @delay, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@SetOnce(@delay)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-b6e7a409f3b1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetOnce(System.TimeSpan,System.Boolean)`

Sets the timer to fire once after the specified delay.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetOnce(System.TimeSpan delay, bool wakeSystem)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:97`.

- `delay` (`System.TimeSpan`): The delay before the timer fires.
- `wakeSystem` (`bool`): If true, the system will be woken from sleep or hibernation when the timer fires. Requires the SE_SYSTEMTIME_NAME privilege.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.TimeSpan @delay, global::System.Boolean @wakeSystem, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@SetOnce(@delay, @wakeSystem)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d0c3a08a0d8c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetPeriodic(System.TimeSpan,System.Int32)`

Sets the timer to fire periodically.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetPeriodic(System.TimeSpan initialDelay, int period)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:127`.

- `initialDelay` (`System.TimeSpan`): The delay before the first firing.
- `period` (`int`): The period between subsequent firings, in milliseconds.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.TimeSpan @initialDelay, global::System.Int32 @period, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@SetPeriodic(@initialDelay, @period)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-0ec0a5977ef2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetPeriodic(System.TimeSpan,System.Int32,System.Boolean)`

Sets the timer to fire periodically.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.SetPeriodic(System.TimeSpan initialDelay, int period, bool wakeSystem)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:137`.

- `initialDelay` (`System.TimeSpan`): The delay before the first firing.
- `period` (`int`): The period between subsequent firings, in milliseconds.
- `wakeSystem` (`bool`): If true, the system will be woken from sleep or hibernation on the first firing. Requires the SE_SYSTEMTIME_NAME privilege.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.TimeSpan @initialDelay, global::System.Int32 @period, global::System.Boolean @wakeSystem, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@SetPeriodic(@initialDelay, @period, @wakeSystem)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-e191b019a5bd"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Wait(System.TimeSpan)`

Waits for the timer to be signaled.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Wait(System.TimeSpan timeout)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:155`.

- `timeout` (`System.TimeSpan`): Maximum time to wait. Use F:System.Threading.Timeout.InfiniteTimeSpan to wait indefinitely.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.TimeSpan @timeout, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Wait(@timeout)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-c59aa5a0808f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Wait`

Waits indefinitely for the timer to be signaled.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.Wait()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:162`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Wait()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-bc86c7e0bd78"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync(System.Threading.CancellationToken)`

Asynchronously waits indefinitely for the timer to be signaled.

```csharp
public System.Threading.Tasks.ValueTask<bool> CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync(System.Threading.CancellationToken cancellationToken)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:171`.

- `cancellationToken` (`System.Threading.CancellationToken`): The cancellation token.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.Threading.CancellationToken @cancellationToken, global::System.IObserver<global::System.Threading.Tasks.ValueTask<global::System.Boolean>> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@WaitAsync(@cancellationToken)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-b704cf8c97e8"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync(System.TimeSpan)`

Asynchronously waits for the timer to be signaled.

```csharp
public System.Threading.Tasks.ValueTask<bool> CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync(System.TimeSpan timeout)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:176`.

- `timeout` (`System.TimeSpan`): Maximum time to wait. Use F:System.Threading.Timeout.InfiniteTimeSpan to wait indefinitely.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.TimeSpan @timeout, global::System.IObserver<global::System.Threading.Tasks.ValueTask<global::System.Boolean>> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@WaitAsync(@timeout)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-b2c1586edde5"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync(System.TimeSpan,System.Threading.CancellationToken)`

Asynchronously waits for the timer to be signaled.

```csharp
public System.Threading.Tasks.ValueTask<bool> CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync(System.TimeSpan timeout, System.Threading.CancellationToken cancellationToken)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:182`.

- `timeout` (`System.TimeSpan`): Maximum time to wait. Use F:System.Threading.Timeout.InfiniteTimeSpan to wait indefinitely.
- `cancellationToken` (`System.Threading.CancellationToken`): The cancellation token.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.TimeSpan @timeout, global::System.Threading.CancellationToken @cancellationToken, global::System.IObserver<global::System.Threading.Tasks.ValueTask<global::System.Boolean>> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@WaitAsync(@timeout, @cancellationToken)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-fd2fb128d43f"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync`

Asynchronously waits indefinitely for the timer to be signaled.

```csharp
public System.Threading.Tasks.ValueTask<bool> CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.WaitAsync()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:166`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver, global::System.IObserver<global::System.Threading.Tasks.ValueTask<global::System.Boolean>> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@WaitAsync()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-12b53312d180"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.IsValid`

Gets a value indicating whether the timer has been created successfully.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer.IsValid { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Power/WaitableTimer.cs:83`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer receiver)
    {
        _ = receiver.@IsValid;
    }
}
```
