namespace Focus.Apps.EasyNpc.Data;

/// <summary>
/// Data format for the mod registry, containing information on previously-seen mods along with
/// tracking information and metadata.
/// </summary>
public class ModRegistryData
{
    /// <summary>
    /// The list of known mods.
    /// </summary>
    public List<ModManifest> Mods { get; set; } = [];
}
