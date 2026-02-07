using NetAF.Rendering;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NetAF.Targets.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NetAFTextTerminal.xaml
    /// </summary>
    public partial class NetAFTextTerminal : UserControl, IFramePresenter
    {
        #region Properties

        /// <summary>
        /// Get or set if transitions are used. This is a dependency property.
        /// </summary>
        public bool UseTransitions
        {
            get { return (bool)GetValue(UseTransitionsProperty); }
            set { SetValue(UseTransitionsProperty, value); }
        }

        /// <summary>
        /// Get or set the strength of the transitions. Values between 0-1 are recommended. This is a dependency property.
        /// </summary>
        public double TransitionStrength
        {
            get { return (double)GetValue(TransitionStrengthProperty); }
            set { SetValue(TransitionStrengthProperty, value); }
        }

        /// <summary>
        /// Get or set the duration of the transitions. This is a dependency property.
        /// </summary>
        public Duration TransitionDuration
        {
            get { return (Duration)GetValue(TransitionDurationProperty); }
            set { SetValue(TransitionDurationProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFTextTerminal.UseTransitions property.
        /// </summary>
        public static readonly DependencyProperty UseTransitionsProperty = DependencyProperty.Register("UseTransitions", typeof(bool), typeof(NetAFTextTerminal), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFTextTerminal.TransitionStrength property.
        /// </summary>
        public static readonly DependencyProperty TransitionStrengthProperty = DependencyProperty.Register("TransitionStrength", typeof(double), typeof(NetAFTextTerminal), new PropertyMetadata(0.1d));

        /// <summary>
        /// Identifies the NetAFTextTerminal.TransitionDuration property.
        /// </summary>
        public static readonly DependencyProperty TransitionDurationProperty = DependencyProperty.Register("TransitionDuration", typeof(Duration), typeof(NetAFTextTerminal), new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(200))));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFTextTerminal class.
        /// </summary>
        public NetAFTextTerminal()
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
            if (UseTransitions)
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
            else
            {
                TextBlock.Text = frame;
            }
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

            return new Assets.Size(columns, rows);
        }

        #endregion
    }
}
