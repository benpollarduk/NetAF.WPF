using NetAF.Rendering;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NetAF.Targets.WPF
{
    /// <summary>
    /// Interaction logic for NetAFTerminal.xaml
    /// </summary>
    public partial class NetAFTerminal : UserControl, IFramePresenter
    {
        #region Properties

        /// <summary>
        /// Get or set the styling to apply to the terminal. The base type to style is TextBlock. This is a dependency property.
        /// </summary>
        public Style TerminalStyle
        {
            get { return (Style)GetValue(TerminalStyleProperty); }
            set { SetValue(TerminalStyleProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFControl.TerminalStyle property.
        /// </summary>
        public static readonly DependencyProperty TerminalStyleProperty = DependencyProperty.Register(nameof(TerminalStyle), typeof(Style), typeof(NetAFTerminal));

        #endregion

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

        #endregion
    }
}
