using NetAF.Logic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetAF.Targets.WPF
{
    /// <summary>
    /// Interaction logic for NetAFPrompt.xaml
    /// </summary>
    public partial class NetAFPrompt : UserControl
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

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFPrompt.PromptStyle property.
        /// </summary>
        public static readonly DependencyProperty PromptStyleProperty = DependencyProperty.Register(nameof(PromptStyle), typeof(Style), typeof(NetAFPrompt));

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

        #region EventHandlers

        private void InputTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            GameExecutor.Update(InputTextBox.Text);
            InputTextBox.Clear();
        }

        #endregion
    }
}
