using NetAF.Commands;
using NetAF.Logic;
using NetAF.Logic.Modes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace NetAF.Targets.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NetAFCommandPicker.xaml
    /// </summary>
    public partial class NetAFCommandPicker : UserControl, IUpdatable
    {
        #region StaticProperties

        /// <summary>
        /// Get the default order to use for the command categories.
        /// </summary>
        private static readonly Dictionary<CommandCategory, int> DefaultCommandCategoryOrder = new()
        {
            { CommandCategory.Global, 0 },
            { CommandCategory.Information, 1 },
            { CommandCategory.Frame, 2 },
            { CommandCategory.Movement, 3 },
            { CommandCategory.RegionMap, 4 },
            { CommandCategory.Scene, 5 },
            { CommandCategory.Conversation, 6 },
            { CommandCategory.Custom, 7 },
            { CommandCategory.Uncategorized, 8 },
        };

        #endregion

        #region Fields

        /// <summary>
        /// Get the command for when a command is selected.
        /// </summary>
        private readonly RoutedUICommand CommandSelectedCommand = new();

        /// <summary>
        /// Get the command for when a prompt is selected.
        /// </summary>
        private readonly RoutedUICommand PromptSelectedCommand = new();

        /// <summary>
        /// Get the command for when a clear is selected.
        /// </summary>
        private readonly RoutedUICommand ClearSelectedCommand = new();

        /// <summary>
        /// Get the command for when acknowledge is selected.
        /// </summary>
        private readonly RoutedUICommand AcknowledgeSelectedCommand = new();

        #endregion

        #region Properties

        /// <summary>
        /// Get the selected command. This is a dependency property.
        /// </summary>
        public CommandHelp? SelectedCommand
        {
            get { return (CommandHelp)GetValue(SelectedCommandProperty); }
            private set { SetValue(SelectedCommandProperty, value); }
        }

        /// <summary>
        /// Get the available commands. This is a dependency property.
        /// </summary>
        public CommandHelp[] AvailableCommands
        {
            get { return (CommandHelp[])GetValue(AvailableCommandsProperty); }
            private set { SetValue(AvailableCommandsProperty, value); }
        }

        /// <summary>
        /// Get the available prompts. This is a dependency property.
        /// </summary>
        public Prompt[] AvailablePrompts
        {
            get { return (Prompt[])GetValue(AvailablePromptsProperty); }
            private set { SetValue(AvailablePromptsProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the prompt buttons. This is a dependency property.
        /// </summary>
        public Style PromptButtonStyle
        {
            get { return (Style)GetValue(PromptButtonStyleProperty); }
            set { SetValue(PromptButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the clear button. This is a dependency property.
        /// </summary>
        public Style ClearButtonStyle
        {
            get { return (Style)GetValue(ClearButtonStyleProperty); }
            set { SetValue(ClearButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the acknowledge button. This is a dependency property.
        /// </summary>
        public Style AcknowledgeButtonStyle
        {
            get { return (Style)GetValue(AcknowledgeButtonStyleProperty); }
            set { SetValue(AcknowledgeButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the global command buttons. This is a dependency property.
        /// </summary>
        public Style GlobalCommandButtonStyle
        {
            get { return (Style)GetValue(GlobalCommandButtonStyleProperty); }
            set { SetValue(GlobalCommandButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the information command buttons. This is a dependency property.
        /// </summary>
        public Style InformationCommandButtonStyle
        {
            get { return (Style)GetValue(InformationCommandButtonStyleProperty); }
            set { SetValue(InformationCommandButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the frame command buttons. This is a dependency property.
        /// </summary>
        public Style FrameCommandButtonStyle
        {
            get { return (Style)GetValue(FrameCommandButtonStyleProperty); }
            set { SetValue(FrameCommandButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the movement command buttons. This is a dependency property.
        /// </summary>
        public Style MovementCommandButtonStyle
        {
            get { return (Style)GetValue(MovementCommandButtonStyleProperty); }
            set { SetValue(MovementCommandButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the region map command buttons. This is a dependency property.
        /// </summary>
        public Style RegionMapCommandButtonStyle
        {
            get { return (Style)GetValue(RegionMapCommandButtonStyleProperty); }
            set { SetValue(RegionMapCommandButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the scene command buttons. This is a dependency property.
        /// </summary>
        public Style SceneCommandButtonStyle
        {
            get { return (Style)GetValue(SceneCommandButtonStyleProperty); }
            set { SetValue(SceneCommandButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the conversation command buttons. This is a dependency property.
        /// </summary>
        public Style ConversationCommandButtonStyle
        {
            get { return (Style)GetValue(ConversationCommandButtonStyleProperty); }
            set { SetValue(ConversationCommandButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the custom command buttons. This is a dependency property.
        /// </summary>
        public Style CustomCommandButtonStyle
        {
            get { return (Style)GetValue(CustomCommandButtonStyleProperty); }
            set { SetValue(CustomCommandButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the execution command buttons. This is a dependency property.
        /// </summary>
        public Style ExecutionCommandButtonStyle
        {
            get { return (Style)GetValue(ExecutionCommandButtonStyleProperty); }
            set { SetValue(ExecutionCommandButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the persistence command buttons. This is a dependency property.
        /// </summary>
        public Style PersistenceCommandButtonStyle
        {
            get { return (Style)GetValue(PersistenceCommandButtonStyleProperty); }
            set { SetValue(PersistenceCommandButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set if the global command buttons should be shown. This is a dependency property.
        /// </summary>
        public bool ShowGlobalCommands
        {
            get { return (bool)GetValue(ShowGlobalCommandsProperty); }
            set { SetValue(ShowGlobalCommandsProperty, value); }
        }

        /// <summary>
        /// Get or set if the information command buttons should be shown. This is a dependency property.
        /// </summary>
        public bool ShowInformationCommands
        {
            get { return (bool)GetValue(ShowInformationCommandsProperty); }
            set { SetValue(ShowInformationCommandsProperty, value); }
        }

        /// <summary>
        /// Get or set if the frame command buttons should be shown. This is a dependency property.
        /// </summary>
        public bool ShowFrameCommands
        {
            get { return (bool)GetValue(ShowFrameCommandsProperty); }
            set { SetValue(ShowFrameCommandsProperty, value); }
        }

        /// <summary>
        /// Get or set if the movement command buttons should be shown. This is a dependency property.
        /// </summary>
        public bool ShowMovementCommands
        {
            get { return (bool)GetValue(ShowMovementCommandsProperty); }
            set { SetValue(ShowMovementCommandsProperty, value); }
        }

        /// <summary>
        /// Get or set if the region map command buttons should be shown. This is a dependency property.
        /// </summary>
        public bool ShowRegionMapCommands
        {
            get { return (bool)GetValue(ShowRegionMapCommandsProperty); }
            set { SetValue(ShowRegionMapCommandsProperty, value); }
        }

        /// <summary>
        /// Get or set if the scene command buttons should be shown. This is a dependency property.
        /// </summary>
        public bool ShowSceneCommands
        {
            get { return (bool)GetValue(ShowSceneCommandsProperty); }
            set { SetValue(ShowSceneCommandsProperty, value); }
        }

        /// <summary>
        /// Get or set if the conversation command buttons should be shown. This is a dependency property.
        /// </summary>
        public bool ShowConversationCommands
        {
            get { return (bool)GetValue(ShowConversationCommandsProperty); }
            set { SetValue(ShowConversationCommandsProperty, value); }
        }

        /// <summary>
        /// Get or set if the custom command buttons should be shown. This is a dependency property.
        /// </summary>
        public bool ShowCustomCommands
        {
            get { return (bool)GetValue(ShowCustomCommandsProperty); }
            set { SetValue(ShowCustomCommandsProperty, value); }
        }

        /// <summary>
        /// Get or set if the execution command buttons should be shown. This is a dependency property.
        /// </summary>
        public bool ShowExecutionCommands
        {
            get { return (bool)GetValue(ShowExecutionCommandsProperty); }
            set { SetValue(ShowExecutionCommandsProperty, value); }
        }

        /// <summary>
        /// Get or set if the persistence command buttons should be shown. This is a dependency property.
        /// </summary>
        public bool ShowPersistenceCommands
        {
            get { return (bool)GetValue(ShowPersistenceCommandsProperty); }
            set { SetValue(ShowPersistenceCommandsProperty, value); }
        }

        /// <summary>
        /// Get or set the ordering to use for the command categories. Categories with a low number are rendered first. This is a dependency property.
        /// </summary>
        public Dictionary<CommandCategory, int> CommandCategoryOrder
        {
            get { return (Dictionary<CommandCategory, int>)GetValue(CommandCategoryOrderProperty); }
            set { SetValue(CommandCategoryOrderProperty, value); }
        }

        /// <summary>
        /// Get or set if an acknowledge button should be shown. This is a dependency property.
        /// </summary>
        public bool ShowAcknowledgeButton
        {
            get { return (bool)GetValue(ShowAcknowledgeButtonProperty); }
            set { SetValue(ShowAcknowledgeButtonProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFCommandPicker.SelectedCommand property.
        /// </summary>
        public static readonly DependencyProperty SelectedCommandProperty = DependencyProperty.Register("SelectedCommand", typeof(CommandHelp), typeof(NetAFCommandPicker), new PropertyMetadata(new PropertyChangedCallback(OnSelectedCommandPropertyChanged)));

        /// <summary>
        /// Identifies the NetAFCommandPicker.AvailableCommands property.
        /// </summary>
        public static readonly DependencyProperty AvailableCommandsProperty = DependencyProperty.Register("AvailableCommands", typeof(CommandHelp[]), typeof(NetAFCommandPicker), new PropertyMetadata(new PropertyChangedCallback(OnAvailableCommandsPropertyChanged)));

        /// <summary>
        /// Identifies the NetAFCommandPicker.AvailablePrompts property.
        /// </summary>
        public static readonly DependencyProperty AvailablePromptsProperty = DependencyProperty.Register("AvailablePrompts", typeof(Prompt[]), typeof(NetAFCommandPicker), new PropertyMetadata(new PropertyChangedCallback(OnAvailablePromptsPropertyChanged)));

        /// <summary>
        /// Identifies the NetAFCommandPicker.PromptButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty PromptButtonStyleProperty = DependencyProperty.Register("PromptButtonStyle", typeof(Style), typeof(NetAFCommandPicker));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ClearButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty ClearButtonStyleProperty = DependencyProperty.Register("ClearButtonStyle", typeof(Style), typeof(NetAFCommandPicker));

        /// <summary>
        /// Identifies the NetAFCommandPicker.AcknowledgeButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty AcknowledgeButtonStyleProperty = DependencyProperty.Register("AcknowledgeButtonStyle", typeof(Style), typeof(NetAFCommandPicker));

        /// <summary>
        /// Identifies the NetAFCommandPicker.GlobalCommandButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty GlobalCommandButtonStyleProperty = DependencyProperty.Register("GlobalCommandButtonStyle", typeof(Style), typeof(NetAFCommandPicker), new PropertyMetadata(CreateButtonStyle(new SolidColorBrush(Colors.Magenta))));

        /// <summary>
        /// Identifies the NetAFCommandPicker.InformationCommandButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty InformationCommandButtonStyleProperty = DependencyProperty.Register("InformationCommandButtonStyle", typeof(Style), typeof(NetAFCommandPicker), new PropertyMetadata(CreateButtonStyle(new SolidColorBrush(Colors.Magenta))));

        /// <summary>
        /// Identifies the NetAFCommandPicker.FrameCommandButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty FrameCommandButtonStyleProperty = DependencyProperty.Register("FrameCommandButtonStyle", typeof(Style), typeof(NetAFCommandPicker), new PropertyMetadata(CreateButtonStyle(new SolidColorBrush(Colors.Magenta))));

        /// <summary>
        /// Identifies the NetAFCommandPicker.MovementCommandButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty MovementCommandButtonStyleProperty = DependencyProperty.Register("MovementCommandButtonStyle", typeof(Style), typeof(NetAFCommandPicker), new PropertyMetadata(CreateButtonStyle(new SolidColorBrush(Colors.LightBlue))));

        /// <summary>
        /// Identifies the NetAFCommandPicker.RegionMapCommandButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty RegionMapCommandButtonStyleProperty = DependencyProperty.Register("RegionMapCommandButtonStyle", typeof(Style), typeof(NetAFCommandPicker), new PropertyMetadata(CreateButtonStyle(new SolidColorBrush(Colors.LightBlue))));

        /// <summary>
        /// Identifies the NetAFCommandPicker.SceneCommandButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty SceneCommandButtonStyleProperty = DependencyProperty.Register("SceneCommandButtonStyle", typeof(Style), typeof(NetAFCommandPicker), new PropertyMetadata(CreateButtonStyle(new SolidColorBrush(Colors.LightGreen))));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ConversationCommandButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty ConversationCommandButtonStyleProperty = DependencyProperty.Register("ConversationCommandButtonStyle", typeof(Style), typeof(NetAFCommandPicker), new PropertyMetadata(CreateButtonStyle(new SolidColorBrush(Colors.LightGreen))));

        /// <summary>
        /// Identifies the NetAFCommandPicker.CustomCommandButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty CustomCommandButtonStyleProperty = DependencyProperty.Register("CustomCommandButtonStyle", typeof(Style), typeof(NetAFCommandPicker), new PropertyMetadata(CreateButtonStyle(new SolidColorBrush(Colors.LightGreen))));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ExecutionCommandButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty ExecutionCommandButtonStyleProperty = DependencyProperty.Register("ExecutionCommandButtonStyle", typeof(Style), typeof(NetAFCommandPicker), new PropertyMetadata(CreateButtonStyle(new SolidColorBrush(Colors.LightGreen))));

        /// <summary>
        /// Identifies the NetAFCommandPicker.PersistenceCommandButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty PersistenceCommandButtonStyleProperty = DependencyProperty.Register("PersistenceCommandButtonStyle", typeof(Style), typeof(NetAFCommandPicker), new PropertyMetadata(CreateButtonStyle(new SolidColorBrush(Colors.SeaGreen))));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowGlobalCommands property.
        /// </summary>
        public static readonly DependencyProperty ShowGlobalCommandsProperty = DependencyProperty.Register("ShowGlobalCommands", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowInformationCommandsProperty property.
        /// </summary>
        public static readonly DependencyProperty ShowInformationCommandsProperty = DependencyProperty.Register("ShowInformationCommands", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowFrameCommandsProperty property.
        /// </summary>
        public static readonly DependencyProperty ShowFrameCommandsProperty = DependencyProperty.Register("ShowFrameCommands", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowMovementCommandsProperty property.
        /// </summary>
        public static readonly DependencyProperty ShowMovementCommandsProperty = DependencyProperty.Register("ShowMovementCommands", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowRegionMapCommandsProperty property.
        /// </summary>
        public static readonly DependencyProperty ShowRegionMapCommandsProperty = DependencyProperty.Register("ShowRegionMapCommands", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowSceneCommandsProperty property.
        /// </summary>
        public static readonly DependencyProperty ShowSceneCommandsProperty = DependencyProperty.Register("ShowSceneCommands", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowConversationCommandsProperty property.
        /// </summary>
        public static readonly DependencyProperty ShowConversationCommandsProperty = DependencyProperty.Register("ShowConversationCommands", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowCustomCommandsProperty property.
        /// </summary>
        public static readonly DependencyProperty ShowCustomCommandsProperty = DependencyProperty.Register("ShowCustomCommands", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowExecutionCommandsProperty property.
        /// </summary>
        public static readonly DependencyProperty ShowExecutionCommandsProperty = DependencyProperty.Register("ShowExecutionCommands", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowPersistenceCommandsProperty property.
        /// </summary>
        public static readonly DependencyProperty ShowPersistenceCommandsProperty = DependencyProperty.Register("ShowPersistenceCommands", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFCommandPicker.CommandCategoryOrder property.
        /// </summary>
        public static readonly DependencyProperty CommandCategoryOrderProperty = DependencyProperty.Register("CommandCategoryOrder", typeof(Dictionary<CommandCategory, int>), typeof(NetAFCommandPicker), new PropertyMetadata(DefaultCommandCategoryOrder));

        /// <summary>
        /// Identifies the NetAFCommandPicker.ShowAcknowledgeButton property.
        /// </summary>
        public static readonly DependencyProperty ShowAcknowledgeButtonProperty = DependencyProperty.Register("ShowAcknowledgeButton", typeof(bool), typeof(NetAFCommandPicker), new PropertyMetadata(true));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFCommandPicker class.
        /// </summary>
        public NetAFCommandPicker()
        {
            InitializeComponent();

            SetupCommandBindings();
        }

        #endregion

        #region Methods

        private void SetupCommandBindings()
        {
            CommandBindings.Add(new CommandBinding(CommandSelectedCommand, CommandSelectedCommand_Executed));
            CommandBindings.Add(new CommandBinding(PromptSelectedCommand, PromptSelectedCommand_Executed));
            CommandBindings.Add(new CommandBinding(ClearSelectedCommand, ClearSelectedCommand_Executed));
            CommandBindings.Add(new CommandBinding(AcknowledgeSelectedCommand, AcknowledgeSelectedCommand_Executed));
        }

        private void ClearButtons()
        {
            ButtonWrapPanel.Children.Clear();
        }

        private void GenerateCommandButtons()
        {
            ClearButtons();

            var categorisedCommands = CategoriseCommands(AvailableCommands);

            foreach (var category in categorisedCommands.Keys.OrderBy(x => CommandCategoryOrder.TryGetValue(x, out int value) ? value : int.MaxValue))
            {
                foreach (var command in categorisedCommands[category].OrderBy(x => x.Command))
                {
                    var button = new Button { Content = command.Command };
                    var styleKey = GetCategoryButtonStyleKey(category);
                    var shownKey = GetCategoryButtonShownKey(category);

                    button.Command = CommandSelectedCommand;
                    button.CommandParameter = command;

                    BindingOperations.SetBinding(button, StyleProperty, GetButtonStyleBinding(styleKey));
                    BindingOperations.SetBinding(button, VisibilityProperty, GetButtonVisibilityBinding(shownKey));

                    ButtonWrapPanel.Children.Add(button);
                }
            }
        }

        private void GenerateAcknowledgeButton()
        {
            ClearButtons();

            var acknowledgeButton = new Button { Content = "Ok" };
            BindingOperations.SetBinding(acknowledgeButton, StyleProperty, GetButtonStyleBinding(nameof(AcknowledgeButtonStyle)));
            
            acknowledgeButton.Command = AcknowledgeSelectedCommand;

            ButtonWrapPanel.Children.Add(acknowledgeButton);
        }

        private void GeneratePromptButtons()
        {
            ClearButtons();

            var clearButton = new Button { Content = "Clear" };
            BindingOperations.SetBinding(clearButton, StyleProperty, GetButtonStyleBinding(nameof(ClearButtonStyle)));

            clearButton.Command = ClearSelectedCommand;

            ButtonWrapPanel.Children.Add(clearButton);

            foreach (var prompt in AvailablePrompts)
            {
                var button = new Button { Content = prompt.Entry };
                BindingOperations.SetBinding(button, StyleProperty, GetButtonStyleBinding(nameof(PromptButtonStyle)));

                button.Command = PromptSelectedCommand;
                button.CommandParameter = prompt;

                ButtonWrapPanel.Children.Add(button);
            }
        }

        private Binding GetButtonStyleBinding(string propertyName)
        {
            return new Binding()
            {
                Source = this,
                Path = new PropertyPath(path: propertyName),
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
        }

        private Binding GetButtonVisibilityBinding(string propertyName)
        {
            return new Binding()
            {
                Source = this,
                Path = new PropertyPath(path: propertyName),
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Converter = new BooleanToVisibilityConverter()
            };
        }

        private Dictionary<CommandCategory, List<CommandHelp>> CategoriseCommands(CommandHelp[] commands)
        {
            Dictionary<CommandCategory, List<CommandHelp>> categorisedCommands = [];

            if (CommandCategoryOrder == null)
                return categorisedCommands;

            foreach (var command in commands)
            {
                if (!categorisedCommands.ContainsKey(command.Category))
                    categorisedCommands.Add(command.Category, []);

                categorisedCommands[command.Category].Add(command);
            }

            return categorisedCommands;
        }

        #endregion

        #region StaticMethods

        private static string GetCategoryButtonShownKey(CommandCategory category)
        {
            return category switch
            {
                CommandCategory.Conversation => nameof(ShowConversationCommands),
                CommandCategory.Custom => nameof(ShowCustomCommands),
                CommandCategory.Execution => nameof(ShowExecutionCommands),
                CommandCategory.Frame => nameof(ShowFrameCommands),
                CommandCategory.Global => nameof(ShowGlobalCommands),
                CommandCategory.Information => nameof(ShowInformationCommands),
                CommandCategory.Movement => nameof(ShowMovementCommands),
                CommandCategory.Persistence => nameof(ShowPersistenceCommands),
                CommandCategory.RegionMap => nameof(ShowRegionMapCommands),
                CommandCategory.Scene => nameof(ShowSceneCommands),
                CommandCategory.Uncategorized => nameof(ShowCustomCommands),
                _ => nameof(ShowCustomCommands)
            };
        }

        private static string GetCategoryButtonStyleKey(CommandCategory category)
        {
            return category switch
            {
                CommandCategory.Conversation => nameof(ConversationCommandButtonStyle),
                CommandCategory.Custom => nameof(CustomCommandButtonStyle),
                CommandCategory.Execution => nameof(ExecutionCommandButtonStyle),
                CommandCategory.Frame => nameof(FrameCommandButtonStyle),
                CommandCategory.Global => nameof(GlobalCommandButtonStyle),
                CommandCategory.Information => nameof(InformationCommandButtonStyle),
                CommandCategory.Movement => nameof(MovementCommandButtonStyle),
                CommandCategory.Persistence => nameof(PersistenceCommandButtonStyle),
                CommandCategory.RegionMap => nameof(RegionMapCommandButtonStyle),
                CommandCategory.Scene => nameof(SceneCommandButtonStyle),
                CommandCategory.Uncategorized => nameof(CustomCommandButtonStyle),
                _ => nameof(CustomCommandButtonStyle)
            };
        }

        private static Style CreateButtonStyle(Brush background)
        {
            var style = new Style();
            style.Setters.Add(new Setter(BackgroundProperty, background));
            return style;
        }

        #endregion

        #region PropertyChangedCallbacks

        private static void OnSelectedCommandPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as NetAFCommandPicker;

            if (control == null)
                return;

            if (e.NewValue is not CommandHelp newCommand)
                return;

            control.AvailablePrompts = GameExecutor.ExecutingGame?.GetPromptsForCommand(newCommand) ?? [];

            if (control.AvailablePrompts == null || control.AvailablePrompts.Length == 0)
            {
                GameExecutor.Update(newCommand.Command);
                control.SelectedCommand = null;
            }
        }

        private static void OnAvailableCommandsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as NetAFCommandPicker;
            control?.GenerateCommandButtons();
        }

        private static void OnAvailablePromptsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as NetAFCommandPicker;
            control?.GeneratePromptButtons();
        }

        #endregion

        #region CommandCallbacks

        private void CommandSelectedCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SelectedCommand = e.Parameter as CommandHelp;
        }

        private void PromptSelectedCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update($"{SelectedCommand?.Command ?? string.Empty} {(e.Parameter as Prompt)?.Entry}");
            SelectedCommand = null;
        }

        private void ClearSelectedCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Update(GameExecutor.ExecutingGame);
        }

        private void AcknowledgeSelectedCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameExecutor.Update();
            SelectedCommand = null;
        }

        #endregion

        #region Implementation of IUpdatable

        /// <summary>
        /// Update the component.
        /// </summary>
        /// <param name="game">The game to update based on.</param>
        public void Update(Game game)
        {
            SelectedCommand = null;
            AvailableCommands = [];

            if (game == null)
                return;

            var showCommands = game.Mode?.Type == GameModeType.Interactive;
            var showAcknowledge = ShowAcknowledgeButton && (game.Mode?.Type is GameModeType.SingleFrameInformation or GameModeType.MultipleFrameInformation);

            if (showCommands)
                AvailableCommands = game.GetContextualCommands();
            else if (showAcknowledge)
                GenerateAcknowledgeButton();
        }

        #endregion
    }
}
