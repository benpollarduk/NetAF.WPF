using NetAF.Rendering;

namespace NetAF.Targets.WPF.Layouts
{
    /// <summary>
    /// Represents any object that is a NetAF layout.
    /// </summary>
    public interface INetAFLayout
    {
        /// <summary>
        /// Get the presenter.
        /// </summary>
        IFramePresenter Presenter { get; }
    }
}
