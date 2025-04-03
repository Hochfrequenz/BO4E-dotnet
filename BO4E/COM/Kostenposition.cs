#nullable enable
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Diese Komponente wird zur Übertagung der Details zu einer Kostenposition verwendet.</summary>
[ProtoContract]
public class Kostenposition : COM
{
    /// <summary>
    ///     Ein Titel für die Zeile. Hier kann z.B. der Netzbetreiber eingetragen werden, wenn es sich um Netzkosten
    ///     handelt.
    /// </summary>
    [JsonProperty(PropertyName = "positionstitel")]
    [JsonPropertyName("positionstitel")]
    [ProtoMember(3)]
    public string? Positionstitel { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(4, Name = nameof(Von))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Von
    {
        get => Von?.UtcDateTime ?? default;
        set => Von = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>von-Datum der Kostenzeitscheibe. Z.B. 2017-01-01</summary>
    [JsonProperty(PropertyName = "von")]
    [JsonPropertyName("von")]
    [ProtoIgnore]
    public DateTimeOffset? Von { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(5, Name = nameof(Bis))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Bis
    {
        get => Bis?.UtcDateTime ?? default;
        set => Bis = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>bis-Datum der Kostenzeitscheibe. Z.B. 2017-12-31</summary>
    [JsonProperty(PropertyName = "bis")]
    [JsonPropertyName("bis")]
    [ProtoIgnore]
    public DateTimeOffset? Bis { get; set; }

    /// <summary>Bezeichnung für den Artikel für den die Kosten ermittelt wurden. Beispiel: Arbeitspreis HT</summary>
    [JsonProperty(PropertyName = "artikelbezeichnung")]
    [JsonPropertyName("artikelbezeichnung")]
    [ProtoMember(6)]
    public string? Artikelbezeichnung { get; set; }

    /// <summary>Detaillierung des Artikels (optional). Beispiel: Drehstromzähler</summary>
    [JsonProperty(PropertyName = "artikeldetail")]
    [JsonPropertyName("artikeldetail")]
    [ProtoMember(7)]
    public string? Artikeldetail { get; set; }

    /// <summary>
    ///     Die Menge, die in die Kostenberechnung eingeflossen ist. Beispiel: 3.660 kWh. Details
    ///     <see cref="BO4E.COM.Menge" />
    /// </summary>
    [JsonProperty(PropertyName = "menge")]
    [JsonPropertyName("menge")]
    [ProtoMember(8)]
    public Menge? Menge { get; set; }

    /// <summary>
    ///     Wenn es einen zeitbasierten Preis gibt (z.B. €/Jahr), dann ist hier die Menge angegeben mit der die Kosten
    ///     berechnet wurden. Z.B.  138 Tage. Details <see cref="BO4E.COM.Menge" />
    /// </summary>
    [JsonProperty(PropertyName = "zeitmenge")]
    [JsonPropertyName("zeitmenge")]
    [ProtoMember(9)]
    public Menge? Zeitmenge { get; set; }

    /// <summary>Der Preis für eine Einheit. Beispiele: 5,8200 ct/kWh oder 55 €/Jahr. Details <see cref="Preis" /></summary>
    [JsonProperty(PropertyName = "einzelpreis")]
    [JsonPropertyName("einzelpreis")]
    [ProtoMember(10)]
    public Preis? Einzelpreis { get; set; }

    /// <summary>
    ///     Der errechnete Gesamtbetrag der Position als Ergebnis der Berechnung &lt;Menge&gt; x &lt;Einzelpreis&gt; oder
    ///     &lt;Einzelpreis&gt; / (Anzahl Tage Jahr) * &lt;zeitmenge&gt;. Details <see cref="Betrag" />
    /// </summary>
    [JsonProperty(PropertyName = "betragKostenposition")]
    [JsonPropertyName("betragKostenposition")]
    [ProtoMember(11)]
    public Betrag? BetragKostenposition { get; set; }
}
