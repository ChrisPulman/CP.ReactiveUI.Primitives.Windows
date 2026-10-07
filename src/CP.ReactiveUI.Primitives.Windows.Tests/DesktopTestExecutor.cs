// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using TUnit.Core.Interfaces;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Runs desktop tests on an STA thread and shuts down its WPF dispatcher before the thread exits.</summary>
public sealed class DesktopTestExecutor : ITestExecutor
{
    /// <summary>The STA test executor.</summary>
    private readonly STAThreadExecutor _staExecutor = new();

    /// <inheritdoc />
    public ValueTask ExecuteTest(TestContext context, Func<ValueTask> action) =>
        _staExecutor.ExecuteTest(context, async () =>
        {
            try
            {
                await action();
            }
            finally
            {
                System.Windows.Threading.Dispatcher.FromThread(Thread.CurrentThread)?.InvokeShutdown();
            }
        });
}
