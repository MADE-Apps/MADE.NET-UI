// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Windows.Input;
    using MADE.UI.Extensions;
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
        /// Identifies the <see cref="HeaderTemplate"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.Register(
            nameof(HeaderTemplate),
            typeof(DataTemplate),
            typeof(ChipBox),
            new PropertyMetadata(null));

        /// <summary>
        /// Identifies the <see cref="Chips"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ChipsProperty = DependencyProperty.Register(
            nameof(Chips),
            typeof(IList<ChipItem>),
            typeof(ChipBox),
            new PropertyMetadata(new ObservableCollection<ChipItem>(), (o, args) => ((ChipBox)o).SetupChips(args.OldValue as IList<ChipItem>, args.NewValue as IList<ChipItem>)));

        /// <summary>
        /// Identifies the <see cref="ChipContentTemplate"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ChipContentTemplateProperty = DependencyProperty.Register(
            nameof(ChipContentTemplate),
            typeof(DataTemplate),
            typeof(ChipBox),
            new PropertyMetadata(default(DataTemplate), (o, args) => ((ChipBox)o).UpdateChipContentTemplates()));

        /// <summary>
        /// Identifies the <see cref="ChipItemsViewStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ChipItemsViewStyleProperty = DependencyProperty.Register(
            nameof(ChipItemsViewStyle),
            typeof(Style),
            typeof(ChipBox),
            new PropertyMetadata(default(Style)));

        /// <summary>
        /// Identifies the <see cref="Suggestions"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SuggestionsProperty = DependencyProperty.Register(
            nameof(Suggestions),
            typeof(object),
            typeof(ChipBox),
            new PropertyMetadata(default));

        /// <summary>
        /// Identifies the <see cref="SuggestionsItemTemplate"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SuggestionsItemTemplateProperty = DependencyProperty.Register(
            nameof(SuggestionsItemTemplate),
            typeof(DataTemplate),
            typeof(ChipBox),
            new PropertyMetadata(default(DataTemplate)));

        /// <summary>
        /// Identifies the <see cref="AllowDuplicate"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AllowDuplicateProperty = DependencyProperty.Register(
            nameof(AllowDuplicate),
            typeof(bool),
            typeof(ChipBox),
            new PropertyMetadata(true));

        /// <summary>
        /// Identifies the <see cref="AllowFreeText"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AllowFreeTextProperty = DependencyProperty.Register(
            nameof(AllowFreeText),
            typeof(bool),
            typeof(ChipBox),
            new PropertyMetadata(true));

        /// <summary>
        /// Identifies the <see cref="IsReadonly"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsReadonlyProperty = DependencyProperty.Register(
            nameof(IsReadonly),
            typeof(bool),
            typeof(ChipBox),
            new PropertyMetadata(default(bool), (o, args) => ((ChipBox)o).UpdateForReadonly()));

        /// <summary>
        /// Identifies the <see cref="TextChangeCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextChangeCommandProperty = DependencyProperty.Register(
            nameof(TextChangeCommand),
            typeof(ICommand),
            typeof(ChipBox),
            new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// Identifies the <see cref="ChipRemoveCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ChipRemoveCommandProperty = DependencyProperty.Register(
            nameof(ChipRemoveCommand),
            typeof(ICommand),
            typeof(ChipBox),
            new PropertyMetadata(default(ICommand)));

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
        /// Occurs when the text has changed within the suggestion box.
        /// </summary>
        public event ChipBoxTextChangedEventHandler TextChanged;

        /// <summary>
        /// Occurs when a chip has been removed.
        /// </summary>
        public event ChipBoxChipRemovedEventHandler ChipRemoved;

        /// <summary>
        /// Gets or sets the content for the control's header.
        /// </summary>
        public object Header
        {
            get => this.GetValue(HeaderProperty);
            set => this.SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Gets or sets the template used to display the content of the control's header.
        /// </summary>
        public DataTemplate HeaderTemplate
        {
            get => (DataTemplate)this.GetValue(HeaderTemplateProperty);
            set => this.SetValue(HeaderTemplateProperty, value);
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
        /// Gets or sets the template associated with the content displayed in the chip.
        /// </summary>
        public DataTemplate ChipContentTemplate
        {
            get => (DataTemplate)GetValue(ChipContentTemplateProperty);
            set => SetValue(ChipContentTemplateProperty, value);
        }

        /// <summary>
        /// Gets or sets the style of the items view.
        /// </summary>
        public Style ChipItemsViewStyle
        {
            get => (Style)this.GetValue(ChipItemsViewStyleProperty);
            set => this.SetValue(ChipItemsViewStyleProperty, value);
        }

        /// <summary>
        /// Gets or sets the suggestions that are displayed to the user when typing.
        /// </summary>
        public object Suggestions
        {
            get => GetValue(SuggestionsProperty);
            set => SetValue(SuggestionsProperty, value);
        }

        /// <summary>
        /// Gets or sets the template used to display the suggestions that are displayed to the user when typing.
        /// </summary>
        public DataTemplate SuggestionsItemTemplate
        {
            get => (DataTemplate)GetValue(SuggestionsItemTemplateProperty);
            set => SetValue(SuggestionsItemTemplateProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to allow duplicate values to be accepted.
        /// </summary>
        /// <remarks>
        /// The default value is True.
        /// </remarks>
        public bool AllowDuplicate
        {
            get => (bool)GetValue(AllowDuplicateProperty);
            set => SetValue(AllowDuplicateProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to allow free text input.
        /// </summary>
        /// <remarks>
        /// The default value is True.
        /// </remarks>
        public bool AllowFreeText
        {
            get => (bool)GetValue(AllowFreeTextProperty);
            set => SetValue(AllowFreeTextProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control is in a read-only state.
        /// </summary>
        /// <remarks>
        /// The default value is False.
        /// </remarks>
        public bool IsReadonly
        {
            get => (bool)GetValue(IsReadonlyProperty);
            set => SetValue(IsReadonlyProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> associated with when the text has changed within the suggestion box.
        /// </summary>
        public ICommand TextChangeCommand
        {
            get => (ICommand)GetValue(TextChangeCommandProperty);
            set => SetValue(TextChangeCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> associated with when a chip has been removed.
        /// </summary>
        public ICommand ChipRemoveCommand
        {
            get => (ICommand)GetValue(ChipRemoveCommandProperty);
            set => SetValue(ChipRemoveCommandProperty, value);
        }

        /// <summary>
        /// Gets the view representing the text input for chips.
        /// </summary>
        public AutoSuggestBox TextBox { get; private set; }

        /// <summary>
        /// Gets the view representing the chip items.
        /// </summary>
        public ItemsControl ChipItemsView { get; private set; }

        /// <summary>
        /// Loads the relevant control template so that it's parts can be referenced.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            if (this.TextBox != null)
            {
                this.TextBox.TextChanged -= OnChipSuggestionTextChanged;
                this.TextBox.QuerySubmitted -= OnChipSuggestionChosen;
            }

            base.OnApplyTemplate();

            this.TextBox = this.GetChildView<AutoSuggestBox>(ChipBoxTextBoxPart);
            this.ChipItemsView = this.GetChildView<ItemsControl>(ChipBoxItemsViewPart);

            if (this.TextBox != null)
            {
                this.TextBox.TextChanged += this.OnChipSuggestionTextChanged;
                this.TextBox.QuerySubmitted += this.OnChipSuggestionChosen;
            }

            this.SetupChips(this.Chips, this.Chips);
            this.UpdateForReadonly();
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
            if (!this.AllowFreeText && args.ChosenSuggestion == null)
            {
                return;
            }

            this.AddChip(args.QueryText);
            if (sender == null)
            {
                return;
            }

            sender.Text = string.Empty;
            sender.IsSuggestionListOpen = false;
        }

        private void OnChipSuggestionTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (sender == null)
            {
                return;
            }

            this.TextChanged?.Invoke(this, new ChipBoxTextChangedEventArgs(sender.Text));
            this.TextChangeCommand?.Execute(sender.Text);
        }

        private void SetupChips(IEnumerable<ChipItem> previousChips, IList<ChipItem> newChips)
        {
            this.UnhookObservableChipsEvent(previousChips);
            this.HookObservableChipsEvent(newChips);

            if (this.ChipItemsView is not { Items: { } })
            {
                return;
            }

            this.ChipItemsView.Items.Clear();

            foreach (var chipItem in newChips)
            {
                this.AddChipItemToView(chipItem);
            }
        }

        private void OnChipItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                {
                    foreach (var item in e.NewItems)
                    {
                        this.AddChipItemToView(item as ChipItem);
                    }

                    break;
                }

                case NotifyCollectionChangedAction.Remove:
                {
                    foreach (var item in e.OldItems)
                    {
                        this.RemoveChipItemFromView(item as ChipItem);
                    }

                    break;
                }
            }
        }

        private void OnChipRemoved(object sender, ChipRemovedEventArgs args)
        {
            this.RemoveChip(args.Content, sender as Chip);
        }

        private void AddChip(object content)
        {
            if (content == null || string.IsNullOrWhiteSpace(content.ToString()))
            {
                return;
            }

            if (this.ValidateDuplicate(content))
            {
                return;
            }

            var chipItem = new ChipItem(content);

            this.AddChipItemToView(chipItem);

            this.UnhookObservableChipsEvent(this.Chips);
            this.Chips?.Add(chipItem);
            this.HookObservableChipsEvent(this.Chips);
        }

        private void RemoveChip(object content, Chip originator = null)
        {
            if (content == null && originator == null)
            {
                return;
            }

            var chipItem = this.Chips?.FirstOrDefault(x => x.Content.Equals(content));
            if (chipItem != null)
            {
                this.UnhookObservableChipsEvent(this.Chips);
                this.Chips.Remove(chipItem);
                this.HookObservableChipsEvent(this.Chips);
            }

            if (originator is { } chip)
            {
                chip.Removed -= this.OnChipRemoved;
                this.ChipItemsView?.Items?.Remove(chip);
            }

            this.ChipRemoved?.Invoke(this, new ChipBoxChipRemovedEventArgs(content));
            this.ChipRemoveCommand?.Execute(content);
        }

        private void AddChipItemToView(ChipItem chipItem)
        {
            if (chipItem == null || this.ChipItemsView is not { Items: { } })
            {
                return;
            }

            if (chipItem.Content == null || string.IsNullOrWhiteSpace(chipItem.Content.ToString()))
            {
                return;
            }

            if (this.ValidateDuplicate(chipItem.Content))
            {
                return;
            }

            var chip = new Chip { Content = chipItem.Content, ContentTemplate = this.ChipContentTemplate };
            this.ChipItemsView.Items.Add(chip);
            chip.Removed += this.OnChipRemoved;
        }

        private void RemoveChipItemFromView(ChipItem item)
        {
            if (item?.Content == null)
            {
                return;
            }

            RemoveChip(item.Content);
        }

        private bool ValidateDuplicate(object content)
        {
            if (this.AllowDuplicate)
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

        private void UpdateChipContentTemplates()
        {
            if (this.ChipItemsView is not { Items: { } })
            {
                return;
            }

            foreach (var chip in this.ChipItemsView.Items.Cast<Chip>())
            {
                chip.ContentTemplate = this.ChipContentTemplate;
            }
        }

        private void UpdateForReadonly()
        {
            this.TextBox.SetVisible(!this.IsReadonly);

            if (this.ChipItemsView is not { Items: { } })
            {
                return;
            }

            foreach (var chip in this.ChipItemsView.Items.Cast<Chip>())
            {
                chip.CanRemove = !this.IsReadonly;
            }
        }

        private void HookObservableChipsEvent(IEnumerable<ChipItem> chips)
        {
            if (chips is ObservableCollection<ChipItem> observableChips)
            {
                observableChips.CollectionChanged += this.OnChipItemsChanged;
            }
        }

        private void UnhookObservableChipsEvent(IEnumerable<ChipItem> chips)
        {
            if (chips is ObservableCollection<ChipItem> observableChips)
            {
                observableChips.CollectionChanged -= this.OnChipItemsChanged;
            }
        }
    }
}