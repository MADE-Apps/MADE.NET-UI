// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using System.Collections;
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Defines an interface for a multi value input text box control.
    /// </summary>
    public interface IChipBox
    {
        /// <summary>
        /// Gets or sets the content for the control's header.
        /// </summary>
        object Header { get; set; }

        /// <summary>
        /// Gets or sets an object source used to generate the chip content of the control.
        /// </summary>
        IList<ChipItem> Chips { get; set; }

        /// <summary>
        /// Gets or sets the style of the items view.
        /// </summary>
        Style ChipItemsViewStyle { get; set; }

        object Suggestions { get; set; }

        DataTemplate SuggestionsItemTemplate { get; set; }
    }
}
