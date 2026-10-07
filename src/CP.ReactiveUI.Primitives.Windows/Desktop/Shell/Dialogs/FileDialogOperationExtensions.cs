// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Operations;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs;
#endif

/// <summary>Creates deferred dialogs that execute on the caller's STA thread without scheduling.</summary>
public static class FileDialogOperationExtensions
{
    /// <summary>Provides deferred open-file dialog operations.</summary>
    /// <param name="builder">The dialog configuration, read when executed.</param>
    extension(FileOpenDialogBuilder builder)
    {
        /// <summary>Defers the open-file dialog until capture or subscription on the caller's STA thread.</summary>
        /// <returns>An operation preserving selection and cancellation results.</returns>
        public WindowsOperation<FileDialogResult> AsOperation() => builder.AsOperation(IntPtr.Zero);

        /// <summary>Defers the open-file dialog until capture or subscription on the caller's STA thread.</summary>
        /// <param name="ownerHandle">The owner window handle, or zero for a top-level dialog.</param>
        /// <returns>An operation preserving selection and cancellation results.</returns>
        public WindowsOperation<FileDialogResult> AsOperation(IntPtr ownerHandle)
        {
            Throw.IfNull(builder, nameof(builder));
            return WindowsOperation.From(() => builder.ShowDialog(ownerHandle));
        }

        /// <summary>Defers the open-file dialog through an injected executor.</summary>
        /// <param name="ownerHandle">The owner window handle.</param>
        /// <param name="executor">The dialog executor.</param>
        /// <returns>A deferred dialog operation.</returns>
        internal WindowsOperation<FileDialogResult> AsOperation(IntPtr ownerHandle, IFileDialogExecutor executor)
        {
            Throw.IfNull(builder, nameof(builder));
            Throw.IfNull(executor, nameof(executor));
            return WindowsOperation.From(() => builder.ShowDialog(ownerHandle, executor));
        }
    }

    /// <summary>Provides deferred save-file dialog operations.</summary>
    /// <param name="builder">The dialog configuration, read when executed.</param>
    extension(FileSaveDialogBuilder builder)
    {
        /// <summary>Defers the save-file dialog until capture or subscription on the caller's STA thread.</summary>
        /// <returns>An operation preserving selection and cancellation results.</returns>
        public WindowsOperation<FileDialogResult> AsOperation() => builder.AsOperation(IntPtr.Zero);

        /// <summary>Defers the save-file dialog until capture or subscription on the caller's STA thread.</summary>
        /// <param name="ownerHandle">The owner window handle, or zero for a top-level dialog.</param>
        /// <returns>An operation preserving selection and cancellation results.</returns>
        public WindowsOperation<FileDialogResult> AsOperation(IntPtr ownerHandle)
        {
            Throw.IfNull(builder, nameof(builder));
            return WindowsOperation.From(() => builder.ShowDialog(ownerHandle));
        }

        /// <summary>Defers the save-file dialog through an injected executor.</summary>
        /// <param name="ownerHandle">The owner window handle.</param>
        /// <param name="executor">The dialog executor.</param>
        /// <returns>A deferred dialog operation.</returns>
        internal WindowsOperation<FileDialogResult> AsOperation(IntPtr ownerHandle, IFileDialogExecutor executor)
        {
            Throw.IfNull(builder, nameof(builder));
            Throw.IfNull(executor, nameof(executor));
            return WindowsOperation.From(() => builder.ShowDialog(ownerHandle, executor));
        }
    }

    /// <summary>Provides deferred folder picker operations.</summary>
    /// <param name="builder">The dialog configuration, read when executed.</param>
    extension(FolderPickerBuilder builder)
    {
        /// <summary>Defers the folder picker until capture or subscription on the caller's STA thread.</summary>
        /// <returns>An operation preserving selection and cancellation results.</returns>
        public WindowsOperation<FileDialogResult> AsOperation() => builder.AsOperation(IntPtr.Zero);

        /// <summary>Defers the folder picker until capture or subscription on the caller's STA thread.</summary>
        /// <param name="ownerHandle">The owner window handle, or zero for a top-level dialog.</param>
        /// <returns>An operation preserving selection and cancellation results.</returns>
        public WindowsOperation<FileDialogResult> AsOperation(IntPtr ownerHandle)
        {
            Throw.IfNull(builder, nameof(builder));
            return WindowsOperation.From(() => builder.ShowDialog(ownerHandle));
        }

        /// <summary>Defers the folder picker through an injected executor.</summary>
        /// <param name="ownerHandle">The owner window handle.</param>
        /// <param name="executor">The dialog executor.</param>
        /// <returns>A deferred dialog operation.</returns>
        internal WindowsOperation<FileDialogResult> AsOperation(IntPtr ownerHandle, IFileDialogExecutor executor)
        {
            Throw.IfNull(builder, nameof(builder));
            Throw.IfNull(executor, nameof(executor));
            return WindowsOperation.From(() => builder.ShowDialog(ownerHandle, executor));
        }
    }
}
