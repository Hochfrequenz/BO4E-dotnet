using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Einordnung der verbrauchenden Technischen Ressource nach § 14a EnWG mit Inbetriebsetzung vor 2024</summary>
public enum EinordnungTechnischeRessource
{
    /// <summary>ZH2: Wechselmöglichkeit in das § 14a EnWGModell gem. Festlegung BK6-22-300 einmalig noch möglich</summary>
    [EnumMember(Value = "WECHSEL_IN_14A_EINMALIG_MOEGLICH")]
    WECHSEL_IN_14A_EINMALIG_MOEGLICH,

    /// <summary>ZH3: Wechselmöglichkeit in das § 14a EnWGModell gem. Festlegung BK6-22-300 nicht möglich</summary>
    [EnumMember(Value = "WECHSEL_IN_14A_NICHT_MOEGLICH")]
    WECHSEL_IN_14A_NICHT_MOEGLICH,

    /// <summary>ZH4: Befristet im alten § 14a EnWG-Modell bis 2028 ohne Wechselmöglichkeit</summary>
    [EnumMember(Value = "BEFRISTET_ALTES_14A")]
    BEFRISTET_ALTES_14A,

    /// <summary>ZH5: Wechsel in das § 14a EnWG-Modell gem. Festlegung BK6-22-300 wurde durchgeführt</summary>
    [EnumMember(Value = "WECHSEL_DURCHGEFUEHRT")]
    WECHSEL_DURCHGEFUEHRT,
}
