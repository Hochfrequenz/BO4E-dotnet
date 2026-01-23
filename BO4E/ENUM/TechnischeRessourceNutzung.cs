#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Art und Nutzung der Technischen Ressource</summary>
public enum TechnischeRessourceNutzung
{
    /// <summary>Z17: Stromverbrauchsart</summary>
    [EnumMember(Value = "STROMVERBRAUCHSART")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STROMVERBRAUCHSART")]
    STROMVERBRAUCHSART,

    /// <summary>Z50: Stromerzeugungsart</summary>
    [EnumMember(Value = "STROMERZEUGUNGSART")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STROMERZEUGUNGSART")]
    STROMERZEUGUNGSART,

    /// <summary>Z56: Speicher</summary>
    [EnumMember(Value = "SPEICHER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SPEICHER")]
    SPEICHER,
}
