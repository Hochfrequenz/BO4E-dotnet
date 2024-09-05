using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.EnergyIdentificationCodes;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Summenzeitreihen BO
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class Summenzeitreihe : BusinessObject
{
    /// <summary>
    /// Für welchen MABIS-Zaehlpuunkt gelten diese Summenzeitreihendaten
    /// </summary>
    [JsonProperty(PropertyName = "zaehlpunktId", Required = Required.Default, Order = 10)]
    [JsonPropertyName("zaehlpunktId")]
    [JsonPropertyOrder(10)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1000)]
    [BoKey]
    public string? ZaehlpunktId { get; set; }

    /// <summary>
    /// Inklusiver Start der Bilanzierung
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(1002, Name = nameof(Bilanzierungsbeginn))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Bilanzierungsbeginn
    {
        get => Bilanzierungsbeginn?.UtcDateTime ?? DateTime.MinValue;
        set => Bilanzierungsbeginn = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    /// Inklusiver Start der Bilanzierung
    /// </summary>
    [JsonProperty(PropertyName = "bilanzierungsbeginn", Required = Required.Default, Order = 12)]
    [JsonPropertyName("bilanzierungsbeginn")]
    [JsonPropertyOrder(12)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoIgnore]
    public DateTimeOffset? Bilanzierungsbeginn { get; set; }

    /// <summary>
    /// Exklusives Ende der Bilanzierung
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(1003, Name = nameof(Bilanzierungsende))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Bilanzierungsende
    {
        get => Bilanzierungsende?.UtcDateTime ?? DateTime.MinValue;
        set => Bilanzierungsende = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    /// Exklusives Ende der Bilanzierung
    /// </summary>
    [JsonProperty(PropertyName = "bilanzierungsende", Required = Required.Default, Order = 13)]
    [JsonPropertyName("bilanzierungsende")]
    [JsonPropertyOrder(13)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoIgnore]
    public DateTimeOffset? Bilanzierungsende { get; set; }

    /// <summary>
    /// Bilanzkreis, should obey <see cref="EnergyIdentificationCodeExtensions.IsValidEIC"/>
    /// </summary>
    [JsonProperty(PropertyName = "bilanzkreis", Required = Required.Default, Order = 14)]
    [JsonPropertyName("bilanzkreis")]
    [JsonPropertyOrder(14)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1004)]
    [BoKey]
    public string? Bilanzkreis { get; set; }

    /// <summary>Bilanzierungsgebiet, dem das Netzgebiet zugeordnet ist - im Falle eines Strom Netzes.</summary>
    [JsonProperty(Required = Required.Default, Order = 15, PropertyName = "bilanzierungsgebiet")]
    [JsonPropertyOrder(15)]
    [JsonPropertyName("bilanzierungsgebiet")]
    [ProtoMember(1005)]
    public string? Bilanzierungsgebiet { get; set; }

    /// <summary>
    /// Regelzone
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 16, PropertyName = "regelzone")]
    [JsonPropertyName("regelzone")]
    [JsonPropertyOrder(16)]
    [ProtoMember(1006)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public string? Regelzone { get; set; }

    /// <summary>
    /// Bezeichnung
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 17, PropertyName = "bezeichnung")]
    [JsonPropertyName("bezeichnung")]
    [JsonPropertyOrder(17)]
    [ProtoMember(1007)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public BezeichnungSummenzeitreihe? Bezeichnung { get; set; }

    /// <summary>
    /// Bezugszeitraum (TAG,MONAT)
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 18, PropertyName = "bezugszeitraum")]
    [JsonPropertyName("bezugszeitraum")]
    [JsonPropertyOrder(18)]
    [ProtoMember(1008)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public Zeiteinheit? Bezugszeitraum { get; set; }

    /// <summary>
    /// Zeitreihentyp (SLS, TLS, etc.)
    /// </summary>
    [JsonProperty(PropertyName = "zeitreihentyp", Required = Required.Default, Order = 19)]
    [JsonPropertyName("zeitreihentyp")]
    [JsonPropertyOrder(19)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1019)]
    public Zeitreihentyp? Zeitreihentyp { get; set; }

    /// <summary>
    ///  Verantwortliche Marktrolle
    /// </summary>
    [JsonProperty(PropertyName = "marktrolle", Required = Required.Default, Order = 20)]
    [JsonPropertyName("marktrolle")]
    [JsonPropertyOrder(20)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1020)]
    public ENUM.Marktrolle? Marktrolle { get; set; }

    /// <summary>
    ///  Spannungsebene
    /// </summary>
    [JsonProperty(PropertyName = "spannungsebene", Required = Required.Default, Order = 21)]
    [JsonPropertyName("spannungsebene")]
    [JsonPropertyOrder(21)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1021)]
    public Netzebene? Spannungsebene { get; set; }

    /// <summary>
    ///     Produkte der Summenzeitreihe
    /// </summary>
    [JsonProperty(PropertyName = "produkte", Order = 22, Required = Required.Default)]
    [JsonPropertyName("produkte")]
    [ProtoMember(1022)]
    [JsonPropertyOrder(22)]
    public List<Zeitreihenprodukt>? Produkte { get; set; }
}
