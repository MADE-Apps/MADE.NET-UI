// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    /// <summary>
    /// Defines a wrapper for an item displayed as a chip.
    /// </summary>
    public class ChipItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChipItem"/> class with the associated content.
        /// </summary>
        /// <param name="content">The content of the chip to display.</param>
        public ChipItem(object content)
        {
            this.Content = content;
        }

        /// <summary>
        /// Gets or sets the content of the chip to display.
        /// </summary>
        public object Content { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.Content?.ToString();
        }
    }
}
