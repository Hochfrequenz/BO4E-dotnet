using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO;

// Ordering is defined in Geschaeftspartner
/// <summary>
///     Objekt zur Kommunikation von Marktteilnehmern jeglicher Art.
/// </summary>
//[ProtoContract]
public class Marktteilnehmer : Geschaeftspartner
{
    /// <summary>
    ///     empty constructor
    /// </summary>
    public Marktteilnehmer()
    {
        Gewerbekennzeichnung = true;
    }

    /// <summary>Gibt im Klartext die Bezeichnung der Marktrolle an.</summary>
    /// <example>LF</example>
    [JsonProperty(Required = Required.Default, Order = 31, PropertyName = "marktrolle")]
    [JsonPropertyName("marktrolle")]
    [JsonPropertyOrder(31)]
    //[ProtoMember(19)]
    public Marktrolle? Marktrolle { get; set; }

    /// <summary>Gibt die Codenummer der Marktrolle an.</summary>
    /// <example>"9903100000006"</example>
    [BoKey(true)]
    [JsonProperty(Order = 32, PropertyName = "rollencodenummer")]
    [JsonPropertyName("rollencodenummer")]
    [JsonPropertyOrder(32)]
    //[ProtoMember(20)]
    public string Rollencodenummer { get; set; }

    /// <summary>Gibt den Typ des Codes an.</summary>
    /// <example>BDEW (instead of 293, 500 etc.)</example>
    [JsonProperty(Order = 33, PropertyName = "rollencodetyp")]
    [JsonPropertyOrder(33)]
    [JsonPropertyName("rollencodetyp")]
    //[ProtoMember(21)]
    public Rollencodetyp Rollencodetyp { get; set; }

    /// <summary>
    ///     Die 1:1-Kommunikationsadresse des Marktteilnehmers. Diese wird in der
    ///     Marktkommunikation verwendet.
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 34, PropertyName = "makoadresse")] // relaxed from always to default to make COM.Marktrolle obsolete.
    [JsonPropertyName("makoadresse")]
    [JsonPropertyOrder(34)]
    //[ProtoMember(22)]
    public string? Makoadresse { get; set; }

    /// <summary>
    ///     Ansprechpartner as in EDIFACT NAD+MS, that includes e.g. the email address of a natural person.
    /// </summary>
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [JsonProperty(Required = Required.Default, Order = 35, PropertyName = "ansprechpartner")]
    [JsonPropertyOrder(35)]
    [JsonPropertyName("ansprechpartner")]
    //[ProtoMember(23)]
    public Ansprechpartner? Ansprechpartner { get; set; }
}
