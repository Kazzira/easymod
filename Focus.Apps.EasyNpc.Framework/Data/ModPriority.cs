namespace Focus.Apps.EasyNpc.Data;

/// <summary>
/// Describes how a single mod is prioritized within a property group defined in
/// <see cref="ProfileData.PropertyGroups"/>.
/// </summary>
public class ModPriority
{
    /// <summary>
    /// Unique <see cref="ModManifest.Key"/> of the mod in this priority slot.
    /// </summary>
    public string ModKey { get; set; } = "";

    /// <summary>
    /// Conditional rule for this priority, determining when it can activate.
    /// </summary>
    public ModPriorityCondition Condition { get; set; }
}

/// <summary>
/// A rule for a <see cref="ModPriority"/> that determines whether it should be active for a
/// specific record, or skipped in favor of a lower-priority mod.
/// </summary>
public enum ModPriorityCondition
{
    Always,

    /// <summary>
    /// Only active when the mod has actually changed at least one <see cref="NpcProperty"/> for the
    /// NPC being considered.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For example, if replacer "A" includes face changes for several NPCs and outfit changes for
    /// only a few of those NPCs, then using <c>OnlyWhenChanged</c> for both properties would cause
    /// NPCs in mod A <em>without</em> custom outfits to use A's face attributes but allow a
    /// different mod "B" to override the outfit; while NPCs <em>with</em> custom outfits would use
    /// both A's face and A's outfit, ignoring the lower-priority B entirely.
    /// </para>
    /// <para>
    /// In practice, this is a "don't revert to vanilla" flag, requesting that any edit from a
    /// previous (lower-priority) mod be preserved.
    /// </para>
    /// </remarks>
    OnlyWhenChanged,
}
