using FastEnumUtility;

namespace Focus.Apps.EasyNpc.Data;

/// <summary>
/// Games that are (possibly) supported by the tool.
/// </summary>
public enum GameName
{
    [Label("Oblivion")]
    Oblivion = 0,

    [Label("Skyrim Legendary Edition")]
    SkyrimLE = 1,

    [Label("Skyrim Special Edition (Steam)")]
    SkyrimSE = 2,

    [Label("Skyrim Special Edition (GOG)")]
    SkyrimSEGog = 7,

    [Label("Skyrim VR")]
    SkyrimVR = 3,

    [Label("Enderal LE")]
    EnderalLE = 5,

    [Label("Enderal SE")]
    EnderalSE = 6,

    [Label("Fallout 4")]
    Fallout4 = 4,

    [Label("Fallout 4 VR")]
    Fallout4VR = 9,
}
