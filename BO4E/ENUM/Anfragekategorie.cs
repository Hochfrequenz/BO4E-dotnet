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
    PROZESSDATENBERICHT,

    /// <summary>GERAETEUEBERNAHME</summary>
    /// <remarks>Z10</remarks>
    [EnumMember(Value = "GERAETEUEBERNAHME")]
    GERAETEUEBERNAHME,

    /// <summary>WEITERVERPFLICHTUNG_BETRIEB_MELO</summary>
    /// <remarks>Z11</remarks>
    [EnumMember(Value = "WEITERVERPFLICHTUNG_BETRIEB_MELO")]
    WEITERVERPFLICHTUNG_BETRIEB_MELO,

    /// <summary>AENDERUNG_MELO</summary>
    /// <remarks>Z12</remarks>
    [EnumMember(Value = "AENDERUNG_MELO")]
    AENDERUNG_MELO,

    /// <summary>STAMMDATEN_MALO_ODER_MELO</summary>
    /// <remarks>Z14</remarks>
    [EnumMember(Value = "STAMMDATEN_MALO_ODER_MELO")]
    STAMMDATEN_MALO_ODER_MELO,

    /// <summary>BILANZIERTE_MENGE_MEHR_MINDER_MENGEN</summary>
    /// <remarks>Z23</remarks>
    [EnumMember(Value = "BILANZIERTE_MENGE_MEHR_MINDER_MENGEN")]
    BILANZIERTE_MENGE_MEHR_MINDER_MENGEN,

    /// <summary>ALLOKATIONSLISTE_MEHR_MINDER_MENGEN</summary>
    /// <remarks>Z24</remarks>
    [EnumMember(Value = "ALLOKATIONSLISTE_MEHR_MINDER_MENGEN")]
    ALLOKATIONSLISTE_MEHR_MINDER_MENGEN,

    /// <summary>ENERGIEMENGE_UND_LEISTUNGSMAXIMUM</summary>
    /// <remarks>Z28</remarks>
    [EnumMember(Value = "ENERGIEMENGE_UND_LEISTUNGSMAXIMUM")]
    ENERGIEMENGE_UND_LEISTUNGSMAXIMUM,

    /// <summary>ABRECHNUNG_MESSSTELLENBETRIEB_MSB_AN_LF</summary>
    /// <remarks>Z29</remarks>
    [EnumMember(Value = "ABRECHNUNG_MESSSTELLENBETRIEB_MSB_AN_LF")]
    ABRECHNUNG_MESSSTELLENBETRIEB_MSB_AN_LF,

    /// <summary> AENDERUNG_PROGNOSEGRUNDLAGE_GERAETEKONFIGURATION</summary>
    /// <remarks>Z30</remarks>
    [EnumMember(Value = "AENDERUNG_PROGNOSEGRUNDLAGE_GERAETEKONFIGURATION")]
    AENDERUNG_PROGNOSEGRUNDLAGE_GERAETEKONFIGURATION,

    /// <summary> AENDERUNG_GERAETEKONFIGURATION</summary>
    /// <remarks>Z31</remarks>
    [EnumMember(Value = "AENDERUNG_GERAETEKONFIGURATION")]
    AENDERUNG_GERAETEKONFIGURATION,

    /// <summary> REKLAMATION_VON_WERTEN</summary>
    /// <remarks>Z34</remarks>
    [EnumMember(Value = "REKLAMATION_VON_WERTEN")]
    REKLAMATION_VON_WERTEN,

    /// <summary>LASTGANG_MALO_TRANCHE</summary>
    /// <remarks>Z48</remarks>
    [EnumMember(Value = "LASTGANG_MALO_TRANCHE")]
    LASTGANG_MALO_TRANCHE,

    /// <summary>SPERRUNG</summary>
    /// <remarks>Z51</remarks>
    [ProtoEnum(Name = "Anfragekategorie_SPERRUNG")]
    [EnumMember(Value = "SPERRUNG")]
    SPERRUNG,

    /// <summary>ENTSPERRUNG</summary>
    /// <remarks>Z52</remarks>
    [ProtoEnum(Name = "Anfragekategorie_ENTSPERRUNG")]
    [EnumMember(Value = "ENTSPERRUNG")]
    ENTSPERRUNG,
}
