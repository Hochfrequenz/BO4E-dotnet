using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Text.Json.Serialization;

namespace BO4E.BO
{
    /// <summary>
    /// Anfrage BO
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.MISSING)]
    public class Anfrage : BusinessObject
    {
        /// <summary>
        /// Für welche Markt- oder Messlokation gilt diese Anfrage.
        /// </summary>
        [JsonProperty(PropertyName = "lokationsId", Required = Required.Always)]
        [JsonPropertyName("lokationsId")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1000)]
        public string LokationsId { get; set; }

        /// <summary>
        /// Gibt an, ob es sich um eine Markt- oder Messlokation handelt.
        /// </summary>
        /// <see cref="Lokationstyp" />
        [JsonProperty(PropertyName = "lokationsTyp", Required = Required.Always)]
        [JsonPropertyName("lokationsTyp")]
        [ProtoMember(1001)]
        public Lokationstyp LokationsTyp { get; set; }

        /// <summary>
        /// OBIS-Kennzahl
        /// </summary>
        /// <example>
        ///     1-0:1.8.1
        /// </example>
        [JsonProperty(PropertyName = "obiskennzahl", Required = Required.Default)]
        [JsonPropertyName("obiskennzahl")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1002)]
        [BoKey]
        public string Obiskennzahl { get; set; }

        /// <summary>
        /// Sollablesetermin / Zeitangabe für Messwertanfrage. Details <see cref="Zeitraum" />
        /// </summary>
        [JsonProperty(PropertyName = "ZeitraumMesswertanfrage", Required = Required.Default)]
        [JsonPropertyName("ZeitraumMesswertanfrage")]
        [ProtoMember(1003)]
        public Zeitraum ZeitraumMesswertanfrage { get; set; }

        /// <summary>
        /// Kategorie der Anfrage (ORDERS ORDRSP BGM 1001)
        /// </summary>
        [JsonProperty(PropertyName = "anfragekategorie", Required = Required.Always)]
        [JsonPropertyName("anfragekategorie")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1004)]
        [BoKey]
        public Anfragekategorie Anfragekategorie { get; set; }

        /// <summary>
        /// Typ/Art der Anfrage (ORDERS ORDRSP IMD 7081)
        /// </summary>
        [JsonProperty(PropertyName = "anfragetyp", Required = Required.Default)]
        [JsonPropertyName("anfragetyp")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1005)]
        public Anfragetyp? Anfragetyp { get; set; }
    }
}