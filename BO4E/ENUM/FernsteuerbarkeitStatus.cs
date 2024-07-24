using System.Runtime.Serialization;

using ProtoBuf;

namespace BO4E.ENUM
{
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
        [ProtoEnum(Name = nameof(Z96_NICHT_FERNSTEUERBAR))]
        [EnumMember(Value = "Z96_NICHT_FERNSTEUERBAR")]
        Z96_NICHT_FERNSTEUERBAR,

        /// <summary>
        /// Marktlokation ist technisch fernsteuerbar.
        /// Der NB bestätigt mit der Anmeldung einer erzeugenden Marktlokation zur Direktvermarktung, dass die Marktlokation mit einer Fernsteuerung ausgestattet, aber dem NB keine Information darüber vorliegt, dass der LF die Marktlokation fernsteuern kann. Die Voraussetzung zur Zahlung der Managementprämie für fernsteuerbare Marktlokation ist nicht gegeben.
        /// </summary>
        [ProtoEnum(Name = nameof(Z97_TECHNISCH_FERNSTEUERBAR))]
        [EnumMember(Value = "Z97_TECHNISCH_FERNSTEUERBAR")]
        Z97_TECHNISCH_FERNSTEUERBAR,

        /// <summary>
        /// Marktlokation ist durch den Lieferanten fernsteuerbar.
        /// Der NB bestätigt mit der Anmeldung einer Marktlokation zur Direktvermarktung, dass die Marktlokation mit einer Fernsteuerung ausgestattet ist und der LF diese auch fernsteuern kann. Die Voraussetzung zur Zahlung der Managementprämie für fernsteuerbare Marktlokationen ist gegeben.
        /// </summary>
        [ProtoEnum(Name = nameof(Z98_LIEFERANT_FERNSTEUERBAR))]
        [EnumMember(Value = "Z98_LIEFERANT_FERNSTEUERBAR")]
        Z98_LIEFERANT_FERNSTEUERBAR
    }
}
