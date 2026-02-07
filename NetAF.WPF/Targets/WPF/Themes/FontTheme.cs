using System.Windows.Media;

namespace NetAF.Targets.WPF.Themes
{
    /// <summary>
    /// Provides a theme for a font.
    /// </summary>
    /// <param name="foreground">The foreground brush.</param>
    /// <param name="background">The background brush.</param>
    /// <param name="fontSize">The font size.</param>
    /// <param name="fontFamily">The font family.</param>
    public class FontTheme(Brush foreground, Brush background, double fontSize, FontFamily fontFamily)
    {
        #region Properties

        /// <summary>
        /// Get or set the foreground brush.
        /// </summary>
        public Brush Foreground { get; set; } = foreground;

        /// <summary>
        /// Get or set the background brush.
        /// </summary>
        public Brush Background { get; set; } = background;

        /// <summary>
        /// Get or set the font size.
        /// </summary>
        public double FontSize { get; set; } = fontSize;

        /// <summary>
        /// Get or set the font family.
        /// </summary>
        public FontFamily FontFamily { get; set; } = fontFamily;

        #endregion
    }
}
