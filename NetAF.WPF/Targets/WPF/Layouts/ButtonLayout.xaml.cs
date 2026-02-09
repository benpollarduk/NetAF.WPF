using NetAF.Events;
using NetAF.Logic;
using NetAF.Logic.Modes;
using System.Windows;
using System.Windows.Controls;

namespace NetAF.Targets.WPF.Layouts
{
    /// <summary>
    /// Interaction logic for ButtonLayout.xaml
    /// </summary>
    public partial class ButtonLayout : UserControl
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
        /// Get or set the style to use for the region map command picker. This is a dependency property.
        /// </summary>
        public Style RegionMapCommandPickerStyle
        {
            get { return (Style)GetValue(RegionMapCommandPickerStyleProperty); }
            set { SetValue(RegionMapCommandPickerStyleProperty, value); }
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
        /// Identifies the ButtonLayout.MovementCommandPickerStyle property.
        /// </summary>
        public static readonly DependencyProperty MovementCommandPickerStyleProperty = DependencyProperty.Register("MovementCommandPickerStyle", typeof(Style), typeof(ButtonLayout));

        /// <summary>
        /// Identifies the ButtonLayout.RegionMapCommandPickerStyle property.
        /// </summary>
        public static readonly DependencyProperty RegionMapCommandPickerStyleProperty = DependencyProperty.Register("RegionMapCommandPickerStyle", typeof(Style), typeof(ButtonLayout));

        /// <summary>
        /// Identifies the ButtonLayout.GeneralCommandPickerStyle property.
        /// </summary>
        public static readonly DependencyProperty GeneralCommandPickerStyleProperty = DependencyProperty.Register("GeneralCommandPickerStyle", typeof(Style), typeof(ButtonLayout));

        /// <summary>
        /// Identifies the ButtonLayout.SceneCommandPickerStyle property.
        /// </summary>
        public static readonly DependencyProperty SceneCommandPickerStyleProperty = DependencyProperty.Register("SceneCommandPickerStyle", typeof(Style), typeof(ButtonLayout));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ButtonLayout class.
        /// </summary>
        public ButtonLayout()
        {
            InitializeComponent();

            EventBus.Subscribe<GameStarted>(GameStarted);
            EventBus.Subscribe<GameUpdated>(GameUpdated);
        }

        #endregion

        #region Methods

        private void GameStarted(GameStarted update)
        {
            Update(update.Game);
        }

        private void GameUpdated(GameUpdated update)
        {
            Update(update.Game);
        }

        private void Update(Game game)
        {
            GeneralCommandPicker.Update(game);
            SceneCommandPicker.Update(game);
            MovementCommandPicker.Update(game);
            RegionMapCommandPicker.Update(game);

            var inMapMode = game.Mode is RegionMapMode;

            MovementCommandPicker.Visibility = inMapMode ? Visibility.Collapsed : Visibility.Visible;
            RegionMapCommandPicker.Visibility = inMapMode ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion
    }
}
