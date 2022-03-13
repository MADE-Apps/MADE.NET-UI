// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using Windows.UI.Xaml;

    /// <summary>
    /// Defines an event argument for when a <see cref="RichEditToolbar"/> font size changed.
    /// </summary>
    public class RichEditToolbarFontSizeChangedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RichEditToolbarFontSizeChangedEventArgs"/> class.
        /// </summary>
        /// <param name="fontSize">The changed font size.</param>
        public RichEditToolbarFontSizeChangedEventArgs(float fontSize)
        {
            this.FontSize = fontSize;
        }

        /// <summary>Gets changed font size.</summary>
        public float FontSize { get; }
    }
}