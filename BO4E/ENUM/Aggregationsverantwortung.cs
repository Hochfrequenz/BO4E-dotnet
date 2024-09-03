using BO4E.meta;
using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Mögliche Qualifier für die Aggregationsverantwortung</summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum Aggregationsverantwortung
{
    /// <summary>Übertragungsnetzbetreiber</summary>
    [ProtoEnum(Name = nameof(Aggregationsverantwortung) + "_" + nameof(UENB))]
    [EnumMember(Value = "UENB")]
    UENB,

    /// <summary>Netzbetreiber</summary>
    [ProtoEnum(Name = nameof(Aggregationsverantwortung) + "_" + nameof(VNB))]
    [EnumMember(Value = "VNB")]
    VNB
}