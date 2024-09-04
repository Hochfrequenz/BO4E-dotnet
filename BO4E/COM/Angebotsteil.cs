#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.BO;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Mit dieser Komponente wird ein Teil einer Angebotsvariante abgebildet. Hier werden alle Angebotspositionen
///     aggregiert.
/// </summary>
[ProtoContract]
public class Angebotsteil : COM
{
    /// <summary>Identifizierung eines Subkapitels einer Anfrage, beispielsweise das Los einer Ausschreibung.</summary>
    [JsonProperty(PropertyName = "anfrageSubreferenz", Order = 10, Required = Required.Default)]
    [JsonPropertyName("anfrageSubreferenz")]
    [JsonPropertyOrder(10)]
    [ProtoMember(3)]
    public string? AnfrageSubreferenz { get; set; }

    /// <summary>
    ///     Marktlokationen, für die dieses Angebotsteil gilt, falls vorhanden. Durch die Marktlokation ist auch die
    ///     Lieferadresse festgelegt. Details <see cref="Marktlokation" />
    /// </summary>
    [JsonProperty(PropertyName = "lieferstellenangebotsteil", Order = 11, Required = Required.Default)]
    [JsonPropertyName("lieferstellenangebotsteil")]
    [JsonPropertyOrder(11)]
    [ProtoMember(4)]
    public List<Marktlokation>? Lieferstellenangebotsteil { get; set; }

    /// <summary>
    ///     Summe der Verbräuche aller in diesem Angebotsteil eingeschlossenen Lieferstellen. Details <see cref="Menge" />
    /// </summary>
    [JsonProperty(PropertyName = "gesamtmengeangebotsteil", Order = 12, Required = Required.Default)]
    [JsonPropertyName("gesamtmengeangebotsteil")]
    [JsonPropertyOrder(12)]
    [ProtoMember(5)]
    public Menge? Gesamtmengeangebotsteil { get; set; }

    /// <summary>
    ///     Summe der Jahresenergiekosten aller in diesem Angebotsteil enthaltenen Lieferstellen. Details
    ///     <see cref="Betrag" />
    /// </summary>
    [JsonProperty(PropertyName = "gesamtkostenangebotsteil", Order = 13, Required = Required.Default)]
    [JsonPropertyName("gesamtkostenangebotsteil")]
    [JsonPropertyOrder(13)]
    [ProtoMember(6)]
    public Betrag? Gesamtkostenangebotsteil { get; set; }

    /// <summary>Einzelne Positionen, die zu diesem Angebotsteil gehören. Details <see cref="Angebotsposition" /></summary>
    [JsonProperty(PropertyName = "positionen", Order = 14, Required = Required.Default)]
    [JsonPropertyName("positionen")]
    [JsonPropertyOrder(14)]
    [ProtoMember(7)]
    public List<Angebotsposition>? Positionen { get; set; }

    /// <summary>Hier kann der Belieferungszeitraum angegeben werden, für den dieser Angebotsteil gilt. Details <see cref="Zeitraum" /></summary>
    [JsonProperty(PropertyName = "lieferzeitraum", Order = 15, Required = Required.Default)]
    [JsonPropertyName("lieferzeitraum")]
    [JsonPropertyOrder(15)]
    [ProtoMember(8)]
    public Zeitraum? Lieferzeitraum { get; set; }
}
