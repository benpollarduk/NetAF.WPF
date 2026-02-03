using System.Windows;
using System.Windows.Controls;

namespace NetAF.Targets.WPF.Layouts
{
    /// <summary>
    /// Interaction logic for CombinationLayout.xaml
    /// </summary>
    public partial class CombinationLayout : UserControl
    {
        #region Properties

        /// <summary>
        /// Get or set the prompt only layout style. This is a dependency property.
        /// </summary>
        public Style PromptOnlyLayoutStyle
        {
            get { return (Style)GetValue(PromptOnlyLayoutStyleProperty); }
            set { SetValue(PromptOnlyLayoutStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the button only layout style. This is a dependency property.
        /// </summary>
        public Style ButtonOnlyLayoutStyle
        {
            get { return (Style)GetValue(ButtonOnlyLayoutStyleProperty); }
            set { SetValue(ButtonOnlyLayoutStyleProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the CombinationLayout.PromptOnlyLayoutStyle property.
        /// </summary>
        public static readonly DependencyProperty PromptOnlyLayoutStyleProperty = DependencyProperty.Register("PromptOnlyLayoutStyle", typeof(Style), typeof(CombinationLayout));

        /// <summary>
        /// Identifies the CombinationLayout.ButtonOnlyLayoutStyle property.
        /// </summary>
        public static readonly DependencyProperty ButtonOnlyLayoutStyleProperty = DependencyProperty.Register("ButtonOnlyLayoutStyle", typeof(Style), typeof(CombinationLayout));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the CombinationLayout class.
        /// </summary>
        public CombinationLayout()
        {
            InitializeComponent();
        }

        #endregion
    }
}
