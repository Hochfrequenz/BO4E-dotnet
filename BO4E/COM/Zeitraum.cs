using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Diese Komponente wird zur Abbildung von Zeiträumen in Form von Dauern oder der Angabe von Start und Ende
///     verwendet.
/// </summary>
[ProtoContract]
public class Zeitraum : COM
{
    /// <summary>Die Einheit in der die Dauer angeben ist. Z.B. Monate. <seealso cref="Zeiteinheit" /></summary>
    [JsonProperty(PropertyName = "einheit", Required = Required.Default)]
    [JsonPropertyName("einheit")]
    [FieldName("unit", Language.EN)]
    [ProtoMember(3)]
    public Zeiteinheit? Einheit { get; set; }

    /// <summary>Gibt die Anzahl der Zeiteinheiten an, z.B. 3 (Monate).</summary>
    [JsonProperty(PropertyName = "dauer", Required = Required.Default)]
    [JsonPropertyName("dauer")]
    [FieldName("duration", Language.EN)]
    [ProtoMember(4)]
    public decimal? Dauer { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(5, Name = nameof(Startdatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Startdatum
    {
        get => Startdatum?.UtcDateTime ?? default;
        set => Startdatum = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Gibt Tag und Uhrzeit (falls vorhanden) an, wann der Zeitraum startet.</summary>
    [JsonProperty(PropertyName = "startdatum", Required = Required.Default)]
    [JsonPropertyName("startdatum")]
    [FieldName("startDate", Language.EN)]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? Startdatum { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(6, Name = nameof(Enddatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Enddatum
    {
        get => Enddatum?.UtcDateTime ?? default;
        set => Enddatum = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Gibt Tag und Uhrzeit (falls vorhanden) an, wann der Zeitraum endet.</summary>
    [JsonProperty(PropertyName = "enddatum", Required = Required.Default)]
    [JsonPropertyName("enddatum")]
    [FieldName("endDate", Language.EN)]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? Enddatum { get; set; }

    // we disagree with the official bo4e standard that there should be 2xtwo separate properties where one property does contain a date and the other one contains a datetime.
    // we only want datetimes and we already have them present in start- and enddatum above. They are, to be honest, also not ideal because their name ends with "datum".
    // To be compatible with libraries that provide a start or end ZEITPUNKT we introduce properties that always hold the same value as their "datum" neighbours.

    /// <summary>
    /// The same value as <see cref="Startdatum"/>
    /// </summary>
    [JsonPropertyName("startzeitpunkt")]
    [JsonProperty(PropertyName = "startzeitpunkt")]
    public DateTimeOffset? Startzeitpunkt
    {
        get => Startdatum;
        set
        {
            if (value != null)
            {
                Startdatum = value;
            }
        }
    }

    /// <summary>
    /// The same value as <see cref="Enddatum"/>
    /// </summary>
    [JsonPropertyName("endzeitpunkt")]
    [JsonProperty(PropertyName = "endzeitpunkt")]
    public DateTimeOffset? Endzeitpunkt
    {
        get => Enddatum;
        set
        {
            if (value != null)
            {
                Enddatum = value;
            }
        }
    }

    /// <summary>
    ///     sets <see cref="Dauer" /> and <see cref="Einheit" /> iff <see cref="Startdatum" /> and <see cref="Enddatum" /> are
    ///     given.
    /// </summary>
    [OnSerialized]
    public void FillNullValues(StreamingContext context)
    {
        if (Startdatum.HasValue && Enddatum.HasValue)
        {
            var ts = Enddatum.Value - Startdatum.Value;
            if (ts.TotalSeconds < 60)
            {
                Dauer = (decimal)ts.TotalSeconds;
                Einheit = Zeiteinheit.SEKUNDE;
            }
            else if (ts.TotalSeconds < 3600)
            {
                Dauer = (decimal)ts.TotalMinutes;
                Einheit = Zeiteinheit.MINUTE;
            }
            else if (ts.TotalSeconds < 24 * 3600)
            {
                Dauer = (decimal)ts.TotalHours;
                Einheit = Zeiteinheit.STUNDE;
            }
            else // if (ts.TotalDays < 31)
            {
                Dauer = (decimal)ts.TotalDays;
                Einheit = Zeiteinheit.TAG;
            }
        }
    }
    /*
    /// <summary>
    /// perform consistency check
    /// </summary>
    [OnDeserialized]
    public void CheckConsistency()
    {
        if (dauer != null && !einheit.HasValue)
        {
            th
        }
    }*/

    // ToDo: Implement typeconverter for Zeitraum<-->TimeRange
}
