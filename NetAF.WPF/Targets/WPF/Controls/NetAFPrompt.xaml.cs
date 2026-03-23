using NetAF.Logic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetAF.Targets.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NetAFPrompt.xaml
    /// </summary>
    public partial class NetAFPrompt : UserControl
    {
        #region Fields

        private int historyIndex = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Get the input history. This is a dependency property.
        /// </summary>
        public Queue<string> InputHistory
        {
            get { return (Queue<string>)GetValue(InputHistoryProperty); }
            private set { SetValue(InputHistoryProperty, value); }
        }

        /// <summary>
        /// Get or set the input history length. This is a dependency property.
        /// </summary>
        public int InputHistoryLength
        {
            get { return (int)GetValue(InputHistoryLengthProperty); }
            set { SetValue(InputHistoryLengthProperty, value); }
        }

        /// <summary>
        /// Get a reference to the input text box.
        /// </summary>
        public TextBox TextBox => InputTextBox;

        /// <summary>
        /// Occurs when a key is pressed.
        /// </summary>
        public event EventHandler<Key>? KeyPressed;

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFPrompt.InputHistory property.
        /// </summary>
        public static readonly DependencyProperty InputHistoryProperty = DependencyProperty.Register("InputHistory", typeof(Queue<string>), typeof(NetAFPrompt), new PropertyMetadata(new Queue<string>()));

        /// <summary>
        /// Identifies the NetAFPrompt.InputHistoryLength property.
        /// </summary>
        public static readonly DependencyProperty InputHistoryLengthProperty = DependencyProperty.Register("InputHistoryLength", typeof(int), typeof(NetAFPrompt), new PropertyMetadata(50));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFPrompt class.
        /// </summary>
        public NetAFPrompt()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void AddToHistory(string input)
        {
            InputHistory.Enqueue(input);

            while (InputHistory.Count > InputHistoryLength)
                InputHistory.Dequeue();
        }

        private void SetTextFromHistoryByOffset(int offset)
        {
            if (InputHistory == null)
                return;

            historyIndex += offset;

            if (historyIndex < 0)
                historyIndex = 0;

            if (historyIndex >= InputHistory.Count)
                historyIndex = InputHistory.Count - 1;

            InputTextBox.Text = InputHistory.ElementAtOrDefault(historyIndex) ?? InputTextBox.Text;
            InputTextBox.CaretIndex = InputTextBox.Text.Length;
        }

        #endregion

        #region EventHandlers

        private void InputTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            KeyPressed?.Invoke(this, e.Key);

            if (e.Key == Key.Enter)
            {
                var entry = InputTextBox.Text;
                                
                if (!string.IsNullOrWhiteSpace(entry))
                    AddToHistory(entry);

                GameExecutor.Update(entry);

                InputTextBox.Clear();
                historyIndex = Math.Max(0, InputHistory.Count);
            }
            else if (e.Key == Key.Up)
            {
                SetTextFromHistoryByOffset(-1);
                e.Handled = true;
            }
            else if (e.Key == Key.Down)
            {
                SetTextFromHistoryByOffset(1);
                e.Handled = true;
            }
        }

        #endregion
    }
}
