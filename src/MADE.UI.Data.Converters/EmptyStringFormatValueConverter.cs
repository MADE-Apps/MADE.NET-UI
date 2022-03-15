// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Data.Converters
{
    using System;
    using MADE.Data.Converters;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    /// <summary>
    /// Defines a XAML value converter for converting an empty <see cref="string"/> to a set <see cref="string"/> value, or returning the non-empty value string.
    /// </summary>
    public partial class EmptyStringFormatValueConverter :
        DependencyObject,
        IValueConverter,
        IValueConverter<string, string>
    {
        /// <summary>
        /// Defines the dependency property for <see cref="EmptyStringValue"/>.
        /// </summary>
        public static readonly DependencyProperty EmptyStringValueProperty =
            DependencyProperty.Register(
                nameof(EmptyStringValue),
                typeof(string),
                typeof(EmptyStringFormatValueConverter),
                new PropertyMetadata("No value provided"));

        /// <summary>
        /// Gets or sets the value to show when the value is empty.
        /// </summary>
        public string EmptyStringValue
        {
            get => (string)this.GetValue(EmptyStringValueProperty);
            set => this.SetValue(EmptyStringValueProperty, value);
        }

        /// <summary>
        /// Converts the <paramref name="value">value</paramref> to the <see cref="EmptyStringValue"/> if empty; otherwise, the value is returned.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The target type (unused).</param>
        /// <param name="parameter">The optional parameter used to help with conversion (unused).</param>
        /// <param name="language">The display language for the conversion (unused).</param>
        /// <returns>The converted <see cref="string"/> object.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return this.Convert(value?.ToString(), parameter);
        }

        /// <summary>
        /// Converts the <paramref name="value">value</paramref> back to the <see cref="string"/> value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The target type (unused).</param>
        /// <param name="parameter">The optional parameter used to help with conversion (unused).</param>
        /// <param name="language">The display language for the conversion (unused).</param>
        /// <returns>The <see cref="string"/> object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return this.ConvertBack(value?.ToString(), parameter);
        }

        /// <summary>
        /// Converts the <paramref name="value">value</paramref> to the <see cref="EmptyStringValue"/> if empty; otherwise, the value is returned.
        /// </summary>
        /// <param name="value">
        /// The value to convert.
        /// </param>
        /// <param name="parameter">
        /// The optional parameter used to help with conversion.
        /// </param>
        /// <returns>
        /// The converted <see cref="string"/> object.
        /// </returns>
        public string Convert(string value, object parameter = default)
        {
            return string.IsNullOrWhiteSpace(value) ? this.EmptyStringValue : value;
        }

        /// <summary>
        /// Converts the <paramref name="value">value</paramref> back to the <see cref="string"/> value.
        /// </summary>
        /// <param name="value">
        /// The value to convert.
        /// </param>
        /// <param name="parameter">
        /// The optional parameter used to help with conversion.
        /// </param>
        /// <returns>
        /// The converted <see cref="string"/> object.
        /// </returns>
        public string ConvertBack(string value, object parameter = default)
        {
            return value == this.EmptyStringValue ? string.Empty : value;
        }
    }
}