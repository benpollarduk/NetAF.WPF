using NetAF.Rendering;
using System.Windows.Controls;
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

        #endregion
    }
}
