using NetAF.Targets.Markup;
using NetAF.Targets.Markup.Model;
using NetAF.Targets.Markup.Model.Nodes;
using NetAF.Targets.WPF.Themes;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace NetAF.Targets.WPF.Classes
{
    /// <summary>
    /// Provides a renderer for rendering FlowDocuments from markup.
    /// </summary>
    internal static class FlowDocumentModelRenderer
    {
        #region StaticMethods

        /// <summary>
        /// Render a FlowDocument from markup.
        /// </summary>
        /// <param name="markup">The markup.</param>
        /// <param name="theme">The theme.</param>
        /// <returns>The flow document.</returns>
        public static FlowDocument Render(string markup, FlowDocumentTheme theme)
        {
            if (!ModelParser.TryParse(markup, out DocumentNode? doc))
            {
                Debug.WriteLine($"Could not render markup: {markup}");
                return new FlowDocument();
            }

            return Render(doc, theme);
        }

        /// <summary>
        /// Render a FlowDocument from a markup model DocumentNode.
        /// </summary>
        /// <param name="document">The document node.</param>
        /// <param name="theme">The theme.</param>
        /// <returns>The flow document.</returns>
        public static FlowDocument Render(DocumentNode document, FlowDocumentTheme theme)
        {
            var flowDoc = new FlowDocument();

            foreach (var block in document.Blocks)
                flowDoc.Blocks.Add(RenderBlock(block, theme));

            return flowDoc;
        }

        private static Block RenderBlock(IBlockNode block, FlowDocumentTheme theme)
        {
            return block switch
            {
                HeadingNode h => RenderHeading(h, theme),
                ParagraphNode p => RenderParagraph(p, theme),
                _ => new Paragraph()
            };
        }

        private static Paragraph RenderHeading(HeadingNode heading, FlowDocumentTheme theme)
        {
            var p = new Paragraph(new Run(heading.Text));

            var fontTheme = heading.Level switch
            {
                HeadingLevel.H1 => theme.Heading1,
                HeadingLevel.H2 => theme.Heading2,
                HeadingLevel.H3 => theme.Heading3,
                HeadingLevel.H4 => theme.Heading4,
                _ => throw new NotImplementedException()
            };

            p.FontSize = fontTheme.FontSize;
            p.FontFamily = fontTheme.FontFamily;
            p.FontWeight = fontTheme.FontWeight;
            p.FontStyle = fontTheme.FontStyle;
            p.Foreground = fontTheme.Foreground;
            p.Background = fontTheme.Background;

            p.Margin = new Thickness(0, 12, 0, 6);

            return p;
        }

        private static Paragraph RenderParagraph(ParagraphNode p, FlowDocumentTheme theme)
        {
            var para = new Paragraph
            {
                Margin = new Thickness(4),
                FontFamily = theme.Paragraph.FontFamily,
                FontSize = theme.Paragraph.FontSize,
                Foreground = theme.Paragraph.Foreground,
                Background = theme.Paragraph.Background
            };

            foreach (var inline in p.Inlines)
                para.Inlines.Add(RenderInline(inline, theme));

            return para;
        }

        private static Inline RenderInline(IInlineNode inline, FlowDocumentTheme theme)
        {
            return inline switch
            {
                TextNode t => new Run(t.Text),
                StyleSpanNode s => RenderStyleSpan(s, theme),
                _ => new Run()
            };
        }

        private static Span RenderStyleSpan(StyleSpanNode s, FlowDocumentTheme theme)
        {
            var span = new Span();

            ApplyStyle(span, s.Style, theme);

            foreach (var child in s.Inlines)
                span.Inlines.Add(RenderInline(child, theme));

            return span;
        }

        private static void ApplyStyle(Span span, TextStyle style, FlowDocumentTheme theme)
        {
            if (style.Monospace)
            {
                span.FontFamily = theme.Monospace.FontFamily;
                span.FontSize = theme.Monospace.FontSize;
                span.Foreground = theme.Monospace.Foreground;
                span.Background = theme.Monospace.Background;
            }
            else
            {
                span.FontFamily = theme.Paragraph.FontFamily;
                span.FontSize = theme.Paragraph.FontSize;
                span.Foreground = theme.Paragraph.Foreground;
                span.Background = theme.Paragraph.Background;
            }

            if (style.Foreground != null)
                span.Foreground = BrushFromColor(style.Foreground);

            if (style.Background != null)
                span.Background = BrushFromColor(style.Background);

            if (style.Bold)
                span.FontWeight = FontWeights.Bold;

            if (style.Italic)
                span.FontStyle = FontStyles.Italic;

            var decorations = new TextDecorationCollection();

            if (style.Strikethrough)
                decorations.Add(TextDecorations.Strikethrough[0]);

            if (style.Underline)
                decorations.Add(TextDecorations.Underline[0]);

            span.TextDecorations = decorations;
        }

        private static SolidColorBrush BrushFromColor(Markup.Color color)
        {
            return new SolidColorBrush(System.Windows.Media.Color.FromRgb(color.Red, color.Green, color.Blue));
        }

        #endregion
    }
}
