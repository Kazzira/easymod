namespace Focus.Apps.EasyNpc.Data;

/// <summary>
/// Overrides the default behaviors for an entire mod or individual NPC.
/// </summary>
public class BehaviorOverrides
{
    /// <summary>
    /// Merging behavior for NPC default outfits with custom armor pieces, if different from the
    /// default.
    /// </summary>
    public CustomOutfitBehavior? CustomOutfitBehavior { get; set; }

    /// <summary>
    /// Merging behavior for NPC custom races, if different from the default.
    /// </summary>
    public CustomRaceBehavior? CustomRaceBehavior { get; set; }

    /// <summary>
    /// Merging behavior for NPC custom face tints, if different from the default.
    /// </summary>
    public FaceTintBehavior? FaceTintBehavior { get; set; }

    /// <summary>
    /// Merging behavior for NPC custom worn armors (skins, wigs, etc.), if different from the
    /// default.
    /// </summary>
    public WornArmorBehavior? WornArmorBehavior { get; set; }
}
