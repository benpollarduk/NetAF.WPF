using NetAF.Rendering.Console;

namespace NetAF.Rendering.WPF
{
    /// <summary>
    /// Provides a grid based frame for displaying a command based interface.
    /// </summary>
    /// <param name="builder">The builder that creates the frame.</param>
    public sealed class TextFrame(TextBuilder builder) : IFrame
    {
        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return builder?.ToString() ?? string.Empty;
        }

        #endregion

        #region Implementation of IFrame<Inline>

        /// <summary>
        /// Render this frame on a presenter.
        /// </summary>
        /// <param name="presenter">The presenter.</param>
        public void Render(IFramePresenter presenter)
        {
            presenter.Write(builder.ToString());
        }

        #endregion
    }
}