// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Reads optional NVIDIA GPU sensors through the installed System32 NVML library.</summary>
#if NETFRAMEWORK
public sealed class NvidiaSensorProvider : IThermalSensorProvider, IDisposable
#else
public sealed partial class NvidiaSensorProvider : IThermalSensorProvider, IDisposable
#endif
{
    /// <summary>The ProviderIdentity value.</summary>
    private const string ProviderIdentity = "provider";

    /// <summary>The GpuName value.</summary>
    private const string GpuName = "NVIDIA GPU";

    /// <summary>The PercentUnit value.</summary>
    private const string PercentUnit = "Percent";

    /// <summary>The BytesUnit value.</summary>
    private const string BytesUnit = "Bytes";

    /// <summary>The NVML NotFound code.</summary>
    private const int NotFound = 6;

    /// <summary>The NVML NoPermission code.</summary>
    private const int NoPermission = 4;

    /// <summary>The NVML DriverNotLoaded code.</summary>
    private const int DriverNotLoaded = 9;

    /// <summary>The NVML LibraryNotFound code.</summary>
    private const int LibraryNotFound = 12;

    /// <summary>The NVML NotSupported code.</summary>
    private const int NotSupported = 3;

    /// <summary>The NVML MemoryClockDomain code.</summary>
    private const int MemoryClockDomain = 2;

    /// <summary>The NVML Timeout code.</summary>
    private const int Timeout = 10;

    /// <summary>The NVML FunctionNotFound code.</summary>
    private const int FunctionNotFound = 13;

    /// <summary>Milliwatts in one Watt.</summary>
    private const double MilliwattsPerWatt = 1000D;

    /// <summary>Serializes reads with shutdown.</summary>
    private readonly Lock _gate = new();

    /// <summary>Tracks successful initialization.</summary>
    private bool _initialized;

    /// <summary>Tracks disposal.</summary>
    private bool _disposed;

    /// <summary>Reads GPU measurements, retaining unavailable measurements and native error codes.</summary>
    /// <returns>GPU sensor measurements with explicit units and availability.</returns>
    public IReadOnlyList<ThermalSensorSample> Capture()
    {
        lock (_gate)
        {
#if NETFRAMEWORK
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(NvidiaSensorProvider));
            }
#else
            ObjectDisposedException.ThrowIf(_disposed, this);
#endif

            var samples = new List<ThermalSensorSample>();
            try
            {
                if (!_initialized)
                {
                    var initialization = NativeMethods.Initialize();
                    if (initialization != 0)
                    {
                        AddUnavailable(samples, ProviderIdentity, GpuName, initialization, null);
                        return samples;
                    }

                    _initialized = true;
                }

                var result = NativeMethods.GetCount(out var count);
                if (result != 0 || count == 0)
                {
                    AddUnavailable(samples, ProviderIdentity, GpuName, result == 0 ? NotFound : result, null);
                    return samples;
                }

                for (uint index = 0; index < count; index++)
                {
                    CaptureDevice(samples, index);
                }
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                AddUnavailable(samples, ProviderIdentity, GpuName, LibraryNotFound, exception.Message);
            }

            return samples;
        }
    }

    /// <summary>Releases this provider's successful NVML initialization after pending reads finish.</summary>
    public void Dispose()
    {
        lock (_gate)
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            if (_initialized)
            {
                _initialized = false;
                _ = NativeMethods.Shutdown();
            }
        }
    }

    /// <summary>Creates a measurement without converting native errors into zero readings.</summary>
    /// <param name="identity">The NVML GPU identity.</param>
    /// <param name="name">The GPU description.</param>
    /// <param name="sensor">The measurement identity.</param>
    /// <param name="unit">The measurement unit.</param>
    /// <param name="result">The native NVML return code.</param>
    /// <param name="value">The reported value.</param>
    /// <param name="error">Optional native binding error.</param>
    /// <returns>The typed measurement.</returns>
    internal static ThermalSensorSample Measurement(string identity, string name, string sensor, string unit, int result, double value, string? error = null) => new()
    {
        SensorId = $"NVML:{identity}:{sensor}",
        Name = $"{name} {sensor}",
        Provider = "NVIDIA NVML",
        Unit = unit,
        Value = result == 0 ? value : null,
        Status = result switch
        {
            0 => WmiQueryStatus.Available,
            NoPermission => WmiQueryStatus.AccessDenied,
            Timeout => WmiQueryStatus.TimedOut,
            1 or NotSupported or NotFound or DriverNotLoaded or LibraryNotFound or FunctionNotFound => WmiQueryStatus.Unavailable,
            _ => WmiQueryStatus.Failed,
        },
        Error = result == 0 ? null : error ?? FormattableString.Invariant($"NVML error {result}"),
    };

    /// <summary>Converts NVML milliwatts into Watts.</summary>
    /// <param name="milliwatts">The native milliwatt reading.</param>
    /// <returns>The power in Watts.</returns>
    internal static double Watts(uint milliwatts) => milliwatts / MilliwattsPerWatt;

    /// <summary>Reads or records GPU measurements.</summary>
    /// <param name="samples">The samples value.</param>
    /// <param name="identity">The identity value.</param>
    /// <param name="name">The name value.</param>
    /// <param name="result">The result value.</param>
    /// <param name="error">The error value.</param>
    private static void AddUnavailable(List<ThermalSensorSample> samples, string identity, string name, int result, string? error)
    {
        samples.Add(Measurement(identity, name, "Temperature", "Celsius", result, 0, error));
        samples.Add(Measurement(identity, name, "Power", "Watts", result, 0, error));
        samples.Add(Measurement(identity, name, "Graphics clock", "MHz", result, 0, error));
        samples.Add(Measurement(identity, name, "SM clock", "MHz", result, 0, error));
        samples.Add(Measurement(identity, name, "Memory clock", "MHz", result, 0, error));
        samples.Add(Measurement(identity, name, "Fan speed", PercentUnit, result, 0, error));
        samples.Add(Measurement(identity, name, "GPU utilization", PercentUnit, result, 0, error));
        samples.Add(Measurement(identity, name, "Memory utilization", PercentUnit, result, 0, error));
        samples.Add(Measurement(identity, name, "Memory total", BytesUnit, result, 0, error));
        samples.Add(Measurement(identity, name, "Memory free", BytesUnit, result, 0, error));
        samples.Add(Measurement(identity, name, "Memory used", BytesUnit, result, 0, error));
    }

    /// <summary>Reads or records GPU measurements.</summary>
    /// <param name="samples">The samples value.</param>
    /// <param name="index">The index value.</param>
    private static unsafe void CaptureDevice(List<ThermalSensorSample> samples, uint index)
    {
        var identity = FormattableString.Invariant($"index-{index}");
        var name = FormattableString.Invariant($"NVIDIA GPU {index}");
        var result = NativeMethods.GetHandle(index, out var device);
        if (result != 0)
        {
            AddUnavailable(samples, identity, name, result, null);
            return;
        }

        const int BufferSize = 256;
        byte* buffer = stackalloc byte[BufferSize];
        if (NativeMethods.GetUuid(device, (IntPtr)buffer, BufferSize) == 0)
        {
            identity = Marshal.PtrToStringAnsi((IntPtr)buffer) ?? identity;
        }

        if (NativeMethods.GetName(device, (IntPtr)buffer, BufferSize) == 0)
        {
            name = Marshal.PtrToStringAnsi((IntPtr)buffer) ?? name;
        }

        result = NativeMethods.GetTemperature(device, 0, out var temperature);
        samples.Add(Measurement(identity, name, "Temperature", "Celsius", result, temperature));
        result = NativeMethods.GetPower(device, out var power);
        samples.Add(Measurement(identity, name, "Power", "Watts", result, Watts(power)));
        result = NativeMethods.GetClock(device, 0, out var graphics);
        samples.Add(Measurement(identity, name, "Graphics clock", "MHz", result, graphics));
        result = NativeMethods.GetClock(device, 1, out var sm);
        samples.Add(Measurement(identity, name, "SM clock", "MHz", result, sm));
        result = NativeMethods.GetClock(device, MemoryClockDomain, out var memoryClock);
        samples.Add(Measurement(identity, name, "Memory clock", "MHz", result, memoryClock));
        result = NativeMethods.GetFan(device, out var fan);
        samples.Add(Measurement(identity, name, "Fan speed", PercentUnit, result, fan));
        result = NativeMethods.GetUtilization(device, out var utilization);
        samples.Add(Measurement(identity, name, "GPU utilization", PercentUnit, result, utilization.Gpu));
        samples.Add(Measurement(identity, name, "Memory utilization", PercentUnit, result, utilization.Memory));
        result = NativeMethods.GetMemory(device, out var memory);
        samples.Add(Measurement(identity, name, "Memory total", BytesUnit, result, memory.Total));
        samples.Add(Measurement(identity, name, "Memory free", BytesUnit, result, memory.Free));
        samples.Add(Measurement(identity, name, "Memory used", BytesUnit, result, memory.Used));
    }

    /// <summary>Sequential NVML native measurement layout.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly record struct NvidiaUtilization
    {
        /// <summary>Gets the native Gpu reading.</summary>
        internal uint Gpu { get; init; }

        /// <summary>Gets the native Memory reading.</summary>
        internal uint Memory { get; init; }
    }

    /// <summary>Sequential NVML native measurement layout.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly record struct NvidiaMemory
    {
        /// <summary>Gets the native Total reading.</summary>
        internal ulong Total { get; init; }

        /// <summary>Gets the native Free reading.</summary>
        internal ulong Free { get; init; }

        /// <summary>Gets the native Used reading.</summary>
        internal ulong Used { get; init; }
    }

    // ABI: NVIDIA/go-nvml/pkg/nvml/nvml.h; unsigned int is 32 bits,
    // unsigned long long is 64 bits, nvmlDevice_t is an opaque pointer, C calling convention.
    /// <summary>Native NVML C declarations.</summary>
