using System.Windows.Controls;
using NetAF.Rendering;

namespace NetAF.Targets.WPF
{
    /// <summary>
    /// Represents a presenter for WebBrowser.
    /// </summary>
    /// <param name="webBrowser">The web browser.</param>
    public sealed class WebBrowserPresenter(WebBrowser webBrowser) : IFramePresenter
    {
        #region Implementation of IFramePresenter

        /// <summary>
        /// Present a frame.
        /// </summary>
        /// <param name="frame">The frame to write, as a string.</param>
        public void Present(string frame)
        {
            webBrowser.NavigateToString(frame);
        }

        #endregion
    }
}
