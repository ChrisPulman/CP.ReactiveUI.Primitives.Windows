# Windows system monitoring

The `Desktop.SystemMonitoring` namespace adds cold observable monitoring to the existing desktop capabilities. Each subscription owns its sampler and any native resources. Sampling starts on a background thread when subscribed; disposing the subscription stops sampling and releases those resources. Intervals must be at least one millisecond and within the Windows timer range. UI callers should dispatch notifications to their UI scheduler before updating controls.

The equivalent APIs are available under `CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring` in the Reactive package.

```csharp
var snapshots = WindowsSystem.Monitor()
    .WithCpu()
    .WithMemory()
    .WithProcesses()
    .WithNetwork()
    .WithStorage()
    .WithGraphics()
    .WithPower()
    .WithHardware()
    .WithThermals()
    .Every(TimeSpan.FromSeconds(1))
    .RefreshHardwareEvery(TimeSpan.FromMinutes(5))
    .RefreshThermalsEvery(TimeSpan.FromSeconds(5))
    .Observe();
```

`WithAll()` selects every supported monitor. Hardware inventory and thermal reads have separate refresh intervals so a fast performance stream can reuse slower inventory snapshots. Each selected field of `SystemSnapshot` is a `MonitoringResult<T>` with `Status`, nullable `Value`, `Error`, `IsAvailable` and `CapturedAt`; check availability before consuming its value. One failed monitor can report its error while the other selected monitors continue producing results.

| API | Available information |
| --- | --- |
| `CpuMonitoring.Capture()` / `Observe(interval)` | Aggregate and logical processor utilization, topology and processor information. Rate counters need an initial sample before utilization is available. |
| `MemoryMonitoring.Capture()` / `Observe(interval)` | Total/available physical memory, commit total/limit/peak, cache, kernel pools, page size, process/thread/handle counts. |
| `ProcessMonitoring.Capture(processId, includeExtendedIdentity)` / `Observe(...)` | Process identity, memory, CPU deltas, thread/handle and I/O counts; optional protected identity details report availability. Process exit and access denial are expected conditions. |
| `NetworkMonitoring.Capture()` / `Observe(interval)` | Network interfaces, cumulative byte and packet totals, throughput deltas and protocol statistics. `CaptureConnections()` provides active connections. |
| `StorageMonitoring.Capture()` / `Observe(interval)` | Mounted drive capacity and free space, physical disk read/write rates and performance counters. |
| `HardwareMonitoring.Capture()` / `Observe(interval)` | Detached WMI inventory: machine, OS, BIOS, baseboard, processors, memory modules/arrays, disks and PnP devices. Query status describes missing providers and access restrictions. |
| `GraphicsMonitoring.Capture()` / `Observe(interval)` | WMI adapter inventory and GPU engine/dedicated/shared memory PDH counters. Counter instance identities retain their LUID; WMI adapter indices are not assumed to identify those LUIDs. |
| `ThermalMonitoring.Capture(provider)` / `Observe(interval, provider)` | ACPI thermal zones and readings supplied by an optional `IThermalSensorProvider`. |
| `NvidiaSensorProvider` | Optional installed-driver NVML readings for GPU temperature, power, graphics/SM/memory clocks, fan percentage, utilization and memory capacity/usage. |
| `PowerMonitoring.Capture()` / `Observe(interval)` | AC/battery state and Windows battery estimates. |
| `PowerPlans.GetPlans()` / `GetActive()` | Installed power schemes and active scheme; explicit plan operations expose settings and activation. |
| `BrightnessMonitoring.Capture()` / `Observe(interval)` | Supported internal display brightness and external monitor brightness through their supported interfaces. |
| `PerformanceCounterMonitoring.Observe(paths, interval)` | Arbitrary English PDH counter paths, including wildcard instances. |
| `WindowsManagement` | Detached WMI rows with explicit query status, enabling additional Windows provider queries. |
| `ServiceMonitoring.Capture()` / `Observe(interval)` | Service names, display names, state, startup mode, account, executable path, PID, accepted controls, and exit codes. |

## Fluent commands and event streams

Commands execute only when explicitly called. Creating a monitor or subscribing to a stream performs reads rather than settings changes.

```csharp
ProcessTarget.ForId(processId)
    .WithPriority(System.Diagnostics.ProcessPriorityClass.BelowNormal);

PowerPlan.ForId(planId)
    .WithAcValue(PowerSettings.ProcessorSubgroup, PowerSettings.ProcessorMaximumState, 80)
    .Activate();

var serviceResult = ServiceTarget.ForName("MyService").Start();
// A native success code means the request was accepted; observe service state to await completion.
if (!serviceResult.IsAccepted)
{
    Console.WriteLine(serviceResult.Error);
}

BrightnessPanel.ForDisplay(displayInstanceName).SetBrightness(50);

var processStarts = WindowsManagement.ObserveChanges(
    @"root\cimv2", "SELECT * FROM Win32_ProcessStartTrace");
var addresses = NetworkMonitoring.ObserveAddressChanges();
```

