namespace MADE.UI.Controls
{
    using System.Windows.Input;
    using MADE.UI.Extensions;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    [TemplatePart(Name = ChipContentPart, Type = typeof(ContentPresenter))]
    [TemplatePart(Name = ChipRemoveButtonPart, Type = typeof(Button))]
    public sealed partial class Chip : ContentControl, IChip
    {
        public static readonly DependencyProperty RemoveCommandProperty = DependencyProperty.Register(
            nameof(RemoveCommand),
            typeof(ICommand),
            typeof(Chip),
            new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty CanRemoveProperty = DependencyProperty.Register(
            nameof(CanRemove),
            typeof(bool),
            typeof(Chip),
            new PropertyMetadata(true, (o, args) => ((Chip)o).SetRemoveButtonVisibility()));

        private const string ChipContentPart = "ChipContent";
        private const string ChipRemoveButtonPart = "ChipRemoveButton";

        public Chip()
        {
            this.DefaultStyleKey = typeof(Chip);
        }

        public event ChipRemoveEventHandler Removed;

        public ICommand RemoveCommand
        {
            get => (ICommand)GetValue(RemoveCommandProperty);
            set => SetValue(RemoveCommandProperty, value);
        }

        public bool CanRemove
        {
            get => (bool)GetValue(CanRemoveProperty);
            set => SetValue(CanRemoveProperty, value);
        }

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
            this.Removed?.Invoke(this, new ChipRemoveEventArgs(this.Content));
        }

        private void SetRemoveButtonVisibility()
        {
            this.RemoveButton?.SetVisible(this.CanRemove);
        }
    }
}