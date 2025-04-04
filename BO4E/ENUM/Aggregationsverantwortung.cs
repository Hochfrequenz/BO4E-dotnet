using System.Runtime.Serialization;
using BO4E.meta;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Mögliche Qualifier für die Aggregationsverantwortung</summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum Aggregationsverantwortung
{
    /// <summary>Übertragungsnetzbetreiber</summary>
    [ProtoEnum(Name = nameof(Aggregationsverantwortung) + "_" + nameof(UENB))]
    [EnumMember(Value = "UENB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UENB")]
    UENB,

    /// <summary>Netzbetreiber</summary>
    [ProtoEnum(Name = nameof(Aggregationsverantwortung) + "_" + nameof(VNB))]
    [EnumMember(Value = "VNB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VNB")]
    VNB,
}
