using NetAF.Events;
using NetAF.Logic;
using NetAF.Rendering.FrameBuilders;
using NetAF.Targets.Markup;
using NetAF.Targets.WPF.Layouts;
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

        #region Methods

        private void SetInputControl(UIElement inputControl)
        {
            if (!IsInitialized)
                return;

            InputControl.Content = inputControl;
        }

        #endregion

        #region EventHandlers

        private void PromptRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SetInputControl(new PromptOnlyLayout());
        }

        private void ButtonsRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SetInputControl(new ButtonOnlyLayout());
        }

        private void CombinationRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SetInputControl(new CombinationLayout());
        }

        #endregion
    }
}