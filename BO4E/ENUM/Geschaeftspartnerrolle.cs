using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Diese Rollen kann ein Geschäftspartner einnehmen.</summary>
public enum Geschaeftspartnerrolle
{
    /// <summary>Lieferant</summary>
    [ProtoEnum(Name = nameof(Geschaeftspartnerrolle) + "_" + nameof(LIEFERANT))]
    [EnumMember(Value = "LIEFERANT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEFERANT")]
    LIEFERANT,

    /// <summary>Dienstleister</summary>
    [ProtoEnum(Name = nameof(Geschaeftspartnerrolle) + "_" + nameof(DIENSTLEISTER))]
    [EnumMember(Value = "DIENSTLEISTER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DIENSTLEISTER")]
    DIENSTLEISTER,

    /// <summary>Kunde</summary>
    [ProtoEnum(Name = nameof(Geschaeftspartnerrolle) + "_" + nameof(KUNDE))]
    [EnumMember(Value = "KUNDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KUNDE")]
    KUNDE,

    /// <summary>Interessent</summary>
    [ProtoEnum(Name = nameof(Geschaeftspartnerrolle) + "_" + nameof(INTERESSENT))]
    [EnumMember(Value = "INTERESSENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INTERESSENT")]
    INTERESSENT,

    /// <summary>Marktpartner</summary>
    [ProtoEnum(Name = nameof(Geschaeftspartnerrolle) + "_" + nameof(MARKTPARTNER))]
    [EnumMember(Value = "MARKTPARTNER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MARKTPARTNER")]
    MARKTPARTNER,
}
