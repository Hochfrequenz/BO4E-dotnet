using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Information zu weiteren technischen Einrichtungen</summary>
public enum InformationWeitereTechnischeRessource
{
    /// <summary>ZH7: Weitere technische Einrichtungen vorhanden. Dieser Code ist auszuwählen, wenn neben den genannten Technischen Ressourcen nach §14aEnWG in der verbrauchenden Marktlokation weitere technische Einrichtungen (z. B. Kraft/Licht) vorhanden sind, die nicht unter § 14a EnWG fallen.</summary>
    [EnumMember(Value = "WEITERE_EINRICHTUNG_VORHANDEN")]
    WEITERE_EINRICHTUNG_VORHANDEN,

    /// <summary>ZH8:	Dieser Code ist auszuwählen, wenn neben den genannten Technischen Ressourcen nach §14a EnWG in der verbrauchenden Marktlokation keine weitere technische Einrichtung vorhanden ist, die nicht unter § 14a EnWG fällt.</summary>
    [EnumMember(Value = "KEINE_WEITERE_EINRICHTUNG_VORHANDEN")]
    KEINE_WEITERE_EINRICHTUNG_VORHANDEN,
}
