namespace NetAF.Targets.WPF.Themes
{
    /// <summary>
    /// Provides a theme for a FlowDocument.
    /// </summary>
    /// <param name="heading1">The H1 theme.</param>
    /// <param name="heading2">The H2 theme.</param>
    /// <param name="heading3">The H3 theme.</param>
    /// <param name="heading4">The H4 theme.</param>
    /// <param name="paragraph">The paragraph theme.</param>
    /// <param name="monospace">The monospace theme.</param>
    public class FlowDocumentTheme(HeaderFontTheme heading1, HeaderFontTheme heading2, HeaderFontTheme heading3, HeaderFontTheme heading4, FontTheme paragraph, FontTheme monospace)
    {
        #region Properties

        /// <summary>
        /// Get or set the H1 theme.
        /// </summary>
        public HeaderFontTheme Heading1 { get; set; } = heading1;

        /// <summary>
        /// Get or set the H2 theme.
        /// </summary>
        public HeaderFontTheme Heading2 { get; set; } = heading2;

        /// <summary>
        /// Get or set the H3 theme.
        /// </summary>
        public HeaderFontTheme Heading3 { get; set; } = heading3;

        /// <summary>
        /// Get or set the H4 theme.
        /// </summary>
        public HeaderFontTheme Heading4 { get; set; } = heading4;

        /// <summary>
        /// Get or set the paragraph theme.
        /// </summary>
        public FontTheme Paragraph { get; set; } = paragraph;

        /// <summary>
        /// Get or set the monospace theme.
        /// </summary>
        public FontTheme Monospace { get; set; } = monospace;

        /// <summary>
        /// Get the largest font size from this theme.
        /// </summary>
        public double LargestFontSize => new FontTheme[] { Heading1, Heading2, Heading3, Heading4, Paragraph, Monospace }.Max(x => x.FontSize);

        #endregion
    }
}
