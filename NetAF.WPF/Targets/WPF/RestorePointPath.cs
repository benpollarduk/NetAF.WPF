using NetAF.Persistence;

namespace NetAF.Targets.WPF
{
    /// <summary>
    /// Represents a restore point with a path.
    /// </summary>
    /// <param name="RestorePoint">The restore point.</param>
    /// <param name="Path">The file path to the restore point.</param>
    public record RestorePointPath(RestorePoint RestorePoint, string Path);
}
