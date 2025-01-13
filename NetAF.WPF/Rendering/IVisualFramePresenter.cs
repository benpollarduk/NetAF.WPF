using NetAF.Rendering;

namespace NetAF.WPF.Rendering
{
    /// <summary>
    /// Represents an object that can render a frame on a visual.
    /// </summary>
    public interface IVisualFramePresenter : IFramePresenter
    {
        /// <summary>
        /// Clear the visual.
        /// </summary>
        void Clear();
    }
}
