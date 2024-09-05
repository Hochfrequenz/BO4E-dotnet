using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Zur Kennzeichnung verschiedener Tarifzeiten, beispielsweise zur Bepreisung oder zur Verbrauchsermittlung.</summary>
public enum Tarifzeit
{
    /// <summary>Tarifzeit Standard für Eintarif-Konfigurationen</summary>
    [EnumMember(Value = "TZ_STANDARD")]
    TZ_STANDARD,

    /// <summary>Tarifzeit für Hochtarif bei Mehrtarif-Konfigurationen</summary>
    [EnumMember(Value = "TZ_HT")]
    TZ_HT,

    /// <summary>Tarifzeit für Niedritarif bei Mehrtarif-Konfigurationen</summary>
    [EnumMember(Value = "TZ_NT")]
    TZ_NT,
}
