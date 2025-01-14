using NetAF.Assets;
using NetAF.Rendering.FrameBuilders;
using NetAF.Rendering.WPF;
using NetAF.Utilities;
using System.Windows.Media;

namespace NetAF.Rendering.Console.FrameBuilders
{
    /// <summary>
    /// Provides a builder of title frames.
    /// </summary>
    /// <param name="textBuilder">A builder to use for the text layout.</param>
    public sealed class TextTitleFrameBuilder(TextBuilder textBuilder) : ITitleFrameBuilder
    {
        #region Properties

        /// <summary>
        /// Get or set the background color.
        /// </summary>
        public Brush BackgroundColor { get; set; } = Brushes.Black;

        /// <summary>
        /// Get or set the title color.
        /// </summary>
        public Brush TitleColor { get; set; } = Brushes.White;

        /// <summary>
        /// Get or set the description color.
        /// </summary>
        public Brush DescriptionColor { get; set; } = Brushes.White;

        #endregion

        #region Implementation of ITitleFrameBuilder

        /// <summary>
        /// Build a frame.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="size">The size of the frame.</param>
        /// <returns>The frame.</returns>
        public IFrame Build(string title, string description, Size size)
        {
            textBuilder.Append(title);
            textBuilder.Append(StringUtilities.Newline.ToString());
            textBuilder.Append(description);

            return new TextFrame(textBuilder);
        }

        #endregion
    }
}
