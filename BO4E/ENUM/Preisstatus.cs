using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Statusinformation für Preise</summary>
public enum Preisstatus
{
    /// <summary>
    ///     vorläufig
    /// </summary>
    [EnumMember(Value = "VORLAEUFIG")]
    VORLAEUFIG,

    /// <summary>
    ///     endgültig
    /// </summary>
    [EnumMember(Value = "ENDGUELTIG")]
    ENDGUELTIG,
}