// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using System.Collections.Generic;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Defines an interface for a customizable and extensible collection of buttons that activate rich text features in an associated <see cref="RichEditBox"/>.
    /// </summary>
    public interface IRichEditToolbar
    {
#if WINDOWS_UWP
        /// <summary>
        /// Gets or sets the associated <see cref="RichEditBox"/> control.
        /// </summary>
        RichEditBox TargetRichEditBox { get; set; }
#endif

        /// <summary>
        /// Gets or sets the additional custom text color options.
        /// </summary>
        IList<RichEditToolbarTextColorOption> CustomTextColorOptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show font size options.
        /// </summary>
        bool ShowFontSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show text color options.
        /// </summary>
        bool ShowTextColorOptions { get; set; }
    }
}