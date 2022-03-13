namespace MADE.UI.Controls
{
    using Windows.UI.Text;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls.Primitives;

    /// <summary>
    /// Defines the font style logic for the <see cref="RichEditToolbar"/>.
    /// </summary>
    public partial class RichEditToolbar
    {
        private const string RichEditToolbarBoldButtonPart = "RichEditToolbarBoldButton";
        private const string RichEditToolbarItalicButtonPart = "RichEditToolbarItalicButton";
        private const string RichEditToolbarUnderlineButtonPart = "RichEditToolbarUnderlineButton";

        /// <summary>
        /// Gets the view representing the button for toggling bold text.
        /// </summary>
        public ToggleButton BoldButton { get; private set; }

        /// <summary>
        /// Gets the view representing the button for toggling italic text.
        /// </summary>
        public ToggleButton ItalicButton { get; private set; }

        /// <summary>
        /// Gets the view representing the button for toggling underline text.
        /// </summary>
        public ToggleButton UnderlineButton { get; private set; }

        private void SetupFontStyleOptions()
        {
            this.BoldButton = this.GetChildView<ToggleButton>(RichEditToolbarBoldButtonPart);
            this.ItalicButton = this.GetChildView<ToggleButton>(RichEditToolbarItalicButtonPart);
            this.UnderlineButton = this.GetChildView<ToggleButton>(RichEditToolbarUnderlineButtonPart);

            if (this.BoldButton != null)
            {
                this.BoldButton.Checked += this.OnBoldButtonChecked;
                this.BoldButton.Unchecked += this.OnBoldButtonChecked;
            }

            if (this.ItalicButton != null)
            {
                this.ItalicButton.Checked += this.OnItalicButtonChecked;
                this.ItalicButton.Unchecked += this.OnItalicButtonChecked;
            }

            if (this.UnderlineButton != null)
            {
                this.UnderlineButton.Checked += this.OnUnderlineButtonChecked;
                this.UnderlineButton.Unchecked += this.OnUnderlineButtonChecked;
            }
        }

        private void UpdateActiveFontStyleOptions()
        {
            if (this.BoldButton != null)
            {
                this.BoldButton.IsChecked = this.TargetRichEditBox
                    .Document
                    .Selection
                    .CharacterFormat
                    .Bold == FormatEffect.On;
            }

            if (this.ItalicButton != null)
            {
                this.ItalicButton.IsChecked = this.TargetRichEditBox
                    .Document
                    .Selection
                    .CharacterFormat
                    .Italic == FormatEffect.On;
            }

            if (this.UnderlineButton != null)
            {
                this.UnderlineButton.IsChecked = this.TargetRichEditBox
                    .Document
                    .Selection
                    .CharacterFormat
                    .Underline == UnderlineType.Single;
            }
        }

        private void ResetFontStyleOptions()
        {
            if (this.BoldButton != null)
            {
                this.BoldButton.Checked -= this.OnBoldButtonChecked;
                this.BoldButton.Unchecked -= this.OnBoldButtonChecked;
            }

            if (this.ItalicButton != null)
            {
                this.ItalicButton.Checked -= this.OnItalicButtonChecked;
                this.ItalicButton.Unchecked -= this.OnItalicButtonChecked;
            }

            if (this.UnderlineButton != null)
            {
                this.UnderlineButton.Checked -= this.OnUnderlineButtonChecked;
                this.UnderlineButton.Unchecked -= this.OnUnderlineButtonChecked;
            }
        }

        private void OnBoldButtonChecked(object sender, RoutedEventArgs e)
        {
            if (this.BoldButton == null || this.TargetRichEditBox == null)
            {
                return;
            }

            var isChecked = this.BoldButton.IsChecked ?? false;
            this.TargetRichEditBox.Document.Selection.CharacterFormat.Bold =
                isChecked ? FormatEffect.On : FormatEffect.Off;
        }

        private void OnItalicButtonChecked(object sender, RoutedEventArgs e)
        {
            if (this.ItalicButton == null || this.TargetRichEditBox == null)
            {
                return;
            }

            var isChecked = this.ItalicButton.IsChecked ?? false;
            this.TargetRichEditBox.Document.Selection.CharacterFormat.Italic =
                isChecked ? FormatEffect.On : FormatEffect.Off;
        }

        private void OnUnderlineButtonChecked(object sender, RoutedEventArgs e)
        {
            if (this.UnderlineButton == null || this.TargetRichEditBox == null)
            {
                return;
            }

            var isChecked = this.UnderlineButton.IsChecked ?? false;
            this.TargetRichEditBox.Document.Selection.CharacterFormat.Underline =
                isChecked ? UnderlineType.Single : UnderlineType.None;
        }
    }
}