using NetAF.Logic;
using NetAF.Rendering.FrameBuilders;
using NetAF.Targets.Text;
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
        /// </summary>5
        public MainWindow()
        {
            InitializeComponent();

            GameConfiguration configuration = new(new TextAdapter(NetAFTerminal), FrameBuilderCollections.Text, Assets.Size.Dynamic);
            GameExecutor.Execute(ExampleGame.Create(configuration));
        }

        #endregion
    }
}