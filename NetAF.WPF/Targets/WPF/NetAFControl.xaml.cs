using NetAF.Logic;
using NetAF.Rendering;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace NetAF.Targets.WPF
{
    /// <summary>
    /// Interaction logic for NetAFControl.xaml
    /// </summary>
    public partial class NetAFControl : UserControl, IFramePresenter
    {
        #region Properties

        /// <summary>
        /// Get or set the styling to apply to the prompt. The base type to style is TextBox. This is a dependency property.
        /// </summary>
        public Style PromptStyle
        {
            get { return (Style)GetValue(PromptStyleProperty); }
            set { SetValue(PromptStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the styling to apply to the terminal. The base type to style is TextBlock. This is a dependency property.
        /// </summary>
        public Style TerminalStyle
        {
            get { return (Style)GetValue(TerminalStyleProperty); }
            set { SetValue(TerminalStyleProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFControl.PromptStyle property.
        /// </summary>
        public static readonly DependencyProperty PromptStyleProperty = DependencyProperty.Register(nameof(PromptStyle), typeof(Style), typeof(NetAFControl));

        /// <summary>
        /// Identifies the NetAFControl.TerminalStyle property.
        /// </summary>
        public static readonly DependencyProperty TerminalStyleProperty = DependencyProperty.Register(nameof(TerminalStyle), typeof(Style), typeof(NetAFControl));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFControl class.
        /// </summary>
        public NetAFControl()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void InputTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            GameExecutor.Update(InputTextBox.Text);
            InputTextBox.Clear();
        }

        #endregion

        #region Implementation of IFramePresenter

        /// <summary>
        /// Present a frame.
        /// </summary>
        /// <param name="frame">The frame to write, as a string.</param>
        public void Present(string frame)
        {
            var transitionIn = FindResource("TransitionIn") as Storyboard;
            var transitionOut = FindResource("TransitionOut") as Storyboard;

            if (string.IsNullOrEmpty(TextBlock.Text) || transitionOut == null)
            {
                TextBlock.Text = frame;
                transitionIn?.Begin();
            }
            else
            {
                transitionOut.Completed += (s, e) =>
                {
                    TextBlock.Text = frame;
                    transitionIn?.Begin();
                };
                transitionOut.Begin();
            }
        }

        #endregion
    }
}
