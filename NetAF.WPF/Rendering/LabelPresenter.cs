using System.Windows.Controls;

namespace NetAF.WPF.Rendering
{
    /// <summary>
    /// Represents a presenter for Label.
    /// </summary>
    /// <param name="label">The label.</param>
    public sealed class LabelPresenter(Label label) : IVisualFramePresenter
    {
        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return label.Content?.ToString() ?? string.Empty;
        }

        #endregion

        #region Implementation of IVisualFramePresenter

        /// <summary>
        /// Clear the visual.
        /// </summary>
        public void Clear()
        {
            label.Content = string.Empty;
        }

        /// <summary>
        /// Write a character.
        /// </summary>
        /// <param name="value">The character to write.</param>
        public void Write(char value)
        {
            Write(value.ToString());
        }

        /// <summary>
        /// Write a string.
        /// </summary>
        /// <param name="value">The string to write.</param>
        public void Write(string value)
        {
            label.Content += $"{label.Content}{value}";
        }

        #endregion
    }
}
