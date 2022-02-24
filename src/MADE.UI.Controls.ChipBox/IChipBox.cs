// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using Windows.UI.Xaml;

    /// <summary>
    /// Defines an interface for a multi value input text box control.
    /// </summary>
    public interface IChipBox
    {
        /// <summary>
        /// Occurs when the text has changed within the suggestion box.
        /// </summary>
        event ChipBoxTextChangedEventHandler TextChanged;

        /// <summary>
        /// Occurs when a chip has been removed.
        /// </summary>
        event ChipBoxChipRemovedEventHandler ChipRemoved;

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> associated with when the text has changed within the suggestion box.
        /// </summary>
        ICommand TextChangeCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> associated with when a chip has been removed.
        /// </summary>
        ICommand ChipRemoveCommand { get; set; }

        /// <summary>
        /// Gets or sets the data used for the header of each control.
        /// </summary>
        object Header { get; set; }

        /// <summary>
        /// Gets or sets the template used to display the content of the control's header.
        /// </summary>
        DataTemplate HeaderTemplate { get; set; }

        /// <summary>
        /// Gets or sets an object source used to generate the chip content of the control.
        /// </summary>
        IList<ChipItem> Chips { get; set; }

        /// <summary>
        /// Gets or sets the template associated with the content displayed in the chip.
        /// </summary>
        DataTemplate ChipContentTemplate { get; set; }

        /// <summary>
        /// Gets or sets the style of the items view.
        /// </summary>
        Style ChipItemsViewStyle { get; set; }

        /// <summary>
        /// Gets or sets the suggestions that are displayed to the user when typing.
        /// </summary>
        object Suggestions { get; set; }

        /// <summary>
        /// Gets or sets the template used to display the suggestions that are displayed to the user when typing.
        /// </summary>
        DataTemplate SuggestionsItemTemplate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow duplicate values to be accepted.
        /// </summary>
        bool AllowDuplicate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow free text input.
        /// </summary>
        bool AllowFreeText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the control is in a read-only state.
        /// </summary>
        bool IsReadonly { get; set; }
    }
}
