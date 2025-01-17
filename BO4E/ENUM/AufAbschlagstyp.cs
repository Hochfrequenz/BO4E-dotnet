using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Festlegung, ob der Auf- oder Abschlag mit relativen oder absoluten Werten erfolgt.</summary>
public enum AufAbschlagstyp
{
    /// <summary>prozentualer AufAbschlag</summary>
    [EnumMember(Value = "RELATIV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RELATIV")]
    RELATIV,

    /// <summary>Absoluter AufAbschlag</summary>
    [EnumMember(Value = "ABSOLUT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABSOLUT")]
    ABSOLUT,
}
