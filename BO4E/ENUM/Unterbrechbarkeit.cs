using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Stromverbrauchsart/Unterbrechbarkeit Marktlokation</summary>
public enum Unterbrechbarkeit
{
    /// <summary>Z62: unterbrechbare Verbrauchseinrichtung</summary>
    [EnumMember(Value = "UV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UV")]
    UV,

    /// <summary>Z63: nicht unterbrechbare Verbrauchseinrichtung</summary>
    [EnumMember(Value = "NUV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NUV")]
    NUV,
}
