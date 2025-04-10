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
