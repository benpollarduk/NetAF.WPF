using System.IO;
using System.Windows.Controls;

namespace NetAF.Rendering.Console
{
    /// <summary>
    /// Represents a presenter for TextBox.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    public sealed class TextBoxPresenter(TextBox textBox) : IFramePresenter
    {
        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return textBox.Text;
        }

        #endregion

        #region Implementation of IFramePresenter

        /// <summary>
        /// Write a character.
        /// </summary>
        /// <param name="value">The character to write.</param>
        public void Write(char value)
        {
            textBox.AppendText(value.ToString());
        }

        /// <summary>
        /// Write a string.
        /// </summary>
        /// <param name="value">The string to write.</param>
        public void Write(string value)
        {
            textBox.AppendText(value);
        }

        #endregion
    }
}
