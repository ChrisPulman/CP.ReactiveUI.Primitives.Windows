// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Operations;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies deferred dialog execution without displaying native UI.</summary>
public sealed class FileDialogOperationTests
{
    /// <summary>The owner handle forwarded to the executor.</summary>
    private const int TestOwnerHandle = 123;

    /// <summary>The execution count after two independent invocations.</summary>
    private const int TwoExecutions = 2;

    /// <summary>Verifies every subscriber shows exactly one dialog on the subscribing thread.</summary>
    /// <param name="kind">The open, save, or folder dialog kind.</param>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(2)]
    public async Task AsOperation_DefersAndRunsOncePerSubscriberAsync(int kind)
    {
        var expected = FileDialogResult.FromPath("selected.txt");
        var executor = new RecordingExecutor(() => expected);
        var owner = new IntPtr(TestOwnerHandle);
        var operation = CreateOperation(kind, owner, executor);
        var observable = operation.Observe();

        await Assert.That(executor.Calls).IsEqualTo(0);
        var first = new RecordingObserver();
        var second = new RecordingObserver();
        var callerThread = Environment.CurrentManagedThreadId;
        using var firstSubscription = observable.Subscribe(first);
        using var secondSubscription = observable.Subscribe(second);

        await Assert.That(executor.Calls).IsEqualTo(TwoExecutions);
        await Assert.That(executor.ThreadId).IsEqualTo(callerThread);
        await Assert.That(executor.OwnerHandle).IsEqualTo(owner.ToInt64());
        await Assert.That(first.Values.Count).IsEqualTo(1);
        await Assert.That(first.Values[0]).IsSameReferenceAs(expected);
        await Assert.That(second.Values.Count).IsEqualTo(1);
        await Assert.That(second.Values[0]).IsSameReferenceAs(expected);
        await Assert.That(first.Completions).IsEqualTo(1);
        await Assert.That(second.Completions).IsEqualTo(1);
        await Assert.That(first.Error).IsNull();
        await Assert.That(second.Error).IsNull();
    }

    /// <summary>Verifies dialog cancellation is emitted as a normal completed result.</summary>
    /// <param name="kind">The open, save, or folder dialog kind.</param>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(2)]
    public async Task Observe_CancellationEmitsResultAndCompletesAsync(int kind)
    {
        var expected = FileDialogResult.Cancelled();
        var executor = new RecordingExecutor(() => expected);
        var observer = new RecordingObserver();
        using var subscription = CreateOperation(kind, IntPtr.Zero, executor).Observe().Subscribe(observer);

        await Assert.That(observer.Values[0]).IsSameReferenceAs(expected);
        await Assert.That(observer.Values[0].WasCancelled).IsTrue();
        await Assert.That(observer.Completions).IsEqualTo(1);
        await Assert.That(observer.Error).IsNull();
        await Assert.That(executor.Calls).IsEqualTo(1);
    }

    /// <summary>Verifies native errors terminate observation and propagate through capture.</summary>
    /// <param name="kind">The open, save, or folder dialog kind.</param>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(2)]
    public async Task Observe_ExecutorFailureNotifiesErrorAsync(int kind)
    {
        var failure = new InvalidOperationException("dialog failed");
        var executor = new RecordingExecutor(() => throw failure);
        var operation = CreateOperation(kind, IntPtr.Zero, executor);
        var observer = new RecordingObserver();
        using var subscription = operation.Observe().Subscribe(observer);

        await Assert.That(observer.Error).IsSameReferenceAs(failure);
        await Assert.That(observer.Values.Count).IsEqualTo(0);
        await Assert.That(observer.Completions).IsEqualTo(0);
        await Assert.That(() => operation.Capture()).Throws<InvalidOperationException>();
        await Assert.That(executor.Calls).IsEqualTo(TwoExecutions);
    }

