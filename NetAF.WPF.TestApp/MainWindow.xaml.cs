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
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            GameConfiguration configuration = new(new TextAdapter(NetAFControl), FrameBuilderCollections.Console, new(80, 50));
            GameExecutor.Execute(ExampleGame.Create(configuration));
        }

        #endregion
    }
}