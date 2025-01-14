using System.Windows.Controls;

namespace NetAF.Rendering.WPF
{
    /// <summary>
    /// Represents a presenter for WebBrowser.
    /// </summary>
    /// <param name="webBrowser">The web browser.</param>
    public sealed class WebBrowserPresenter(WebBrowser webBrowser) : IFramePresenter
    {
        #region Implementation of IFramePresenter

        /// <summary>
        /// Write a string.
        /// </summary>
        /// <param name="value">The string to write.</param>
        public void Write(string value)
        {
            webBrowser.NavigateToString(value);
        }

        #endregion
    }
}
