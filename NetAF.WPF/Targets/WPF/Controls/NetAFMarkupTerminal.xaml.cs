using NetAF.Rendering;
using NetAF.Targets.WPF.Classes;
using NetAF.Targets.WPF.Themes;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NetAF.Targets.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NetAFMarkupTerminal.xaml
    /// </summary>
    public partial class NetAFMarkupTerminal : UserControl, IFramePresenter
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

        /// <summary>
        /// Get or set the theme for FlowDocuments. This is a dependency property.
        /// </summary>
        public FlowDocumentTheme FlowDocumentTheme
        {
            get { return (FlowDocumentTheme)GetValue(FlowDocumentThemeProperty); }
            set { SetValue(FlowDocumentThemeProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFMarkupTerminal.UseTransitions property.
        /// </summary>
        public static readonly DependencyProperty UseTransitionsProperty = DependencyProperty.Register("UseTransitions", typeof(bool), typeof(NetAFMarkupTerminal), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFMarkupTerminal.TransitionStrength property.
        /// </summary>
        public static readonly DependencyProperty TransitionStrengthProperty = DependencyProperty.Register("TransitionStrength", typeof(double), typeof(NetAFMarkupTerminal), new PropertyMetadata(0.1d));

        /// <summary>
        /// Identifies the NetAFMarkupTerminal.TransitionDuration property.
        /// </summary>
        public static readonly DependencyProperty TransitionDurationProperty = DependencyProperty.Register("TransitionDuration", typeof(Duration), typeof(NetAFMarkupTerminal), new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(200))));

        /// <summary>
        /// Identifies the NetAFMarkupTerminal.FlowDocumentTheme property.
        /// </summary>
        public static readonly DependencyProperty FlowDocumentThemeProperty = DependencyProperty.Register("FlowDocumentTheme", typeof(FlowDocumentTheme), typeof(NetAFMarkupTerminal), new PropertyMetadata(DefaultTheme.FlowDocument));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFMarkupTerminal class.
        /// </summary>
        public NetAFMarkupTerminal()
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
            var flowDocument = FlowDocumentModelRenderer.Render(frame, FlowDocumentTheme);

            if (UseTransitions)
            {
                var transitionIn = FindResource("TransitionIn") as Storyboard;
                var transitionOut = FindResource("TransitionOut") as Storyboard;

                if (Viewer.Document == null || transitionOut == null)
                {
                    Viewer.Document = flowDocument;
                    transitionIn?.Begin();
                }
                else
                {
                    transitionOut.Completed += (s, e) =>
                    {
                        Viewer.Document = flowDocument;
                        transitionIn?.Begin();
                    };
                    transitionOut.Begin();
                }
            }
            else
            {
                Viewer.Document = flowDocument;
            }
        }

        /// <summary>
        /// Get the size of the presentable area.
        /// </summary>
        /// <returns>The size.</returns>
        public Assets.Size GetPresentableSize()
        {
            // use formatted text to get a standard character size in pixels using M as a reference character
            // because of the rich content it is impossible to say exactly how much presentable space there is...
            var formattedText = new FormattedText(
                "M",
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(FlowDocumentTheme.Heading1.FontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                FlowDocumentTheme.LargestFontSize,
                Brushes.Black,
                VisualTreeHelper.GetDpi(Viewer).PixelsPerDip);

            var characterWidth = formattedText.Width;
            var characterHeight = formattedText.Height;
            var availableWidth = Viewer.ActualWidth - (Viewer.Padding.Left + Viewer.Padding.Right);
            var availableHeight = Viewer.ActualHeight - (Viewer.Padding.Top + Viewer.Padding.Bottom);
            var columns = (int)Math.Floor(availableWidth / characterWidth);
            var rows = (int)Math.Floor(availableHeight / characterHeight);

            return new Assets.Size(columns, rows);
        }

        #endregion
    }
}
