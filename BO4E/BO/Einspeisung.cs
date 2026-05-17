using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Einspeisung BO
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class Einspeisung : BusinessObject
{
    /// <summary>
    /// Für welche Marktlokation gelten diese Einspeisedaten
    /// </summary>
    [JsonProperty(PropertyName = "marktlokationsId", Order = 10)]
    [JsonPropertyName("marktlokationsId")]
    [JsonPropertyOrder(10)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(10)]
    [BoKey]
    public string? MarktlokationsId { get; set; }

    /// <summary>
    /// Für welche Tranche gelten diese Einspeisedaten
    /// </summary>
    [JsonProperty(PropertyName = "trancheId", Order = 101)]
    [JsonPropertyName("trancheId")]
    [JsonPropertyOrder(101)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(101)]
    [BoKey]
    public string? TrancheId { get; set; }

    /// <summary>
    /// Empfänger der Vergütung zur Einspeisung
    /// </summary>
    [JsonProperty(PropertyName = "verguetungsempfaenger", Order = 11)]
    [JsonPropertyName("verguetungsempfaenger")]
    [JsonPropertyOrder(11)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(11)]
    public Geschaeftspartnerrolle? Verguetungsempfaenger { get; set; }

    /// <summary>
    /// Vermarktungsformen gemäß dem Erneuerbare-Energien-Gesetz (EEG).
    /// </summary>
    [JsonProperty(PropertyName = "eegVermarktungsform", Order = 12)]
    [JsonPropertyName("eegVermarktungsform")]
    [JsonPropertyOrder(12)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(12)]
    public EEGVermarktungsform? EEGVermarktungsform { get; set; }

    /// <summary>Land der Förderung, Details <see cref="ENUM.Landescode" /></summary>
    [JsonProperty(PropertyName = "landescode", Order = 13)]
    [JsonPropertyName("landescode")]
    [ProtoMember(13)]
    [JsonPropertyOrder(13)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    public Landescode? Landescode { get; set; }

    /// <summary>
    /// Status der Fernsteuerbarkeit einer Marktlokation
    /// </summary>
    [JsonProperty(PropertyName = "fernsteuerbarkeitStatus", Order = 14)]
    [JsonPropertyName("fernsteuerbarkeitStatus")]
    [JsonPropertyOrder(14)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(14)]
    public FernsteuerbarkeitStatus? FernsteuerbarkeitStatus { get; set; }

    /// <summary>
    /// Erzeugungsart
    /// </summary>
    [JsonProperty(PropertyName = "erzeugungsart", Order = 15)]
    [JsonPropertyName("erzeugungsart")]
    [JsonPropertyOrder(15)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(15)]
    public Erzeugungsart? Erzeugungsart { get; set; }

    /// <summary>
    /// Direktvermarktungspflichtig
    /// </summary>
    [JsonProperty(PropertyName = "istDvPflichtig", Order = 16)]
    [JsonPropertyName("istDvPflichtig")]
    [JsonPropertyOrder(16)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(16)]
    public bool? IstDvPflichtig { get; set; }
}
