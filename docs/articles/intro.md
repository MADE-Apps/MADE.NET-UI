---
uid: made-intro
title: Getting Started
---

# Getting Started

MADE.NET UI is a collection of components designed for building applications with the Uno Platform on Windows, Android, iOS, and WebAssembly.

## Installation

All packages listed below can be installed via NuGet or via the dotnet CLI by running the following command using a listed package name:

```
dotnet add package MADE.UI
```

### Available packages

| Package | Version |
| --- | --- |
| MADE.Media.Image | [![NuGet](https://img.shields.io/nuget/v/MADE.Media.Image)](https://www.nuget.org/packages/MADE.Media.Image/) |
| MADE.UI | [![NuGet](https://img.shields.io/nuget/v/MADE.UI)](https://www.nuget.org/packages/MADE.UI/) |
| MADE.UI.Controls.ChipBox | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Controls.ChipBox)](https://www.nuget.org/packages/MADE.UI.Controls.ChipBox/) |
| MADE.UI.Controls.DropDownList | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Controls.DropDownList)](https://www.nuget.org/packages/MADE.UI.Controls.DropDownList/) |
| MADE.UI.Controls.FilePicker | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Controls.FilePicker)](https://www.nuget.org/packages/MADE.UI.Controls.FilePicker/) |
| MADE.UI.Controls.RichEditToolbar | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Controls.RichEditToolbar)](https://www.nuget.org/packages/MADE.UI.Controls.RichEditToolbar/) |
| MADE.UI.Controls.Validator | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Controls.Validator)](https://www.nuget.org/packages/MADE.UI.Controls.Validator/) |
| MADE.UI.Data.Converters | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Data.Converters)](https://www.nuget.org/packages/MADE.UI.Data.Converters/) |
| MADE.UI.Styling | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.Styling)](https://www.nuget.org/packages/MADE.UI.Styling/) |
| MADE.UI.ViewManagement | [![NuGet](https://img.shields.io/nuget/v/MADE.UI.ViewManagement)](https://www.nuget.org/packages/MADE.UI.ViewManagement/) |

#### Media.Image

The Media Image package is designed to be used in applications that require image processing.

It provides capabilities, such as:

- LoadStorageFileThumbnailImageBehavior, a XAML behavior for loading a thumbnail from a `StorageFile` on an `Image` element.

<span class="button">

[Discover Media.Image](features/media-image.md)

</span>

#### UI

The UI package is a base library for building out great user experiences for applications built for Windows, Android, iOS, and the web.

Taking advantage of the Uno Platform, the UI packages provide extensible features such as:

- Control, a base implementation on top of the XAML `Control` type with additional functionality such as `IsVisible` (to get and set the state of the control's visibility), and `GetChildView` (to find and retrieve a UI element which is a child of the element).
- ContentControl, a base implementation on top of the XAML `ContentControl` type with additional functionality such as `IsVisible` (to get and set the state of the control's visibility), and `GetChildView` (to find and retrieve a UI element which is a child of the element).
- ViewExtensions, a collection of extensions for manipulating XAML `UIElement` objects including `SetVisible` (to toggle the visible state of the element and child elements).

<span class="button">

[Discover UI](features/ui.md)

</span>

#### UI.Controls.ChipBox

The UI Controls ChipBox library contains a cross-platform UI element that provides a multi value input for a text box with auto-suggest capabilities. Values added are displayed as removable chips.

<span class="button">

[Discover UI.Controls.ChipBox](features/ui-controls-chipbox.md)

</span>

#### UI.Controls.DropDownList

The UI Controls DropDownList library contains a Windows UI element that provides a selection user experience, allowing a user to select one or multiple items from a list.

The control works in a similar way to the `ComboBox` element in the Windows SDK, with the added extensibility to change modes to select multiple items.

<span class="button">

[Discover UI.Controls.DropDownList](features/ui-controls-dropdownlist.md)

</span>

#### UI.Controls.FilePicker

The UI Controls FilePicker library contains a cross-platform UI element that provides a web-like `<input type="file" />` equivalent for native applications.

The control provides the capability to select one or multiple files of given types and show them within the UI.

<span class="button">

[Discover UI.Controls.FilePicker](features/ui-controls-filepicker.md)

</span>

#### UI.Controls.RichEditToolbar

The UI Controls RichEditToolbar library contains a cross-platform UI element that provides customizable and extensible collection of buttons that activate rich text features in an associated RichEditBox.

Think the InkToolbar equivalent for RichEditBox controls!

<span class="button">

[Discover UI.Controls.RichEditToolbar](features/ui-controls-richedittoolbar.md)

</span>

#### UI.Controls.Validator

The UI Controls Validator library contains a cross-platform UI element that provides validation capabilities over any input element.

Taking advantage of the Data Validation library, you can simply and easily setup input validation with error messaging for all input types, both built-in and custom, with minimal effort.

<span class="button">

[Discover UI.Controls.Validator](features/ui-controls-validator.md)

</span>

#### UI.Data.Converters

The UI Data Converters package is designed for making the conversion of data objects to a different type in native applications for Windows, Android, iOS, macOS, Linux, and the web easier.

<span class="button">

[Discover UI.Data.Converters](features/ui-data-converters.md)

</span>

#### UI.Styling

The UI Styling library contains a collection of cross-platform UI styling components for improving the designing of applications.

<span class="button">

[Discover UI.Styling](features/ui-styling.md)

</span>

#### UI.ViewManagement

The UI View Management package is designed for improving how your applications can create and manage additional windows in Windows applications.

<span class="button">

[Discover UI.ViewManagement](features/ui-view-management.md)

</span>
