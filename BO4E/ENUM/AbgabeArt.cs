using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Schwachlastfähigkeit Marktlokation</summary>
public enum AbgabeArt
{
    /// <summary>
    ///     KAS: für alle konzessionsvertraglichen Sonderregelungen, die nicht in die Systematik der KAV eingegliedert
    ///     sind
    /// </summary>
    [EnumMember(Value = "KAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KAS")]
    KAS,

    /// <summary>SA: Sondervertragskunden  1 kV, Preis nach § 2 (3) (für Strom 0,11 ct/kWh und für Gas 0,03 ct/kWh)</summary>
    [EnumMember(Value = "SA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SA")]
    SA,

    /// <summary>SAS: Kennzeichnung, dass ein abweichender Preis für Sondervertragskunden vorliegt</summary>
    [EnumMember(Value = "SAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SAS")]
    SAS,

    /// <summary>TA: Tarifkunden, für Strom § 2. (2) 1b HT bzw.ET(hohe KA) und für Gas § 2 (2) 2b</summary>
    [EnumMember(Value = "TA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TA")]
    TA,

    /// <summary>TAS: Kennzeichnung, dass ein abweichender Preis für Tarifkunden vorliegt</summary>
    [EnumMember(Value = "TAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TAS")]
    TAS,

    /// <summary>TK: für Gas nach KAV § 2 (2) 2a bei ausschließlicher Nutzung zum Kochen und Warmwassererzeugung</summary>
    [EnumMember(Value = "TK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TK")]
    TK,

    /// <summary>TKS: Kennzeichnung, wenn nach KAV § 2 (2) 2a ein anderen Preis zu verwenden ist</summary>
    [EnumMember(Value = "TKS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TKS")]
    TKS,

    /// <summary>TS: für Strom mit Schwachlast § 2. (2) 1a NT(niedrige KA, 0,61 ct/kWh)</summary>
    [EnumMember(Value = "TS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TS")]
    TS,

    /// <summary>TSS: Kennzeichnung, dass ein abweichender Preis für Schwachlast angewendet wird</summary>
    [EnumMember(Value = "TSS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TSS")]
    TSS,
}
