<img src="assets/ProjectBanner.png" alt="MADE project banner" />

# MADE Uno

A library of Uno Platform UI components, supporting Windows, Android, iOS, and WebAssembly platforms.

This is a collection of companion libraries to the [MADE.NET](https://github.com/MADE-Apps/MADE.NET) libraries.

## Support MADE Uno ♥

As many developers know, projects like MADE Uno are built and maintained in spare time. If you find this project useful, please **Star** the repo and if possible, sponsor the project development on GitHub.

## Build Status

| Build | Status | Current Version |
| ------ | ------ | ------ |
| Packages | [![CI](https://github.com/MADE-Apps/MADE-Uno/actions/workflows/ci.yml/badge.svg)](https://github.com/MADE-Apps/MADE-Uno/actions/workflows/ci.yml) | [![NuGet](https://img.shields.io/nuget/v/MADE.UI)](https://www.nuget.org/profiles/made-apps) |
| Docs | [![Docs](https://github.com/MADE-Apps/MADE-Uno/actions/workflows/docs.yml/badge.svg)](https://github.com/MADE-Apps/MADE-Uno/actions/workflows/docs.yml) | N/A |

## Installation 💾

[MADE Uno](https://www.nuget.org/profiles/made-apps) components are publicly available via NuGet. Each available package is detailed below.

| Package | Current | Preview | Downloads |
| ------ | ------ | ------ | ------ |
| UI | [![NuGet](https://img.shields.io/nuget/v/MADE.UI)](https://www.nuget.org/packages/MADE.UI/) | [![NuGet](https://img.shields.io/nuget/vpre/MADE.UI)](https://www.nuget.org/packages/MADE.UI/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/MADE.UI.svg)](https://www.nuget.org/packages/MADE.UI) |
| UI.Controls.DropDownList | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Controls.DropDownList)](https://www.nuget.org/packages/MADE.UI.Controls.DropDownList/) | [![NuGet](https://img.shields.io/nuget/vpre/MADE.UI.Controls.DropDownList)](https://www.nuget.org/packages/MADE.UI.Controls.DropDownList/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/MADE.UI.Controls.DropDownList.svg)](https://www.nuget.org/packages/MADE.UI.Controls.DropDownList) |
| UI.Controls.FilePicker | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Controls.FilePicker)](https://www.nuget.org/packages/MADE.UI.Controls.FilePicker/) | [![NuGet](https://img.shields.io/nuget/vpre/MADE.UI.Controls.FilePicker)](https://www.nuget.org/packages/MADE.UI.Controls.FilePicker/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/MADE.UI.Controls.FilePicker.svg)](https://www.nuget.org/packages/MADE.UI.Controls.FilePicker) |
| UI.Controls.Validator | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Controls.Validator)](https://www.nuget.org/packages/MADE.UI.Controls.Validator/) | [![NuGet](https://img.shields.io/nuget/vpre/MADE.UI.Controls.Validator)](https://www.nuget.org/packages/MADE.UI.Controls.Validator/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/MADE.UI.Controls.Validator.svg)](https://www.nuget.org/packages/MADE.UI.Controls.Validator) |
| UI.Styling | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Styling)](https://www.nuget.org/packages/MADE.UI.Styling/) | [![NuGet](https://img.shields.io/nuget/vpre/MADE.UI.Styling)](https://www.nuget.org/packages/MADE.UI.Styling/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/MADE.UI.Styling.svg)](https://www.nuget.org/packages/MADE.UI.Styling) |
| UI.ViewManagement | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.ViewManagement)](https://www.nuget.org/packages/MADE.UI.ViewManagement/) | [![NuGet](https://img.shields.io/nuget/vpre/MADE.UI.ViewManagement)](https://www.nuget.org/packages/MADE.UI.ViewManagement/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/MADE.UI.ViewManagement.svg)](https://www.nuget.org/packages/MADE.UI.ViewManagement) |
| UI.Views.Dialogs | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Views.Dialogs)](https://www.nuget.org/packages/MADE.UI.Views.Dialogs/) | [![NuGet](https://img.shields.io/nuget/vpre/MADE.UI.Views.Dialogs)](https://www.nuget.org/packages/MADE.UI.Views.Dialogs/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/MADE.UI.Views.Dialogs.svg)](https://www.nuget.org/packages/MADE.UI.Views.Dialogs) |
| UI.Views.Navigation | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Views.Navigation)](https://www.nuget.org/packages/MADE.UI.Views.Navigation/) | [![NuGet](https://img.shields.io/nuget/vpre/MADE.UI.Views.Navigation)](https://www.nuget.org/packages/MADE.UI.Views.Navigation/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/MADE.UI.Views.Navigation.svg)](https://www.nuget.org/packages/MADE.UI.Views.Navigation) |
| UI.Views.Navigation.Mvvm | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Views.Navigation.Mvvm)](https://www.nuget.org/packages/MADE.UI.Views.Navigation.Mvvm/) | [![NuGet](https://img.shields.io/nuget/vpre/MADE.UI.Views.Navigation.Mvvm)](https://www.nuget.org/packages/MADE.UI.Views.Navigation.Mvvm/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/MADE.UI.Views.Navigation.Mvvm.svg)](https://www.nuget.org/packages/MADE.UI.Views.Navigation.Mvvm) |

## Contributing 🚀

Looking to help build MADE Uno? Take a look through our [contribution guidelines](CONTRIBUTING.md). We actively encourage you to jump in and help with any issues!

## Building MADE Uno 🛠

MADE Uno is built using .NET Standard, taking advantage of the new SDK-style projects and multi-targeting enabled with the help of [MSBuild.Sdk.Extras](https://github.com/novotnyllc/MSBuildSdkExtras).

Each library is configured to take advantage of the Uno Platform libraries to provide cross-platform components.

You can build the solution using Visual Studio with the following workloads installed:

- .NET desktop development
- Universal Windows Platform development
- Mobile Development with .NET
- .NET Core cross-platform development

## License

MADE Uno is made available under the terms and conditions of the [MIT license](LICENSE).
