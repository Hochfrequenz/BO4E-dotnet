﻿using System.Text.Json.Serialization;
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
        [JsonProperty(Required = Required.Always, PropertyName = "referenzRechenschrittID")]
        [JsonPropertyName("referenzRechenschrittID")]
        public int ReferenzRechenschrittId { get; set; }

        /// <summary>
        /// Die Rechenoperation dieses Schrittes
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 3, PropertyName = "operation")]
        [JsonPropertyName("operation")]
        [BoKey]
        [ProtoMember(3)]
        public ArithmetischeOperation Operation { get; set; }

        /// <summary>
        /// Ein möglicher Trafoverlust
        /// </summary>
        /// <remarks>UTILTS SG9 CCI Z16</remarks>
        [JsonProperty(Required = Required.AllowNull, Order = 4, PropertyName = "verlustfaktorTrafo")]
        [JsonPropertyName("verlustfaktorTrafo")]
        [ProtoMember(4)]
        public decimal? VerlustfaktorTrafo { get; set; }

        /// <summary>
        /// Ein möglicher Leitungsverlust
        /// </summary>
        /// <remarks>UTILTS SG9 CCI ZB2</remarks>
        [JsonProperty(Required = Required.AllowNull, Order = 5, PropertyName = "verlustfaktorLeitung")]
        [JsonPropertyName("verlustfaktorLeitung")]
        [ProtoMember(5)]
        public decimal? VerlustfaktorLeitung { get; set; }

        /// <summary>
        /// Verweis auf MesslokationsId
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 6, PropertyName = "messlokationId")]
        [JsonPropertyName("messlokationId")]
        [ProtoMember(6)]
        public string MesslokationId { get; set; }

        /// <summary>
        /// rekursive Verschachtelung weiterer rechenschritte
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 6, PropertyName = "weitererRechenschritt")]
        [JsonPropertyName("weitererRechenschritt")]
        public Rechenschritt WeitererRechenschritt { get; set; }
    }
}