#if NETFRAMEWORK
    private static class NativeMethods
#else
    private static partial class NativeMethods
#endif
    {
        /// <summary>Reads Initialize while preserving an absent NVML entry point as unavailable.</summary>
        /// <returns>The NVML result code.</returns>
        internal static int Initialize()
        {
            try
            {
                return InitializeCore();
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads Shutdown while preserving an absent NVML entry point as unavailable.</summary>
        /// <returns>The NVML result code.</returns>
        internal static int Shutdown()
        {
            try
            {
                return ShutdownCore();
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads GetCount while preserving an absent NVML entry point as unavailable.</summary>
        /// <param name="count">The native count value.</param>
        /// <returns>The NVML result code.</returns>
        internal static int GetCount(out uint count)
        {
            try
            {
                return GetCountCore(out count);
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                count = default;
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads GetHandle while preserving an absent NVML entry point as unavailable.</summary>
        /// <param name="index">The native index value.</param>
        /// <param name="device">The native device value.</param>
        /// <returns>The NVML result code.</returns>
        internal static int GetHandle(uint index, out IntPtr device)
        {
            try
            {
                return GetHandleCore(index, out device);
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                device = default;
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads GetName while preserving an absent NVML entry point as unavailable.</summary>
        /// <param name="device">The native device value.</param>
        /// <param name="name">The native name value.</param>
        /// <param name="length">The native length value.</param>
        /// <returns>The NVML result code.</returns>
        internal static int GetName(IntPtr device, IntPtr name, uint length)
        {
            try
            {
                return GetNameCore(device, name, length);
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads GetUuid while preserving an absent NVML entry point as unavailable.</summary>
        /// <param name="device">The native device value.</param>
        /// <param name="uuid">The native uuid value.</param>
        /// <param name="length">The native length value.</param>
        /// <returns>The NVML result code.</returns>
        internal static int GetUuid(IntPtr device, IntPtr uuid, uint length)
        {
            try
            {
                return GetUuidCore(device, uuid, length);
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads GetTemperature while preserving an absent NVML entry point as unavailable.</summary>
        /// <param name="device">The native device value.</param>
        /// <param name="sensor">The native sensor value.</param>
        /// <param name="temperature">The native temperature value.</param>
        /// <returns>The NVML result code.</returns>
        internal static int GetTemperature(IntPtr device, uint sensor, out uint temperature)
        {
            try
            {
                return GetTemperatureCore(device, sensor, out temperature);
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                temperature = default;
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads GetPower while preserving an absent NVML entry point as unavailable.</summary>
        /// <param name="device">The native device value.</param>
        /// <param name="power">The native power value.</param>
        /// <returns>The NVML result code.</returns>
        internal static int GetPower(IntPtr device, out uint power)
        {
            try
            {
                return GetPowerCore(device, out power);
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                power = default;
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads GetClock while preserving an absent NVML entry point as unavailable.</summary>
        /// <param name="device">The native device value.</param>
        /// <param name="clockType">The native clockType value.</param>
        /// <param name="clock">The native clock value.</param>
        /// <returns>The NVML result code.</returns>
        internal static int GetClock(IntPtr device, uint clockType, out uint clock)
        {
            try
            {
                return GetClockCore(device, clockType, out clock);
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                clock = default;
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads GetFan while preserving an absent NVML entry point as unavailable.</summary>
        /// <param name="device">The native device value.</param>
        /// <param name="speed">The native speed value.</param>
        /// <returns>The NVML result code.</returns>
        internal static int GetFan(IntPtr device, out uint speed)
        {
            try
            {
                return GetFanCore(device, out speed);
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                speed = default;
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads GetUtilization while preserving an absent NVML entry point as unavailable.</summary>
        /// <param name="device">The native device value.</param>
        /// <param name="utilization">The native utilization value.</param>
        /// <returns>The NVML result code.</returns>
        internal static int GetUtilization(IntPtr device, out NvidiaUtilization utilization)
        {
            try
            {
                return GetUtilizationCore(device, out utilization);
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                utilization = default;
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Reads GetMemory while preserving an absent NVML entry point as unavailable.</summary>
        /// <param name="device">The native device value.</param>
        /// <param name="memory">The native memory value.</param>
        /// <returns>The NVML result code.</returns>
        internal static int GetMemory(IntPtr device, out NvidiaMemory memory)
        {
            try
            {
                return GetMemoryCore(device, out memory);
            }
            catch (Exception exception) when (exception is DllNotFoundException or EntryPointNotFoundException or BadImageFormatException)
            {
                memory = default;
                return exception is EntryPointNotFoundException ? FunctionNotFound : LibraryNotFound;
            }
        }

        /// <summary>Calls the documented nvmlInit_v2 read or lifecycle entry point.</summary>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlInit_v2", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int InitializeCore();
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlInit_v2")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int InitializeCore();
#endif

        /// <summary>Calls the documented nvmlShutdown read or lifecycle entry point.</summary>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlShutdown", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int ShutdownCore();
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlShutdown")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int ShutdownCore();
#endif

        /// <summary>Calls the documented nvmlDeviceGetCount_v2 read or lifecycle entry point.</summary>
        /// <param name="count">The native count parameter.</param>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlDeviceGetCount_v2", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int GetCountCore(out uint count);
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlDeviceGetCount_v2")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int GetCountCore(out uint count);
#endif

        /// <summary>Calls the documented nvmlDeviceGetHandleByIndex_v2 read or lifecycle entry point.</summary>
        /// <param name="index">The native index parameter.</param>
        /// <param name="device">The native device parameter.</param>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlDeviceGetHandleByIndex_v2", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int GetHandleCore(uint index, out IntPtr device);
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlDeviceGetHandleByIndex_v2")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int GetHandleCore(uint index, out IntPtr device);
#endif

        /// <summary>Calls the documented nvmlDeviceGetName read or lifecycle entry point.</summary>
        /// <param name="device">The native device parameter.</param>
        /// <param name="name">The native name parameter.</param>
        /// <param name="length">The native length parameter.</param>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlDeviceGetName", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int GetNameCore(IntPtr device, IntPtr name, uint length);
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlDeviceGetName")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int GetNameCore(IntPtr device, IntPtr name, uint length);
#endif

        /// <summary>Calls the documented nvmlDeviceGetUUID read or lifecycle entry point.</summary>
        /// <param name="device">The native device parameter.</param>
        /// <param name="uuid">The native uuid parameter.</param>
        /// <param name="length">The native length parameter.</param>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlDeviceGetUUID", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int GetUuidCore(IntPtr device, IntPtr uuid, uint length);
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlDeviceGetUUID")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int GetUuidCore(IntPtr device, IntPtr uuid, uint length);
#endif

        /// <summary>Calls the documented nvmlDeviceGetTemperature read or lifecycle entry point.</summary>
        /// <param name="device">The native device parameter.</param>
        /// <param name="sensor">The native sensor parameter.</param>
        /// <param name="temperature">The native temperature parameter.</param>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlDeviceGetTemperature", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int GetTemperatureCore(IntPtr device, uint sensor, out uint temperature);
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlDeviceGetTemperature")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int GetTemperatureCore(IntPtr device, uint sensor, out uint temperature);
#endif

        /// <summary>Calls the documented nvmlDeviceGetPowerUsage read or lifecycle entry point.</summary>
        /// <param name="device">The native device parameter.</param>
        /// <param name="power">The native power parameter.</param>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlDeviceGetPowerUsage", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int GetPowerCore(IntPtr device, out uint power);
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlDeviceGetPowerUsage")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int GetPowerCore(IntPtr device, out uint power);
#endif

        /// <summary>Calls the documented nvmlDeviceGetClockInfo read or lifecycle entry point.</summary>
        /// <param name="device">The native device parameter.</param>
        /// <param name="clockType">The native clockType parameter.</param>
        /// <param name="clock">The native clock parameter.</param>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlDeviceGetClockInfo", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int GetClockCore(IntPtr device, uint clockType, out uint clock);
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlDeviceGetClockInfo")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int GetClockCore(IntPtr device, uint clockType, out uint clock);
#endif

        /// <summary>Calls the documented nvmlDeviceGetFanSpeed read or lifecycle entry point.</summary>
        /// <param name="device">The native device parameter.</param>
        /// <param name="speed">The native speed parameter.</param>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlDeviceGetFanSpeed", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int GetFanCore(IntPtr device, out uint speed);
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlDeviceGetFanSpeed")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int GetFanCore(IntPtr device, out uint speed);
#endif

        /// <summary>Calls the documented nvmlDeviceGetUtilizationRates read or lifecycle entry point.</summary>
        /// <param name="device">The native device parameter.</param>
        /// <param name="utilization">The native utilization parameter.</param>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlDeviceGetUtilizationRates", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int GetUtilizationCore(IntPtr device, out NvidiaUtilization utilization);
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlDeviceGetUtilizationRates")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int GetUtilizationCore(IntPtr device, out NvidiaUtilization utilization);
#endif

        /// <summary>Calls the documented nvmlDeviceGetMemoryInfo read or lifecycle entry point.</summary>
        /// <param name="device">The native device parameter.</param>
        /// <param name="memory">The native memory parameter.</param>
        /// <returns>The NVML return code.</returns>
#if NETFRAMEWORK
        [DllImport("nvml.dll", EntryPoint = "nvmlDeviceGetMemoryInfo", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int GetMemoryCore(IntPtr device, out NvidiaMemory memory);
#else
        [LibraryImport("nvml.dll", EntryPoint = "nvmlDeviceGetMemoryInfo")]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static partial int GetMemoryCore(IntPtr device, out NvidiaMemory memory);
#endif
    }
}
