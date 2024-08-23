using FastEnumUtility;
using VYaml.Annotations;

namespace Focus.Apps.EasyNpc.Data;

[YamlObject(NamingConvention.UpperCamelCase)]
public enum NpcProperty
{
    [Label("AIDT")]
    AIData,

    [Label("PKID")]
    AIPackages,

    [Label("ATKD")]
    AttackData,

    [Label("ATKR")]
    AttackRace,

    [Label("ANAM")]
    AwayModelName,

    [Label("ACBS")]
    BaseStats,

    [Label("CNAM")]
    Class,

    [Label("ECOR")]
    CombatOverridePackageList,

    [Label("ZNAM")]
    CombatStyle,

    [Label("CRIF")]
    CrimeFaction,

    [Label("INAM")]
    DeathItem,

    [Label("DOFT")]
    DefaultOutfit,

    [Label("DPLT")]
    DefaultPackageList,

    [Label("DEST")]
    DestructionData,

    [Label("NAM9")]
    FaceMorphs,

    [Label("NAMA")]
    FaceParts,

    [Label("FTST")]
    FaceTextureSet,

    [Label("SNAM")]
    Faction,

    [Label("FULL")]
    FullName,

    [Label("ACBS.F")]
    GenderFlags,

    [Label("GNAM")]
    GiftFilter,

    [Label("GWOR")]
    GuardWarnOverridePackageList,

    [Label("PNAM")]
    HeadParts,

    [Label("HCLF")]
    HairColor,

    [Label("NAM6")]
    Height,

    [Label("KWDA")]
    Keywords,

    [Label("OCOR")]
    ObserveDeadBodyOverridePackageList,

    [Label("PRKR")]
    Perks,

    [Label("RNAM")]
    Race,

    [Label("VMAD")]
    ScriptInfo,

    [Label("SHRT")]
    ShortName,

    [Label("DNAM")]
    Skills,

    [Label("QNAM")]
    SkinTone,

    [Label("SOFT")]
    SleepOutfit,

    [Label("NAM8")]
    SoundLevel,

    [Label("CSDT")]
    SoundTypes,

    [Label("SPOR")]
    SpectatorOverridePackageList,

    [Label("SPLO")]
    Spells,

    [Label("TPLT")]
    Template,

    [Label("TINI")]
    TintLayers,

    [Label("VTCK")]
    VoiceType,

    [Label("NAM7")]
    Weight,

    [Label("WNAM")]
    WornArmor,
}
