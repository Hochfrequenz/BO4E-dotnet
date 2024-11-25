using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Mit dieser Aufzählung kann zwischen den Bilanzierungsmethoden bzw. -Grundlagen unterschieden werden.</summary>
public enum Bilanzierungsmethode
{
    /// <summary>Registrierende Leistungsmessung</summary>
    [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(RLM))]
    [EnumMember(Value = "RLM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RLM")]
    RLM,

    /// <summary>Standard Lastprofil</summary>
    [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(SLP))]
    [EnumMember(Value = "SLP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SLP")]
    SLP,

    /// <summary>TLP gemeinsame Messung</summary>
    [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(TLP_GEMEINSAM))]
    [EnumMember(Value = "TLP_GEMEINSAM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TLP_GEMEINSAM")]
    TLP_GEMEINSAM,

    /// <summary>TLP getrennte Messung</summary>
    [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(TLP_GETRENNT))]
    [EnumMember(Value = "TLP_GETRENNT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TLP_GETRENNT")]
    TLP_GETRENNT,

    /// <summary>Pauschale Betrachtung (Band)</summary>
    [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(PAUSCHAL))]
    [EnumMember(Value = "PAUSCHAL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PAUSCHAL")]
    PAUSCHAL,

    /// <summary>
    ///     intelligentes Messsystem / Smart Meter
    /// </summary>
    [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(IMS))]
    [EnumMember(Value = "IMS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IMS")]
    IMS,
}
