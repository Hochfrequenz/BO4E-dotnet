using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Aufzählung für die Typisierung von Ausschreibungen.</summary>
public enum Ausschreibungstyp
{
    /// <summary>öffentlich-rechtlich</summary>
    [EnumMember(Value = "OEFFENTLICHRECHTLICH")]
    OEFFENTLICHRECHTLICH,

    /// <summary>Europaweit</summary>
    [EnumMember(Value = "EUROPAWEIT")]
    EUROPAWEIT
}
