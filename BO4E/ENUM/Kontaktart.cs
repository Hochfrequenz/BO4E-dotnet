using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Art des Kontaktes zwischen Geschäftspartnern.</summary>
public enum Kontaktart
{
    /// <summary>Anschreiben</summary>
    [EnumMember(Value = "ANSCHREIBEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANSCHREIBEN")]
    ANSCHREIBEN,

    /// <summary>Telefonat</summary>
    [EnumMember(Value = "TELEFONAT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TELEFONAT")]
    TELEFONAT,

    /// <summary>Fax</summary>
    [EnumMember(Value = "FAX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FAX")]
    FAX,

    /// <summary>E-Mail</summary>
    [EnumMember(Value = "E_MAIL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("E_MAIL")]
    E_MAIL,

    /// <summary>SMS</summary>
    [EnumMember(Value = "SMS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SMS")]
    SMS,
}
