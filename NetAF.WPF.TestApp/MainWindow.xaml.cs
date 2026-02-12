using NetAF.Events;
using NetAF.Logic;
using NetAF.Rendering.FrameBuilders;
using NetAF.Targets.Markup;
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

            var configuration = new GameConfiguration(new MarkupAdapter(Terminal), FrameBuilderCollections.Markup, Assets.Size.Dynamic);
            GameExecutor.Execute(ExampleGame.Create(configuration));
        }

        #endregion
    }
}