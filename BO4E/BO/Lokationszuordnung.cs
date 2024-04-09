using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// 
    /// </summary>
    public class Lokationszuordnung : BusinessObject
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 1, PropertyName = "marktlokationen")]
        [JsonPropertyName("marktlokationen")]
        [JsonPropertyOrder(1)]
        [ProtoMember(1)]
        public string[] Marktlokationen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 2, PropertyName = "messlokationen")]
        [JsonPropertyName("messlokationen")]
        [JsonPropertyOrder(2)]
        [ProtoMember(2)]
        public string[] Messlokationen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 3, PropertyName = "netzlokationen")]
        [JsonPropertyName("netzlokationen")]
        [JsonPropertyOrder(3)]
        [ProtoMember(3)]
        public string[] Netzlokationen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 4, PropertyName = "technischeRessourcen")]
        [JsonPropertyName("technischeRessourcen")]
        [JsonPropertyOrder(4)]
        [ProtoMember(4)]
        public string[] TechnischeRessourcen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5, PropertyName = "steuerbareRessourcen")]
        [JsonPropertyName("steuerbareRessourcen")]
        [JsonPropertyOrder(5)]
        [ProtoMember(5)]
        public string[] SteuerebareRessourcen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 6, PropertyName = "gueltigkeit")]
        [JsonPropertyName("gueltigkeit")]
        [JsonPropertyOrder(6)]
        [ProtoMember(6)]
        // Instead of COM.Zeitspanne (bo4e-python)
        public Zeitraum[] Gueltigkeit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 7, PropertyName = "arithmetik")]
        [JsonPropertyName("arithmetik")]
        [JsonPropertyOrder(7)]
        [ProtoMember(7)]
        public ArithmetischeOperation[] Arithmetik { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 8, PropertyName = "zuordnungstyp")]
        [JsonPropertyName("zuordnungstyp")]
        [JsonPropertyOrder(8)]
        [ProtoMember(8)]
        public string Zuordnungstyp { get; set; }

    }
}