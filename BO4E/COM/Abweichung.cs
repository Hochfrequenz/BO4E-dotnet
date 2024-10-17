using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// Zur Angabe einer Abweichung bei Ablehnung einer COMDIS. (REMADV SG5 RFF und SG7 AJT/FTX)
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class Abweichung : COM
{
    /// <summary>
    /// Angabe des Abweichungsgrunds
    /// </summary>
    [JsonProperty(PropertyName = "abweichungsgrund", Order = 3)]
    [JsonPropertyName("abweichungsgrund")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(3)]
    public Abweichungsgrund? Abweichungsgrund { get; set; }

    /// <summary>
    /// Nähere Erläuterung zum Abweichungsgrund
    /// </summary>
    [JsonProperty(PropertyName = "abweichungsgrundBemerkung", Order = 4)]
    [JsonPropertyName("abweichungsgrundBemerkung")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(4)]
    public string? AbweichungsgrundBemerkung { get; set; }

    /// <summary>
    /// Zugehörige Rechnung
    /// </summary>
    [JsonProperty(PropertyName = "zugehoerigeRechnung", Order = 5)]
    [JsonPropertyName("zugehoerigeRechnung")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(5)]
    public string? ZugehoerigeRechnung { get; set; }

    /// <summary>
    /// Abschlagsrechnungen
    /// </summary>
    [JsonProperty(PropertyName = "abschlagsrechnungen", Order = 6)]
    [JsonPropertyName("abschlagsrechnungen")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(6)]
    public List<string>? Abschlagsrechnungen { get; set; }

    /// <summary>
    /// Angabe des Abweichungsgrunds (Code)
    /// </summary>
    [JsonProperty(PropertyName = "abweichungsgrundCode", Order = 8)]
    [JsonPropertyName("abweichungsgrundCode")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(8)]
    public string? AbweichungsgrundCode { get; set; }

    /// <summary>
    /// Angabe des Abweichungsgrunds (Code)
    /// </summary>
    [JsonProperty(PropertyName = "abweichungsgrundCodeliste", Order = 9)]
    [JsonPropertyName("abweichungsgrundCodeliste")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(9)]
    public string? AbweichungsgrundCodeliste { get; set; }
}
