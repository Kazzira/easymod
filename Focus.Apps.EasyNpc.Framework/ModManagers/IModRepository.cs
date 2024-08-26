using Focus.Apps.EasyNpc.Data;

namespace Focus.Apps.EasyNpc.ModManagers;

/// <summary>
/// Provides methods to retrieve information about installed mods.
/// </summary>
public interface IModRepository
{
    /// <summary>
    /// Gets the set of all installed mods, and their components.
    /// </summary>
    /// <remarks>
    /// Since it is generally the individual <see cref="ModComponent"/>s that have priorities,
    /// results are not guaranteed to be in any particular order.
    /// </remarks>
    IAsyncEnumerable<ModManifest> GetMods();
}
