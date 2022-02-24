// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Controls
{
    using Windows.UI.Xaml.Automation.Peers;
    using Windows.UI.Xaml.Automation.Provider;

    /// <summary>
    /// Defines a framework element automation peer for the <see cref="Chip"/> control.
    /// </summary>
    public class ChipAutomationPeer : FrameworkElementAutomationPeer, IValueProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChipAutomationPeer"/> class.
        /// </summary>
        /// <param name="owner">
        /// The <see cref="Chip" /> that is associated with this <see cref="AutomationPeer"/>.
        /// </param>
        public ChipAutomationPeer(Chip owner)
            : base(owner)
        {
        }

        /// <summary>Gets a value that indicates whether the value of a control is read-only.</summary>
        /// <returns>**true** if the value is read-only; **false** if it can be modified.</returns>
        public bool IsReadOnly => !OwningChip.CanRemove;

        /// <summary>Gets the value of the control.</summary>
        /// <returns>The value of the control.</returns>
        public string Value => this.OwningChip.Content?.ToString() ?? string.Empty;

        private Chip OwningChip => this.Owner as Chip;

        /// <summary>Sets the value of a control.</summary>
        /// <param name="value">The value to set. The provider is responsible for converting the value to the appropriate data type.</param>
        public void SetValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            OwningChip.Content = value;
        }

        /// <summary>
        /// Gets the control type for the element that is associated with the UI Automation peer.
        /// </summary>
        /// <returns>The control type.</returns>
        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.ListItem;
        }

        /// <summary>
        /// Provides the type name of the <see cref="ChipBox"/> when a Microsoft UI Automation client calls GetClassName or an equivalent Microsoft UI Automation client API.
        /// </summary>
        /// <returns>The type name of the <see cref="ChipBox"/>.</returns>
        protected override string GetClassNameCore()
        {
            return this.Owner.GetType().Name;
        }

        /// <summary>
        /// Provides the name given to the <see cref="ChipBox"/> when a Microsoft UI Automation client calls GetName or an equivalent Microsoft UI Automation client API.
        /// </summary>
        /// <returns>The name of the <see cref="ChipBox"/>.</returns>
        protected override string GetNameCore()
        {
            string name = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                name = base.GetNameCore();
            }

            if (this.OwningChip != null)
            {
                name = this.OwningChip.Name;
            }

            if (string.IsNullOrEmpty(name))
            {
                name = this.GetClassName();
            }

            return name;
        }

        /// <summary>
        /// Provides the interaction patterns associated with the <see cref="Chip"/> when a Microsoft UI Automation client calls GetPattern or an equivalent Microsoft UI Automation client API.
        /// </summary>
        /// <param name="patternInterface">A value from the PatternInterface enumeration.</param>
        /// <returns>This if it supports the pattern interface; otherwise, null.</returns>
        protected override object GetPatternCore(PatternInterface patternInterface)
        {
            switch (patternInterface)
            {
                case PatternInterface.Value:
                    return this;
            }

            return base.GetPatternCore(patternInterface);
        }
    }
}