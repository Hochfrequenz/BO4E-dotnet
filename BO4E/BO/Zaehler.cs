#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Mit diesem Geschäftsobjekt wird die Information zu einem Zähler abgebildet.
/// </summary>
[ProtoContract]
public class Zaehler : BusinessObject
{
    /// <summary>Nummerierung des Zählers, vergeben durch den Messstellenbetreiber</summary>
    [BoKey]
    [JsonProperty(Order = 10, PropertyName = "zaehlernummer")]
    [JsonPropertyName("zaehlernummer")]
    [ProtoMember(4)]
    [JsonPropertyOrder(10)]
    public string? Zaehlernummer { get; set; }

    /// <summary>Strom oder Gas. <seealso cref="ENUM.Sparte" /></summary>
    [JsonProperty(Order = 11, PropertyName = "sparte")]
    [JsonPropertyName("sparte")]
    [ProtoMember(5)]
    [JsonPropertyOrder(11)]
    public Sparte? Sparte { get; set; }

    /// <summary>
    ///     Spezifikation die Richtung des Zählers betreffend.
    ///     <seealso cref="ENUM.Zaehlerauspraegung" />
    /// </summary>
    [JsonProperty(Order = 12, PropertyName = "zaehlerauspraegung")]
    [JsonPropertyName("zaehlerauspraegung")]
    [ProtoMember(6)]
    [JsonPropertyOrder(12)]
    public Zaehlerauspraegung? Zaehlerauspraegung { get; set; }

    /// <summary>
    ///     Typisierung des Zählers
    ///     <seealso cref="ENUM.Zaehlertyp" />
    /// </summary>
    [JsonProperty(
        //
        Order = 13,
        PropertyName = "zaehlertyp"
    )]
    [ProtoMember(7)]
    [JsonPropertyOrder(13)]
    [JsonPropertyName("zaehlertyp")]
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)] // this is ALWAYS required in BO4E standard; Maybe nullable if you as a LIEFERANT don't care about the type of Zähler, othern than in the grid
    public Zaehlertyp? Zaehlertyp { get; set; }

    /// <summary>
    ///     Spezifikation bezüglich unterstützter Tarifarten.
    ///     <seealso cref="ENUM.Tarifart" />
    /// </summary>
    [JsonProperty(Order = 14, PropertyName = "tarifart")]
    [JsonPropertyName("tarifart")]
    [ProtoMember(8)]
    [JsonPropertyOrder(14)]
    public Tarifart? Tarifart { get; set; }

    /// <summary>Zählerkonstante auf dem Zähler.</summary>
    [JsonProperty(Order = 15, PropertyName = "zaehlerkonstante")]
    [JsonPropertyName("zaehlerkonstante")]
    [ProtoMember(9)]
    [JsonPropertyOrder(15)]
    public decimal? Zaehlerkonstante { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(10, Name = nameof(EichungBis))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _EichungBis
    {
        get => EichungBis?.UtcDateTime ?? default;
        set => EichungBis = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Bis zu diesem Datum ist der Zähler geeicht.</summary>
    [JsonProperty(Order = 16, PropertyName = "eichungBis")]
    [JsonPropertyName("eichungBis")]
    [JsonPropertyOrder(16)]
    [ProtoIgnore]
    public DateTimeOffset? EichungBis { get; set; } // ToDO implement date

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(11, Name = nameof(LetzteEichung))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _LetzteEichung
    {
        get => LetzteEichung?.UtcDateTime ?? default;
        set =>
            LetzteEichung = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Zu diesem Datum fand die letzte Eichprüfung des Zählers statt.</summary>
    [JsonProperty(Order = 17, PropertyName = "letzteEichung")]
    [JsonPropertyName("letzteEichung")]
    [ProtoIgnore]
    [JsonPropertyOrder(17)]
    public DateTimeOffset? LetzteEichung { get; set; }

    /// <summary>
    ///     Die Zählwerke des Zählers.
    ///     <seealso cref="Zaehlwerk" />
    /// </summary>
    [JsonProperty(Order = 18, PropertyName = "zaehlwerke")]
    [JsonPropertyName("zaehlwerke")]
    [ProtoMember(12)]
    [JsonPropertyOrder(18)]
    public List<Zaehlwerk>? Zaehlwerke { get; set; }

    /// <summary>Der Hersteller des Zählers. Details <see cref="Geschaeftspartner" /></summary>
    [JsonProperty(
        Order = 19,
        NullValueHandling = NullValueHandling.Ignore,
        PropertyName = "zaehlerhersteller"
    )]
    [JsonPropertyName("zaehlerhersteller")]
    [ProtoMember(13)]
    [JsonPropertyOrder(19)]
    public Geschaeftspartner? Zaehlerhersteller { get; set; }

    /// <summary>
    ///     Referenz auf das Smartmeter-Gateway
    /// </summary>
    [JsonProperty(Order = 20, PropertyName = "gateway")]
    [JsonPropertyName("gateway")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1014)]
    [JsonPropertyOrder(20)]
    public string? Gateway { get; set; }

    /// <summary>
    ///     Fernschaltung
    /// </summary>
    [JsonProperty(Order = 21, PropertyName = "fernschaltung")]
    [JsonPropertyName("fernschaltung")]
    [ProtoMember(1015)]
    [JsonPropertyOrder(21)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public Fernschaltung? Fernschaltung { get; set; }

    /// <summary>
    ///     Messwerterfassung am Zählpunkt
    /// </summary>
    [JsonProperty(Order = 22, PropertyName = "messwerterfassung")]
    [JsonPropertyName("messwerterfassung")]
    [ProtoMember(1016)]
    [JsonPropertyOrder(22)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public Messwerterfassung? Messwerterfassung { get; set; }

    /// <summary>
    ///     Typisierung des Zählers (spezifikation für EHZ und MME)
    ///     <seealso cref="ENUM.ZaehlertypSpezifikation" />
    /// </summary>
    [JsonProperty(PropertyName = "zaehlertypspezifikation", Order = 23)]
    [ProtoMember(1017)]
    [JsonPropertyOrder(23)]
    [JsonPropertyName("zaehlertypspezifikation")]
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public ZaehlertypSpezifikation? Zaehlertypspezifikation { get; set; }

    /// <summary>
    ///     Befestigungsart
    /// </summary>
    [JsonProperty(Order = 24, PropertyName = "befestigungsart")]
    [JsonPropertyName("befestigungsart")]
    [ProtoMember(1018)]
    [JsonPropertyOrder(24)]
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public Befestigungsart? Befestigungsart { get; set; }

    /// <summary>
    ///     Zaehlergroesse
    /// </summary>
    [JsonProperty(Order = 25, PropertyName = "zaehlergroesse")]
    [JsonPropertyName("zaehlergroesse")]
    [ProtoMember(1019)]
    [JsonPropertyOrder(25)]
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    [Newtonsoft.Json.JsonConverter(typeof(LenientGeraetemerkmalGasConverter))]
    [System.Text.Json.Serialization.JsonConverter(
        typeof(LenientSystemTextNullableGeraetemerkmalGasConverter)
    )]
    public Geraetemerkmal? Zaehlergroesse { get; set; }

    /// <summary>Liste der Geräte, die zu diesem Zähler gehören.</summary>
    [JsonProperty(PropertyName = "geraete", Order = 26)]
    [JsonPropertyOrder(26)]
    [JsonPropertyName("geraete")]
    [ProtoMember(1020)]
    public List<Geraet>? Geraete { get; set; }
}
