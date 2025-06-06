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

    /// <summary>Netzlokation</summary>
    [EnumMember(Value = "NELO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NELO")]
    NELO,
    /// <summary>Steuerbare Ressource</summary>
    [EnumMember(Value = "SR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SR")]
    SR,
    
    /// <summary>Technische Ressource</summary>
    [EnumMember(Value = "TR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TR")]
    TR,
}
