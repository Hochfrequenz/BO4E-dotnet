using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Mit dieser Komponente werden Zählwerke modelliert.</summary>
[ProtoContract]
public class Zaehlwerk : COM
{
    /// <summary>
    ///     Identifikation des Zählwerks (Registers) innerhalb des Zählers. Oftmals eine laufende Nummer hinter der
    ///     Zählernummer. Z.B. 47110815_1
    /// </summary>
    [JsonProperty(PropertyName = "zaehlwerkId", Order = 3)]
    [JsonPropertyName("zaehlwerkId")]
    [ProtoMember(3)]
    [JsonPropertyOrder(3)]
    public string? ZaehlwerkId { get; set; }

    /// <summary>Zusätzliche Bezeichnung, z.B. Zählwerk_Wirkarbeit.</summary>
    [JsonProperty(PropertyName = "bezeichnung", Order = 4)]
    [JsonPropertyName("bezeichnung")]
    [ProtoMember(4)]
    [JsonPropertyOrder(4)]
    public string? Bezeichnung { get; set; }

    /// <summary>Die Energierichtung, Einspeisung oder Ausspeisung. Details <see cref="Energierichtung" /></summary>
    [JsonProperty(PropertyName = "richtung", Order = 5)]
    [JsonPropertyName("richtung")]
    [ProtoMember(5)]
    [JsonPropertyOrder(5)]
    public Energierichtung? Richtung { get; set; }

    /// <summary>
    ///     Die OBIS-Kennzahl für das Zählwerk, die festlegt, welche auf die gemessene Größe mit dem Stand gemeldet wird.
    ///     Nur Zählwerkstände mit dieser OBIS-Kennzahl werden an diesem Zählwerk registriert. Beispiel:1-0:1.8.1 für
    ///     elektrische Wirkarbeit.
    /// </summary>
    [JsonProperty(PropertyName = "obisKennzahl", Order = 6)]
    [JsonPropertyName("obisKennzahl")]
    [ProtoMember(6)]
    [JsonPropertyOrder(6)]
    public string? ObisKennzahl { get; set; }

    /// <summary>
    ///     Mit diesem Faktor wird eine Zählerstandsdifferenz multipliziert, um zum eigentlichen Verbrauch im Zeitraum zu
    ///     kommen.
    /// </summary>
    [JsonProperty(PropertyName = "wandlerfaktor", Order = 7)]
    [JsonPropertyName("wandlerfaktor")]
    [ProtoMember(7)]
    [JsonPropertyOrder(7)]
    public decimal? Wandlerfaktor { get; set; }

    /// <summary>Die Einheit der gemessenen Größe, z.B. kWh. Details <see cref="Mengeneinheit" /></summary>
    [JsonProperty(PropertyName = "einheit", Order = 8)]
    [JsonPropertyName("einheit")]
    [ProtoMember(8)]
    [JsonPropertyOrder(8)]
    public Mengeneinheit? Einheit { get; set; }

    /// <summary>Obis kennzahl</summary>
    [JsonProperty(PropertyName = "kennzahl", Order = 1009)]
    [JsonPropertyName("kennzahl")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [Obsolete("Use existing obisKennzahl instead.", true)]
    [ProtoMember(1009)]
    [JsonPropertyOrder(1009)]
    public string? Kennzahl { get; set; }

    /// <summary>schwachlastfaehig</summary>
    [JsonProperty(PropertyName = "schwachlastfaehig", Order = 1010)]
    [JsonPropertyName("schwachlastfaehig")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1010)]
    [JsonPropertyOrder(1010)]
    public Schwachlastfaehig? Schwachlastfaehig { get; set; }

