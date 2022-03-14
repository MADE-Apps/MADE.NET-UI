// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using Windows.UI.Xaml;

    /// <summary>
    /// Defines an event argument for when a <see cref="RichEditToolbar"/> list style changed.
    /// </summary>
    public class RichEditToolbarListStyleChangedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RichEditToolbarListStyleChangedEventArgs"/> class with the reference to the clicked item.
        /// </summary>
        /// <param name="bulletedList">A value indicating whether bulleted list is enabled.</param>
        /// <param name="numberedList">A value indicating whether numbered list is enabled.</param>
        public RichEditToolbarListStyleChangedEventArgs(bool bulletedList, bool numberedList)
        {
            this.BulletedList = bulletedList;
            this.NumberedList = numberedList;
        }

        /// <summary>
        /// Gets a value indicating whether bulleted list is enabled.
        /// </summary>
        public bool BulletedList { get; }

        /// <summary>
        /// Gets a value indicating whether numbered list is enabled.
        /// </summary>
        public bool NumberedList { get; }
    }
}
