using System.Windows;
using System.Windows.Media;

namespace NetAF.Targets.WPF.Themes
{
    /// <summary>
    /// Provides a theme for a font.
    /// </summary>
    /// <param name="Foreground">The foreground brush.</param>
    /// <param name="Background">The background brush.</param>
    /// <param name="FontSize">The font size.</param>
    /// <param name="FontFamily">The font family.</param>
    /// <param name="FontWeight">The font weight.</param>
    /// <param name="FontStyle">The font style.</param>
    public record HeaderFontTheme(Brush Foreground, Brush Background, double FontSize, FontFamily FontFamily, FontWeight FontWeight, FontStyle FontStyle) : FontTheme(Foreground, Background, FontSize, FontFamily);
}
