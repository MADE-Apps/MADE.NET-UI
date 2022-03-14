// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using Windows.UI.Xaml;

    /// <summary>
    /// Defines an event argument for when a <see cref="RichEditToolbar"/> text color changed.
    /// </summary>
    public class RichEditToolbarTextColorChangedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RichEditToolbarTextColorChangedEventArgs"/> class.
        /// </summary>
        /// <param name="color">The color as a hex value.</param>
        public RichEditToolbarTextColorChangedEventArgs(string color)
        {
            this.Color = color;
        }

        /// <summary>Gets the color as a hex value.</summary>
        public string Color { get; }
    }
}
