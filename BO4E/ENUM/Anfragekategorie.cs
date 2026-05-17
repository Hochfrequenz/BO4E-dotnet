using System.Runtime.Serialization;
using BO4E.meta;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>
/// Kategorie der Anfrage (ORDERS ORDRSP ORDCHG BGM 1001)
/// </summary>
[NonOfficial(NonOfficialCategory.MISSING)]
public enum Anfragekategorie
{
    /// <summary>PROZESSDATENBERICHT</summary>
    /// <remarks>7</remarks>
    [EnumMember(Value = "PROZESSDATENBERICHT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PROZESSDATENBERICHT")]
    PROZESSDATENBERICHT,

    /// <summary>GERAETEUEBERNAHME</summary>
    /// <remarks>Z10</remarks>
    [EnumMember(Value = "GERAETEUEBERNAHME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GERAETEUEBERNAHME")]
    GERAETEUEBERNAHME,

    /// <summary>WEITERVERPFLICHTUNG_BETRIEB_MELO</summary>
    /// <remarks>Z11</remarks>
    [EnumMember(Value = "WEITERVERPFLICHTUNG_BETRIEB_MELO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WEITERVERPFLICHTUNG_BETRIEB_MELO")]
    WEITERVERPFLICHTUNG_BETRIEB_MELO,

    /// <summary>AENDERUNG_MELO</summary>
    /// <remarks>Z12</remarks>
    [EnumMember(Value = "AENDERUNG_MELO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AENDERUNG_MELO")]
    AENDERUNG_MELO,

    /// <summary>STAMMDATEN_MALO_ODER_MELO</summary>
    /// <remarks>Z14</remarks>
    [EnumMember(Value = "STAMMDATEN_MALO_ODER_MELO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STAMMDATEN_MALO_ODER_MELO")]
    STAMMDATEN_MALO_ODER_MELO,

    /// <summary>BILANZIERTE_MENGE_MEHR_MINDER_MENGEN</summary>
    /// <remarks>Z23</remarks>
    [EnumMember(Value = "BILANZIERTE_MENGE_MEHR_MINDER_MENGEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "BILANZIERTE_MENGE_MEHR_MINDER_MENGEN"
    )]
    BILANZIERTE_MENGE_MEHR_MINDER_MENGEN,

    /// <summary>ALLOKATIONSLISTE_MEHR_MINDER_MENGEN</summary>
    /// <remarks>Z24</remarks>
    [EnumMember(Value = "ALLOKATIONSLISTE_MEHR_MINDER_MENGEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ALLOKATIONSLISTE_MEHR_MINDER_MENGEN")]
    ALLOKATIONSLISTE_MEHR_MINDER_MENGEN,

    /// <summary>ENERGIEMENGE_UND_LEISTUNGSMAXIMUM</summary>
    /// <remarks>Z28</remarks>
    [EnumMember(Value = "ENERGIEMENGE_UND_LEISTUNGSMAXIMUM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIEMENGE_UND_LEISTUNGSMAXIMUM")]
    ENERGIEMENGE_UND_LEISTUNGSMAXIMUM,

    /// <summary>ABRECHNUNG_MESSSTELLENBETRIEB_MSB_AN_LF</summary>
    /// <remarks>Z29</remarks>
    [EnumMember(Value = "ABRECHNUNG_MESSSTELLENBETRIEB_MSB_AN_LF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ABRECHNUNG_MESSSTELLENBETRIEB_MSB_AN_LF"
    )]
    ABRECHNUNG_MESSSTELLENBETRIEB_MSB_AN_LF,

    /// <summary> AENDERUNG_PROGNOSEGRUNDLAGE_GERAETEKONFIGURATION</summary>
    /// <remarks>Z30</remarks>
    [EnumMember(Value = "AENDERUNG_PROGNOSEGRUNDLAGE_GERAETEKONFIGURATION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "AENDERUNG_PROGNOSEGRUNDLAGE_GERAETEKONFIGURATION"
    )]
    AENDERUNG_PROGNOSEGRUNDLAGE_GERAETEKONFIGURATION,

    /// <summary> AENDERUNG_GERAETEKONFIGURATION</summary>
    /// <remarks>Z31</remarks>
    [EnumMember(Value = "AENDERUNG_GERAETEKONFIGURATION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AENDERUNG_GERAETEKONFIGURATION")]
    AENDERUNG_GERAETEKONFIGURATION,

    /// <summary> REKLAMATION_VON_WERTEN</summary>
    /// <remarks>Z34</remarks>
    [EnumMember(Value = "REKLAMATION_VON_WERTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REKLAMATION_VON_WERTEN")]
    REKLAMATION_VON_WERTEN,

    /// <summary>LASTGANG_MALO_TRANCHE</summary>
    /// <remarks>Z48</remarks>
    [EnumMember(Value = "LASTGANG_MALO_TRANCHE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LASTGANG_MALO_TRANCHE")]
    LASTGANG_MALO_TRANCHE,

    /// <summary>SPERRUNG</summary>
    /// <remarks>Z51</remarks>
    [ProtoEnum(Name = "Anfragekategorie_SPERRUNG")]
    [EnumMember(Value = "SPERRUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SPERRUNG")]
    SPERRUNG,

    /// <summary>ENTSPERRUNG</summary>
    /// <remarks>Z52</remarks>
    [ProtoEnum(Name = "Anfragekategorie_ENTSPERRUNG")]
    [EnumMember(Value = "ENTSPERRUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENTSPERRUNG")]
    ENTSPERRUNG,

    /// <summary>BESTELLUNG_AENDERUNG_MELO</summary>
    /// <remarks>Z93</remarks>
    [ProtoEnum(Name = "Anfragekategorie_BESTELLUNG_AENDERUNG_MELO")]
    [EnumMember(Value = "BESTELLUNG_AENDERUNG_MELO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BESTELLUNG_AENDERUNG_MELO")]
    BESTELLUNG_AENDERUNG_MELO,
}
