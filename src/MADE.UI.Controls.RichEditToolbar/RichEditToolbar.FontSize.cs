namespace MADE.UI.Controls
{
    using MADE.UI.Extensions;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Defines the font size logic for the <see cref="RichEditToolbar"/>.
    /// </summary>
    public partial class RichEditToolbar
    {
        /// <summary>
        /// Identifies the <see cref="ShowFontSizeOptions"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowFontSizeOptionsProperty = DependencyProperty.Register(
            nameof(ShowFontSizeOptions),
            typeof(bool),
            typeof(RichEditToolbar),
            new PropertyMetadata(true, (o, args) => ((RichEditToolbar)o).UpdateFontSizeOptionsVisibility()));

        private const string RichEditToolbarIncreaseTextSizeButtonPart = "RichEditToolbarIncreaseTextSizeButton";
        private const string RichEditToolbarDecreaseTextSizeButtonPart = "RichEditToolbarDecreaseTextSizeButton";
        private const int DefaultFontSize = 11;

#if !WINDOWS_UWP
        private int currentFontSize = DefaultFontSize;
#endif

        /// <summary>
        /// Occurs when the font size has changed.
        /// </summary>
        public event RichEditToolbarFontSizeChangedEventHandler FontSizeChanged;

        /// <summary>
        /// Gets or sets a value indicating whether to show font size options.
        /// </summary>
        public bool ShowFontSizeOptions
        {
            get => (bool)GetValue(ShowFontSizeOptionsProperty);
            set => SetValue(ShowFontSizeOptionsProperty, value);
        }

        /// <summary>
        /// Gets the view representing the button for increasing the font size.
        /// </summary>
        public Button FontSizeIncreaseButton { get; private set; }

        /// <summary>
        /// Gets the view representing the button for decreasing the font size.
        /// </summary>
        public Button FontSizeDecreaseButton { get; private set; }

        private void SetupFontSizeOptions()
        {
            this.FontSizeIncreaseButton = this.GetChildView<Button>(RichEditToolbarIncreaseTextSizeButtonPart);
            this.FontSizeDecreaseButton = this.GetChildView<Button>(RichEditToolbarDecreaseTextSizeButtonPart);

            if (this.FontSizeDecreaseButton != null)
            {
                this.FontSizeDecreaseButton.Click += this.OnFontSizeDecreaseClicked;
            }

            if (this.FontSizeIncreaseButton != null)
            {
                this.FontSizeIncreaseButton.Click += this.OnFontSizeIncreaseClicked;
            }
        }

        private void UpdateFontSizeOptionsVisibility()
        {
            this.FontSizeIncreaseButton?.SetVisible(this.ShowFontSizeOptions);
            this.FontSizeDecreaseButton?.SetVisible(this.ShowFontSizeOptions);
        }

        private void ResetFontSizeOptions()
        {
            if (this.FontSizeDecreaseButton != null)
            {
                this.FontSizeDecreaseButton.Click -= this.OnFontSizeDecreaseClicked;
            }

            if (this.FontSizeIncreaseButton != null)
            {
                this.FontSizeIncreaseButton.Click -= this.OnFontSizeIncreaseClicked;
            }
        }

        private void OnFontSizeIncreaseClicked(object sender, RoutedEventArgs e)
        {
#if WINDOWS_UWP
            if (this.TargetRichEditBox == null || this.TargetRichEditBox.Document.Selection.CharacterFormat.Size <= 0)
            {
                return;
            }

            this.TargetRichEditBox.Document.Selection.CharacterFormat.Size++;

            this.FontSizeChanged?.Invoke(this, new RichEditToolbarFontSizeChangedEventArgs(this.TargetRichEditBox.Document.Selection.CharacterFormat.Size));
#else
            currentFontSize++;
            this.FontSizeChanged?.Invoke(this, new RichEditToolbarFontSizeChangedEventArgs(currentFontSize));
#endif
        }

        private void OnFontSizeDecreaseClicked(object sender, RoutedEventArgs e)
        {
#if WINDOWS_UWP
            if (this.TargetRichEditBox == null || this.TargetRichEditBox.Document.Selection.CharacterFormat.Size <= 1)
            {
                return;
            }

            this.TargetRichEditBox.Document.Selection.CharacterFormat.Size--;
#else
            currentFontSize--;
            this.FontSizeChanged?.Invoke(this, new RichEditToolbarFontSizeChangedEventArgs(currentFontSize));
#endif
        }
    }
}