using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;
using System.Text.Json.Serialization;

namespace BO4E.BO
{
    /// <summary>
    /// Reklamations BO
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.MISSING)]
    public class Reklamation : BusinessObject
    {
        /// <summary>
        /// Für welche Markt- oder Messlokation gilt diese Reklamation.
        /// </summary>
        [JsonProperty(PropertyName = "lokationsId", Required = Required.Always, Order = 10)]
        [JsonPropertyName("lokationsId")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1000)]
        [JsonPropertyOrder(10)]
        public string LokationsId { get; set; }

        /// <summary>
        /// Gibt an, ob es sich um eine Markt- oder Messlokation handelt.
        /// </summary>
        /// <see cref="Lokationstyp" />
        [JsonProperty(PropertyName = "lokationsTyp", Required = Required.Always, Order = 11)]
        [JsonPropertyName("lokationsTyp")]
        [ProtoMember(1001)]
        [JsonPropertyOrder(11)]
        public Lokationstyp LokationsTyp { get; set; }


        /// <summary>
        /// OBIS-Kennzahl
        /// </summary>
        /// <example>
        ///     1-0:1.8.1
        /// </example>
        [JsonProperty(PropertyName = "obiskennzahl", Required = Required.Always, Order = 12)]
        [JsonPropertyName("obiskennzahl")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1002)]
        [BoKey]
        [JsonPropertyOrder(12)]
        public string Obiskennzahl { get; set; }

        /// <summary>
        /// Sollablesetermin / Zeitangabe für Messwertanfrage. Details <see cref="Zeitraum" />
        /// </summary>
        [JsonProperty(PropertyName = "ZeitraumMesswertanfrage", Required = Required.Default, Order = 13)]
        [JsonPropertyName("ZeitraumMesswertanfrage")]
        [ProtoMember(1003)]
        [JsonPropertyOrder(13)]
        public Zeitraum? ZeitraumMesswertanfrage { get; set; }

        /// <summary>
        /// Hier wird für die Reklamation von Werten der Reklamationsgrund angegeben.
        /// </summary>
        [JsonProperty(PropertyName = "reklamationsgrund", Required = Required.Always, Order = 14)]
        [JsonPropertyName("reklamationsgrund")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1004)]
        [BoKey]
        [JsonPropertyOrder(14)]
        public Reklamationsgrund Reklamationsgrund { get; set; }

        /// <summary>
        /// Freitext für eine weitere Beschreibung des Reklamationsgrunds
        /// </summary>
        [JsonProperty(PropertyName = "reklamationsgrundBemerkung", Required = Required.Default, Order = 15)]
        [JsonPropertyName("reklamationsgrundBemerkung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1005)]
        [JsonPropertyOrder(15)]
        public string? ReklamationsgrundBemerkung { get; set; }
    }
}
