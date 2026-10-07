# Windows Task Manager example

A native WPF dashboard built on the lean Windows primitives package. It samples CPU, memory, processes, network, storage, GPU, power, hardware and thermal providers every second. The view coalesces updates on the dispatcher and keeps 60 CPU and memory samples. Logical processor tiles show each core's utilization history and frequency.

Run from the repository root on Windows:

```powershell
dotnet run --project src/CP.ReactiveUI.Primitives.Windows.Example.TaskManager/CP.ReactiveUI.Primitives.Windows.Example.TaskManager.csproj --framework net10.0-windows10.0.19041.0
```

The project also targets .NET Framework 4.8. Click table column headers to sort process measurements; the sort is retained across samples. Hardware tabs show CPU, memory modules, GPU, storage, OS, machine inventory and query availability; the GPU counters, network and disk tabs expose live counters and provider diagnostics. No data is fabricated. Empty rates require a second sample or indicate an unsupported counter; provider errors appear along the bottom. Windows thermal providers commonly expose no usable sensors.

Monitoring is read-only. The Power tab activates an installed Windows power scheme only after you select it and click **Apply power plan**. That explicit change persists in Windows. This example never changes process priorities or terminates processes. Closing the view stops rendering and unsubscribes on a worker thread to avoid blocking the dispatcher during native cleanup.

The Services tab shows Windows service inventory. Hardware → Thermals includes firmware zones and an optional NVIDIA NVML sensor provider. When the installed NVIDIA driver exposes its System32 NVML library, it reports GPU temperature, power, clocks, fan percentage, utilization, and memory counters. Unsupported measurements retain their reason and status; NVML is not downloaded or installed by the example.
