using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Gibt an, ob es sich um eine Markt- oder Messlokation handelt.</summary>
public enum Lokationstyp
{
    /// <summary>Marktlokation</summary>
    [EnumMember(Value = "MALO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MALO")]
    MALO,

    /// <summary>Messlokation</summary>
    [EnumMember(Value = "MELO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MELO")]
    MELO,
}
