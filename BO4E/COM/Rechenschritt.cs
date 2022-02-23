using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Ein Berechnungsschritt ist Teil einer <see cref="BO4E.BO.Berechnungsformel"/>
    /// </summary>
    /// <remarks>Entspricht der SG9 in UTILTS</remarks>
    public class Rechenschritt : COM
    {
        /// <summary>
        /// Die BestandteilID des Rechenschritt (1-99999)
        /// </summary>
        /// <remarks>UTILTS SG8 RFF 1154 / SG</remarks>
        [JsonProperty(Required = Required.Always, PropertyName = "rechenschrittBestandteilId")]
        [JsonPropertyName("rechenschrittBestandteilId")]
        public int RechenschrittBestandteilId { get; set; }

        /// <summary>
        /// Die ReferenzID des Rechenschritt (1-99999)
        /// </summary>
        /// <remarks>UTILTS SG8 RFF 1154 / SG</remarks>
        [JsonProperty(Required = Required.Always, PropertyName = "referenzRechensschrittID")]
        [JsonPropertyName("referenzRechensschrittID")]
        public int ReferenzRechenschrittId { get; set; }

        /// <summary>
        /// Die Rechenoperation
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 3, PropertyName = "operation")]
        [JsonPropertyName("operation")]
        [BoKey]
        [ProtoMember(3)]
        public ArithmetischeOperation Operation { get; set; }

        /// <summary>
        /// Ein möglicher Trafoverlust
        /// </summary>
        [JsonProperty(Required = Required.AllowNull, Order = 4, PropertyName = "verlustTrafo")]
        [JsonPropertyName("verlustTrafo")]
        [ProtoMember(4)]
        public decimal? VerlustTrafo { get; set; }

        /// <summary>
        /// Ein möglicher Leitungsverlust
        /// </summary>
        [JsonProperty(Required = Required.AllowNull, Order = 5, PropertyName = "verlustLeitung")]
        [JsonPropertyName("verlustLeitung")]
        [ProtoMember(5)]
        public decimal? VerlustLeitung { get; set; }

        /// <summary>
        /// Verweis auf MesslokationsId
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 6, PropertyName = "referenzMesslokationId")]
        [JsonPropertyName("referenzMesslokationId")]
        [ProtoMember(6)]
        public string ReferenzMesslokationId { get; set; }

        /// <summary>
        /// rekursive Verschachtelung weiterer rechenschritte
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 6, PropertyName = "weitererRechenschritt")]
        [JsonPropertyName("weitererRechenschritt")]
        public Rechenschritt WeitererRechenschritt { get; set; }
    }
}