    /// <summary>Verifies configuring public operations performs no native work.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task PublicAsOperation_ValidatesBuilderWithoutShowingDialogAsync()
    {
        await Assert.That(new FileOpenDialogBuilder().AsOperation()).IsNotNull();
        await Assert.That(new FileSaveDialogBuilder().AsOperation()).IsNotNull();
        await Assert.That(new FolderPickerBuilder().AsOperation()).IsNotNull();
        await Assert.That(static () => ((FileOpenDialogBuilder)null).AsOperation()).Throws<ArgumentNullException>();
        await Assert.That(static () => ((FileSaveDialogBuilder)null).AsOperation()).Throws<ArgumentNullException>();
        await Assert.That(static () => ((FolderPickerBuilder)null).AsOperation()).Throws<ArgumentNullException>();
        await Assert.That(static () => new FileOpenDialogBuilder().AsOperation(IntPtr.Zero, null)).Throws<ArgumentNullException>();
        await Assert.That(static () => new FileSaveDialogBuilder().AsOperation(IntPtr.Zero, null)).Throws<ArgumentNullException>();
        await Assert.That(static () => new FolderPickerBuilder().AsOperation(IntPtr.Zero, null)).Throws<ArgumentNullException>();
    }

    /// <summary>Verifies deferred execution reads the builder's current configuration.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task Capture_ReadsConfigurationAtExecutionAsync()
    {
        var executor = new RecordingExecutor(FileDialogResult.Cancelled);
        var builder = new FileOpenDialogBuilder().WithTitle("initial");
        var operation = builder.AsOperation(IntPtr.Zero, executor);
        _ = builder.WithTitle("updated");
        var result = operation.Capture();

        await Assert.That(executor.Title).IsEqualTo("updated");
        await Assert.That(result.WasCancelled).IsTrue();
        await Assert.That(executor.Calls).IsEqualTo(1);
    }

    /// <summary>Creates the selected dialog operation without executing it.</summary>
    /// <param name="kind">The open, save, or folder dialog kind.</param>
    /// <param name="owner">The owner handle to forward.</param>
    /// <param name="executor">The injected dialog executor.</param>
    /// <returns>The deferred dialog operation.</returns>
    private static WindowsOperation<FileDialogResult> CreateOperation(int kind, IntPtr owner, IFileDialogExecutor executor) => kind switch
    {
        0 => new FileOpenDialogBuilder().AsOperation(owner, executor),
        1 => new FileSaveDialogBuilder().AsOperation(owner, executor),
        _ => new FolderPickerBuilder().AsOperation(owner, executor),
    };

    /// <summary>Records invocation details and returns an injected dialog outcome.</summary>
    /// <param name="show">The callback supplying the dialog outcome.</param>
    private sealed class RecordingExecutor(Func<FileDialogResult> show) : IFileDialogExecutor
    {
        /// <summary>Gets the number of dialog invocations.</summary>
        public int Calls { get; private set; }

        /// <summary>Gets the thread that executed the last dialog.</summary>
        public int ThreadId { get; private set; }

        /// <summary>Gets the owner handle of the last dialog.</summary>
        public long OwnerHandle { get; private set; }

        /// <summary>Gets the title of the last dialog.</summary>
        public string Title { get; private set; }

        /// <inheritdoc />
        public FileDialogResult ShowOpen(FileOpenDialogRequest request) => Show(request.OwnerHandle, request.Title);

        /// <inheritdoc />
        public FileDialogResult ShowSave(FileSaveDialogRequest request) => Show(request.OwnerHandle, request.Title);

        /// <inheritdoc />
        public FileDialogResult ShowFolder(FolderPickerDialogRequest request) => Show(request.OwnerHandle, request.Title);

        /// <summary>Records the invocation and invokes the supplied callback.</summary>
        /// <param name="ownerHandle">The dialog owner handle.</param>
        /// <param name="title">The configured dialog title.</param>
        /// <returns>The callback's dialog result.</returns>
        private FileDialogResult Show(long ownerHandle, string title)
        {
            Calls++;
            ThreadId = Environment.CurrentManagedThreadId;
            OwnerHandle = ownerHandle;
            Title = title;
            return show();
        }
    }

    /// <summary>Records dialog observable notifications.</summary>
    private sealed class RecordingObserver : IObserver<FileDialogResult>
    {
        /// <summary>Gets the emitted dialog results.</summary>
        public List<FileDialogResult> Values { get; } = [];

        /// <summary>Gets the terminal error.</summary>
        public Exception Error { get; private set; }

        /// <summary>Gets the number of completion notifications.</summary>
        public int Completions { get; private set; }

        /// <inheritdoc />
        public void OnNext(FileDialogResult value) => Values.Add(value);

        /// <inheritdoc />
        public void OnError(Exception error) => Error = error;

        /// <inheritdoc />
        public void OnCompleted() => Completions++;
    }
}
