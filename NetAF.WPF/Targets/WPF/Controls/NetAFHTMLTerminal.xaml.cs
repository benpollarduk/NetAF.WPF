using NetAF.Rendering;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NetAF.Targets.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NetAFHtmlTerminal.xaml
    /// </summary>
    public partial class NetAFHtmlTerminal : UserControl, IFramePresenter
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFHtmlTerminal class.
        /// </summary>
        public NetAFHtmlTerminal()
        {
            InitializeComponent();
        }

        #endregion

        #region StaticMethods

        private static string FormatFrame(string frame, Color background, Color foreground, FontFamily fontFamily, double fontSize, Thickness padding)
        {
            // convert WPF ARGB to CSS Hex (RRGGBB)
            string bgHex = $"#{background.R:X2}{background.G:X2}{background.B:X2}";
            string fgHex = $"#{foreground.R:X2}{foreground.G:X2}{foreground.B:X2}";

            return $@"
                    <html>
                    <head>
                        <style>
                            body {{ 
                                background-color: {bgHex}; 
                                color: {fgHex};
                                overflow: auto;
                                padding: {padding.Top}px {padding.Right}px {padding.Bottom}px {padding.Left}px;
                            }}
                            pre {{
                                font-family: '{fontFamily.Source}', 'Courier New', monospace;
                                white-space: pre;
                                font-size: {fontSize}px;
                            }}
                        </style>
                    </head>
                    <body>
                        <pre>{frame}</pre>
                    </body>
                    </html>";
        }

        #endregion

        #region Implementation of IFramePresenter

        /// <summary>
        /// Present a frame.
        /// </summary>
        /// <param name="frame">The frame to write, as a string.</param>
        public void Present(string frame)
        {
            var formattedFrame = FormatFrame(frame, Colors.Black, Colors.White, FontFamily, FontSize, Padding);
            WebBrowser.NavigateToString(formattedFrame);
        }

        /// <summary>
        /// Get the size of the presentable area.
        /// </summary>
        /// <returns>The size.</returns>
        public Assets.Size GetPresentableSize()
        {
            // use formatted text to get a standard character size in pixels using M as a reference character
            var formattedText = new FormattedText(
                "M",
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(FontFamily, FontStyle, FontWeight, FontStretch),
                FontSize,
                Brushes.Black,
                VisualTreeHelper.GetDpi(WebBrowser).PixelsPerDip);

            var characterWidth = formattedText.Width;
            var characterHeight = formattedText.Height;
            var availableWidth = WebBrowser.ActualWidth - (Padding.Left + Padding.Right);
            var availableHeight = WebBrowser.ActualHeight - (Padding.Top + Padding.Bottom);
            var columns = (int)Math.Floor(availableWidth / characterWidth);
            var rows = (int)Math.Floor(availableHeight / characterHeight);

            return new Assets.Size(columns, rows);
        }

        #endregion
    }
}
