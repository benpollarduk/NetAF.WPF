using NetAF.Rendering;
using System.Windows.Controls;

namespace NetAF.Targets.WPF.Layouts
{
    /// <summary>
    /// Interaction logic for PromptAndTerminalLayout.xaml
    /// </summary>
    public partial class PromptAndTerminalLayout : UserControl, INetAFLayout
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PromptAndTerminalLayout class.
        /// </summary>
        public PromptAndTerminalLayout()
        {
            InitializeComponent();
        }

        #endregion

        #region Implementation of INetAFLayout

        /// <summary>
        /// Get the presenter.
        /// </summary>
        public IFramePresenter Presenter => Terminal;

        #endregion
    }
}