    /// <summary>Verwendungungszweck der Werte Marktlokation</summary>
    [JsonProperty(PropertyName = "verwendungszwecke", Order = 1011)]
    [JsonPropertyName("verwendungszwecke")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1011)]
    [JsonPropertyOrder(1011)]
    public List<Verwendungszweck>? Verwendungszwecke { get; set; }

    /// <summary>Stromverbrauchsart/Verbrauchsart Marktlokation</summary>
    [Obsolete("Abgelöst durch 'Verbrauchsarten'. (Mehrere Verbrauchsarten möglich)")]
    [JsonProperty(PropertyName = "verbrauchsart", Order = 1012)]
    [JsonPropertyName("verbrauchsart")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1012)]
    [JsonPropertyOrder(1012)]
    public Verbrauchsart? Verbrauchsart { get; set; }

    /// <summary>Stromverbrauchsart/Unterbrechbarkeit Marktlokation</summary>
    [JsonProperty(PropertyName = "unterbrechbarkeit", Order = 1013)]
    [JsonPropertyName("unterbrechbarkeit")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1013)]
    [JsonPropertyOrder(1013)]
    public Unterbrechbarkeit? Unterbrechbarkeit { get; set; }

    /// <summary>Stromverbrauchsart/Wärmenutzung Marktlokation</summary>
    [JsonProperty(PropertyName = "waermenutzung", Order = 1014)]
    [JsonPropertyName("waermenutzung")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1014)]
    [JsonPropertyOrder(1014)]
    public Waermenutzung? Waermenutzung { get; set; }

    [JsonProperty(PropertyName = "konzessionsabgabe", Order = 1015)]
    [JsonPropertyName("konzessionsabgabe")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1015)]
    [JsonPropertyOrder(1015)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    // Todo @hamid: add a docstring
    public Konzessionsabgabe? Konzessionsabgabe { get; set; }

    [JsonProperty(PropertyName = "steuerbefreit", Order = 1016)]
    [JsonPropertyName("steuerbefreit")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1016)]
    [JsonPropertyOrder(1016)]
    // Todo @hamid: add a docstring
    public bool? Steuerbefreit { get; set; }

    [JsonProperty(PropertyName = "vorkommastelle", Order = 1017)]
    [JsonPropertyName("vorkommastelle")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1017)]
    [JsonPropertyOrder(1017)]
    // Todo @hamid: add a docstring
    public int? Vorkommastelle { get; set; }

    [JsonProperty(PropertyName = "nachkommastelle", Order = 1018)]
    [JsonPropertyName("nachkommastelle")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1018)]
    [JsonPropertyOrder(1018)]
    // Todo @hamid: add a docstring
    public int? Nachkommastelle { get; set; }

    [JsonProperty(PropertyName = "abrechnungsrelevant", Order = 1019)]
    [JsonPropertyName("abrechnungsrelevant")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1019)]
    [JsonPropertyOrder(1019)]
    // Todo @hamid: add a docstring
    public bool? Abrechnungsrelevant { get; set; }

    [JsonProperty(PropertyName = "anzahlAblesungen", Order = 1020)]
    [JsonPropertyName("anzahlAblesungen")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1020)]
    [JsonPropertyOrder(1020)]
    public int? AnzahlAblesungen { get; set; }

    [JsonProperty(PropertyName = "zaehlzeiten", Order = 1021)]
    [JsonPropertyName("zaehlzeiten")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1021)]
    [JsonPropertyOrder(1021)]
    public Zaehlzeitregister? Zaehlzeiten { get; set; }

    /// <summary>
    /// Konfiguration (iMSys) des Zählwerks
    /// </summary>
    [JsonProperty(PropertyName = "konfiguration", Order = 1022)]
    [JsonPropertyName("konfiguration")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1022)]
    [JsonPropertyOrder(1022)]
    public string? Konfiguration { get; set; }

    /// <summary>
    /// Art der E-Mobilität
    /// Das Segment dient dazu, im Falle der E-Mobilität eine genauere Angabe über die Art der E-Mobilität zu definieren.
    /// Beispiel: CAV+Z87'
    ///     ZE6: Wallbox: An der Marktlokation ist eine nicht öffentlliche Lademöglichkeit vorhanden
    ///     Z87: E-Mobilitätsladesäule: Es handelt sich um eine öffentliche Ladesäule mit ggf. mehreren Ladeanschlüssen an der Marktlokation.
    ///     ZE7: Ladepark: Es handelt sich um mehr als eine öffentliche Ladesäule an der Marktlokation
    /// </summary>
    [JsonProperty(PropertyName = "emobilitaetsart", Order = 1023)]
    [JsonPropertyOrder(1023)]
    [JsonPropertyName("emobilitaetsart")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1023)]
    public EMobilitaetsart? EMobilitaetsart { get; set; }

    /// <summary>Verbrauchsarten Marktlokation</summary>
    [JsonProperty(PropertyName = "Verbrauchsarten", Order = 1024)]
    [JsonPropertyName("Verbrauchsarten")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1024)]
    [JsonPropertyOrder(1024)]
    [System.Text.Json.Serialization.JsonConverter(
        typeof(LenientSystemTextVerbrauchsartListConverter)
    )]
    [Newtonsoft.Json.JsonConverter(typeof(LenientNewtonsoftVerbrauchsartListConverter))]
    public List<Verbrauchsart>? Verbrauchsarten { get; set; }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
