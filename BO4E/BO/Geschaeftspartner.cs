using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Mit diesem Objekt können Geschäftspartner übertragen werden. Sowohl
///     Unternehmen, als auch Privatpersonen können Geschäftspartner sein.
/// </summary>
/// Hinweis: Marktteilnehmer haben ein eigenes BO
/// <see cref="Marktteilnehmer" />
/// , welches sich von diesem BO
/// ableitet. Hier sollte daher keine Zuordnung zu Marktrollen erfolgen.
[ProtoContract]
// [ProtoInclude(41, typeof(Marktteilnehmer))] multiple inheritance is not yet supported by protobuf-net
public class Geschaeftspartner : BusinessObject
{
    /// <summary>Die Anrede für den GePa, Z.B. Herr. <seealso cref="Anrede" /></summary>
    [JsonProperty(Order = 6, PropertyName = "anrede")]
    [JsonPropertyName("anrede")]
    [JsonPropertyOrder(6)]
    [ProtoMember(4)]
    [FieldName("salutation", Language.EN)]
    public Anrede? Anrede { get; set; }

    /// <summary>
    ///     title of name
    /// </summary>
    /// <example>Dr.</example>
    [JsonProperty(Order = 7, PropertyName = "title")]
    [JsonPropertyName("title")]
    [JsonPropertyOrder(7)]
    [ProtoMember(1001)]
    [Obsolete("Please use anrede instead or Ansprechpartner.individuelleAnrede", true)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public string? Title { get; set; }

    /// <summary>
    ///     Erster Teil des Namens. Hier kann der Firmenname oder bei Privatpersonen
    ///     beispielsweise der Nachname dargestellt werden. Beispiele: Yellow Strom GmbH
    ///     oder Hagen
    /// </summary>
    [JsonProperty(Order = 8, PropertyName = "name1")]
    [JsonPropertyName("name1")]
    [JsonPropertyOrder(8)]
    [ProtoMember(6)]
    [DataCategory(DataCategory.NAME)]
    [BoKey]
    public string? Name1 { get; set; }

    /// <summary>
    ///     Zweiter Teil des Namens. Hier kann der eine Erweiterung zum Firmennamen oder
    ///     bei Privatpersonen beispielsweise der Vorname dargestellt werden. Beispiele:
    ///     Bereich Süd oder Nina
    /// </summary>
    [JsonProperty(Order = 9, PropertyName = "name2")]
    [JsonPropertyName("name2")]
    [JsonPropertyOrder(9)]
    [ProtoMember(7)]
    [DataCategory(DataCategory.NAME)]
    public string? Name2 { get; set; }

    /// <summary>
    ///     Dritter Teil des Namens. Hier können weitere Ergänzungen zum Firmennamen oder
    ///     bei Privatpersonen Zusätze zum Namen dargestellt werden. Beispiele: und Afrika
    ///     oder Sängerin
    /// </summary>
    [JsonProperty(Order = 10, PropertyName = "name3")]
    [JsonPropertyName("name3")]
    [JsonPropertyOrder(10)]
    [ProtoMember(8)]
    [DataCategory(DataCategory.NAME)]
    public string? Name3 { get; set; }

    /// <summary>
    ///     Kennzeichnung ob es sich um einen Gewerbe/Unternehmen (gewerbeKennzeichnung = true)
    ///     oder eine Privatperson handelt. (gewerbeKennzeichnung = false)
    /// </summary>
    [JsonProperty(Order = 11, PropertyName = "gewerbekennzeichnung")]
    [JsonPropertyName("gewerbekennzeichnung")]
    [JsonPropertyOrder(11)]
    [ProtoMember(9)]
    [FieldName("isCommercial", Language.EN)]
    public bool Gewerbekennzeichnung { get; set; }

    /// <summary>Handelsregisternummer des Geschäftspartners</summary>
    [JsonProperty(Order = 12, PropertyName = "hrnummer")]
    [JsonPropertyOrder(12)]
    [JsonPropertyName("hrnummer")]
    [ProtoMember(10)]
    [DataCategory(DataCategory.LEGAL)]
    public string? Hrnummer { get; set; }

    /// <summary> Amtsgericht bzw Handelsregistergericht, das die Handelsregisternummer herausgegeben hat</summary>
    [JsonProperty(Order = 13, PropertyName = "amtsgericht")]
    [JsonPropertyOrder(13)]
    [JsonPropertyName("amtsgericht")]
    [ProtoMember(11)]
    [DataCategory(DataCategory.LEGAL)]
    public string? Amtsgericht { get; set; }

    /// <summary>Bevorzugter Kontaktweg des Geschäftspartners.</summary>
    [JsonProperty(Order = 14, PropertyName = "kontaktweg")]
    [JsonPropertyOrder(14)]
    [JsonPropertyName("kontaktweg")]
    [ProtoMember(12)]
    public List<Kontaktart>? Kontaktweg { get; set; }

    /// <summary>Die Umsatzsteuer-ID des Geschäftspartners. Beispiel: DE 813281825</summary>
    /// <remarks>VA Umsatzsteuernummer</remarks>
    [JsonProperty(Order = 15, PropertyName = "umsatzsteuerId")]
    [JsonPropertyOrder(15)]
    [JsonPropertyName("umsatzsteuerId")]
    [ProtoMember(13)]
    [DataCategory(DataCategory.LEGAL)]
    public string? UmsatzsteuerId { get; set; }

    /// <summary>* Die Gläubiger-ID welche im Zahlungsverkehr verwendet wird- Z.B. DE 47116789</summary>
    [JsonProperty(Order = 16, PropertyName = "glaeubigerId")]
    [JsonPropertyOrder(16)]
    [JsonPropertyName("glaeubigerId")]
    [ProtoMember(14)]
    [DataCategory(DataCategory.FINANCE)]
    public string? GlaeubigerId { get; set; }

    /// <summary>E-Mail-Adresse des Ansprechpartners. Z.B. info@mp-energie.de</summary>
    [JsonProperty(Order = 17, PropertyName = "eMailAdresse")]
    [JsonPropertyOrder(17)]
    [JsonPropertyName("eMailAdresse")]
    [ProtoMember(15)]
    [DataCategory(DataCategory.ADDRESS)]
    public string? EMailAdresse { get; set; }

    /// <summary>Internetseite des Marktpartners. Beispiel: www.mp-energie.de</summary>
    [JsonProperty(Order = 18, PropertyName = "website")]
    [JsonPropertyName("website")]
    [JsonPropertyOrder(18)]
    [ProtoMember(16)]
    [DataCategory(DataCategory.ADDRESS)]
    public string? Website { get; set; }

    /// <summary>Rolle, die der Geschäftspartner hat (z.B. Interessent, Kunde).</summary>
    [JsonProperty(Order = 19, PropertyName = "geschaeftspartnerrolle")] // ToDo: it's actually required but I need it to work quickly
    [JsonPropertyName("geschaeftspartnerrolle")]
    [JsonPropertyOrder(19)]
    [FieldName("role", Language.EN)]
    [ProtoMember(17)]
    public List<Geschaeftspartnerrolle>? Geschaeftspartnerrolle { get; set; }

    /// <summary>
    ///     Adresse des Geschäftspartners, an der sich der Hauptsitz befindet. Details <seealso cref="Adresse" />
    /// </summary>
    [JsonProperty(Order = 20, PropertyName = "partneradresse")]
    [JsonPropertyName("partneradresse")]
    [ProtoMember(18)]
    [JsonPropertyOrder(20)]
    [FieldName("partnerAddress", Language.EN)]
    public Adresse? Partneradresse { get; set; }

    /// <summary>
    /// Grundlage zur Verringerung der Umlagen nach EnFG
    /// </summary>
    [JsonProperty(PropertyName = "grundlageZurVerringerungDerUmlagenNachEnfg", Order = 21)]
    [JsonPropertyName("grundlageZurVerringerungDerUmlagenNachEnfg")]
    [JsonPropertyOrder(21)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(19)]
    public GrundlageZurVerringerungDerUmlagenNachEnfg? GrundlageZurVerringerungDerUmlagenNachEnfg { get; set; }

    /// <summary>
    /// Gründe der Privilegierung nach EnFG
    /// </summary>
    [JsonProperty(PropertyName = "gruendeDerPrivilegierungNachEnFG", Order = 22)]
    [JsonPropertyName("gruendeDerPrivilegierungNachEnFG")]
    [JsonPropertyOrder(22)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(20)]
    public List<GrundDerPrivilegierungNachEnFG>? GruendeDerPrivilegierungNachEnFG { get; set; }

    /// <summary>Bankverbindung</summary>
    [JsonProperty(Order = 23, PropertyName = "bankverbindung")]
    [JsonPropertyName("bankverbindung")]
    [JsonPropertyOrder(23)]
    [ProtoMember(21)]
    [DataCategory(DataCategory.FINANCE)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public Bankverbindung? Bankverbindung { get; set; }

    /// <summary>Die Steuernummer-ID des Geschäftspartners. Beispiel: 30120345678</summary>
    /// <remarks>FC Steuernummer</remarks>
    [JsonProperty(Order = 24, PropertyName = "steuernummer")]
    [JsonPropertyOrder(24)]
    [JsonPropertyName("steuernummer")]
    [ProtoMember(22)]
    [DataCategory(DataCategory.LEGAL)]
    public string? Steuernummer { get; set; }

    /// <summary>Die Erreichbarkeit eines Unternehmens an Werktagen.</summary>
    [JsonProperty(Order = 25, PropertyName = "erreichbarkeit")]
    [JsonPropertyOrder(25)]
    [JsonPropertyName("erreichbarkeit")]
    [ProtoMember(23)]
    [DataCategory(DataCategory.LEGAL)]
    public Erreichbarkeit? Erreichbarkeit { get; set; }
}
