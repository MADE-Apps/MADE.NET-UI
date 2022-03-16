// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Data.Converters
{
    using System;
    using MADE.Data.Converters;
    using MADE.UI.Data.Converters.Extensions;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media.Imaging;

    /// <summary>
    /// Defines a XAML value converter for converting from a <see cref="byte"/> array to <see cref="BitmapSource"/>.
    /// </summary>
    public class ByteArrayToImageSourceValueConverter : IValueConverter, IValueConverter<byte[], BitmapSource>
    {
        /// <summary>
        /// Converts the <paramref name="value">value</paramref> to the <see cref="BitmapSource"/> type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The target type (unused).</param>
        /// <param name="parameter">The optional parameter used to help with conversion (unused).</param>
        /// <param name="language">The display language for the conversion (unused).</param>
        /// <returns>The converted <see cref="string"/> object.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value switch
            {
                byte[] bytes => this.Convert(bytes),
                _ => value
            };
        }

        /// <summary>
        /// Converting back from <see cref="BitmapSource"/> to a <see cref="byte"/> array is not supported.
        /// </summary>
        /// <param name="value">The value to convert (unused).</param>
        /// <param name="targetType">The target type (unused).</param>
        /// <param name="parameter">The optional parameter used to help with conversion (unused).</param>
        /// <param name="language">The display language for the conversion (unused).</param>
        /// <returns>
        /// An unset value.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }

        /// <summary>
        /// Converts the <paramref name="value">value</paramref> to the <see cref="BitmapSource"/> type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="parameter">
        /// The optional parameter used to help with conversion.
        /// </param>
        /// <returns>
        /// The converted <see cref="BitmapSource"/> object.
        /// </returns>
        public BitmapSource Convert(byte[] value, object parameter = null)
        {
            return value.ToBitmapSource();
        }

        /// <summary>
        /// Converting back from <see cref="BitmapSource"/> to a <see cref="byte"/> array is not supported.
        /// </summary>
        /// <returns>
        /// The converted <see cref="DateTime"/> object.
        /// </returns>
        public byte[] ConvertBack(BitmapSource value, object parameter = null)
        {
            // Not supported.
            return null;
        }
    }
}
