using NetAF.Assets;
using NetAF.Logic;
using NetAF.Rendering;
using NetAF.Targets.Text;

namespace NetAF.Targets.WPF
{
    /// <summary>
    /// Provides an adapter for WPF.
    /// </summary>
    public class WPFAdapter : IIOAdapter
    {
        #region Fields

        private readonly TextAdapter textAdapter;
        private readonly IFramePresenter presenter;

        #endregion

        #region Properties

        /// <summary>
        /// Occurs whenever a frame is rendered.
        /// </summary>
        public event EventHandler FrameRendered;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the WPFAdpater class.
        /// </summary>
        /// <param name="presenter">The presenter to use for presenting frames.</param>
        public WPFAdapter(IFramePresenter presenter)
        {
            this.presenter = presenter;
            textAdapter = new TextAdapter(presenter);
        }

        #endregion

        #region Implementation of IIOAdapter

        /// <summary>
        /// Get the current size of the output.
        /// </summary>
        public Size CurrentOutputSize => presenter.GetPresentableSize();

        /// <summary>
        /// Setup for a game.
        /// </summary>
        /// <param name="game">The game to set up for.</param>
        public void Setup(Game game)
        {
            textAdapter.Setup(game);
        }

        /// <summary>
        /// Render a frame.
        /// </summary>
        /// <param name="frame">The frame to render.</param>
        public void RenderFrame(IFrame frame)
        {
            textAdapter.RenderFrame(frame);
            FrameRendered?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
