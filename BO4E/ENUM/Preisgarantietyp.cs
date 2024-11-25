using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Aufzählung der Möglichkeiten für die Vergabe von Preisgarantien</summary>
public enum Preisgarantietyp
{
    /// <summary>Der Versorger gewährt eine Preisgarantie auf alle Preisbestandteile ohne die Umsatzsteuer</summary>
    [EnumMember(Value = "ALLE_PREISBESTANDTEILE_NETTO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ALLE_PREISBESTANDTEILE_NETTO")]
    ALLE_PREISBESTANDTEILE_NETTO,

    /// <summary>
    ///     Der Versorger gewährt eine Preisgarantie auf alle Preisbestandteile ohne Abgaben (Energiesteuern, Umlagen,
    ///     Abgaben)
    /// </summary>
    [EnumMember(Value = "PREISBESTANDTEILE_OHNE_ABGABEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PREISBESTANDTEILE_OHNE_ABGABEN")]
    PREISBESTANDTEILE_OHNE_ABGABEN,

    /// <summary>Der Versorger garantiert ausschließlich den Energiepreis</summary>
    [EnumMember(Value = "NUR_ENERGIEPREIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NUR_ENERGIEPREIS")]
    NUR_ENERGIEPREIS,
}
