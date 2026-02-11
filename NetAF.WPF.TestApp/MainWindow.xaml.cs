using NetAF.Assets.Locations;
using NetAF.Events;
using NetAF.Logic;
using NetAF.Rendering;
using NetAF.Rendering.FrameBuilders;
using NetAF.Targets.Markup;
using NetAF.Targets.Markup.Rendering;
using NetAF.Targets.Markup.Rendering.FrameBuilders;
using System.Windows;
using System.Windows.Input;

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

            // remove map from the scene frame builder
            var frameBuilders = FrameBuilderCollections.Markup;
            frameBuilders.SetFrameBuilder(new MarkupSceneFrameBuilder(new MarkupBuilder(), null));

            var configuration = new GameConfiguration(new MarkupAdapter(OutputLayout.Terminal), frameBuilders, Assets.Size.Dynamic);
            GameExecutor.Execute(ExampleGame.Create(configuration));
        }

        #endregion
    }
}