using NetAF.Assets;
using NetAF.Rendering;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NetAF.Targets.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for NetAFTerminal.xaml
    /// </summary>
    public partial class NetAFTerminal : UserControl, IFramePresenter
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFTerminal class.
        /// </summary>
        public NetAFTerminal()
        {
            InitializeComponent();
        }

        #endregion

        #region Implementation of IFramePresenter

        /// <summary>
        /// Present a frame.
        /// </summary>
        /// <param name="frame">The frame to write, as a string.</param>
        public void Present(string frame)
        {
            var transitionIn = FindResource("TransitionIn") as Storyboard;
            var transitionOut = FindResource("TransitionOut") as Storyboard;

            if (string.IsNullOrEmpty(TextBlock.Text) || transitionOut == null)
            {
                TextBlock.Text = frame;
                transitionIn?.Begin();
            }
            else
            {
                transitionOut.Completed += (s, e) =>
                {
                    TextBlock.Text = frame;
                    transitionIn?.Begin();
                };
                transitionOut.Begin();
            }
        }

        /// <summary>
        /// Get the size of the presentable area.
        /// </summary>
        /// <returns>The size.</returns>
        public Size GetPresentableSize()
        {
            // use formatted text to get a standard character size in pixels using M as a reference character
            var formattedText = new FormattedText(
                "M",
                CultureInfo.CurrentCulture,
                System.Windows.FlowDirection.LeftToRight,
                new Typeface(TextBlock.FontFamily, TextBlock.FontStyle, TextBlock.FontWeight, TextBlock.FontStretch),
                TextBlock.FontSize,
                Brushes.Black,
                VisualTreeHelper.GetDpi(TextBlock).PixelsPerDip);

            var characterWidth = formattedText.Width;
            var characterHeight = formattedText.Height;
            var availableWidth = TextBlock.ActualWidth - (TextBlock.Padding.Left + TextBlock.Padding.Right);
            var availableHeight = TextBlock.ActualHeight - (TextBlock.Padding.Top + TextBlock.Padding.Bottom);
            var columns = (int)Math.Floor(availableWidth / characterWidth);
            var rows = (int)Math.Floor(availableHeight / characterHeight);

            return new Size(columns, rows);
        }

        #endregion
    }
}
