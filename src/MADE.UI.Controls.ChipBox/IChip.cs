// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using System.Windows.Input;

    /// <summary>
    /// Defines an interface for displaying a value as a chip with remove capabilities.
    /// </summary>
    public interface IChip
    {
        /// <summary>
        /// Occurs when the user pressed the remove chip button.
        /// </summary>
        event ChipRemovedEventHandler Removed;

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> associated with when the user pressed the remove chip button.
        /// </summary>
        ICommand RemoveCommand { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the chip can be removed.
        /// </summary>
        bool CanRemove { get; set; }
    }
}
