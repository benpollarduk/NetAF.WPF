namespace NetAF.Targets.WPF.Themes
{
    /// <summary>
    /// Provides a theme for a FlowDocument.
    /// </summary>
    /// <param name="Heading1">The H1 theme.</param>
    /// <param name="Heading2">The H2 theme.</param>
    /// <param name="Heading3">The H3 theme.</param>
    /// <param name="Heading4">The H4 theme.</param>
    /// <param name="Paragraph">The paragraph theme.</param>
    /// <param name="Monospace">The monospace theme.</param>
    public record FlowDocumentTheme(HeaderFontTheme Heading1,
                                    HeaderFontTheme Heading2,
                                    HeaderFontTheme Heading3,
                                    HeaderFontTheme Heading4, 
                                    FontTheme Paragraph, 
                                    FontTheme Monospace)
    {
        #region Properties

        /// <summary>
        /// Get the largest font size from this theme.
        /// </summary>
        public double LargestFontSize => new FontTheme[] { Heading1, Heading2, Heading3, Heading4, Paragraph, Monospace }.Max(x => x.FontSize);

        #endregion
    }
}
