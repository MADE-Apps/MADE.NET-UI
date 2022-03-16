---
uid: package-ui-data-converters
title: Using the UI Data Converters package
---

# Using the UI Data Converters package

The UI Data Converters package is designed for making the conversion of data objects to a different type in native applications for Windows, Android, iOS, macOS, Linux, and the web easier.

## Converting boolean values to a string (and back) with the BooleanToStringValueConverter

The `MADE.UI.Data.Converters.BooleanToStringValueConverter` provides a way to convert a boolean value to a string and back with a bound data source in a XAML view.

```xml
<Grid>
    <Grid.Resources>
        <converters:BooleanToStringValueConverter x:Key="BooleanToStringValueConverter" TrueValue="Yes" FalseValue="No" />
    </Grid.Resources>

    <!-- A true boolean will return the TrueValue of the converter -->
    <TextBlock Text="{x:Bind ViewModel.True, Converter={StaticResource BooleanToStringValueConverter}}" />

    <!-- A false boolean will return the FalseValue of the converter -->
    <TextBlock Text="{x:Bind ViewModel.False, Converter={StaticResource BooleanToStringValueConverter}}" />
</Grid>
```

Instances of the converter can be set up with varying values for the `TrueValue` and `FalseValue` properties that will represent the value shown when the boolean is true and false, respectively. The default values are `Yes` and `No`.

**Note**, when converting back from the string value to a boolean when used in a `TwoWay` binding, the `TrueValue` and `FalseValue` properties are used to determine which value is considered true and false. If the string value does not match, an exception will be thrown.

## Displaying a byte array as an image with the ByteArrayToImageSourceValueConverter

The `MADE.UI.Data.Converters.ByteArrayToImageSourceValueConverter` provides a way to convert a bound byte array containing the details of an image to an image source that can be bound to an `Image` XAML element.

```xml
<Grid>
    <Grid.Resources>
        <converters:ByteArrayToImageSourceValueConverter x:Key="ByteArrayToImageSourceValueConverter" />
    </Grid.Resources>

    <!-- Converts the image's byte array into a source image that is loaded into the element -->
    <Image Source="{x:Bind ViewModel.ImageBytes, Converter={StaticResource ByteArrayToImageSourceValueConverter}, Mode=OneWay}" />
</Grid>
```

## Formatting a DateTime value with the DateTimeToStringValueConverter

The `MADE.UI.Data.Converters.DateTimeToStringValueConverter` converts a given `DateTime` object into a string using the provided format in the binding `ConverterParameter` property.

```xml
<Grid>
    <Grid.Resources>
        <converters:DateTimeToStringValueConverter x:Key="DateTimeToStringValueConverter" />
    </Grid.Resources>

    <!-- Converts the DateTime object into the dd/MM/yyyy format -->
    <TextBlock Text="{x:Bind ViewModel.DateTime, Converter={StaticResource DateTimeToStringValueConverter}, ConverterParameter=dd/MM/yyyy}" />
</Grid>
```

**Note**, the converter supports any of the standard and custom formats supported by the `DateTime.ToString()` method. You can [find more information on these in the Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings).
