using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Modellierung eines Ansprechpartners für einen bestimmten Geschäftspartner.
/// </summary>
[ProtoContract]
public class Ansprechpartner : BusinessObject
{
    /// <summary>
    ///     Mögliche Anrede des Ansprechpartners
    /// </summary>
    [JsonProperty(Order = 10, PropertyName = "anrede")]
    [JsonPropertyName("anrede")]
    [JsonPropertyOrder(10)]
    [ProtoMember(4)]
    [DataCategory(DataCategory.NAME)]
    public Anrede? Anrede { get; set; }

    /// <summary>
    ///     Im Falle einer nicht standardisierten Anrede kann hier eine frei definierbare
    ///     Anrede vorgegeben werden. Beispiel: "Sehr geehrte Frau Müller, sehr geehrter
    ///     Herr Dr. Müller"
    /// </summary>
    [JsonProperty(Order = 11, PropertyName = "inviduelleAnrede")]
    [JsonPropertyName("inviduelleAnrede")]
    [JsonPropertyOrder(11)]
    [ProtoMember(5)]
    [DataCategory(DataCategory.NAME)]
    public string? IndividuelleAnrede { get; set; }

    /// <summary>Möglicher Titel des Ansprechpartners</summary>
    [JsonProperty(Order = 12, PropertyName = "titel")]
    [JsonPropertyName("titel")]
    [JsonPropertyOrder(12)]
    [ProtoMember(6)]
    [DataCategory(DataCategory.NAME)]
    public Titel? Titel { get; set; }

    /// <summary>Vorname des Ansprechpartners</summary>
    [JsonProperty(Order = 13, PropertyName = "vorname")]
    [JsonPropertyName("vorname")]
    [JsonPropertyOrder(13)]
    [ProtoMember(7)]
    [DataCategory(DataCategory.NAME)]
    [BoKey]
    public string? Vorname { get; set; }

    /// <summary>Nachname (Familienname) des Ansprechpartners</summary>
    [JsonProperty(Order = 14, PropertyName = "nachname")]
    [JsonPropertyName("nachname")]
    [JsonPropertyOrder(14)]
    [ProtoMember(8)]
    [DataCategory(DataCategory.NAME)]
    [BoKey]
    public string? Nachname { get; set; }

    /// <summary>E-Mail Adresse</summary>
    [JsonProperty(Order = 15, PropertyName = "eMailAdresse")]
    [JsonPropertyName("eMailAdresse")]
    [JsonPropertyOrder(15)]
    [ProtoMember(9)]
    [DataCategory(DataCategory.ADDRESS)]
    public string? EMailAdresse { get; set; }

    /// <summary>Weitere Informationen zum Ansprechpartner</summary>
    [JsonProperty(Order = 16, PropertyName = "kommentar")]
    [JsonPropertyName("kommentar")]
    [JsonPropertyOrder(16)]
    [ProtoMember(10)]
    [DataCategory(DataCategory.NAME)]
    public string? Kommentar { get; set; }

    /// <summary>Der Geschäftspartner, für den dieser Ansprechpartner modelliert wird.</summary>
    [JsonProperty(Order = 17, PropertyName = "geschaeftspartner")]
    [JsonPropertyName("geschaeftspartner")]
    [JsonPropertyOrder(17)]
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)] // it's always required in BO4E, changed it to default 2020-08-31 KK
    [ProtoMember(11)]
    [BoKey]
    public Geschaeftspartner? Geschaeftspartner { get; set; }

    /// <summary> Adresse des Ansprechpartners, falls diese von der Adresse des Geschäftspartners abweicht.</summary>
    [JsonProperty(Order = 18, PropertyName = "adresse")]
    [JsonPropertyName("adresse")]
    [JsonPropertyOrder(18)]
    [ProtoMember(12)]
    [DataCategory(DataCategory.ADDRESS)]
    public Adresse? Adresse { get; set; }

    /// <summary>Liste der Telefonnummern, unter denen der Ansprechpartner erreichbar ist.</summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)] //  We suggest to name it "rufnummern" instead of "rufnummer" because it's a list")]
    [JsonProperty(Order = 19, PropertyName = "rufnummern")]
    [JsonPropertyName("rufnummern")]
    [JsonPropertyOrder(19)]
    [ProtoMember(13)]
    [DataCategory(DataCategory.ADDRESS)]
    public List<Rufnummer>? Rufnummern { get; set; }

    /// <summary>Liste der Abteilungen und Zuständigkeiten des Ansprechpartners.</summary>
    [JsonProperty(Order = 20, PropertyName = "zustaendigkeit")]
    [JsonPropertyName("zustaendigkeit")]
    [JsonPropertyOrder(20)]
    [ProtoMember(14)]
    public List<Zustaendigkeit>? Zustaendigkeit { get; set; }
}
