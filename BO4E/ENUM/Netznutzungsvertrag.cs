using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Art des Netznutzungsvertrags</summary>
public enum Netznutzungsvertragsart
{
    /// <summary>Z08: Direkter Vertrag zwischen Kunden und NB</summary>
    [EnumMember(Value = "KUNDEN_NB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KUNDEN_NB")]
    KUNDEN_NB,

    /// <summary>Z09: Vertrag zwischen Lieferanten und NB</summary>
    [EnumMember(Value = "LIEFERANTEN_NB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEFERANTEN_NB")]
    LIEFERANTEN_NB,
}
