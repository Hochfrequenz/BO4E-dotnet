using System.Runtime.Serialization;

using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Grund der Privilegierung nach EnFG (UTILMD Strom)
/// </summary>
[NonOfficial(NonOfficialCategory.MISSING)]
public enum GrundDerPrivilegierungNachEnFG
{
    /// <summary> § 21 EnFG Stromspeicher und Verlustenergie </summary>
    /// <remarks>ZU5</remarks>
    [EnumMember(Value = "STROMSPEICHER_UND_VERLUSTENERGIE")]
    STROMSPEICHER_UND_VERLUSTENERGIE,

    /// <summary> § 22 EnFG elektrisch angetriebene Wärmepumpen </summary>
    /// <remarks>ZU6</remarks>
    [EnumMember(Value = "ELEKTRISCH_ANGETRIEBENE_WAERMEPUMPEN")]
    ELEKTRISCH_ANGETRIEBENE_WAERMEPUMPEN,

    /// <summary> § 23 EnFG Umlageerhebung bei Anlagen zur Verstromung von Kuppelgasen </summary>
    /// <remarks>ZU7</remarks>
    [EnumMember(Value = "UMLAGEERHEBUNG_BEI_ANLAGEN_ZUR_VERSTROMUNG_VON_KUPPELGASEN")]
    UMLAGEERHEBUNG_BEI_ANLAGEN_ZUR_VERSTROMUNG_VON_KUPPELGASEN,

    /// <summary> § 24 EnFG Herstellung von Grünen Wasserstoff </summary>
    /// <remarks>ZU8</remarks>
    [EnumMember(Value = "HERSTELLUNG_VON_GRUENEN_WASSERSTOFF")]
    HERSTELLUNG_VON_GRUENEN_WASSERSTOFF,

    /// <summary> §§ 30 - 35 EnFG stromkostenintensive Unternehmen </summary>
    /// <remarks>ZU9</remarks>
    [EnumMember(Value = "STROMKOSTENINTENSIVE_UNTERNEHMEN")]
    STROMKOSTENINTENSIVE_UNTERNEHMEN,

    /// <summary> § 36 EnFG Herstellung von Wasserstoff in stromkostenintensiven Unternehmen </summary>
    /// <remarks>ZV0</remarks>
    [EnumMember(Value = "HERSTELLUNG_VON_WASSERSTOFF_IN_STROMKOSTENINTENSIVEN_UNTERNEHMEN")]
    HERSTELLUNG_VON_WASSERSTOFF_IN_STROMKOSTENINTENSIVEN_UNTERNEHMEN,

    /// <summary> § 37 EnFG Schienenbahnen </summary>
    /// <remarks>ZV1</remarks>
    [EnumMember(Value = "SCHIENENBAHNEN")]
    SCHIENENBAHNEN,

    /// <summary> § 38 EnFG elektrische betriebene Bussen im Linienverkehr </summary>
    /// <remarks>ZV2</remarks>
    [EnumMember(Value = "ELEKTRISCHE_BETRIEBENE_BUSSEN_IM_LINIENVERKEHR")]
    ELEKTRISCHE_BETRIEBENE_BUSSEN_IM_LINIENVERKEHR,

    /// <summary> § 39 EnFG Landstromanlagen </summary>
    /// <remarks>ZV3</remarks>
    [EnumMember(Value = "LANDSTROMANLAGEN")]
    LANDSTROMANLAGEN,
}