#nullable enable
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Abbildung verschiedener in der INVOIC angegebenen Rechnungstypen.</summary>
public enum NNRechnungstyp
{
    /// <summary>Abschlagsrechnung</summary>
    [ProtoEnum(Name = nameof(NNRechnungstyp) + "_" + nameof(ABSCHLAGSRECHNUNG))]
    [EnumMember(Value = "ABSCHLAGSRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABSCHLAGSRECHNUNG")]
    ABSCHLAGSRECHNUNG,

    /// <summary>Turnusrechnung</summary>
    [ProtoEnum(Name = nameof(NNRechnungstyp) + "_" + nameof(TURNUSRECHNUNG))]
    [EnumMember(Value = "TURNUSRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TURNUSRECHNUNG")]
    TURNUSRECHNUNG,

    /// <summary>Monatsrechnung</summary>
    [ProtoEnum(Name = nameof(NNRechnungstyp) + "_" + nameof(MONATSRECHNUNG))]
    [EnumMember(Value = "MONATSRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MONATSRECHNUNG")]
    MONATSRECHNUNG,

    /// <summary>Rechnung für WiM</summary>
    [ProtoEnum(Name = nameof(NNRechnungstyp) + "_" + nameof(WIMRECHNUNG))]
    [EnumMember(Value = "WIMRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WIMRECHNUNG")]
    WIMRECHNUNG,

    /// <summary>Zwischenrechnung</summary>
    [ProtoEnum(Name = nameof(NNRechnungstyp) + "_" + nameof(ZWISCHENRECHNUNG))]
    [EnumMember(Value = "ZWISCHENRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZWISCHENRECHNUNG")]
    ZWISCHENRECHNUNG,

    /// <summary>Integrierte 13. Rechnung</summary>
    [ProtoEnum(Name = nameof(NNRechnungstyp) + "_" + nameof(INTEGRIERTE_13TE_RECHNUNG))]
    [EnumMember(Value = "INTEGRIERTE_13TE_RECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INTEGRIERTE_13TE_RECHNUNG")]
    INTEGRIERTE_13TE_RECHNUNG,

    /// <summary>13. Rechnung</summary>
    [ProtoEnum(Name = nameof(NNRechnungstyp) + "_" + nameof(_13TE_RECHNUNG))]
    [EnumMember(Value = "_13TE_RECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("_13TE_RECHNUNG")]
    _13TE_RECHNUNG,

    /// <summary>Mehr/Mindermengenabrechnung</summary>
    [ProtoEnum(Name = nameof(NNRechnungstyp) + "_" + nameof(MEHRMINDERMENGENRECHNUNG))]
    [EnumMember(Value = "MEHRMINDERMENGENRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MEHRMINDERMENGENRECHNUNG")]
    MEHRMINDERMENGENRECHNUNG,
}
