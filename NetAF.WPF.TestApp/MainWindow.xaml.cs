using NetAF.Logic;
using NetAF.Targets.WPF;
using System.Windows;

namespace NetAF.WPF.TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            StartGame();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Start the game.
        /// </summary>
        private void StartGame()
        {
            Task.Run(() =>
            {
                var configuration = new WpfGameConfiguration(NetAFControl.Adapter, ExitMode.ReturnToTitleScreen);
                Game.Execute(ExampleGame.Create(configuration));
            });
        }

        #endregion
    }
}