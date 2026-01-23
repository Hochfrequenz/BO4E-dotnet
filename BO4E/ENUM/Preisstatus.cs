using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Statusinformation für Preise</summary>
public enum Preisstatus
{
    /// <summary>
    ///     vorläufig
    /// </summary>
    [EnumMember(Value = "VORLAEUFIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VORLAEUFIG")]
    VORLAEUFIG,

    /// <summary>
    ///     endgültig
    /// </summary>
    [EnumMember(Value = "ENDGUELTIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENDGUELTIG")]
    ENDGUELTIG,
}
