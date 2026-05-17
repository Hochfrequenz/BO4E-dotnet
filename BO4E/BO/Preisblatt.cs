using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Das allgemeine Modell zur Abbildung von Preisen. Davon abgeleitet können, über die Zuordnung identifizierender
///     Merkmale, spezielle Preisblatt-Varianten modelliert werden.
///     Die jeweiligen Sätze von Merkmalen sind in der Grafik ergänzt worden und stellen jeweils eine Ausprägung für die
///     verschiedenen Anwendungsfälle der Preisblätter dar.
/// </summary>
[ProtoContract]
// [ProtoInclude(30, typeof(PreisblattDienstleistung))] // protobuf-net doesn't support multiple levels of inheritance yet
// [ProtoInclude(31, typeof(PreisblattKonzessionsabgabe))] // protobuf-net doesn't support multiple levels of inheritance yet
// [ProtoInclude(32, typeof(PreisblattMessung))] // protobuf-net doesn't support multiple levels of inheritance yet
// [ProtoInclude(33, typeof(PreisblattNetznutzung))] // protobuf-net doesn't support multiple levels of inheritance yet
// [ProtoInclude(34, typeof(PreisblattUmlagen))] // protobuf-net doesn't support multiple levels of inheritance yet
public class Preisblatt : BusinessObject
{
    /// <summary>
    ///     Eine Bezeichnung für das Preisblatt.
    /// </summary>
    [JsonProperty(Order = 10, PropertyName = "bezeichnung")]
    [JsonPropertyName("bezeichnung")]
    [ProtoMember(4)]
    [JsonPropertyOrder(10)]
    [DataCategory(DataCategory.FINANCE)]
    [BoKey]
    public string? Bezeichnung { get; set; }

    /// <summary>
    ///     Der Zeitraum für den der Preis festgelegt ist. Details siehe <see cref="Zeitraum" />
    /// </summary>
    [JsonProperty(Order = 11, PropertyName = "gueltigkeit")]
    [JsonPropertyName("gueltigkeit")]
    [JsonPropertyOrder(11)]
    [ProtoMember(5)]
    [DataCategory(DataCategory.FINANCE)]
    public Zeitraum? Gueltigkeit { get; set; }

    /// <summary>
    ///     Die einzelnen Positionen, die mit dem Preisblatt abgerechnet werden können. Z.B. Arbeitspreis, Grundpreis etc.
    ///     Details siehe <see cref="Preisposition" />
    /// </summary>
    [JsonProperty(Order = 13, PropertyName = "preispositionen")] // at least one entry
    [JsonPropertyName("preispositionen")]
    [DataCategory(DataCategory.FINANCE)]
    [JsonPropertyOrder(13)]
    [ProtoMember(6)]
    public List<Preisposition>? Preispositionen { get; set; }

    /*/// <summary>
    /// Staffelgrenzen der jeweiligen Preise. Details siehe <see cref="Preisstaffel"/>
    /// </summary>
    [JsonProperty( Order = 6)] // at least 1 entry
    [DataCategory(DataCategory.FINANCE)]
    public List<Preisstaffel> preisstaffeln { get;set; }*/
    // https://github.com/Hochfrequenz/energy-service-hub/issues/11

    /// <summary>
    ///     Gibt den Status des veröffentlichten Preises an
    /// </summary>
    [JsonProperty(PropertyName = "preisstatus", Order = 14)]
    [JsonPropertyName("preisstatus")]
    [JsonPropertyOrder(14)]
    public Preisstatus? preisstatus { get; set; }

    /// <summary>Strom oder Gas. <seealso cref="ENUM.Sparte" /></summary>
    [JsonProperty(Order = 15, PropertyName = "sparte")]
    [JsonPropertyName("sparte")]
    [JsonPropertyOrder(15)]
    public Sparte? Sparte { get; set; }
}
