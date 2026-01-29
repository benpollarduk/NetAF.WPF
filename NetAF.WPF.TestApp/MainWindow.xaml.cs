using NetAF.Logic;
using NetAF.Rendering.FrameBuilders;
using NetAF.Targets.Text;
using NetAF.Targets.WPF;
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

            NetAFPrompt.Focus();
            
            var adapter = new WPFAdapter(NetAFTerminal);
            adapter.FrameRendered += (_, _) =>
            {
                NetAFCommandPicker.Update(GameExecutor.ExecutingGame);
                NetAFMovementCommandPicker.Update(GameExecutor.ExecutingGame);
            };
            GameConfiguration configuration = new(adapter, FrameBuilderCollections.Text, Assets.Size.Dynamic);
            GameExecutor.Execute(ExampleGame.Create(configuration));
        }

        #endregion
    }
}