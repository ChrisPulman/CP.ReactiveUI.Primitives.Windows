// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Windows;
using ReactiveUI.Builder;

namespace CPDeploymentStudio.Example;

/// <summary>Provides the application entry point.</summary>
public partial class App : Application
{
    /// <summary>Initializes a new instance of the <see cref="App"/> class and configures ReactiveUI WPF services.</summary>
    public App() => RxAppBuilder.CreateReactiveUIBuilder().WithWpf().BuildApp();
}
