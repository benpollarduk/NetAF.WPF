using NetAF.Logging.Events;
using NetAF.Targets.WPF.Controls;
using System.Windows;
using System.Windows.Controls;

namespace NetAF.Targets.WPF.Layouts
{
    /// <summary>
    /// Interaction logic for ButtonOnlyLayout.xaml
    /// </summary>
    public partial class ButtonOnlyLayout : UserControl
    {
        #region Properties

        /// <summary>
        /// Get or set the style to use for the movement command picker. This is a dependency property.
        /// </summary>
        public Style MovementCommandPickerStyle
        {
            get { return (Style)GetValue(MovementCommandPickerStyleProperty); }
            set { SetValue(MovementCommandPickerStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the general command picker. This is a dependency property.
        /// </summary>
        public Style GeneralCommandPickerStyle
        {
            get { return (Style)GetValue(GeneralCommandPickerStyleProperty); }
            set { SetValue(GeneralCommandPickerStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the scene command picker. This is a dependency property.
        /// </summary>
        public Style SceneCommandPickerStyle
        {
            get { return (Style)GetValue(SceneCommandPickerStyleProperty); }
            set { SetValue(SceneCommandPickerStyleProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the ButtonOnlyLayout.MovementCommandPickerStyle property.
        /// </summary>
        public static readonly DependencyProperty MovementCommandPickerStyleProperty = DependencyProperty.Register("MovementCommandPickerStyle", typeof(Style), typeof(ButtonOnlyLayout));

        /// <summary>
        /// Identifies the ButtonOnlyLayout.GeneralCommandPickerStyle property.
        /// </summary>
        public static readonly DependencyProperty GeneralCommandPickerStyleProperty = DependencyProperty.Register("GeneralCommandPickerStyle", typeof(Style), typeof(ButtonOnlyLayout));

        /// <summary>
        /// Identifies the ButtonOnlyLayout.SceneCommandPickerStyle property.
        /// </summary>
        public static readonly DependencyProperty SceneCommandPickerStyleProperty = DependencyProperty.Register("SceneCommandPickerStyle", typeof(Style), typeof(ButtonOnlyLayout));

        #endregion

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
