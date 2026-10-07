// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Windows;

namespace CP.ReactiveUI.Primitives.Windows.Example.TaskManager;

/// <summary>Starts the native task manager dashboard.</summary>
internal static class Program
{
    /// <summary>Creates the WPF application on its UI thread.</summary>
    [STAThread]
    private static void Main()
    {
        Application application = new();
        _ = application.Run(new MainWindow());
    }
}
