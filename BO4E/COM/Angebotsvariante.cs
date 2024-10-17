using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Führt die verschiedenen Ausprägungen der Angebotsberechnung auf.</summary>
[ProtoContract]
public class Angebotsvariante : COM
{
    /// <summary>Gibt den Status eines Angebotes an. <seealso cref="ENUM.Angebotsstatus" /></summary>
    [JsonProperty(PropertyName = "angebotsstatus", Order = 10)]
    [JsonPropertyName("angebotsstatus")]
    [JsonPropertyOrder(10)]
    [ProtoMember(4)]
    public Angebotsstatus Angebotsstatus { get; set; }

    /// <summary>Umschreibung des Inhalts der Angebotsvariante.</summary>
    [JsonProperty(PropertyName = "beschreibung", Order = 11)]
    [JsonPropertyName("beschreibung")]
    [JsonPropertyOrder(11)]
    [ProtoMember(5)]
    public string? Beschreibung { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(6, Name = nameof(Erstelldatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Erstelldatum
    {
        get => Erstelldatum?.UtcDateTime ?? default;
        set =>
            Erstelldatum = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Datum der Erstellung der Angebotsvariante</summary>
    [JsonProperty(PropertyName = "erstelldatum", Order = 12)]
    [JsonPropertyName("erstelldatum")]
    [JsonPropertyOrder(12)]
    [ProtoIgnore]
    public DateTimeOffset? Erstelldatum { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(7, Name = nameof(Bindefrist))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Bindefrist
    {
        get => Bindefrist?.UtcDateTime ?? default;
        set => Bindefrist = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Bis zu diesem Zeitpunkt (Tag/Uhrzeit) inklusive gilt die Angebotsvariante, z.B. 31.12.2017, 17:00 Uhr.</summary>
    [JsonProperty(PropertyName = "bindefrist", Order = 13)]
    [JsonPropertyName("bindefrist")]
    [JsonPropertyOrder(13)]
    [ProtoIgnore]
    public DateTimeOffset? Bindefrist { get; set; }

    /// <summary>Aufsummierte Wirkarbeitsmenge aller Angebotsteile. <seealso cref="Menge" /></summary>
    [JsonProperty(PropertyName = "gesamtmenge", Order = 14)]
    [JsonPropertyName("gesamtmenge")]
    [JsonPropertyOrder(14)]
    [ProtoMember(8)]
    public Menge? Gesamtmenge { get; set; }

    /// <summary>Aufsummierte Kosten aller Angebotsteile. <seealso cref="Betrag" /></summary>
    [JsonProperty(PropertyName = "gesamtkosten", Order = 15)]
    [JsonPropertyName("gesamtkosten")]
    [JsonPropertyOrder(15)]
    [ProtoMember(9)]
    public Betrag? Gesamtkosten { get; set; }

    /// <summary>
    ///     Angebotsteile werden im einfachsten Fall für eine Marktlokation oder Lieferstellenadresse erzeugt. Hier werden
    ///     die Mengen und Gesamtkosten aller Angebotspositionen zusammengefasst. Eine Variante besteht mindestens aus einem
    ///     Angebotsteil. Details <see cref="Angebotsteil" />
    /// </summary>
    [JsonProperty(PropertyName = "teile", Order = 16)]
    [JsonPropertyName("teile")]
    [JsonPropertyOrder(16)]
    [ProtoMember(10)]
    public List<Angebotsteil>? Teile { get; set; }
}
