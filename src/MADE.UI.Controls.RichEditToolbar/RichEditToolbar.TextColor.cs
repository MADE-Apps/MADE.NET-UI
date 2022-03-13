namespace MADE.UI.Controls
{
    using System.Collections.Generic;
    using System.Linq;
    using MADE.UI.Extensions;
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
        /// Identifies the <see cref="ShowTextColorOptions"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowTextColorOptionsProperty = DependencyProperty.Register(
            nameof(ShowTextColorOptions),
            typeof(bool),
            typeof(RichEditToolbar),
            new PropertyMetadata(true, (o, args) => ((RichEditToolbar)o).UpdateTextColorOptionsVisibility()));

        /// <summary>
        /// Identifies the <see cref="CustomTextColorOptions"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CustomTextColorOptionsProperty = DependencyProperty.Register(
            nameof(CustomTextColorOptions),
            typeof(IList<RichEditToolbarTextColorOption>),
            typeof(RichEditToolbar),
            new PropertyMetadata(default(IList<RichEditToolbarTextColorOption>)));

        private const string RichEditToolbarColorButtonPart = "RichEditToolbarColorButton";
        private const string RichEditToolbarColorOptionsPart = "RichEditToolbarColorOptions";

        private static readonly IList<RichEditToolbarTextColorOption> DefaultTextColorOptions =
            new List<RichEditToolbarTextColorOption>
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
        /// Occurs when the text color has changed.
        /// </summary>
        public event RichEditToolbarTextColorChangedEventHandler TextColorChanged;

        /// <summary>
        /// Gets or sets the additional custom text color options.
        /// </summary>
        public IList<RichEditToolbarTextColorOption> CustomTextColorOptions
        {
            get => (IList<RichEditToolbarTextColorOption>)GetValue(CustomTextColorOptionsProperty);
            set => SetValue(CustomTextColorOptionsProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show text color options.
        /// </summary>
        public bool ShowTextColorOptions
        {
            get => (bool)GetValue(ShowTextColorOptionsProperty);
            set => SetValue(ShowTextColorOptionsProperty, value);
        }

        /// <summary>
        /// Gets the view representing the button for setting text color.
        /// </summary>
        public Button TextColorButton { get; private set; }

        /// <summary>
        /// Gets the view representing the panel for displaying text color options.
        /// </summary>
        public Panel TextColorOptionsPanel { get; private set; }

        private void SetupTextColorOptions()
        {
            this.TextColorButton = this.GetChildView<Button>(RichEditToolbarColorButtonPart);
            this.TextColorOptionsPanel = this.GetChildView<Panel>(RichEditToolbarColorOptionsPart);

            if (this.TextColorOptionsPanel == null)
            {
                return;
            }

            var textColorOptions = this.CustomTextColorOptions == null
                ? DefaultTextColorOptions
                : DefaultTextColorOptions.Concat(this.CustomTextColorOptions);

            foreach (var textColorOption in textColorOptions)
            {
                var textColorButton = new Button {Background = textColorOption.Color.ToSolidColorBrush()};

                var textColorButtonToolTip = new ToolTip {Content = textColorOption.Name};

                ToolTipService.SetToolTip(textColorButton, textColorButtonToolTip);

                textColorButton.Click += this.OnTextColorButtonClicked;

                this.TextColorOptionsPanel.Children.Add(textColorButton);
            }
        }

#if WINDOWS_UWP
        private void UpdateActiveTextColorOptions()
        {
            if (this.TextColorButton == null)
            {
                return;
            }

            var color = this.TargetRichEditBox.Document.Selection.CharacterFormat.ForegroundColor;

            this.TextColorButton.Foreground = color.ToSolidColorBrush();

            this.EmitTextColorChanged(color);
        }
#endif

        private void UpdateTextColorOptionsVisibility()
        {
            this.TextColorButton?.SetVisible(this.ShowTextColorOptions);
        }

        private void ResetTextColorOptions()
        {
            if (this.TextColorOptionsPanel == null)
            {
                return;
            }

            foreach (var element in this.TextColorOptionsPanel.Children)
            {
                if (element is Button textColorButton)
                {
                    textColorButton.Click -= this.OnTextColorButtonClicked;
                }
            }

            this.TextColorOptionsPanel.Children.Clear();
        }

        private void OnTextColorButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sender == null
#if WINDOWS_UWP
                || this.TargetRichEditBox == null
#endif
               )
            {
                return;
            }

            if (sender is not Button colorElement)
            {
                return;
            }

            var brush = colorElement.Background as SolidColorBrush;
            var color = brush?.Color ?? Colors.Black;

            if (this.TextColorButton != null)
            {
                this.TextColorButton.Foreground = brush ?? Colors.Black.ToSolidColorBrush();
            }

#if WINDOWS_UWP
            this.TargetRichEditBox.Document.Selection.CharacterFormat.ForegroundColor = color;
#endif

            this.EmitTextColorChanged(color);
        }

        private void EmitTextColorChanged(Color color)
        {
            this.TextColorChanged?.Invoke(this, new RichEditToolbarTextColorChangedEventArgs(color.ToHexString()));
        }
    }
}