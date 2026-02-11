using NetAF.Logic;

namespace NetAF.Targets.WPF
{
    /// <summary>
    /// Represents any component that is updateable.
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// Update the component.
        /// </summary>
        /// <param name="game">The game to update based on.</param>
        void Update(Game game);
    }
}
