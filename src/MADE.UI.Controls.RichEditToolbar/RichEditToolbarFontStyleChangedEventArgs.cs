// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using Windows.UI.Xaml;

    /// <summary>
    /// Defines an event argument for when a <see cref="RichEditToolbar"/> font style changed.
    /// </summary>
    public class RichEditToolbarFontStyleChangedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RichEditToolbarFontStyleChangedEventArgs"/> class.
        /// </summary>
        /// <param name="bold">A value indicating whether bold is enabled.</param>
        /// <param name="italic">A value indicating whether italic is enabled.</param>
        /// <param name="underline">A value indicating whether underline is enabled.</param>
        public RichEditToolbarFontStyleChangedEventArgs(bool bold, bool italic, bool underline)
        {
            this.Bold = bold;
            this.Italic = italic;
            this.Underline = underline;
        }

        /// <summary>
        /// Gets a value indicating whether underline is enabled.
        /// </summary>
        public bool Underline { get; }

        /// <summary>
        /// Gets a value indicating whether italic is enabled.
        /// </summary>
        public bool Italic { get; }

        /// <summary>
        /// Gets a value indicating whether bold is enabled.
        /// </summary>
        public bool Bold { get; }
    }
}