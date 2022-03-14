namespace MADE.UI.Controls
{
    using Windows.UI.Text;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls.Primitives;
    using Extensions;

    /// <summary>
    /// Defines the list style logic for the <see cref="RichEditToolbar"/>.
    /// </summary>
    public partial class RichEditToolbar
    {
        /// <summary>
        /// Identifies the <see cref="ShowListStyleOptions"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowListStyleOptionsProperty = DependencyProperty.Register(
            nameof(ShowListStyleOptions),
            typeof(bool),
            typeof(RichEditToolbar),
            new PropertyMetadata(true, (o, args) => ((RichEditToolbar)o).UpdateListStyleOptionsVisibility()));

        private const string RichEditToolbarBulletListButtonPart = "RichEditToolbarBulletListButton";
        private const string RichEditToolbarNumberListButtonPart = "RichEditToolbarNumberListButton";

        /// <summary>
        /// Occurs when the list style has changed.
        /// </summary>
        public event RichEditToolbarListStyleChangedEventHandler ListStyleChanged;

        /// <summary>
        /// Gets or sets a value indicating whether to show list style options.
        /// </summary>
        public bool ShowListStyleOptions
        {
            get => (bool)GetValue(ShowListStyleOptionsProperty);
            set => SetValue(ShowListStyleOptionsProperty, value);
        }

        /// <summary>
        /// Gets the view representing the button for toggling bullet list.
        /// </summary>
        public ToggleButton BulletListButton { get; private set; }

        /// <summary>
        /// Gets the view representing the button for toggling number list.
        /// </summary>
        public ToggleButton NumberListButton { get; private set; }

        private void SetupListStyleOptions()
        {
            this.BulletListButton = this.GetChildView<ToggleButton>(RichEditToolbarBulletListButtonPart);
            this.NumberListButton = this.GetChildView<ToggleButton>(RichEditToolbarNumberListButtonPart);

            this.UpdateListStyleOptionsVisibility();

            if (this.BulletListButton != null)
            {
                this.BulletListButton.Checked += this.OnBulletListButtonChecked;
                this.BulletListButton.Unchecked += this.OnBulletListButtonChecked;
            }

            if (this.NumberListButton != null)
            {
                this.NumberListButton.Checked += this.OnNumberListButtonChecked;
                this.NumberListButton.Unchecked += this.OnNumberListButtonChecked;
            }
        }

        private void UpdateListStyleOptionsVisibility()
        {
            this.BulletListButton?.SetVisible(this.ShowListStyleOptions);
            this.NumberListButton?.SetVisible(this.ShowListStyleOptions);
        }

#if WINDOWS_UWP
        private void UpdateActiveListStyleOptions()
        {
            var activeListStyleOption = this.TargetRichEditBox
                .Document
                .Selection
                .ParagraphFormat
                .ListType;

            if (activeListStyleOption == MarkerType.Undefined)
            {
                return;
            }

            if (this.BulletListButton != null)
            {
                this.BulletListButton.IsChecked = activeListStyleOption == MarkerType.Bullet;
            }

            if (this.NumberListButton != null)
            {
                this.NumberListButton.IsChecked = activeListStyleOption == MarkerType.CircledNumber;
            }

            this.EmitListStyleChanged();
        }
#endif

        private void ResetListStyleOptions()
        {
            if (this.BulletListButton != null)
            {
                this.BulletListButton.Checked -= this.OnBulletListButtonChecked;
                this.BulletListButton.Unchecked -= this.OnBulletListButtonChecked;
            }

            if (this.NumberListButton != null)
            {
                this.NumberListButton.Checked -= this.OnNumberListButtonChecked;
                this.NumberListButton.Unchecked -= this.OnNumberListButtonChecked;
            }
        }

        private void OnNumberListButtonChecked(object sender, RoutedEventArgs e)
        {
            if (this.NumberListButton == null
#if WINDOWS_UWP
                || this.TargetRichEditBox == null
#endif
               )
            {
                return;
            }

#if WINDOWS_UWP
            var isChecked = this.NumberListButton.IsChecked ?? false;
            var isBulletListChecked = this.BulletListButton?.IsChecked ?? false;

            // Resets the bullet list check option.
            if (isChecked && isBulletListChecked && this.BulletListButton != null)
            {
                this.BulletListButton.Unchecked -= this.OnBulletListButtonChecked;
                this.BulletListButton.IsChecked = false;
                this.BulletListButton.Unchecked += this.OnBulletListButtonChecked;
            }

            this.TargetRichEditBox
                    .Document
                    .Selection
                    .ParagraphFormat.ListType =
                isChecked ? MarkerType.CircledNumber : MarkerType.None;

            this.TargetRichEditBox.Document.Selection.ParagraphFormat.ListStyle = MarkerStyle.Plain;
#endif

            this.EmitListStyleChanged();
        }

        private void OnBulletListButtonChecked(object sender, RoutedEventArgs e)
        {
            if (this.BulletListButton == null
#if WINDOWS_UWP
                || this.TargetRichEditBox == null
#endif
               )
            {
                return;
            }

#if WINDOWS_UWP
            var isChecked = this.BulletListButton.IsChecked ?? false;
            var isNumberListChecked = this.NumberListButton?.IsChecked ?? false;

            // Resets the number list check option.
            if (isChecked && isNumberListChecked && this.NumberListButton != null)
            {
                this.NumberListButton.Unchecked -= this.OnNumberListButtonChecked;
                this.NumberListButton.IsChecked = false;
                this.NumberListButton.Unchecked += this.OnNumberListButtonChecked;
            }

            this.TargetRichEditBox
                    .Document
                    .Selection
                    .ParagraphFormat.ListType =
                isChecked ? MarkerType.Bullet : MarkerType.None;
#endif

            this.EmitListStyleChanged();
        }

        private void EmitListStyleChanged()
        {
            if (this.ListStyleChanged == null)
            {
                return;
            }

            var numberedList = this.NumberListButton?.IsChecked ?? false;
            var bulletedList = this.BulletListButton?.IsChecked ?? false;

            this.ListStyleChanged.Invoke(
                this,
                new RichEditToolbarListStyleChangedEventArgs(bulletedList, numberedList));
        }
    }
}