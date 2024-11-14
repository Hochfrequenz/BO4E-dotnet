using System.Runtime.Serialization;
using BO4E.meta;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Mögliche Qualifier für die Aggregationsverantwortung</summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum BezeichnungSummenzeitreihe
{
    /// <summary>BG-SZR Kategorie B (Z95)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(BG_SZR_B))]
    [EnumMember(Value = "BG_SZR_B")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BG_SZR_B")]
    BG_SZR_B,

    /// <summary>BG-SZR Kategorie C (Z96)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(BG_SZR_C))]
    [EnumMember(Value = "BG_SZR_C")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BG_SZR_C")]
    BG_SZR_C,

    /// <summary>BK-SZR Kategorie A (Z97)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(BK_SZR_A))]
    [EnumMember(Value = "BK_SZR_A")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BK_SZR_A")]
    BK_SZR_A,

    /// <summary>BK-SZR Kategorie B Ebene Regelzone (Z98)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(BK_SZR_B_RZ))]
    [EnumMember(Value = "BK_SZR_B_RZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BK_SZR_B_RZ")]
    BK_SZR_B_RZ,

    /// <summary>BK-SZR Kategorie B Ebene Bilanzierungsgebiet (Z99)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(BK_SZR_B_BG))]
    [EnumMember(Value = "BK_SZR_B_BG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BK_SZR_B_BG")]
    BK_SZR_B_BG,

    /// <summary>BK-SZR Kategorie C (ZA0)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(BK_SZR_C))]
    [EnumMember(Value = "BK_SZR_C")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BK_SZR_C")]
    BK_SZR_C,

    /// <summary>LF-SZR Kategorie A (ZA1)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(LF_SZR_A))]
    [EnumMember(Value = "LF_SZR_A")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LF_SZR_A")]
    LF_SZR_A,

    /// <summary>LF-SZR Kategorie B Ebene Regelzone (ZA2)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(LF_SZR_B_RZ))]
    [EnumMember(Value = "LF_SZR_B_RZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LF_SZR_B_RZ")]
    LF_SZR_B_RZ,

    /// <summary>LF-SZR Kategorie B Ebene Bilanzierungsgebiet (ZA3)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(LF_SZR_B_BG))]
    [EnumMember(Value = "LF_SZR_B_BG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LF_SZR_B_BG")]
    LF_SZR_B_BG,

    /// <summary>Deltazeitreihe (ZA4)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(DZUE))]
    [EnumMember(Value = "DZUE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DZUE")]
    DZUE,

    /// <summary>Netzzeitreihe (ZA5)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(NZR))]
    [EnumMember(Value = "NZR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NZR")]
    NZR,

    /// <summary>Abrechnungssummenzeitreih (ZA6)</summary>
    [ProtoEnum(Name = nameof(BezeichnungSummenzeitreihe) + "_" + nameof(ASZR))]
    [EnumMember(Value = "ASZR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ASZR")]
    ASZR,
}
