// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Automation.Peers;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Defines a control for providing multi value input for a text box.
    /// </summary>
    [TemplatePart(Name = ChipBoxTextBoxPart, Type = typeof(AutoSuggestBox))]
    [TemplatePart(Name = ChipBoxItemsViewPart, Type = typeof(ItemsControl))]
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
        /// Identifies the <see cref="Chips"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ChipsProperty = DependencyProperty.Register(
            nameof(Chips),
            typeof(IList<ChipItem>),
            typeof(ChipBox),
            new PropertyMetadata(new ObservableCollection<ChipItem>()));

        /// <summary>
        /// Identifies the <see cref="ChipItemsViewStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ChipItemsViewStyleProperty = DependencyProperty.Register(
            nameof(ChipItemsViewStyle),
            typeof(Style),
            typeof(ChipBox),
            new PropertyMetadata(default(Style)));

        public static readonly DependencyProperty SuggestionsProperty = DependencyProperty.Register(
            nameof(Suggestions),
            typeof(object),
            typeof(ChipBox),
            new PropertyMetadata(default));

        public static readonly DependencyProperty SuggestionsItemTemplateProperty = DependencyProperty.Register(
            nameof(SuggestionsItemTemplate),
            typeof(DataTemplate),
            typeof(ChipBox),
            new PropertyMetadata(default(DataTemplate)));

        public static readonly DependencyProperty AllowDuplicatesProperty = DependencyProperty.Register(
            nameof(AllowDuplicates),
            typeof(bool),
            typeof(ChipBox),
            new PropertyMetadata(default(bool)));

        private const string ChipBoxTextBoxPart = "ChipBoxTextBox";

        private const string ChipBoxItemsViewPart = "ChipBoxItemsView";

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
        /// Gets or sets an object source used to generate the chip content of the control.
        /// </summary>
        public IList<ChipItem> Chips
        {
            get => (IList<ChipItem>)this.GetValue(ChipsProperty);
            set => this.SetValue(ChipsProperty, value);
        }

        /// <summary>
        /// Gets or sets the style of the items view.
        /// </summary>
        public Style ChipItemsViewStyle
        {
            get => (Style)this.GetValue(ChipItemsViewStyleProperty);
            set => this.SetValue(ChipItemsViewStyleProperty, value);
        }

        public object Suggestions
        {
            get => GetValue(SuggestionsProperty);
            set => SetValue(SuggestionsProperty, value);
        }

        public DataTemplate SuggestionsItemTemplate
        {
            get => (DataTemplate)GetValue(SuggestionsItemTemplateProperty);
            set => SetValue(SuggestionsItemTemplateProperty, value);
        }

        public bool AllowDuplicates
        {
            get => (bool)GetValue(AllowDuplicatesProperty);
            set => SetValue(AllowDuplicatesProperty, value);
        }

        /// <summary>
        /// Gets the view representing the text input for chips.
        /// </summary>
        public AutoSuggestBox TextBox { get; private set; }

        public ItemsControl ChipItemsView { get; private set; }

        /// <summary>
        /// Loads the relevant control template so that it's parts can be referenced.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            if (this.TextBox != null)
            {
                this.TextBox.QuerySubmitted -= OnChipSuggestionChosen;
            }

            base.OnApplyTemplate();

            this.TextBox = this.GetChildView<AutoSuggestBox>(ChipBoxTextBoxPart);
            this.ChipItemsView = this.GetChildView<ItemsControl>(ChipBoxItemsViewPart);

            if (this.TextBox != null)
            {
                this.TextBox.QuerySubmitted += this.OnChipSuggestionChosen;
            }
        }

        /// <summary>
        /// Provides the class-specific <see cref="ChipBoxAutomationPeer"/> implementation for the Microsoft UI Automation infrastructure.
        /// </summary>
        /// <returns>The class-specific <see cref="ChipBoxAutomationPeer"/> instance.</returns>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new ChipBoxAutomationPeer(this);
        }

        private void OnChipSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            this.AddChip(args.QueryText);
            if (sender != null)
            {
                sender.Text = string.Empty;
            }
        }

        private void AddChip(object content)
        {
            if (content == null || string.IsNullOrWhiteSpace(content.ToString()))
            {
                return;
            }

            if (this.ValidateDuplicates(content))
            {
                return;
            }

            var chipItem = new ChipItem { Content = content };

            if (this.ChipItemsView is { Items: { } })
            {
                var chip = new Chip { Content = chipItem.Content };
                this.ChipItemsView.Items.Add(chip);
                chip.Removed += OnChipRemoved;
            }

            this.Chips?.Add(chipItem);
        }

        private bool ValidateDuplicates(object content)
        {
            if (this.AllowDuplicates)
            {
                return false;
            }

            // Check the actual chip view item first
            if (this.ChipItemsView is { Items: { } })
            {
                var existingChip = this.ChipItemsView.Items.Cast<Chip>().FirstOrDefault(x => x.Content != null && x.Content.Equals(content));
                if (existingChip != null)
                {
                    return true;
                }
            }

            var existingChipItem = this.Chips?.FirstOrDefault(x => x.Content.Equals(content));
            return existingChipItem != null;
        }

        private void OnChipRemoved(object sender, ChipRemoveEventArgs args)
        {
            var chipItem = this.Chips?.FirstOrDefault(x => x.Content.Equals(args.Item));
            if (chipItem != null)
            {
                this.Chips.Remove(chipItem);
            }

            if (sender is Chip chip)
            {
                chip.Removed -= this.OnChipRemoved;
                this.ChipItemsView?.Items?.Remove(chip);
            }
        }
    }
}