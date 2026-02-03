using System.Windows;
using System.Windows.Controls;

namespace NetAF.Targets.WPF.Layouts
{
    /// <summary>
    /// Interaction logic for PromptOnlyLayout.xaml
    /// </summary>
    public partial class PromptOnlyLayout : UserControl
    {
        #region Properties

        /// <summary>
        /// Get or set the prompt style. This is a dependency property.
        /// </summary>
        public Style PromptStyle
        {
            get { return (Style)GetValue(PromptStyleProperty); }
            set { SetValue(PromptStyleProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the PromptOnlyLayout.PromptStyle property.
        /// </summary>
        public static readonly DependencyProperty PromptStyleProperty = DependencyProperty.Register("PromptStyle", typeof(Style), typeof(PromptOnlyLayout));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PromptOnlyLayout class.
        /// </summary>
        public PromptOnlyLayout()
        {
            InitializeComponent();
        }

        #endregion
    }
}
