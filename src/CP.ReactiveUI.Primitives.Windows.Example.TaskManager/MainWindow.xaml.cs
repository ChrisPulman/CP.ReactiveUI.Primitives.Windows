// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if !NETFRAMEWORK
using System.Runtime.InteropServices;
#endif
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;

namespace CP.ReactiveUI.Primitives.Windows.Example.TaskManager;

/// <summary>Shows live native measurements without changing system settings during monitoring.</summary>
public partial class MainWindow : Window
{
    /// <summary>The maximum samples kept for each graph.</summary>
    private const int HistoryCapacity = 60;

    /// <summary>The graph's fixed percentage ceiling.</summary>
    private const double PercentMaximum = 100;

    /// <summary>The graph's logical height in pixels.</summary>
    private const double GraphHeight = 110;

    /// <summary>The graph's width for each logical processor.</summary>
    private const double CoreGraphWidth = 140;

    /// <summary>The bytes in one gibibyte.</summary>
    private const double BytesPerGibibyte = 1_073_741_824;

    /// <summary>The UI coalescing timer interval in milliseconds.</summary>
    private const int RenderIntervalMilliseconds = 500;

    /// <summary>The bounded aggregate CPU history.</summary>
    private readonly Queue<double> _cpuHistory = new();

    /// <summary>The bounded physical memory history.</summary>
    private readonly Queue<double> _memoryHistory = new();

    /// <summary>The bounded per-processor histories keyed by native instance identity.</summary>
    private readonly Dictionary<string, Queue<double>> _coreHistory = [with(comparer: StringComparer.Ordinal)];

    /// <summary>The UI timer that coalesces incoming snapshots.</summary>
    private readonly DispatcherTimer _renderTimer;

    /// <summary>The subscription owned by this view.</summary>
    private IDisposable? _subscription;

    /// <summary>The newest unrendered snapshot.</summary>
    private SystemSnapshot? _pending;

    /// <summary>Initializes a new instance of the <see cref="MainWindow"/> class.</summary>
    public MainWindow()
    {
        InitializeComponent();
        _renderTimer = new(DispatcherPriority.Background, Dispatcher)
        {
            Interval = TimeSpan.FromMilliseconds(RenderIntervalMilliseconds),
        };
        _renderTimer.Tick += RenderLatest;
        Loaded += LoadPowerPlans;
        Closed += CloseMonitor;
    }

    /// <summary>Draws a bounded history using a fixed percentage scale.</summary>
    /// <param name="history">The samples to update.</param>
    /// <param name="sample">The latest available percentage.</param>
    /// <param name="line">The graph stroke.</param>
    /// <param name="width">The graph width.</param>
    private static void DrawHistory(Queue<double> history, double sample, Polyline line, double width)
        => line.Points = UpdateHistory(history, sample, width);

    /// <summary>Appends a percentage and returns graph points for the bounded history.</summary>
    /// <param name="history">The samples to update.</param>
    /// <param name="sample">The latest percentage.</param>
    /// <param name="width">The graph width.</param>
    /// <returns>The points on the fixed percentage scale.</returns>
    private static PointCollection UpdateHistory(Queue<double> history, double sample, double width)
    {
        history.Enqueue(Math.Max(0, Math.Min(PercentMaximum, sample)));
        if (history.Count > HistoryCapacity)
        {
            _ = history.Dequeue();
        }

        PointCollection points = new(history.Count);
        var index = HistoryCapacity - history.Count;
        foreach (var value in history)
        {
            points.Add(new(index * width / (HistoryCapacity - 1), GraphHeight - (value * GraphHeight / PercentMaximum)));
            index++;
        }

        return points;
    }

    /// <summary>Adds an unavailable provider's reason to the visible status.</summary>
    /// <typeparam name="T">The measurement type.</typeparam>
    /// <param name="text">The output status.</param>
    /// <param name="name">The provider name.</param>
    /// <param name="result">The provider result.</param>
    private static void AppendStatus<T>(StringBuilder text, string name, MonitoringResult<T> result)
    {
        if (!result.IsAvailable)
        {
            _ = text.Append(name).Append(": ").Append(result.Error ?? result.Status.ToString()).AppendLine();
        }
    }

    /// <summary>Adds unavailable native queries to the visible status.</summary>
    /// <param name="text">The output status.</param>
    /// <param name="name">The provider name.</param>
    /// <param name="result">The native query result.</param>
    private static void AppendQueryStatus(StringBuilder text, string name, WmiQueryResult? result)
    {
        if (result is not null && result.Status != WmiQueryStatus.Available)
        {
            _ = text.Append(name).Append(": ").Append(result.Error ?? result.Status.ToString()).AppendLine();
        }
    }

