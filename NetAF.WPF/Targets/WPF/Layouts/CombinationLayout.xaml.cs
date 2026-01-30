using NetAF.Logging.Events;
using NetAF.Rendering;
using System.Windows.Controls;

namespace NetAF.Targets.WPF.Layouts
{
    /// <summary>
    /// Interaction logic for CombinationLayout.xaml
    /// </summary>
    public partial class CombinationLayout : UserControl, INetAFLayout
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the CombinationLayout class.
        /// </summary>
        public CombinationLayout()
        {
            InitializeComponent();

            EventBus.Subscribe<GameUpdated>(GameUpdated);
        }

        #endregion

        #region Methods

        private void GameUpdated(GameUpdated update)
        {
            GeneralCommandPicker.Update(update.Game);
            SceneCommandPicker.Update(update.Game);
            MovementCommandPicker.Update(update.Game);
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
