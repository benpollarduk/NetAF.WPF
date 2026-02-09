using System.Windows;
using System.Windows.Media;

namespace NetAF.Targets.WPF.Themes
{
    /// <summary>
    /// Provides a theme for a header font.
    /// </summary>
    /// <param name="foreground">The foreground brush.</param>
    /// <param name="background">The background brush.</param>
    /// <param name="fontSize">The font size.</param>
    /// <param name="fontFamily">The font family.</param>
    /// <param name="fontWeight">The font weight.</param>
    /// <param name="fontStyle">The font style.</param>
    /// <param name="margin">The margin.</param>
    public class HeaderFontTheme(Brush foreground, Brush background, double fontSize, FontFamily fontFamily, FontWeight fontWeight, FontStyle fontStyle, Thickness margin) : FontTheme(foreground, background, fontSize, fontFamily)
    {
        #region Properties

        /// <summary>
        /// Get or set the font weight.
        /// </summary>
        public FontWeight FontWeight { get; set; } = fontWeight;

        /// <summary>
        /// Get or set the font style.
        /// </summary>
        public FontStyle FontStyle { get; set; } = fontStyle;

        /// <summary>
        /// Get or set the margin.
        /// </summary>
        public Thickness Margin { get; set; } = margin;

        #endregion
    }
}