Service results retain native method return codes, and their `Target` can be used for another explicit operation. Process control targets bind to creation time and retain a query handle throughout each command to prevent PID reuse during execution. This follows Windows' [process-object lifetime semantics](https://devblogs.microsoft.com/oldnewthing/20110107-00/?p=11803%2F). Telemetry requests query-only access rather than all-access rights, and native calls receive SafeHandle arguments so their lifetime is protected during marshalling. Process parent/command-line enrichment is optional because it adds WMI work to each sample; use `WithExtendedProcessIdentity()` deliberately. `WithProcesses(processId)` limits sampling to one process.

Use `WithAll()` to select all built-in monitoring categories, or `WithoutSections(...)` to remove categories from an immutable configuration. Hardware and thermal refresh intervals can be changed independently with `RefreshHardwareEvery(...)` and `RefreshThermalsEvery(...)`. Individual `Capture` and `Observe` functions remain available when a composite snapshot is unnecessary.

Supported external-monitor brightness is exposed through disposable `BrightnessDisplay.OpenForMonitor(...)` sessions. Dispose each returned session after use. DDC/CI support and value ranges are queried before adjustment; internal-panel WMI brightness uses percentage values. Changes can require elevation or provider-specific permissions, and native failures are reported rather than suppressed.

## Generic English performance counters

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;

using var query = new PerformanceCounterQuery(new[]
{
    @"\Processor Information(*)\% Processor Time",
    @"\Memory\Available Bytes",
});

var first = query.Capture();
// Capture again after your chosen interval for rate counters.
var current = query.Capture();

var stream = PerformanceCounterMonitoring.Observe(
    new[] { @"\GPU Engine(*)\Utilization Percentage" },
    TimeSpan.FromSeconds(1));
```

The constructor snapshots and validates the path collection. It opens PDH resources on the first capture; a stream opens them only after subscription. Queries are disposable and serialize capture against disposal. Counter category availability depends on the Windows version, driver and installed providers. Native errors appear as samples with a null `Value` and their native `Status`, rather than fabricated zeroes. Status zero (`PDH_CSTATUS_VALID_DATA`) and one (`PDH_CSTATUS_NEW_DATA`) identify valid values. Rate counters may need two captures; do not interpret their first null value as zero activity. `CounterPath` preserves the requested English path and `InstanceName` identifies each wildcard result.

PDH uses English names independently of the Windows display language. Wildcard queries read formatted arrays; instance additions can cause buffer resizing and are retried. See Microsoft's [English counter API](https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhaddenglishcounterw), [formatted array API](https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetformattedcounterarrayw), [formatted values](https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetformattedcountervalue), and [PDH status semantics](https://learn.microsoft.com/en-us/windows/win32/perfctrs/pdh-error-codes).

## Sensor and provider limits

Windows does not provide a universal user-mode API for CPU core or GPU temperatures, fan speeds, voltage, NVMe SMART health, or vendor overclocking controls. ACPI thermal-zone temperatures describe firmware zones; they are not CPU core measurements. WMI `AdapterRAM` can be inaccurate, particularly for memory above four GiB. GPU counter categories require suitable Windows/driver support and can be unavailable on a machine with otherwise valid display adapters.

Use a vendor-supported sensor implementation through `IThermalSensorProvider` when these readings are required. Missing categories, sensors, providers, permissions, monitor capabilities and battery estimates remain explicitly unavailable. Hardware inventory does not imply support for modifying hardware. External monitor brightness also depends on the monitor, transport and DDC/CI support.

The built-in NVIDIA provider reads the installed driver's `nvml.dll` only from System32. It does not install a driver or write hardware settings. Native GPU UUIDs identify sensors; fallback ordinal identities are explicitly NVML identities, not WMI indices or PDH LUID mappings. GPU power is converted from milliwatts to watts, and fan speed is a percentage rather than fabricated RPM. Every unsupported native reading retains its status.

```csharp
var sensors = WindowsSystem.Monitor()
    .WithCpu().WithMemory().WithGraphics()
    .WithThermals(static () => new NvidiaSensorProvider())
    .RefreshThermalsEvery(TimeSpan.FromSeconds(5))
    .Every(TimeSpan.FromSeconds(1))
    .Observe();
```

The factory creates a vendor provider per subscription. A factory-created provider implementing `IDisposable` is disposed with the monitor; a provider passed directly to `ThermalMonitoring.Capture` or `Observe` stays caller-owned. NVIDIA API availability varies by driver and GPU. See the [NVML initialization/lifetime contract](https://docs.nvidia.com/deploy/nvml-api/latest/api/group__nvmlInitializationAndCleanup.html) and [device query APIs](https://docs.nvidia.com/deploy/nvml-api/latest/api/group__nvmlDeviceQueries.html).

## Existing desktop capabilities

The existing desktop surface remains available for window discovery/manipulation, message and event hooks, keyboard/mouse/raw input, display/DPI information, clipboard, device notifications, media, power/session lifecycle, shell dialogs/icons, app operations, capture/composition and registry/settings operations. Those APIs perform event observation or specific desktop actions; the monitoring APIs above add recurring system snapshots and performance rates. Use direct `Capture` calls when a one-time snapshot suffices, and dispose observable subscriptions when their owning view or service closes.
