namespace Focus.Apps.EasyNpc.Data;

/// <summary>
/// Configures the treatment of a source mod during patching/merging.
/// </summary>
public class ModConfiguration
{
    /// <summary>
    /// Configures overrides for individual field/subrecord behaviors.
    /// </summary>
    public BehaviorOverrides BehaviorOverrides { get; set; } = new();
}
