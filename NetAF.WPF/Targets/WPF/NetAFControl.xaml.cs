using NetAF.Rendering;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetAF.Targets.WPF
{
    /// <summary>
    /// Interaction logic for NetAFControl.xaml
    /// </summary>
    public partial class NetAFControl : UserControl, IFramePresenter
    {
        #region Properties

        /// <summary>
        /// Get or set the adapter.
        /// </summary>
        public WpfAdapter Adapter { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFControl class.
        /// </summary>
        public NetAFControl()
        {
            InitializeComponent();

            Adapter = new WpfAdapter(this);
        }

        #endregion

        #region EventHandlers

        private void InputTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            Adapter.InputReceived(InputTextBox.Text);
            InputTextBox.Clear();
        }

        #endregion

        #region Implementation of IFramePresenter

        /// <summary>
        /// Present a frame.
        /// </summary>
        /// <param name="frame">The frame to write, as a string.</param>
        public void Present(string frame)
        {
            Browser.NavigateToString(frame);
        }


        #endregion
    }
}
