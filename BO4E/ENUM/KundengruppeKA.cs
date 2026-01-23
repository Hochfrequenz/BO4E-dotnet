#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Eine Aufzählung zur Einordnung für die Höhe der Konzessionsabgabe.</summary>
public enum KundengruppeKA
{
    /// <summary>Strom</summary>
    [EnumMember(Value = "S_TARIF_25000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("S_TARIF_25000")]
    S_TARIF_25000,

    /// <summary>Strom</summary>
    [EnumMember(Value = "S_TARIF_100000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("S_TARIF_100000")]
    S_TARIF_100000,

    /// <summary>Strom</summary>
    [EnumMember(Value = "S_TARIF_500000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("S_TARIF_500000")]
    S_TARIF_500000,

    /// <summary>Strom</summary>
    [EnumMember(Value = "S_TARIF_G_500000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("S_TARIF_G_500000")]
    S_TARIF_G_500000,

    /// <summary>Strom</summary>
    [EnumMember(Value = "S_SONDERKUNDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("S_SONDERKUNDE")]
    S_SONDERKUNDE,

    /// <summary>Gas</summary>
    [EnumMember(Value = "G_KOWA_25000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("G_KOWA_25000")]
    G_KOWA_25000,

    /// <summary>Gas</summary>
    [EnumMember(Value = "G_KOWA_100000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("G_KOWA_100000")]
    G_KOWA_100000,

    /// <summary>Gas</summary>
    [EnumMember(Value = "G_KOWA_500000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("G_KOWA_500000")]
    G_KOWA_500000,

    /// <summary>Gas</summary>
    [EnumMember(Value = "G_KOWA_G_500000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("G_KOWA_G_500000")]
    G_KOWA_G_500000,

    /// <summary>Gas</summary>
    [EnumMember(Value = "G_TARIF_25000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("G_TARIF_25000")]
    G_TARIF_25000,

    /// <summary>Gas</summary>
    [EnumMember(Value = "G_TARIF_100000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("G_TARIF_100000")]
    G_TARIF_100000,

    /// <summary>Gas</summary>
    [EnumMember(Value = "G_TARIF_500000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("G_TARIF_500000")]
    G_TARIF_500000,

    /// <summary>Gas</summary>
    [EnumMember(Value = "G_TARIF_G_500000")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("G_TARIF_G_500000")]
    G_TARIF_G_500000,

    /// <summary>Gas</summary>
    [EnumMember(Value = "G_SONDERKUNDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("G_SONDERKUNDE")]
    G_SONDERKUNDE,

    /// <summary>beides</summary>
    [EnumMember(Value = "SONDER_KAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONDER_KAS")]
    SONDER_KAS,

    /// <summary>beides</summary>
    [EnumMember(Value = "SONDER_SAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONDER_SAS")]
    SONDER_SAS,

    /// <summary>beides</summary>
    [EnumMember(Value = "SONDER_TAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONDER_TAS")]
    SONDER_TAS,

    /// <summary>Gas</summary>
    [EnumMember(Value = "SONDER_TKS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONDER_TKS")]
    SONDER_TKS,

    /// <summary>Strom</summary>
    [EnumMember(Value = "SONDER_TSS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONDER_TSS")]
    SONDER_TSS,
}
