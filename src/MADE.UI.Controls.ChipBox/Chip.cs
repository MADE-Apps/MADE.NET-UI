// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using System.Windows.Input;
    using MADE.UI.Extensions;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Defines a control for displaying a value as a chip with remove capabilities.
    /// </summary>
    [TemplatePart(Name = ChipContentPart, Type = typeof(ContentPresenter))]
    [TemplatePart(Name = ChipRemoveButtonPart, Type = typeof(Button))]
    public sealed partial class Chip : ContentControl, IChip
    {
        /// <summary>
        /// Identifies the <see cref="RemoveCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty RemoveCommandProperty = DependencyProperty.Register(
            nameof(RemoveCommand),
            typeof(ICommand),
            typeof(Chip),
            new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// Identifies the <see cref="CanRemove"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CanRemoveProperty = DependencyProperty.Register(
            nameof(CanRemove),
            typeof(bool),
            typeof(Chip),
            new PropertyMetadata(true, (o, args) => ((Chip)o).SetRemoveButtonVisibility()));

        private const string ChipContentPart = "ChipContent";
        private const string ChipRemoveButtonPart = "ChipRemoveButton";

        /// <summary>
        /// Initializes a new instance of the <see cref="Chip"/> class.
        /// </summary>
        public Chip()
        {
            this.DefaultStyleKey = typeof(Chip);
        }

        /// <summary>
        /// Occurs when the user pressed the remove chip button.
        /// </summary>
        public event ChipRemovedEventHandler Removed;

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> associated with when the user pressed the remove chip button.
        /// </summary>
        public ICommand RemoveCommand
        {
            get => (ICommand)GetValue(RemoveCommandProperty);
            set => SetValue(RemoveCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the chip can be removed.
        /// </summary>
        public bool CanRemove
        {
            get => (bool)GetValue(CanRemoveProperty);
            set => SetValue(CanRemoveProperty, value);
        }

        /// <summary>
        /// Gets the view representing the remove chip button.
        /// </summary>
        public Button RemoveButton { get; private set; }

        /// <summary>
        /// Loads the relevant control template so that it's parts can be referenced.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            if (this.RemoveButton != null)
            {
                this.RemoveButton.Click -= this.OnRemoveClick;
            }

            base.OnApplyTemplate();

            this.RemoveButton = this.GetChildView<Button>(ChipRemoveButtonPart);

            if (this.RemoveButton != null)
            {
                this.RemoveButton.Click += this.OnRemoveClick;
            }

            this.SetRemoveButtonVisibility();
        }

        private void OnRemoveClick(object sender, RoutedEventArgs e)
        {
            this.RemoveCommand?.Execute(this.Content);
            this.Removed?.Invoke(this, new ChipRemovedEventArgs(this.Content));
        }

        private void SetRemoveButtonVisibility()
        {
            this.RemoveButton?.SetVisible(this.CanRemove);
        }
    }
}