// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using System.Collections.Generic;
    using Windows.UI.Xaml;

    /// <summary>
    /// Defines an event argument for when the <see cref="DropDownList"/> selected items has updated.
    /// </summary>
    public class DropDownListSelectedItemsUpdatedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownListSelectedItemsUpdatedEventArgs"/> class.
        /// </summary>
        public DropDownListSelectedItemsUpdatedEventArgs(IEnumerable<object> selectedItems)
        {
            this.SelectedItems = selectedItems;
        }

        /// <summary>
        /// Gets the updated selected items.
        /// </summary>
        public IEnumerable<object> SelectedItems { get; }
    }
}