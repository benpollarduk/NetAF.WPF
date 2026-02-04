using NetAF.Commands.Global;
using NetAF.Commands.RegionMap;
using NetAF.Logic;
using NetAF.Logic.Modes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetAF.Targets.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NetAFRegionMapCommandPicker.xaml
    /// </summary>
    public partial class NetAFRegionMapCommandPicker : UserControl
    {
        #region Properties

        /// <summary>
        /// Get or set the style to use for the north button. This is a dependency property.
        /// </summary>
        public Style PanNorthButtonStyle
        {
            get { return (Style)GetValue(PanNorthButtonStyleProperty); }
            set { SetValue(PanNorthButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the east button. This is a dependency property.
        /// </summary>
        public Style PanEastButtonStyle
        {
            get { return (Style)GetValue(PanEastButtonStyleProperty); }
            set { SetValue(PanEastButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the south button. This is a dependency property.
        /// </summary>
        public Style PanSouthButtonStyle
        {
            get { return (Style)GetValue(PanSouthButtonStyleProperty); }
            set { SetValue(PanSouthButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the west button. This is a dependency property.
        /// </summary>
        public Style PanWestButtonStyle
        {
            get { return (Style)GetValue(PanWestButtonStyleProperty); }
            set { SetValue(PanWestButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the up button. This is a dependency property.
        /// </summary>
        public Style PanUpButtonStyle
        {
            get { return (Style)GetValue(PanUpButtonStyleProperty); }
            set { SetValue(PanUpButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the down button. This is a dependency property.
        /// </summary>
        public Style PanDownButtonStyle
        {
            get { return (Style)GetValue(PanDownButtonStyleProperty); }
            set { SetValue(PanDownButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the zoom in button. This is a dependency property.
        /// </summary>
        public Style ZoomInButtonStyle
        {
            get { return (Style)GetValue(ZoomInButtonStyleProperty); }
            set { SetValue(ZoomInButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the zoom out button. This is a dependency property.
        /// </summary>
        public Style ZoomOutButtonStyle
        {
            get { return (Style)GetValue(ZoomOutButtonStyleProperty); }
            set { SetValue(ZoomOutButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the zoom reset button. This is a dependency property.
        /// </summary>
        public Style PanResetButtonStyle
        {
            get { return (Style)GetValue(PanResetButtonStyleProperty); }
            set { SetValue(PanResetButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the end button. This is a dependency property.
        /// </summary>
        public Style EndButtonStyle
        {
            get { return (Style)GetValue(EndButtonStyleProperty); }
            set { SetValue(EndButtonStyleProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFRegionMapCommandPicker.PanNorthButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty PanNorthButtonStyleProperty = DependencyProperty.Register("PanNorthButtonStyle", typeof(Style), typeof(NetAFRegionMapCommandPicker));

        /// <summary>
        /// Identifies the NetAFRegionMapCommandPicker.PanEastButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty PanEastButtonStyleProperty = DependencyProperty.Register("PanEastButtonStyle", typeof(Style), typeof(NetAFRegionMapCommandPicker));

        /// <summary>
        /// Identifies the NetAFRegionMapCommandPicker.PanSouthButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty PanSouthButtonStyleProperty = DependencyProperty.Register("PanSouthButtonStyle", typeof(Style), typeof(NetAFRegionMapCommandPicker));

        /// <summary>
        /// Identifies the NetAFRegionMapCommandPicker.PanWestButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty PanWestButtonStyleProperty = DependencyProperty.Register("PanWestButtonStyle", typeof(Style), typeof(NetAFRegionMapCommandPicker));

        /// <summary>
        /// Identifies the NetAFRegionMapCommandPicker.PanUpButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty PanUpButtonStyleProperty = DependencyProperty.Register("PanUpButtonStyle", typeof(Style), typeof(NetAFRegionMapCommandPicker));

        /// <summary>
        /// Identifies the NetAFRegionMapCommandPicker.PanDownButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty PanDownButtonStyleProperty = DependencyProperty.Register("PanDownButtonStyle", typeof(Style), typeof(NetAFRegionMapCommandPicker));

        /// <summary>
        /// Identifies the NetAFRegionMapCommandPicker.ZoomInButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty ZoomInButtonStyleProperty = DependencyProperty.Register("ZoomInButtonStyle", typeof(Style), typeof(NetAFRegionMapCommandPicker));

        /// <summary>
        /// Identifies the NetAFRegionMapCommandPicker.ZoomOutButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty ZoomOutButtonStyleProperty = DependencyProperty.Register("ZoomOutButtonStyle", typeof(Style), typeof(NetAFRegionMapCommandPicker));

        /// <summary>
        /// Identifies the NetAFRegionMapCommandPicker.PanResetButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty PanResetButtonStyleProperty = DependencyProperty.Register("PanResetButtonStyle", typeof(Style), typeof(NetAFRegionMapCommandPicker));

        /// <summary>
        /// Identifies the NetAFRegionMapCommandPicker.EndButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty EndButtonStyleProperty = DependencyProperty.Register("EndButtonStyle", typeof(Style), typeof(NetAFRegionMapCommandPicker));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFRegionMapCommandPicker class.
        /// </summary>
        public NetAFRegionMapCommandPicker()
        {
            InitializeComponent();

            PanNorthButtonStyle = TryFindResource("DefaultPanNorthButtonStyle") as Style ?? new Style();
            PanEastButtonStyle = TryFindResource("DefaultPanEastButtonStyle") as Style ?? new Style();
            PanSouthButtonStyle = TryFindResource("DefaultPanSouthButtonStyle") as Style ?? new Style();
            PanWestButtonStyle = TryFindResource("DefaultPanWestButtonStyle") as Style ?? new Style();
            PanUpButtonStyle = TryFindResource("DefaultPanUpButtonStyle") as Style ?? new Style();
            PanDownButtonStyle = TryFindResource("DefaultPanDownButtonStyle") as Style ?? new Style();
            ZoomInButtonStyle = TryFindResource("DefaultZoomInButtonStyle") as Style ?? new Style();
            ZoomOutButtonStyle = TryFindResource("DefaultZoomOutButtonStyle") as Style ?? new Style();
            PanResetButtonStyle = TryFindResource("DefaultPanResetButtonStyle") as Style ?? new Style();
            EndButtonStyle = TryFindResource("DefaultEndButtonStyle") as Style ?? new Style();
        }

        #endregion

        #region Methods

        /// <summary>
        /// PanUpdate the control to match an executing game state.
        /// </summary>
        /// <param name="game">The game to update based on.</param>
        public void Update(Game game)
        {
            if (game?.Mode is not RegionMapMode)
            {
                PanNorthButton.IsEnabled = false;
                PanEastButton.IsEnabled = false;
                PanSouthButton.IsEnabled = false;
                PanWestButton.IsEnabled = false;
                PanUpButton.IsEnabled = false;
                PanDownButton.IsEnabled = false;
                ZoomInButton.IsEnabled = false;
                ZoomOutButton.IsEnabled = false;
                PanResetButton.IsEnabled = false;
                EndButton.IsEnabled = false;
            }
            else
            {
                var availableCommands = game?.GetContextualCommands() ?? [];

                PanNorthButton.IsEnabled = availableCommands.Contains(Pan.NorthCommandHelp);
                PanEastButton.IsEnabled = availableCommands.Contains(Pan.EastCommandHelp);
                PanSouthButton.IsEnabled = availableCommands.Contains(Pan.SouthCommandHelp);
                PanWestButton.IsEnabled = availableCommands.Contains(Pan.WestCommandHelp);
                PanUpButton.IsEnabled = availableCommands.Contains(Pan.UpCommandHelp);
                PanDownButton.IsEnabled = availableCommands.Contains(Pan.DownCommandHelp);
                ZoomInButton.IsEnabled = availableCommands.Contains(ZoomIn.CommandHelp);
                ZoomOutButton.IsEnabled = availableCommands.Contains(ZoomOut.CommandHelp);
                PanResetButton.IsEnabled = availableCommands.Contains(PanReset.CommandHelp);
                EndButton.IsEnabled = true;
            }
        }

        #endregion

        #region EventHandlers

        private void PanNorthSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Pan.NorthCommandHelp.Command);
        }

        private void PanEastSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Pan.EastCommandHelp.Command);
        }

        private void PanSouthSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Pan.SouthCommandHelp.Command);
        }

        private void PanWestSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Pan.WestCommandHelp.Command);
        }

        private void PanUpSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Pan.UpCommandHelp.Command);
        }

        private void PanDownSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(Pan.DownCommandHelp.Command);
        }

        private void ZoomInSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(ZoomIn.CommandHelp.Command);
        }

        private void PanResetSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(PanReset.CommandHelp.Command);
        }

        private void ZoomOutSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(ZoomOut.CommandHelp.Command);
        }

        private void EndSelectedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update(End.CommandHelp.Command);
        }

        #endregion
    }
}
