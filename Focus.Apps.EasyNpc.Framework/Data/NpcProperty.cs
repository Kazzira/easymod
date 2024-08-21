using System.Runtime.Serialization;

namespace Focus.Apps.EasyNpc.Data;

public enum NpcProperty
{
    [EnumMember(Value = "AIDT")]
    AIData,

    [EnumMember(Value = "PKID")]
    AIPackages,

    [EnumMember(Value = "ATKD")]
    AttackData,

    [EnumMember(Value = "ATKR")]
    AttackRace,

    [EnumMember(Value = "ANAM")]
    AwayModelName,

    [EnumMember(Value = "ACBS")]
    BaseStats,

    [EnumMember(Value = "CNAM")]
    Class,

    [EnumMember(Value = "ECOR")]
    CombatOverridePackageList,

    [EnumMember(Value = "ZNAM")]
    CombatStyle,

    [EnumMember(Value = "ACBS.F")]
    ConfigurationFlags,

    [EnumMember(Value = "CRIF")]
    CrimeFaction,

    [EnumMember(Value = "INAM")]
    DeathItem,

    [EnumMember(Value = "DOFT")]
    DefaultOutfit,

    [EnumMember(Value = "DPLT")]
    DefaultPackageList,

    [EnumMember(Value = "DEST")]
    DestructionData,

    [EnumMember(Value = "NAM9")]
    FaceMorphs,

    [EnumMember(Value = "NAMA")]
    FaceParts,

    [EnumMember(Value = "FTST")]
    FaceTextureSet,

    [EnumMember(Value = "SNAM")]
    Faction,

    [EnumMember(Value = "FULL")]
    FullName,

    [EnumMember(Value = "GNAM")]
    GiftFilter,

    [EnumMember(Value = "GWOR")]
    GuardWarnOverridePackageList,

    [EnumMember(Value = "PNAM")]
    HeadParts,

    [EnumMember(Value = "HCLF")]
    HairColor,

    [EnumMember(Value = "NAM6")]
    Height,

    [EnumMember(Value = "KWDA")]
    Keywords,

    [EnumMember(Value = "OCOR")]
    ObserveDeadBodyOverridePackageList,

    [EnumMember(Value = "PRKR")]
    Perks,

    [EnumMember(Value = "RNAM")]
    Race,

    [EnumMember(Value = "VMAD")]
    ScriptInfo,

    [EnumMember(Value = "SHRT")]
    ShortName,

    [EnumMember(Value = "DNAM")]
    Skills,

    [EnumMember(Value = "QNAM")]
    SkinTone,

    [EnumMember(Value = "SOFT")]
    SleepOutfit,

    [EnumMember(Value = "NAM8")]
    SoundLevel,

    [EnumMember(Value = "CSDT")]
    SoundType,

    [EnumMember(Value = "SPOR")]
    SpectatorOverridePackageList,

    [EnumMember(Value = "SPLO")]
    Spells,

    [EnumMember(Value = "TPLT")]
    Template,

    [EnumMember(Value = "TINI")]
    TintLayers,

    [EnumMember(Value = "VTCK")]
    VoiceType,

    [EnumMember(Value = "NAM7")]
    Weight,

    [EnumMember(Value = "WNAM")]
    WornArmor,
}
