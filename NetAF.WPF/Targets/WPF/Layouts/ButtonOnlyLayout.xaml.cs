using NetAF.Logging.Events;
using System.Windows.Controls;

namespace NetAF.Targets.WPF.Layouts
{
    /// <summary>
    /// Interaction logic for ButtonOnlyLayout.xaml
    /// </summary>
    public partial class ButtonOnlyLayout : UserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ButtonOnlyLayout class.
        /// </summary>
        public ButtonOnlyLayout()
        {
            InitializeComponent();
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

        #region EventHandlers

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            EventBus.Subscribe<GameUpdated>(GameUpdated);
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            EventBus.Unsubscribe<GameUpdated>(GameUpdated);
        }

        #endregion
    }
}
