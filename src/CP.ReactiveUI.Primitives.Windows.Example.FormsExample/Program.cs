// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
using System;
using System.Windows.Forms;
using ReactiveUI.Builder;

namespace CP.ReactiveUI.Primitives.Windows.Example.FormsExample;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        _ = RxAppBuilder.CreateReactiveUIBuilder()
            .WithWinForms()
            .BuildApp();

        using var service = new WindowsOperationsService();
        using var viewModel = new OperationsCenterViewModel(service);
        Application.Run(new OperationsCenterForm(viewModel));
    }
}
