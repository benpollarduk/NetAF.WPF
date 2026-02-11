using NetAF.Events;
using NetAF.Logic;
using NetAF.Rendering;
using NetAF.Targets.WPF.Controls;
using System.Windows;
using System.Windows.Controls;

namespace NetAF.Targets.WPF.OutputLayouts
{
    /// <summary>
    /// Interaction logic for SplitMapLayout.xaml
    /// </summary>
    public partial class SplitMapLayout : UserControl, IUpdatable
    {
        #region Properties

        /// <summary>
        /// Get the terminal control.
        /// </summary>
        public NetAFMarkupTerminal Terminal => TerminalControl;

        /// <summary>
        /// Get or set the style to use for the terminal. This is a dependency property.
        /// </summary>
        public Style TerminalStyle
        {
            get { return (Style)GetValue(TerminalStyleProperty); }
            set { SetValue(TerminalStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the room map. This is a dependency property.
        /// </summary>
        public Style RoomMapStyle
        {
            get { return (Style)GetValue(RoomMapStyleProperty); }
            set { SetValue(RoomMapStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the spacing to use between sections. This is a dependency property.
        /// </summary>
        public double SectionSpacing
        {
            get { return (double)GetValue(SectionSpacingProperty); }
            set { SetValue(SectionSpacingProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the SplitMapLayout.TerminalStyle property.
        /// </summary>
        public static readonly DependencyProperty TerminalStyleProperty = DependencyProperty.Register("TerminalStyle", typeof(Style), typeof(SplitMapLayout));

        /// <summary>
        /// Identifies the SplitMapLayout.RoomMapStyle property.
        /// </summary>
        public static readonly DependencyProperty RoomMapStyleProperty = DependencyProperty.Register("RoomMapStyle", typeof(Style), typeof(SplitMapLayout));

        /// <summary>
        /// Identifies the SplitMapLayout.SectionSpacing property.
        /// </summary>
        public static readonly DependencyProperty SectionSpacingProperty = DependencyProperty.Register("SectionSpacing", typeof(double), typeof(SplitMapLayout), new PropertyMetadata(50d));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SplitMapLayout class.
        /// </summary>
        public SplitMapLayout()
        {
            InitializeComponent();

            // remove map from the scene frame builder
            FrameProperties.ShowMapInScenes = false;

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

        #endregion

        #region Implementation of IUpdatable

        /// <summary>
        /// Update the component.
        /// </summary>
        /// <param name="game">The game to update based on.</param>
        public void Update(Game game)
        {
            MapControl.Update(game);
        }

        #endregion
    }
}
