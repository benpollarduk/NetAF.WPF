using NetAF.Logic;
using NetAF.Rendering;

namespace NetAF.Adapters
{
    /// <summary>
    /// Provides an adapter for the WPF.
    /// </summary>
    /// <param name="presenter">The presenter to use for presenting frames.</param>
    public sealed class WPFAdapter(IFramePresenter presenter) : IIOAdapter
    {
        #region Implementation of IIOAdapter

        /// <summary>
        /// Setup for a game.
        /// </summary>
        /// <param name="game">The game to set up for.</param>
        public void Setup(Game game)
        {
        }

        /// <summary>
        /// Render a frame.
        /// </summary>
        /// <param name="frame">The frame to render.</param>
        public void RenderFrame(IFrame frame)
        {
            frame.Render(presenter);
        }

        /// <summary>
        /// Wait for acknowledgment.
        /// </summary>
        /// <returns>True if the acknowledgment was received correctly, else false.</returns>
        public bool WaitForAcknowledge()
        {
            
        }

        /// <summary>
        /// Wait for input.
        /// </summary>
        /// <returns>The input.</returns>
        public string WaitForInput()
        {
            
        }

        #endregion
    }
}
