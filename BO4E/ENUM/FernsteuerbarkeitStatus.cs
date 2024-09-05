using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>
/// Status der Fernsteuerbarkeit einer Marktlokation gemäß den Vorgaben für die Direktvermarktung.
/// </summary>
[ProtoContract]
public enum FernsteuerbarkeitStatus
{
    /// <summary>
    /// Marktlokation ist technisch nicht fernsteuerbar.
    /// Der NB bestätigt mit der Anmeldung einer erzeugenden Marktlokation zur Direktvermarktung, dass die Anlage nicht mit einer Fernsteuerung ausgestattet ist und nicht fernsteuerbar ist. Die Voraussetzung zur Zahlung der Managementprämie für fernsteuerbare Anlagen ist nicht gegeben.
    /// </summary>
    /// <remarks>Z96</remarks>
    [ProtoEnum(Name = nameof(FernsteuerbarkeitStatus) + "_" + nameof(NICHT_FERNSTEUERBAR))]
    [EnumMember(Value = "NICHT_FERNSTEUERBAR")]
    NICHT_FERNSTEUERBAR,

    /// <summary>
    /// Marktlokation ist technisch fernsteuerbar.
    /// Der NB bestätigt mit der Anmeldung einer erzeugenden Marktlokation zur Direktvermarktung, dass die Marktlokation mit einer Fernsteuerung ausgestattet, aber dem NB keine Information darüber vorliegt, dass der LF die Marktlokation fernsteuern kann. Die Voraussetzung zur Zahlung der Managementprämie für fernsteuerbare Marktlokation ist nicht gegeben.
    /// </summary>
    /// <remarks>Z97</remarks>
    [ProtoEnum(Name = nameof(FernsteuerbarkeitStatus) + "_" + nameof(TECHNISCH_FERNSTEUERBAR))]
    [EnumMember(Value = "TECHNISCH_FERNSTEUERBAR")]
    TECHNISCH_FERNSTEUERBAR,

    /// <summary>
    /// Marktlokation ist durch den Lieferanten fernsteuerbar.
    /// Der NB bestätigt mit der Anmeldung einer Marktlokation zur Direktvermarktung, dass die Marktlokation mit einer Fernsteuerung ausgestattet ist und der LF diese auch fernsteuern kann. Die Voraussetzung zur Zahlung der Managementprämie für fernsteuerbare Marktlokationen ist gegeben.
    /// </summary>
    /// <remarks>Z98</remarks>
    [ProtoEnum(Name = nameof(FernsteuerbarkeitStatus) + "_" + nameof(LIEFERANT_FERNSTEUERBAR))]
    [EnumMember(Value = "LIEFERANT_FERNSTEUERBAR")]
    LIEFERANT_FERNSTEUERBAR,
}
