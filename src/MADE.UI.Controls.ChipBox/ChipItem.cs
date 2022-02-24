namespace MADE.UI.Controls
{
    public class ChipItem
    {
        public object Content { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.Content?.ToString();
        }
    }
}
