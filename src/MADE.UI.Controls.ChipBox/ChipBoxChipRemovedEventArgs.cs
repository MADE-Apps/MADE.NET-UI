// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using Windows.UI.Xaml;

    /// <summary>
    /// Defines an event argument for when a <see cref="Chip"/> is removed from a <see cref="ChipBox"/>.
    /// </summary>
    public class ChipBoxChipRemovedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChipBoxChipRemovedEventArgs"/> class.
        /// </summary>
        public ChipBoxChipRemovedEventArgs(object content)
        {
            this.Content = content;
        }

        /// <summary>
        /// Gets the content of the chip that has been removed.
        /// </summary>
        public object Content { get; }
    }
}