namespace MADE.UI.Controls
{
    using System.Windows.Input;

    /// <summary>
    /// Defines an extension interface for a selection control that provides a drop-down list box that allows users to select one or multiple items from a list.
    /// </summary>
    public interface IDropDownList2
    {
        /// <summary>
        /// Occurs when the selected items has updated.
        /// </summary>
        event DropDownListSelectedItemsUpdatedEventHandler SelectedItemsUpdated;

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> associated with when the drop-down opens.
        /// </summary>
        ICommand DropDownOpenCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> associated with when the drop-down closes.
        /// </summary>
        ICommand DropDownCloseCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> associated with when the currently selected item changes.
        /// </summary>
        ICommand SelectionChangeCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> associated with when the selected items has updated.
        /// </summary>
        ICommand SelectedItemsUpdateCommand { get; set; }
    }
}