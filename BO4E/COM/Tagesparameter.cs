using System.Text.Json.Serialization;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Speichert Informationen zu einer tagesparameter abhängigen Messstelle. z.B. den Namen einer Klimazone oder die ID der Wetterstation für die Temperaturmessstelle
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public class Tagesparameter : COM
{
    /// <summary>
    ///     Qualifier der Klimazone
    /// </summary>
    /// <example>7624q</example>
    [JsonProperty(PropertyName = "klimazone")]
    [JsonPropertyName("klimazone")]
    [ProtoMember(3)]
    public string? Klimazone { get; set; }

    /// <summary>
    ///     Qualifier der Temperaturmessstelle
    /// </summary>
    /// <example>1234x</example>
    [JsonProperty(PropertyName = "temperaturmessstelle")]
    [JsonPropertyName("temperaturmessstelle")]
    [ProtoMember(4)]
    public string? Temperaturmessstelle { get; set; }

    /// <summary>
    ///    Dienstanbieter (bei Temperaturmessstellen)
    /// </summary>
    /// <example>ZT1</example>
    [JsonProperty(PropertyName = "dienstanbieter")]
    [JsonPropertyName("dienstanbieter")]
    [ProtoMember(5)]
    public string? Dienstanbieter { get; set; }

    /// <summary>
    ///    Herausgeber des Lastprofil-Codes
    /// </summary>
    /// <example>BDEW</example>
    [JsonProperty(PropertyName = "herausgeber")]
    [JsonPropertyName("herausgeber")]
    [ProtoMember(6)]
    public string? Herausgeber { get; set; }
}
