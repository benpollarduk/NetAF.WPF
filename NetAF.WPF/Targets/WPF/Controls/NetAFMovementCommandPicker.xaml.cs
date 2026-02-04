using NetAF.Commands.Scene;
using NetAF.Logic;
using NetAF.Logic.Modes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetAF.Targets.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NetAFMovementCommandPicker.xaml
    /// </summary>
    public partial class NetAFMovementCommandPicker : UserControl
    {
        #region Properties

        /// <summary>
        /// Get or set the style to use for the north button. This is a dependency property.
        /// </summary>
        public Style NorthButtonStyle
        {
            get { return (Style)GetValue(NorthButtonStyleProperty); }
            set { SetValue(NorthButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the east button. This is a dependency property.
        /// </summary>
        public Style EastButtonStyle
        {
            get { return (Style)GetValue(EastButtonStyleProperty); }
            set { SetValue(EastButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the south button. This is a dependency property.
        /// </summary>
        public Style SouthButtonStyle
        {
            get { return (Style)GetValue(SouthButtonStyleProperty); }
            set { SetValue(SouthButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the west button. This is a dependency property.
        /// </summary>
        public Style WestButtonStyle
        {
            get { return (Style)GetValue(WestButtonStyleProperty); }
            set { SetValue(WestButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the up button. This is a dependency property.
        /// </summary>
        public Style UpButtonStyle
        {
            get { return (Style)GetValue(UpButtonStyleProperty); }
            set { SetValue(UpButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the down button. This is a dependency property.
        /// </summary>
        public Style DownButtonStyle
        {
            get { return (Style)GetValue(DownButtonStyleProperty); }
            set { SetValue(DownButtonStyleProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFMovementCommandPicker.NorthButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty NorthButtonStyleProperty = DependencyProperty.Register("NorthButtonStyle", typeof(Style), typeof(NetAFMovementCommandPicker));

        /// <summary>
        /// Identifies the NetAFMovementCommandPicker.EastButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty EastButtonStyleProperty = DependencyProperty.Register("EastButtonStyle", typeof(Style), typeof(NetAFMovementCommandPicker));

        /// <summary>
        /// Identifies the NetAFMovementCommandPicker.SouthButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty SouthButtonStyleProperty = DependencyProperty.Register("SouthButtonStyle", typeof(Style), typeof(NetAFMovementCommandPicker));

        /// <summary>
        /// Identifies the NetAFMovementCommandPicker.WestButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty WestButtonStyleProperty = DependencyProperty.Register("WestButtonStyle", typeof(Style), typeof(NetAFMovementCommandPicker));

        /// <summary>
        /// Identifies the NetAFMovementCommandPicker.UpButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty UpButtonStyleProperty = DependencyProperty.Register("UpButtonStyle", typeof(Style), typeof(NetAFMovementCommandPicker));

        /// <summary>
        /// Identifies the NetAFMovementCommandPicker.DownButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty DownButtonStyleProperty = DependencyProperty.Register("DownButtonStyle", typeof(Style), typeof(NetAFMovementCommandPicker));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFMovementCommandPicker class.
        /// </summary>
        public NetAFMovementCommandPicker()
        {
            InitializeComponent();

            NorthButtonStyle = TryFindResource("DefaultNorthButtonStyle") as Style ?? new Style();
            EastButtonStyle = TryFindResource("DefaultEastButtonStyle") as Style ?? new Style();
            SouthButtonStyle = TryFindResource("DefaultSouthButtonStyle") as Style ?? new Style();
            WestButtonStyle = TryFindResource("DefaultWestButtonStyle") as Style ?? new Style();
            UpButtonStyle = TryFindResource("DefaultUpButtonStyle") as Style ?? new Style();
            DownButtonStyle = TryFindResource("DefaultDownButtonStyle") as Style ?? new Style();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Update the control to match an executing game state.
        /// </summary>
        /// <param name="game">The game to update based on.</param>
        public void Update(Game game)
        {
            if (game?.Mode is not SceneMode)
            {
                NorthButton.IsEnabled = false;
                EastButton.IsEnabled = false;
                SouthButton.IsEnabled = false;
                WestButton.IsEnabled = false;
                UpButton.IsEnabled = false;
                DownButton.IsEnabled = false;
            }
            else
            {
                var availableCommands = game?.GetContextualCommands() ?? [];

                NorthButton.IsEnabled = availableCommands.Contains(Move.NorthCommandHelp);
                EastButton.IsEnabled = availableCommands.Contains(Move.EastCommandHelp);
                SouthButton.IsEnabled = availableCommands.Contains(Move.SouthCommandHelp);
                WestButton.IsEnabled = availableCommands.Contains(Move.WestCommandHelp);
                UpButton.IsEnabled = availableCommands.Contains(Move.UpCommandHelp);
                DownButton.IsEnabled = availableCommands.Contains(Move.DownCommandHelp);
            }
        }

        #endregion

        #region EventHandlers

        private void NorthSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Move.NorthCommandHelp.Command);
        }

        private void EastSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Move.EastCommandHelp.Command);
        }

        private void SouthSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Move.SouthCommandHelp.Command);
        }

        private void WestSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Move.WestCommandHelp.Command);
        }

        private void UpSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Move.UpCommandHelp.Command);
        }

        private void DownSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Move.DownCommandHelp.Command);
        }

        #endregion
    }
}
