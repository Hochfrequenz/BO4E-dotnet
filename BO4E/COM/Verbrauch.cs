using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Abbildung eines zeitlich abgegrenzten Verbrauchs.
/// </summary>
[ProtoContract]
public class Verbrauch : COM
{
    [ProtoIgnore]
    internal const string SapProfdecimalsKey = "sap_profdecimals";

    /// <summary>
    ///     static serializer options for Verbracuhconverter
    /// </summary>
    public static JsonSerializerOptions VerbrauchSerializerOptions;

    static Verbrauch()
    {
        VerbrauchSerializerOptions = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
    }

    /// <summary>
    ///     <inheritdoc cref="CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo" />
    /// </summary>
    [ProtoIgnore]
    [Obsolete(
        "This property moved. Use the property BO4E.meta."
            + nameof(CentralEuropeStandardTime)
            + "."
            + nameof(CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo)
            + " instead.",
        true
    )]
    // ReSharper disable once InconsistentNaming
    public static TimeZoneInfo CENTRAL_EUROPE_STANDARD_TIME =>
        CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo;

    /// <summary>
    ///     Beginn des Zeitraumes, für den der Verbrauch angegeben wird.
    /// </summary>
    /// <remarks>
    /// <c>Required = Required.Default</c>, DateTime aber nicht nullable, laut bo4e doku wäre es optional
    ///</remarks>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(2, Name = nameof(Startdatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Startdatum
    {
        get => Startdatum?.UtcDateTime ?? default;
        set => Startdatum = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Gibt Tag und Uhrzeit (falls vorhanden) an, wann der Zeitraum startet.</summary>
    [JsonProperty(PropertyName = "startdatum")]
    [JsonPropertyName("startdatum")]
    [FieldName("startDate", Language.EN)]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? Startdatum { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(3, Name = nameof(Enddatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Enddatum
    {
        get => Enddatum?.UtcDateTime ?? default;
        set => Enddatum = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Gibt Tag und Uhrzeit (falls vorhanden) an, wann der Zeitraum endet.</summary>
    [JsonProperty(PropertyName = "enddatum")]
    [JsonPropertyName("enddatum")]
    [FieldName("endDate", Language.EN)]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? Enddatum { get; set; }

    /// <summary>
    ///     Gibt an, ob es sich um eine PROGNOSE oder eine MESSUNG handelt.
    /// </summary>
    /// <seealso cref="ENUM.Wertermittlungsverfahren" />
    [JsonProperty(PropertyName = "wertermittlungsverfahren", Order = 5)]
    [JsonPropertyName("wertermittlungsverfahren")]
    [ProtoMember(5)]
    public Wertermittlungsverfahren? Wertermittlungsverfahren { get; set; }

    /// <summary>
    ///     Enthält die Gültigkeit des angegebenen Wertes
    /// </summary>
    /// <seealso cref="ENUM.Messwertstatus" />
    [JsonProperty(PropertyName = "messwertstatus", Order = 5)]
    [JsonPropertyName("messwertstatus")]
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [ProtoMember(10)]
    public Messwertstatus? Messwertstatus { get; set; }

    /// <summary>
    /// Enthält die Auflistung der STS Segmente Plausibilisierungshinweis, Ersatzwertbildungsverfahren,
    /// Korrekturgrund, Gasqualität, Tarif, Grundlage der Energiemenge
    /// </summary>
    [JsonProperty(PropertyName = "statuszusatzinformationen", Order = 5)]
    [JsonPropertyName("statuszusatzinformationen")]
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [ProtoMember(11)]
    public List<StatusZusatzInformation>? StatusZusatzInformationen { get; set; }

    /// <summary>
    ///     Die OBIS-Kennzahl für den Wert, die festlegt, welche Größe mit dem Stand gemeldet wird.
    /// </summary>
    /// <example>
    ///     1-0:1.8.1
    /// </example>
    [JsonProperty(PropertyName = "obiskennzahl", Order = 6)]
    [JsonPropertyName("obiskennzahl")]
    [ProtoMember(6)]
    public string Obiskennzahl { get; set; }

    /// <summary>
    ///     Gibt den absoluten Wert der Menge an.
    /// </summary>
    [JsonProperty(PropertyName = "wert", Order = 7)]
    [JsonPropertyName("wert")]
    [ProtoMember(7)]
    public decimal Wert { get; set; }

    /// <summary>
    ///     Gibt die Einheit zum jeweiligen Wert an.
    /// </summary>
    /// <seealso cref="Mengeneinheit" />
    [JsonProperty(PropertyName = "einheit", Order = 8)]
    [JsonPropertyName("einheit")]
    [ProtoMember(8)]
    public Mengeneinheit Einheit { get; set; }

    /// <summary>type</summary>
    /// <example>arbeitleistungtagesparameterabhmalo | veranschlagtejahresmenge | TUMKundenwert</example>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [JsonProperty(PropertyName = "type")]
    [JsonPropertyName("type")]
    [ProtoMember(9)]
    public Verbrauchsmengetyp? Type { get; set; }

    /// <summary>Tarifstufe</summary>
    /// <seealso cref="ENUM.Tarifstufe" />
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [JsonProperty(PropertyName = "tarifstufe")]
    [JsonPropertyName("tarifstufe")]
    [ProtoMember(12)]
    public Tarifstufe? Tarifstufe { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(13, Name = nameof(Nutzungszeitpunkt))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Nutzungszeitpunkt
    {
        get => Nutzungszeitpunkt?.UtcDateTime ?? default;
        set =>
            Nutzungszeitpunkt =
                value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Wird verwendet, um einen Zählerstand eindeutig einem Prozesszeitpunkt zuzuordnen. Dieser Prozesszeitpunkt kann entweder ein Zeitpunkt einer Stammdatenänderung sein(z. B.bei einem Gerätewechsel, in der die Änderung vor dem Versand des Zählerstandes übermittelt wurde) oder die Bestellung eines Wertes aufgrund eines eingetretenen Ereignisses(z.B. Lieferantenwechsel). Der  Nutzungszeitpunkt ist für den Zählerstand der Zeitpunkt der für die weitere Verarbeitung relevant ist(z.B.Zuordnung bei Empfänger anhand der Zuordnungstupel).</summary>
    [JsonProperty(PropertyName = "nutzungszeitpunkt", Order = 13)]
    [JsonPropertyName("nutzungszeitpunkt")]
    [ProtoIgnore]
    [JsonPropertyOrder(13)]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? Nutzungszeitpunkt { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(14, Name = nameof(Ausfuehrungszeitpunkt))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Ausfuehrungszeitpunkt
    {
        get => Ausfuehrungszeitpunkt?.UtcDateTime ?? default;
        set =>
            Ausfuehrungszeitpunkt =
                value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Wird verwendet, um einen Zählerstand eindeutig einer tatsächlichen Änderung zuzuordnen, z.B.bei einem Gerätewechsel oder Geräteparameteränderung der tatsächliche Zeitpunkt an dem die Änderung an der Messlokation durchgeführt wurde.Der Nutzungszeitpunkt ist für den Zählerstand der Zeitpunkt der für die weitere Verarbeitung relevant ist(z.B. Zuordnung bei Empfänger anhand der Zuordnungstupel).</summary>
    [JsonProperty(PropertyName = "ausfuehrungszeitpunkt", Order = 14)]
    [JsonPropertyName("ausfuehrungszeitpunkt")]
    [ProtoIgnore]
    [JsonPropertyOrder(14)]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? Ausfuehrungszeitpunkt { get; set; }

    /// <summary>Gibt die Temperaturmaßzahl (TMZ) für Profilscharen an.</summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [JsonProperty(PropertyName = "temperaturmasszahl", Order = 15)]
    [JsonPropertyName("temperaturmasszahl")]
    [JsonPropertyOrder(15)]
    [ProtoMember(15)]
    public string? Temperaturmasszahl { get; set; }

    /// <summary>Gibt Zeitfenster für Profilscharen an.</summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [JsonProperty(PropertyName = "zeitfenster", Order = 16)]
    [JsonPropertyName("zeitfenster")]
    [JsonPropertyOrder(16)]
    [ProtoMember(16)]
    public Zeitfenster? Zeitfenster { get; set; }
}
