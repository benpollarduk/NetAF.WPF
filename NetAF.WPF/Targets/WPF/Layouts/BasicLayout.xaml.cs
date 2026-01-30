using NetAF.Logging.Events;
using NetAF.Targets.WPF.Controls;
using System.Windows.Controls;

namespace NetAF.Targets.WPF.Layouts
{
    /// <summary>
    /// Interaction logic for BasicLayout.xaml
    /// </summary>
    public partial class BasicLayout : UserControl
    {
        #region Properties

        /// <summary>
        /// Get the terminal.
        /// </summary>
        public NetAFTerminal Terminal => terminal;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BasicLayout class.
        /// </summary>
        public BasicLayout()
        {
            InitializeComponent();

            EventBus.Subscribe<GameUpdated>(GameUpdated);
        }

        #endregion

        #region Methods

        private void GameUpdated(GameUpdated update)
        {
            generalCommandPicker.Update(update.Game);
            sceneCommandPicker.Update(update.Game);
            movementCommandPicker.Update(update.Game);
        }

        #endregion
    }
}
