// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using Windows.UI.Xaml;

    /// <summary>
    /// Defines an event argument for when the text of the <see cref="ChipBox"/> has changed.
    /// </summary>
    public class ChipBoxTextChangedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChipBoxTextChangedEventArgs"/> class with the changed text.
        /// </summary>
        /// <param name="text">The text that has been changed to.</param>
        public ChipBoxTextChangedEventArgs(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Gets the text that has been changed to.
        /// </summary>
        public string Text { get; }
    }
}