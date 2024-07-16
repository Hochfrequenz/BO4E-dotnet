using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Aufzählung der unterstützten Ausschreibungsportale.</summary>
public enum Ausschreibungsportal
{
    /// <summary>enPORTAL</summary>
    [EnumMember(Value = "ENPORTAL")]
    ENPORTAL,

    /// <summary>Energie Argentur.NRW</summary>
    [EnumMember(Value = "ENERGIE_AGENTUR")]
    ENERGIE_AGENTUR,

    /// <summary>BMWI-Ausschreibungen</summary>
    [EnumMember(Value = "BMWI")]
    BMWI,

    /// <summary>energie-handelsplatz.de</summary>
    [EnumMember(Value = "ENERGIE_HANDELSPLATZ")]
    ENERGIE_HANDELSPLATZ,

    /// <summary>BUND.DE</summary>
    [EnumMember(Value = "BUND")]
    BUND,

    /// <summary>vera_online.de</summary>
    [EnumMember(Value = "VERA_ONLINE")]
    VERA_ONLINE,

    /// <summary>ispex.de</summary>
    [EnumMember(Value = "ISPEX")]
    ISPEX,

    /// <summary>energiemarktplatz.de</summary>
    [EnumMember(Value = "ENERGIEMARKTPLATZ")]
    ENERGIEMARKTPLATZ,

    /// <summary>evergabe.de</summary>
    [EnumMember(Value = "EVERGABE")]
    EVERGABE,

    /// <summary>dtad.de</summary>
    [EnumMember(Value = "DTAD")]
    DTAD
}
