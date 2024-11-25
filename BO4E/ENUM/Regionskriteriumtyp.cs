using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
///     Klassifizierung der Kriterien für eine regionale Eingrenzung.
/// </summary>
public enum Regionskriteriumtyp
{
    /// <summary>
    ///     offizielle Bundeslandkennziffer
    /// </summary>
    [EnumMember(Value = "BUNDESLANDKENNZIFFER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BUNDESLANDKENNZIFFER")]
    BUNDESLANDKENNZIFFER,

    /// <summary>
    ///     Bundesland Name
    /// </summary>
    [EnumMember(Value = "BUNDESLAND_NAME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BUNDESLAND_NAME")]
    BUNDESLAND_NAME,

    /// <summary>
    ///     offizielle Marktgebiet-Codenummer
    /// </summary>
    [EnumMember(Value = "MARKTGEBIET_NUMMER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MARKTGEBIET_NUMMER")]
    MARKTGEBIET_NUMMER,

    /// <summary>
    ///     Marktgebiet Name
    /// </summary>
    [EnumMember(Value = "MARKTGEBIET_NAME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MARKTGEBIET_NAME")]
    MARKTGEBIET_NAME,

    /// <summary>
    ///     offizielle Regelgebiet Nummer
    /// </summary>
    [EnumMember(Value = "REGELGEBIET_NUMMER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REGELGEBIET_NUMMER")]
    REGELGEBIET_NUMMER,

    /// <summary>
    ///     Regelgebiet Name
    /// </summary>
    [EnumMember(Value = "REGELGEBIET_NAME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REGELGEBIET_NAME")]
    REGELGEBIET_NAME,

    /// <summary>
    ///     offizielle Netzbetreiber-Codenummer
    /// </summary>
    [EnumMember(Value = "NETZBETREIBER_NUMMER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NETZBETREIBER_NUMMER")]
    NETZBETREIBER_NUMMER,

    /// <summary>
    ///     Netzbetreiber Name
    /// </summary>
    [EnumMember(Value = "NETZBETREIBER_NAME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NETZBETREIBER_NAME")]
    NETZBETREIBER_NAME,

    /// <summary>
    ///     Strom: Bilanzierungsgebietsnummer, Gas: Netzkontonummer
    /// </summary>
    [EnumMember(Value = "BILANZIERUNGS_GEBIET_NUMMER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZIERUNGS_GEBIET_NUMMER")]
    BILANZIERUNGS_GEBIET_NUMMER,

    /// <summary>
    ///     offizielle Messstellenbetreiber-Codenummer
    /// </summary>
    [EnumMember(Value = "MSB_NUMMER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MSB_NUMMER")]
    MSB_NUMMER,

    /// <summary>
    ///     Name des MSB
    /// </summary>
    [EnumMember(Value = "MSB_NAME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MSB_NAME")]
    MSB_NAME,

    /// <summary>
    ///     offizielle Lieferanten-Codenummer eines Versorgers
    /// </summary>
    [EnumMember(Value = "VERSORGER_NUMMER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERSORGER_NUMMER")]
    VERSORGER_NUMMER,

    /// <summary>
    ///     Name eines Versorgers
    /// </summary>
    [EnumMember(Value = "VERSORGER_NAME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERSORGER_NAME")]
    VERSORGER_NAME,

    /// <summary>
    ///     offizielle Lieferanten-Codenummer des Grundversorgers
    /// </summary>
    [EnumMember(Value = "GRUNDVERSORGER_NUMMER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUNDVERSORGER_NUMMER")]
    GRUNDVERSORGER_NUMMER,

    /// <summary>
    ///     Name des Grundversorger
    /// </summary>
    [EnumMember(Value = "GRUNDVERSORGER_NAME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUNDVERSORGER_NAME")]
    GRUNDVERSORGER_NAME,

    /// <summary>
    ///     Kreis
    /// </summary>
    [EnumMember(Value = "KREIS_NAME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KREIS_NAME")]
    KREIS_NAME,

    /// <summary>
    ///     offizielle Kreiskennziffer
    /// </summary>
    [EnumMember(Value = "KREISKENNZIFFER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KREISKENNZIFFER")]
    KREISKENNZIFFER,

    /// <summary>
    ///     Gemeinde
    /// </summary>
    [EnumMember(Value = "GEMEINDE_NAME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEMEINDE_NAME")]
    GEMEINDE_NAME,

    /// <summary>
    ///     offizielle Gemeindekennziffer
    /// </summary>
    [EnumMember(Value = "GEMEINDEKENNZIFFER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEMEINDEKENNZIFFER")]
    GEMEINDEKENNZIFFER,

    /// <summary>
    ///     Postleitzahl
    /// </summary>
    [EnumMember(Value = "POSTLEITZAHL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("POSTLEITZAHL")]
    POSTLEITZAHL,

    /// <summary>
    ///     Ort
    /// </summary>
    [EnumMember(Value = "ORT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ORT")]
    ORT,

    /// <summary>
    ///     Einwohnerzahl Gemeinde
    /// </summary>
    [EnumMember(Value = "EINWOHNERZAHL_GEMEINDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINWOHNERZAHL_GEMEINDE")]
    EINWOHNERZAHL_GEMEINDE,

    /// <summary>
    ///     Einwohnerzahl Ort
    /// </summary>
    [EnumMember(Value = "EINWOHNERZAHL_ORT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINWOHNERZAHL_ORT")]
    EINWOHNERZAHL_ORT,

    /// <summary>
    ///     km Umkreis
    /// </summary>
    [EnumMember(Value = "KM_UMKREIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KM_UMKREIS")]
    KM_UMKREIS,

    /// <summary>
    ///     bundesweite Betrachtung
    /// </summary>
    [EnumMember(Value = "BUNDESWEIT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BUNDESWEIT")]
    BUNDESWEIT,
}
