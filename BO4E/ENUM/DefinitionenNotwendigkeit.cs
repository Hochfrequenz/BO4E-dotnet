using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// Beschreibt, ob Definitionen notwendig sind
/// </summary>
/// <remarks>Entspricht dem UTILTS SG5+STS Datenelement 4405 "Status der Nutzung von Definitionen"</remarks>
public enum DefinitionenNotwendigkeit
{
    /// <summary>
    /// Zählzeitdefinitionen werden verwendet 
    /// </summary>
    /// <remarks>Z02</remarks>
    [EnumMember(Value = "ZAEHLZEITDEFINITIONEN_WERDEN_VERWENDET")]
    ZAEHLZEITDEFINITIONEN_WERDEN_VERWENDET,
    /// <summary>
    /// Zählzeitdefinitionen werden nicht verwendet
    /// </summary>
    /// <remarks>Z03</remarks>
    [EnumMember(Value = "ZAEHLZEITDEFINITIONEN_WERDEN_NICHT_VERWENDET")]
    ZAEHLZEITDEFINITIONEN_WERDEN_NICHT_VERWENDET,

    /// <summary>
    /// Definitionen werden verwendet 
    /// </summary>
    /// <remarks>Z45</remarks>
    [EnumMember(Value = "DEFINITIONEN_WERDEN_VERWENDET")]
    DEFINITIONEN_WERDEN_VERWENDET,
    /// <summary>
    /// Definitionen werden nicht verwendet
    /// </summary>
    /// <remarks>Z46</remarks>
    [EnumMember(Value = "DEFINITIONEN_WERDEN_NICHT_VERWENDET")]
    DEFINITIONEN_WERDEN_NICHT_VERWENDET,
}
