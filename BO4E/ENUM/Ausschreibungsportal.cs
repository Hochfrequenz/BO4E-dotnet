#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Aufzählung der unterstützten Ausschreibungsportale.</summary>
public enum Ausschreibungsportal
{
    /// <summary>enPORTAL</summary>
    [EnumMember(Value = "ENPORTAL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENPORTAL")]
    ENPORTAL,

    /// <summary>Energie Argentur.NRW</summary>
    [EnumMember(Value = "ENERGIE_AGENTUR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIE_AGENTUR")]
    ENERGIE_AGENTUR,

    /// <summary>BMWI-Ausschreibungen</summary>
    [EnumMember(Value = "BMWI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BMWI")]
    BMWI,

    /// <summary>energie-handelsplatz.de</summary>
    [EnumMember(Value = "ENERGIE_HANDELSPLATZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIE_HANDELSPLATZ")]
    ENERGIE_HANDELSPLATZ,

    /// <summary>BUND.DE</summary>
    [EnumMember(Value = "BUND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BUND")]
    BUND,

    /// <summary>vera_online.de</summary>
    [EnumMember(Value = "VERA_ONLINE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERA_ONLINE")]
    VERA_ONLINE,

    /// <summary>ispex.de</summary>
    [EnumMember(Value = "ISPEX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ISPEX")]
    ISPEX,

    /// <summary>energiemarktplatz.de</summary>
    [EnumMember(Value = "ENERGIEMARKTPLATZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIEMARKTPLATZ")]
    ENERGIEMARKTPLATZ,

    /// <summary>evergabe.de</summary>
    [EnumMember(Value = "EVERGABE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EVERGABE")]
    EVERGABE,

    /// <summary>dtad.de</summary>
    [EnumMember(Value = "DTAD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DTAD")]
    DTAD,
}
