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
        #region Properties

        /// <summary>
        /// Get or set the WPF adapter.
        /// </summary>
        private WpfAdapter WPFAdapter { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            WPFAdapter = new WpfAdapter(new WebBrowserPresenter(OutputWebBrowser));
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
                var configuration = new WpfGameConfiguration(WPFAdapter, ExitMode.ReturnToTitleScreen);
                Game.Execute(ExampleGame.Create(configuration));
            });
        }

        #endregion

        #region EventHandlers

        private void InputTextBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
                return;

            WPFAdapter.InputReceived(InputTextBox.Text);
            InputTextBox.Clear();
        }

        #endregion
    }
}