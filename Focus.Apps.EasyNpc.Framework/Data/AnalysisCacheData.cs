namespace Focus.Apps.EasyNpc.Data;

/// <summary>
/// Holds the most recent analysis results for a given profile.
/// </summary>
public class AnalysisCacheData
{
    /// <summary>
    /// Hash of the entire load order.
    /// </summary>
    /// <remarks>
    /// This combines all the individual <see cref="ModAnalysis.PluginHashes"/> into an
    /// order-sensitive hash which will change if the plugins themselves are the same but their
    /// priorities are different.
    /// </remarks>
    public int LoadOrderHash { get; set; }

    /// <summary>
    /// Per-mod analysis results.
    /// </summary>
    /// <remarks>
    /// Each entry has a key corresponding to a mod's <see cref="ModManifest.Key"/>.
    /// </remarks>
    public Dictionary<string, ModAnalysis> Mods { get; set; } = [];
}
