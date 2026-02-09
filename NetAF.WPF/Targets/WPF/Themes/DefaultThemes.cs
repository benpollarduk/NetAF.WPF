using System.Windows;
using System.Windows.Media;

namespace NetAF.Targets.WPF.Themes
{
    /// <summary>
    /// Provides a store for default theme.
    /// </summary>
    public static class DefaultTheme
    {
        /// <summary>
        /// Get the font family.
        /// </summary>
        public static FontFamily FontFamily => new("Segoe UI");

        /// <summary>
        /// Get the foreground brush.
        /// </summary>
        public static Brush Foreground => new SolidColorBrush(Colors.LimeGreen);

        /// <summary>
        /// Get the background brush.
        /// </summary>
        public static Brush Background => new SolidColorBrush(Colors.Transparent);

        /// <summary>
        /// Get the theme for H1.
        /// </summary>
        public static HeaderFontTheme H1 => new(Foreground, Background, 22, FontFamily, FontWeights.Bold, FontStyles.Normal, new Thickness(0, 12, 0, 6));

        /// <summary>
        /// Get the theme for H2.
        /// </summary>
        public static HeaderFontTheme H2 => new(Foreground, Background, 20, FontFamily, FontWeights.SemiBold, FontStyles.Normal, new Thickness(0, 12, 0, 6));

        /// <summary>
        /// Get the default theme for H3.
        /// </summary>
        public static HeaderFontTheme H3 => new(Foreground, Background, 18, FontFamily, FontWeights.Normal, FontStyles.Normal, new Thickness(0, 12, 0, 6));

        /// <summary>
        /// Get the theme for H4.
        /// </summary>
        public static HeaderFontTheme H4 => new(Foreground, Background, 16, FontFamily, FontWeights.Normal, FontStyles.Normal, new Thickness(0, 12, 0, 6));

        /// <summary>
        /// Get the theme for paragraph.
        /// </summary>
        public static ParagraphFontTheme Paragraph => new(Foreground, Background, 14, FontFamily, new Thickness(2));

        /// <summary>
        /// Get the theme for monospace.
        /// </summary>
        public static FontTheme Monospace => new(Foreground, Background, 14, new FontFamily("Consolas"));

        /// <summary>
        /// Get the theme for flow documents.
        /// </summary>
        public static FlowDocumentTheme FlowDocument => new(H1, H2, H3, H4, Paragraph, Monospace);
    }
}
