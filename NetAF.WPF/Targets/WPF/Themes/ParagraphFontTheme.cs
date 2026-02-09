using System.Windows;
using System.Windows.Media;

namespace NetAF.Targets.WPF.Themes
{
    /// <summary>
    /// Provides a theme for a paragraph font.
    /// </summary>
    /// <param name="foreground">The foreground brush.</param>
    /// <param name="background">The background brush.</param>
    /// <param name="fontSize">The font size.</param>
    /// <param name="fontFamily">The font family.</param>
    /// <param name="margin">The margin.</param>
    public class ParagraphFontTheme(Brush foreground, Brush background, double fontSize, FontFamily fontFamily, Thickness margin) : FontTheme(foreground, background, fontSize, fontFamily)
    {
        #region Properties

        /// <summary>
        /// Get or set the margin.
        /// </summary>
        public Thickness Margin { get; set; } = margin;

        #endregion
    }
}
