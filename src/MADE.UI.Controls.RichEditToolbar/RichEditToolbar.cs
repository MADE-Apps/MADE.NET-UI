// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Automation.Peers;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;

    /// <summary>
    /// Defines a customizable and extensible collection of buttons that activate rich text features in an associated <see cref="RichEditBox"/>.
    /// </summary>
    [TemplatePart(Name = RichEditToolbarOptionsBarPart, Type = typeof(CommandBar))]
    [TemplatePart(Name = RichEditToolbarIncreaseTextSizeButtonPart, Type = typeof(Button))]
    [TemplatePart(Name = RichEditToolbarDecreaseTextSizeButtonPart, Type = typeof(Button))]
    [TemplatePart(Name = RichEditToolbarBoldButtonPart, Type = typeof(ToggleButton))]
    [TemplatePart(Name = RichEditToolbarItalicButtonPart, Type = typeof(ToggleButton))]
    [TemplatePart(Name = RichEditToolbarUnderlineButtonPart, Type = typeof(ToggleButton))]
    [TemplatePart(Name = RichEditToolbarColorButtonPart, Type = typeof(Button))]
    [TemplatePart(Name = RichEditToolbarColorOptionsPart, Type = typeof(Panel))]
    public partial class RichEditToolbar : Control, IRichEditToolbar
    {
#if WINDOWS_UWP
        /// <summary>
        /// Identifies the <see cref="TargetRichEditBox"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TargetRichEditBoxProperty = DependencyProperty.Register(
            nameof(TargetRichEditBox),
            typeof(RichEditBox),
            typeof(RichEditToolbar),
            new PropertyMetadata(default(RichEditBox), (o, args) => ((RichEditToolbar)o).SetupRichEditBox()));
#endif

        /// <summary>
        /// Identifies the <see cref="CustomOptions"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CustomOptionsProperty = DependencyProperty.Register(
            nameof(CustomOptions),
            typeof(IList<ICommandBarElement>),
            typeof(RichEditToolbar),
            new PropertyMetadata(new List<ICommandBarElement>()));

        private const string RichEditToolbarOptionsBarPart = "LayoutRoot";

        /// <summary>
        /// Initializes a new instance of the <see cref="RichEditToolbar"/> class.
        /// </summary>
        public RichEditToolbar()
        {
            this.DefaultStyleKey = typeof(RichEditToolbar);
        }

#if WINDOWS_UWP
        /// <summary>
        /// Gets or sets the associated <see cref="RichEditBox"/> control.
        /// </summary>
        public RichEditBox TargetRichEditBox
        {
            get => (RichEditBox)GetValue(TargetRichEditBoxProperty);
            set => SetValue(TargetRichEditBoxProperty, value);
        }
#endif

        /// <summary>
        /// Gets or sets the additional custom options.
        /// </summary>
        public IList<ICommandBarElement> CustomOptions
        {
            get => (IList<ICommandBarElement>)GetValue(CustomOptionsProperty);
            set => SetValue(CustomOptionsProperty, value);
        }

        /// <summary>
        /// Gets the view representing the option button bar.
        /// </summary>
        public CommandBar Toolbar { get; private set; }

        /// <summary>
        /// Loads the relevant control template so that its parts can be referenced.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            this.ResetFontSizeOptions();
            this.ResetFontStyleOptions();
            this.ResetTextColorOptions();
#if WINDOWS_UWP
            this.ResetRichEditBox();
#endif

            base.OnApplyTemplate();

            this.Toolbar = this.GetChildView<CommandBar>(RichEditToolbarOptionsBarPart);

            this.SetupFontSizeOptions();
            this.SetupFontStyleOptions();
            this.SetupTextColorOptions();

#if WINDOWS_UWP
            this.SetupRichEditBox();
#endif

            this.SetupCustomOptions();
        }

        /// <summary>
        /// Provides the class-specific <see cref="RichEditToolbarAutomationPeer"/> implementation for the Microsoft UI Automation infrastructure.
        /// </summary>
        /// <returns>The class-specific <see cref="RichEditToolbarAutomationPeer"/> instance.</returns>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new RichEditToolbarAutomationPeer(this);
        }

#if WINDOWS_UWP
        private void SetupRichEditBox()
        {
            if (this.TargetRichEditBox == null)
            {
                return;
            }

            this.UpdateActiveToolbarOptions();
            this.TargetRichEditBox.Document.Selection.CharacterFormat.Size = DefaultFontSize;
            this.TargetRichEditBox.SelectionChanged += this.OnRichEditBoxSelectionChanged;
        }

        private void ResetRichEditBox()
        {
            if (this.TargetRichEditBox != null)
            {
                this.TargetRichEditBox.SelectionChanged -= this.OnRichEditBoxSelectionChanged;
            }
        }


        private void OnRichEditBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            this.UpdateActiveToolbarOptions();
        }

        private void UpdateActiveToolbarOptions()
        {
            this.UpdateActiveFontStyleOptions();
            this.UpdateActiveTextColorOptions();
        }
#endif

        private void SetupCustomOptions()
        {
            if (this.Toolbar == null || this.CustomOptions == null)
            {
                return;
            }

            foreach (var option in this.CustomOptions)
            {
                if (!this.Toolbar.PrimaryCommands.Contains(option))
                {
                    this.Toolbar.PrimaryCommands.Add(option);
                }
            }
        }
    }
}