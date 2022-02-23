// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
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
        /// Gets or sets an object source used to generate the content of the control.
        /// </summary>
        object ItemsSource { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate used to display each item.
        /// </summary>
        DataTemplate ItemTemplate { get; set; }

        /// <summary>
        /// Gets or sets a reference to a custom DataTemplateSelector logic class.
        /// <para>
        /// The DataTemplateSelector referenced by this property returns a template to apply to items.
        /// </para>
        /// </summary>
        DataTemplateSelector ItemTemplateSelector { get; set; }

        /// <summary>
        /// Gets or sets the template that defines the panel that controls the layout of items.
        /// </summary>
        ItemsPanelTemplate ItemsPanel { get; set; }
    }
}
