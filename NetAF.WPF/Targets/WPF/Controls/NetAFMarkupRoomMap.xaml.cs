using NetAF.Assets.Locations;
using NetAF.Logic;
using NetAF.Rendering;
using NetAF.Targets.Markup.Rendering;
using NetAF.Targets.Markup.Rendering.FrameBuilders;
using NetAF.Targets.WPF.Themes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NetAF.Targets.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NetAFMarkupRoomMap.xaml
    /// </summary>
    public partial class NetAFMarkupRoomMap : UserControl, IUpdatable
    {
        #region Properties

        /// <summary>
        /// Get or set if transitions are used. This is a dependency property.
        /// </summary>
        public bool UseTransitions
        {
            get { return (bool)GetValue(UseTransitionsProperty); }
            set { SetValue(UseTransitionsProperty, value); }
        }

        /// <summary>
        /// Get or set the strength of the transitions. Values between 0-1 are recommended. This is a dependency property.
        /// </summary>
        public double TransitionStrength
        {
            get { return (double)GetValue(TransitionStrengthProperty); }
            set { SetValue(TransitionStrengthProperty, value); }
        }

        /// <summary>
        /// Get or set the duration of the transitions. This is a dependency property.
        /// </summary>
        public Duration TransitionDuration
        {
            get { return (Duration)GetValue(TransitionDurationProperty); }
            set { SetValue(TransitionDurationProperty, value); }
        }

        /// <summary>
        /// Get or set the theme for FlowDocuments. This is a dependency property.
        /// </summary>
        public FlowDocumentTheme FlowDocumentTheme
        {
            get { return (FlowDocumentTheme)GetValue(FlowDocumentThemeProperty); }
            set { SetValue(FlowDocumentThemeProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFMarkupRoomMap.UseTransitions property.
        /// </summary>
        public static readonly DependencyProperty UseTransitionsProperty = DependencyProperty.Register("UseTransitions", typeof(bool), typeof(NetAFMarkupRoomMap), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the NetAFMarkupRoomMap.TransitionStrength property.
        /// </summary>
        public static readonly DependencyProperty TransitionStrengthProperty = DependencyProperty.Register("TransitionStrength", typeof(double), typeof(NetAFMarkupRoomMap), new PropertyMetadata(0.1d));

        /// <summary>
        /// Identifies the NetAFMarkupRoomMap.TransitionDuration property.
        /// </summary>
        public static readonly DependencyProperty TransitionDurationProperty = DependencyProperty.Register("TransitionDuration", typeof(Duration), typeof(NetAFMarkupRoomMap), new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(200))));

        /// <summary>
        /// Identifies the NetAFMarkupRoomMap.FlowDocumentTheme property.
        /// </summary>
        public static readonly DependencyProperty FlowDocumentThemeProperty = DependencyProperty.Register("FlowDocumentTheme", typeof(FlowDocumentTheme), typeof(NetAFMarkupRoomMap), new PropertyMetadata(DefaultTheme.FlowDocument));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFMarkupRoomMap class.
        /// </summary>
        public NetAFMarkupRoomMap()
        {
            InitializeComponent();
        }

        #endregion

        #region Implementation of IUpdatable

        /// <summary>
        /// Update the component.
        /// </summary>
        /// <param name="game">The game to update based on.</param>
        public void Update(Game game)
        {
            var region = game?.Overworld?.CurrentRegion;
            var room = region?.CurrentRoom;
            var markup = "";

            if (room != null)
            {
                var markupBuilder = new MarkupBuilder();
                var roomBuilder = new MarkupRoomMapBuilder(markupBuilder);
                roomBuilder.BuildRoomMap(room, ViewPoint.Create(region), KeyType.None);
                markup = markupBuilder.ToString();
            }

            var flowDocument = FlowDocumentModelRenderer.Render(markup ?? string.Empty, FlowDocumentTheme);

            if (UseTransitions)
            {
                var transitionIn = FindResource("TransitionIn") as Storyboard;
                var transitionOut = FindResource("TransitionOut") as Storyboard;

                if (Viewer.Document == null || transitionOut == null)
                {
                    Viewer.Document = flowDocument;
                    transitionIn?.Begin();
                }
                else
                {
                    transitionOut.Completed += (s, e) =>
                    {
                        Viewer.Document = flowDocument;
                        transitionIn?.Begin();
                    };
                    transitionOut.Begin();
                }
            }
            else
            {
                Viewer.Document = flowDocument;
            }
        }

        #endregion
    }
}
