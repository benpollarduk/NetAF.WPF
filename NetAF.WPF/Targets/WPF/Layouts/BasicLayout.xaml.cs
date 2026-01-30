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

        #region EventHandlers

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            prompt.Focus();
            EventBus.Subscribe<GameUpdated>(GameUpdated);
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            EventBus.Unsubscribe<GameUpdated>(GameUpdated);
        }

        #endregion
    }
}
