using System.Text;

namespace NetAF.Rendering.Console
{
    /// <summary>
    /// Provides a class for building text.
    /// </summary>
    public class TextBuilder()
    {
        #region Fields

        private readonly StringBuilder builder = new();

        #endregion

        #region Methods

        /// <summary>
        /// Clear the contents of this builder.
        /// </summary>
        public void Clear()
        {
            builder.Clear();
        }

        /// <summary>
        /// Append text.
        /// </summary>
        /// <param name="text">The text to append.</param>
        public void Append(string text)
        {
            builder.Append(text);
        }

        #endregion

        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return builder.ToString();
        }

        #endregion
    }
}
