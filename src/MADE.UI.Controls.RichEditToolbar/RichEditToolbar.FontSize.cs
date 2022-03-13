namespace MADE.UI.Controls
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Defines the font size logic for the <see cref="RichEditToolbar"/>.
    /// </summary>
    public partial class RichEditToolbar
    {
        private const string RichEditToolbarIncreaseTextSizeButtonPart = "RichEditToolbarIncreaseTextSizeButton";
        private const string RichEditToolbarDecreaseTextSizeButtonPart = "RichEditToolbarDecreaseTextSizeButton";
        private const int DefaultTextSize = 11;

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
            if (this.TargetRichEditBox == null || this.TargetRichEditBox.Document.Selection.CharacterFormat.Size <= 0)
            {
                return;
            }

            this.TargetRichEditBox.Document.Selection.CharacterFormat.Size++;
        }

        private void OnFontSizeDecreaseClicked(object sender, RoutedEventArgs e)
        {
            if (this.TargetRichEditBox == null || this.TargetRichEditBox.Document.Selection.CharacterFormat.Size <= 1)
            {
                return;
            }

            this.TargetRichEditBox.Document.Selection.CharacterFormat.Size--;
        }
    }
}