namespace MADE.UI.Controls
{
    using System.Collections.Generic;
    using System.Linq;
    using MADE.UI.Styling.Colors;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    /// <summary>
    /// Defines the text color logic for the <see cref="RichEditToolbar"/>.
    /// </summary>
    public partial class RichEditToolbar
    {
        /// <summary>
        /// Identifies the <see cref="CustomFontColorOptions"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CustomFontColorOptionsProperty = DependencyProperty.Register(
            nameof(CustomFontColorOptions),
            typeof(IList<RichEditToolbarFontColorOption>),
            typeof(RichEditToolbar),
            new PropertyMetadata(default(IList<RichEditToolbarFontColorOption>)));

        private const string RichEditToolbarColorButtonPart = "RichEditToolbarColorButton";
        private const string RichEditToolbarColorOptionsPart = "RichEditToolbarColorOptions";

        private static readonly IList<RichEditToolbarFontColorOption> DefaultFontColorOptions =
            new List<RichEditToolbarFontColorOption>
            {
                new() {Name = "Black", Color = "#000000"},
                new() {Name = "White", Color = "#ffffff"},
                new() {Name = "Silver", Color = "#d1d3d4"},
                new() {Name = "Gray", Color = "#a7a9ac"},
                new() {Name = "Dark Gray", Color = "#808285"},
                new() {Name = "Charcoal", Color = "#58595b"},
                new() {Name = "Magenta", Color = "#b31564"},
                new() {Name = "Red", Color = "#e61b1b"},
                new() {Name = "Red-orange", Color = "#ff5500"},
                new() {Name = "Orange", Color = "#ffaa00"},
                new() {Name = "Gold", Color = "#ffce00"},
                new() {Name = "Yellow", Color = "#ffe600"},
                new() {Name = "Grass green", Color = "#a2e61b"},
                new() {Name = "Green", Color = "#26e600"},
                new() {Name = "Dark green", Color = "#008055"},
                new() {Name = "Teal", Color = "#00aacc"},
                new() {Name = "Blue", Color = "#004de6"},
                new() {Name = "Indigo", Color = "#3d00b8"},
                new() {Name = "Violet", Color = "#6600cc"},
                new() {Name = "Purple", Color = "#600080"},
                new() {Name = "Beige", Color = "#f7d7c4"},
                new() {Name = "Light brown", Color = "#bb9167"},
                new() {Name = "Brown", Color = "#8e562e"},
                new() {Name = "Dark brown", Color = "#613d30"},
                new() {Name = "Pastel pink", Color = "#ff80ff"},
                new() {Name = "Pastel orange", Color = "#ffc680"},
                new() {Name = "Pastel yellow", Color = "#ffff80"},
                new() {Name = "Pastel green", Color = "#80ff9e"},
                new() {Name = "Pastel blue", Color = "#80d6ff"},
                new() {Name = "Pastel purple", Color = "#bcb3ff"},
            };

        /// <summary>
        /// Gets or sets the additional custom font color options.
        /// </summary>
        public IList<RichEditToolbarFontColorOption> CustomFontColorOptions
        {
            get => (IList<RichEditToolbarFontColorOption>)GetValue(CustomFontColorOptionsProperty);
            set => SetValue(CustomFontColorOptionsProperty, value);
        }

        /// <summary>
        /// Gets the view representing the button for setting font color.
        /// </summary>
        public Button FontColorButton { get; private set; }

        /// <summary>
        /// Gets the view representing the panel for displaying font color options.
        /// </summary>
        public Panel FontColorOptionsPanel { get; private set; }

        private void SetupFontColorOptions()
        {
            this.FontColorButton = this.GetChildView<Button>(RichEditToolbarColorButtonPart);
            this.FontColorOptionsPanel = this.GetChildView<Panel>(RichEditToolbarColorOptionsPart);

            if (this.FontColorOptionsPanel == null)
            {
                return;
            }

            var fontColorOptions = this.CustomFontColorOptions == null
                ? DefaultFontColorOptions
                : DefaultFontColorOptions.Concat(this.CustomFontColorOptions);

            foreach (var fontColorOption in fontColorOptions)
            {
                var fontColorButton = new Button {Background = fontColorOption.Color.ToSolidColorBrush()};

                var fontColorButtonToolTip = new ToolTip {Content = fontColorOption.Name};

                ToolTipService.SetToolTip(fontColorButton, fontColorButtonToolTip);

                fontColorButton.Click += this.OnFontColorButtonClicked;

                this.FontColorOptionsPanel.Children.Add(fontColorButton);
            }
        }

        private void UpdateActiveFontColorOptions()
        {
            if (this.FontColorButton != null)
            {
                this.FontColorButton.Foreground = this.TargetRichEditBox
                    .Document
                    .Selection
                    .CharacterFormat
                    .ForegroundColor
                    .ToSolidColorBrush();
            }
        }

        private void ResetFontColorOptions()
        {
            if (this.FontColorOptionsPanel == null)
            {
                return;
            }

            foreach (var element in this.FontColorOptionsPanel.Children)
            {
                if (element is Button fontColorButton)
                {
                    fontColorButton.Click -= this.OnFontColorButtonClicked;
                }
            }

            this.FontColorOptionsPanel.Children.Clear();
        }

        private void OnFontColorButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sender == null || this.TargetRichEditBox == null)
            {
                return;
            }

            if (sender is not Button colorElement)
            {
                return;
            }

            var brush = colorElement.Background as SolidColorBrush;
            var color = brush?.Color ?? Colors.Black;

            if (this.FontColorButton != null)
            {
                this.FontColorButton.Foreground = brush ?? Colors.Black.ToSolidColorBrush();
            }

            this.TargetRichEditBox.Document.Selection.CharacterFormat.ForegroundColor = color;
        }
    }
}