    /// <summary>Updates all tabs from the latest snapshot on the UI thread.</summary>
    /// <param name="sender">The rendering timer.</param>
    /// <param name="args">The tick arguments.</param>
    private void RenderLatest(object? sender, EventArgs args)
    {
        var snapshot = Interlocked.Exchange(ref _pending, null);
        if (snapshot is null)
        {
            return;
        }

        DataContext = snapshot;
        UpdateProcesses(snapshot.Processes.Value);
        UpdateCores(snapshot.Cpu.Value);
        CaptureStatus.Text = $"LIVE  •  Sample {snapshot.Sequence:N0}  •  {snapshot.Timestamp.ToLocalTime():T}  •  click column headers to sort";
        if (snapshot.Cpu.Value?.Total.TotalPercent is { } cpu)
        {
            CpuText.Text = $"{cpu:F1} %";
            DrawHistory(_cpuHistory, cpu, CpuLine, CpuCanvas.ActualWidth);
        }
        else
        {
            CpuText.Text = snapshot.Cpu.Error ?? "Waiting for CPU baseline";
        }

        if (snapshot.Memory.Value is { } memory && memory.TotalPhysicalBytes != 0)
        {
            var used = memory.TotalPhysicalBytes - memory.AvailablePhysicalBytes;
            var percent = used * PercentMaximum / memory.TotalPhysicalBytes;
            MemoryText.Text = $"{used / BytesPerGibibyte:F1} / {memory.TotalPhysicalBytes / BytesPerGibibyte:F1} GiB";
            DrawHistory(_memoryHistory, percent, MemoryLine, MemoryCanvas.ActualWidth);
        }
        else
        {
            MemoryText.Text = snapshot.Memory.Error ?? "Physical memory unavailable";
        }

        UpdateProviderStatus(snapshot);
    }

    /// <summary>Reports provider availability and native query failures.</summary>
    /// <param name="snapshot">The latest monitoring results.</param>
    private void UpdateProviderStatus(SystemSnapshot snapshot)
    {
        StringBuilder status = new();
        AppendStatus(status, "CPU", snapshot.Cpu);
        AppendStatus(status, "Memory", snapshot.Memory);
        AppendStatus(status, "Processes", snapshot.Processes);
        AppendStatus(status, "Network", snapshot.Network);
        AppendStatus(status, "Storage", snapshot.Storage);
        AppendStatus(status, "GPU", snapshot.Graphics);
        AppendStatus(status, "Power", snapshot.Power);
        AppendStatus(status, "Hardware", snapshot.Hardware);
        AppendStatus(status, "Thermals", snapshot.Thermals);
        if (snapshot.Hardware.Value is { } hardware)
        {
            foreach (var query in hardware.Queries)
            {
                AppendQueryStatus(status, query.Key, query.Value);
            }
        }

        if (snapshot.Network.Value is { } network)
        {
            foreach (var error in network.Errors)
            {
                _ = status.Append("Network: ").Append(error).AppendLine();
            }
        }

        AppendQueryStatus(status, "Thermals", snapshot.Thermals.Value?.ThermalZones);
        AppendQueryStatus(status, "GPU inventory", snapshot.Graphics.Value?.Inventory);

        ProviderStatus.Text = status.Length == 0 ? "Providers available. Blank counters are unavailable or awaiting a rate baseline. Monitoring is read-only." : status.ToString();
    }

    /// <summary>Retains the user's process sort choice when replacing the live snapshot.</summary>
    /// <param name="snapshot">The latest process collection.</param>
    private void UpdateProcesses(ProcessSnapshot? snapshot)
    {
        var previous = CollectionViewSource.GetDefaultView(ProcessTable.ItemsSource);
        var sorts = previous?.SortDescriptions;
        ProcessTable.ItemsSource = snapshot?.Processes;
        var current = CollectionViewSource.GetDefaultView(ProcessTable.ItemsSource);
        if (sorts is not null && current is not null)
        {
            foreach (var sort in sorts)
            {
                current.SortDescriptions.Add(sort);
            }
        }
        else if (current is not null)
        {
            current.SortDescriptions.Add(new(nameof(ProcessInfo.WorkingSetBytes), ListSortDirection.Descending));
        }
    }

    /// <summary>Builds per-core tiles with bounded histories.</summary>
    /// <param name="sample">The latest CPU sample.</param>
    private void UpdateCores(CpuSample? sample)
    {
        List<CoreTile> tiles = new();
        if (sample is not null)
        {
            foreach (var processor in sample.LogicalProcessors)
            {
                var history = GetCoreHistory(processor.InstanceName);
                var points = processor.Utilization.TotalPercent is { } percent
                    ? UpdateHistory(history, percent, CoreGraphWidth)
                    : new PointCollection();
                tiles.Add(new(processor, points));
            }
        }

        CoreTiles.ItemsSource = tiles;
    }

