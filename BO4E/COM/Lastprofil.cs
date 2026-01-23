#nullable enable
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// Lastprofil
/// </summary>
[ProtoContract]
public class Lastprofil : COM
{
    /// <summary>
    /// Bezeichnung des Profils, durch DVGW bzw. den Netzbetreiber vergeben (z.B. H0)
    /// </summary>
    [JsonProperty(PropertyName = "bezeichnung")]
    [JsonPropertyName("bezeichnung")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1001)]
    public string? Bezeichnung { get; set; }

    /// <summary>
    /// Optionale Bezeichnung der Profilschar, durch DVGW bzw. den Netzbetreiber vergeben (z.B. H0)
    /// </summary>
    [JsonProperty(PropertyName = "profilschar")]
    [JsonPropertyName("profilschar")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1002)]
    public string? Profilschar { get; set; }

    /// <summary>
    /// Verfahren des Profils (analytisch oder synthetisch)
    /// </summary>
    [JsonProperty(PropertyName = "verfahren")]
    [JsonPropertyName("verfahren")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1003)]
    public Profilverfahren? Verfahren { get; set; }

    /// <summary>
    /// true, falls es sich um ein Einspeiseprofil handelt
    /// </summary>
    [JsonProperty(PropertyName = "einspeisung")]
    [JsonPropertyName("einspeisung")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1004)]
    public bool? Einspeisung { get; set; }

    /// <summary>
    /// Klimazone / Temperaturmessstelle
    /// </summary>
    [JsonProperty(PropertyName = "tagesparameter")]
    [JsonPropertyName("tagesparameter")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1005)]
    public Tagesparameter? Tagesparameter { get; set; }

    /// <summary>
    ///    Profilart des Lastprofils
    /// </summary>
    /// <example>ART_STANDARDLASTPROFIL</example>
    [JsonProperty(PropertyName = "profilart")]
    [JsonPropertyName("profilart")]
    [ProtoMember(1006)]
    public Profilart? Profilart { get; set; }

    /// <summary>
    ///    Herausgeber des Lastprofil-Codes
    /// </summary>
    /// <example>BDEW</example>
    [JsonProperty(PropertyName = "herausgeber")]
    [JsonPropertyName("herausgeber")]
    [ProtoMember(1007)]
    public string? Herausgeber { get; set; }

    /// <summary>
    ///   Profiltyp
    /// </summary>
    /// <example>HAUSHALT</example>
    [JsonProperty(PropertyName = "profiltyp")]
    [JsonPropertyName("profiltyp")]
    [ProtoMember(1008)]
    public Profilklasse? Profiltyp { get; set; }

    /// <summary>
    ///   Normierungsfaktor
    /// </summary>
    /// <example>300_KWH_K</example>
    [JsonProperty(PropertyName = "normierungsfaktor")]
    [JsonPropertyName("normierungsfaktor")]
    [ProtoMember(1009)]
    public Normierungsfaktor? Normierungsfaktor { get; set; }
}
