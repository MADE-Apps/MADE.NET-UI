// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Styling.Colors
{
    using System;
    using MADE.Data.Validation.Extensions;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;

    /// <summary>
    /// Defines a XAML value converter to darken the color of a specified <see cref="SolidColorBrush"/>.
    /// </summary>
    public class DarkenColorBrushConverter : IValueConverter
    {
        /// <summary>
        /// Converts the <paramref name="value">value</paramref> to a darker <see cref="SolidColorBrush"/> using the <paramref name="parameter"/> darken value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The target type (unused).</param>
        /// <param name="parameter">The optional parameter used to define the amount to darken by.</param>
        /// <param name="language">The display language for the conversion (unused).</param>
        /// <returns>The darkened <see cref="SolidColorBrush"/> object.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is not SolidColorBrush colorBrush)
            {
                colorBrush = value switch
                {
                    Color color => color.ToSolidColorBrush(),
                    System.Drawing.Color systemColor => systemColor.ToSolidColorBrush(),
                    _ => Colors.Transparent.ToSolidColorBrush()
                };
            }

            float.TryParse(parameter?.ToString(), out var darkenAmount);
            if (darkenAmount.IsZero())
            {
                // Apply darken default.
                darkenAmount = 30;
            }

            var darkerColor = colorBrush.Color.Darken(darkenAmount);

            return new SolidColorBrush(darkerColor);
        }

        /// <summary>
        /// Convert back is not supported by the <see cref="DarkenColorBrushConverter"/>.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
