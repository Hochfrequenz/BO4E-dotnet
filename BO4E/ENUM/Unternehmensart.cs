using ProtoBuf;

namespace BO4E.ENUM;

using System.Runtime.Serialization;

/// <summary>
/// kategorisiert Unternehmen nach Ihrer Marktrolle (basierend auf dem PARTIN-Datenmodell)
/// </summary>
public enum Unternehmensart
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [EnumMember(Value = "LIEFERANT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEFERANT")]
    [ProtoEnum(Name = nameof(Unternehmensart) + "_" + nameof(LIEFERANT))]
    LIEFERANT,

    [EnumMember(Value = "NETZBETREIBER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NETZBETREIBER")]
    [ProtoEnum(Name = nameof(Unternehmensart) + "_" + nameof(NETZBETREIBER))]
    NETZBETREIBER,

    [EnumMember(Value = "MESSSTELLENBETREIBER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MESSSTELLENBETREIBER")]
    [ProtoEnum(Name = nameof(Unternehmensart) + "_" + nameof(NETZBETREIBER))]
    MESSSTELLENBETREIBER,

    [EnumMember(Value = "ÜBERTRAGUNGSNETZBETREIBER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ÜBERTRAGUNGSNETZBETREIBER")]
    [ProtoEnum(Name = nameof(Unternehmensart) + "_" + nameof(ÜBERTRAGUNGSNETZBETREIBER))]
    ÜBERTRAGUNGSNETZBETREIBER,

    [EnumMember(Value = "BILANZKOORDINATOR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZKOORDINATOR")]
    [ProtoEnum(Name = nameof(Unternehmensart) + "_" + nameof(BILANZKOORDINATOR))]
    BILANZKOORDINATOR,

    [EnumMember(Value = "BILANZKREISVERANTWORTLICHER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZKREISVERANTWORTLICHER")]
    [ProtoEnum(Name = nameof(Unternehmensart) + "_" + nameof(BILANZKREISVERANTWORTLICHER))]
    BILANZKREISVERANTWORTLICHER,

    [EnumMember(Value = "ENERGIESERVICEANBIETER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIESERVICEANBIETER")]
    [ProtoEnum(Name = nameof(Unternehmensart) + "_" + nameof(ENERGIESERVICEANBIETER))]
    ENERGIESERVICEANBIETER,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
