#nullable enable
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Der Preis, auf den sich ein Auf- oder Abschlag bezieht.</summary>
public enum AufAbschlagsziel
{
    /// <summary>Auf/Abschlag auf den Arbeitspreis HT</summary>
    [ProtoEnum(Name = nameof(AufAbschlagsziel) + "_" + nameof(ARBEITSPREIS_HT))]
    [EnumMember(Value = "ARBEITSPREIS_HT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ARBEITSPREIS_HT")]
    ARBEITSPREIS_HT,

    /// <summary>Auf/Abschlag auf den Arbeitspreis NT</summary>
    [ProtoEnum(Name = nameof(AufAbschlagsziel) + "_" + nameof(ARBEITSPREIS_NT))]
    [EnumMember(Value = "ARBEITSPREIS_NT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ARBEITSPREIS_NT")]
    ARBEITSPREIS_NT,

    /// <summary>Auf/Abschlag auf den Arbeitspreis HT und NT</summary>
    [ProtoEnum(Name = nameof(AufAbschlagsziel) + "_" + nameof(ARBEITSPREIS_HT_NT))]
    [EnumMember(Value = "ARBEITSPREIS_HT_NT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ARBEITSPREIS_HT_NT")]
    ARBEITSPREIS_HT_NT,

    /// <summary>Auf/Abschlag auf den Grundpreis</summary>
    [ProtoEnum(Name = nameof(AufAbschlagsziel) + "_" + nameof(GRUNDPREIS))]
    [EnumMember(Value = "GRUNDPREIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUNDPREIS")]
    GRUNDPREIS,

    /// <summary>Auf/Abschlag auf den Gesamtpreis</summary>
    [ProtoEnum(Name = nameof(AufAbschlagsziel) + "_" + nameof(GESAMTPREIS))]
    [EnumMember(Value = "GESAMTPREIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GESAMTPREIS")]
    GESAMTPREIS,
}