    /// <summary>Gets the bounded history for one native processor instance.</summary>
    /// <param name="instanceName">The stable performance-counter identity.</param>
    /// <returns>The processor's history queue.</returns>
    private Queue<double> GetCoreHistory(string instanceName)
    {
#if NETFRAMEWORK
        if (!_coreHistory.TryGetValue(instanceName, out var history))
        {
            history = new();
            _coreHistory.Add(instanceName, history);
        }

        return history;
#else
        ref var history = ref CollectionsMarshal.GetValueRefOrAddDefault(_coreHistory, instanceName, out _);
        return history ??= new();
#endif
    }

    /// <summary>Reads installed plans off the UI thread without applying any scheme.</summary>
    /// <param name="sender">The loaded view.</param>
    /// <param name="args">The load arguments.</param>
    private async void LoadPowerPlans(object sender, RoutedEventArgs args)
    {
        Loaded -= LoadPowerPlans;
        _subscription = WindowsSystem.Monitor().WithCpu().WithMemory().WithProcesses().WithNetwork()
            .WithStorage().WithGraphics().WithPower().WithHardware().WithServices()
            .WithThermals(static () => new NvidiaSensorProvider())
            .Every(TimeSpan.FromSeconds(1)).Observe().Subscribe(new SnapshotObserver(this));
        _renderTimer.Start();
        try
        {
            var plans = await Task.Run(PowerPlans.GetPlans);
            if (IsVisible)
            {
                PlanChooser.ItemsSource = plans;
                PowerStatus.Text = "Select a plan to enable an explicit change.";
            }
        }
        catch (NativeWin32Exception exception)
        {
            PowerStatus.Text = exception.Message;
        }
    }

    /// <summary>Applies only the scheme explicitly selected by the user.</summary>
    /// <param name="sender">The apply button.</param>
    /// <param name="args">The click arguments.</param>
    private void ApplyPowerPlan(object sender, RoutedEventArgs args)
    {
        if (PlanChooser.SelectedItem is not PowerPlan plan)
        {
            PowerStatus.Text = "Select an installed power plan first.";
            return;
        }

        try
        {
            PowerPlans.SetActive(plan.Id);
            PowerStatus.Text = "Selected power plan activated in Windows.";
        }
        catch (NativeWin32Exception exception)
        {
            PowerStatus.Text = exception.Message;
        }
    }

    /// <summary>Stops UI updates and releases native monitoring away from the UI thread.</summary>
    /// <param name="sender">The closed view.</param>
    /// <param name="args">The close arguments.</param>
    private void CloseMonitor(object? sender, EventArgs args)
    {
        _renderTimer.Stop();
        _renderTimer.Tick -= RenderLatest;
        var subscription = _subscription;
        _subscription = null;
        if (subscription is not null)
        {
            _ = Task.Run(subscription.Dispose);
        }
    }

    /// <summary>Coalesces subscription callbacks into a single pending snapshot.</summary>
    /// <param name="window">The receiving view.</param>
    private sealed class SnapshotObserver(MainWindow window) : IObserver<SystemSnapshot>
    {
        /// <summary>Replaces the previous pending snapshot.</summary>
        /// <param name="value">The latest snapshot.</param>
        public void OnNext(SystemSnapshot value) => _ = Interlocked.Exchange(ref window._pending, value);

        /// <summary>Reports a terminal monitoring failure on the UI thread.</summary>
        /// <param name="error">The terminal error.</param>
        public void OnError(Exception error) => _ = window.Dispatcher.BeginInvoke(new Action(() => window.ProviderStatus.Text = error.Message));

        /// <summary>Reports completion of the monitoring source.</summary>
        public void OnCompleted() => _ = window.Dispatcher.BeginInvoke(new Action(() => window.CaptureStatus.Text = "Monitoring completed."));
    }

    /// <summary>A processor sample paired with points for its history graph.</summary>
    /// <param name="sample">The native processor measurement.</param>
    /// <param name="history">The bounded graph points.</param>
    private sealed class CoreTile(LogicalProcessorSample sample, PointCollection history)
    {
        /// <summary>Gets the native processor measurement.</summary>
        public LogicalProcessorSample Sample { get; } = sample;

        /// <summary>Gets the bounded history points.</summary>
        public PointCollection History { get; } = history;
    }
}
