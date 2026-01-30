using NetAF.Logging.Events;
using NetAF.Logic;
using NetAF.Rendering.FrameBuilders;
using NetAF.Targets.Text;
using NetAF.Targets.WPF.Controls;
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

            EventBus.Subscribe<GameStarted>(x => Title = x.Game.Info.Name);

            GameConfiguration configuration = new(new TextAdapter(Layout.Terminal), FrameBuilderCollections.Text, Assets.Size.Dynamic);
            GameExecutor.Execute(ExampleGame.Create(configuration));
        }

        #endregion
    }
}