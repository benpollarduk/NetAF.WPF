using System.Windows.Controls;

namespace NetAF.WPF.Rendering
{
    /// <summary>
    /// Represents a presenter for TextBlock.
    /// </summary>
    /// <param name="textBlock">The text block.</param>
    public sealed class TextBlockPresenter(TextBlock textBlock) : IVisualFramePresenter
    {
        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return textBlock.Text;
        }

        #endregion

        #region Implementation of IVisualFramePresenter

        /// <summary>
        /// Clear the visual.
        /// </summary>
        public void Clear()
        {
            textBlock.Text = string.Empty;
        }

        /// <summary>
        /// Write a character.
        /// </summary>
        /// <param name="value">The character to write.</param>
        public void Write(char value)
        {
            textBlock.Text += value.ToString();
        }

        /// <summary>
        /// Write a string.
        /// </summary>
        /// <param name="value">The string to write.</param>
        public void Write(string value)
        {
            textBlock.Text += value.ToString();
        }

        #endregion
    }
}
