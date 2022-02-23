// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using System.Collections.Generic;
    using Windows.Foundation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Automation.Peers;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Media;

    /// <summary>
    /// Defines a control for providing multi value input for a text box.
    /// </summary>
    [TemplatePart(Name = ChipBoxTextBoxPart, Type = typeof(AutoSuggestBox))]
    public partial class ChipBox : Control, IChipBox
    {
        /// <summary>
        /// Identifies the <see cref="Header"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            nameof(Header),
            typeof(object),
            typeof(ChipBox),
            new PropertyMetadata(default));

        /// <summary>
        /// Identifies the <see cref="ItemsSource"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            nameof(ItemsSource),
            typeof(object),
            typeof(ChipBox),
            new PropertyMetadata(default));

        /// <summary>
        /// Identifies the <see cref="ItemTemplate"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
            nameof(ItemTemplate),
            typeof(DataTemplate),
            typeof(ChipBox),
            new PropertyMetadata(default(DataTemplate)));

        /// <summary>
        /// Identifies the <see cref="ItemTemplateSelector"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemTemplateSelectorProperty = DependencyProperty.Register(
            nameof(ItemTemplateSelector),
            typeof(DataTemplateSelector),
            typeof(ChipBox),
            new PropertyMetadata(default(DataTemplateSelector)));

        /// <summary>
        /// Identifies the <see cref="ItemsPanel"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsPanelProperty = DependencyProperty.Register(
            nameof(ItemsPanel),
            typeof(ItemsPanelTemplate),
            typeof(ChipBox),
            new PropertyMetadata(default(ItemsPanelTemplate)));

        private const string ChipBoxTextBoxPart = "ChipBoxTextBox";

        /// <summary>
        /// Initializes a new instance of the <see cref="ChipBox"/> class.
        /// </summary>
        public ChipBox()
        {
            this.DefaultStyleKey = typeof(ChipBox);
        }

        /// <summary>
        /// Gets or sets the content for the control's header.
        /// </summary>
        public object Header
        {
            get => this.GetValue(HeaderProperty);
            set => this.SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Gets or sets an object source used to generate the content of the control.
        /// </summary>
        public object ItemsSource
        {
            get => this.GetValue(ItemsSourceProperty);
            set => this.SetValue(ItemsSourceProperty, value);
        }

        /// <summary>
        /// Gets or sets the DataTemplate used to display each item.
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)this.GetValue(ItemTemplateProperty);
            set => this.SetValue(ItemTemplateProperty, value);
        }

        /// <summary>
        /// Gets or sets a reference to a custom DataTemplateSelector logic class.
        /// <para>
        /// The DataTemplateSelector referenced by this property returns a template to apply to items.
        /// </para>
        /// </summary>
        public DataTemplateSelector ItemTemplateSelector
        {
            get => (DataTemplateSelector)this.GetValue(ItemTemplateSelectorProperty);
            set => this.SetValue(ItemTemplateSelectorProperty, value);
        }

        /// <summary>
        /// Gets or sets the template that defines the panel that controls the layout of items.
        /// </summary>
        public ItemsPanelTemplate ItemsPanel
        {
            get => (ItemsPanelTemplate)this.GetValue(ItemsPanelProperty);
            set => this.SetValue(ItemsPanelProperty, value);
        }

        /// <summary>
        /// Gets the view representing the text input for chips.
        /// </summary>
        public AutoSuggestBox TextBox { get; private set; }

        /// <summary>
        /// Loads the relevant control template so that it's parts can be referenced.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.TextBox = this.GetChildView<AutoSuggestBox>(ChipBoxTextBoxPart);
        }

        /// <summary>
        /// Provides the class-specific <see cref="ChipBoxAutomationPeer"/> implementation for the Microsoft UI Automation infrastructure.
        /// </summary>
        /// <returns>The class-specific <see cref="ChipBoxAutomationPeer"/> instance.</returns>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new ChipBoxAutomationPeer(this);
        }
    }
}