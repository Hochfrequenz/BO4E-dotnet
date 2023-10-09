using System.ComponentModel;
using System.Text.Json.Serialization;

using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    ///     Objekt zur Aufnahme der Informationen zu einer Netzlokation
    /// </summary>
    [ProtoContract]
    public class Netzlokation : BusinessObject
    {
        /// <summary>
        ///     Identifikationsnummer einer Netzlokation, an der Energie entweder
        ///     verbraucht, oder erzeugt wird (Like MarktlokationsId <see cref="Marktlokation"/>)
        /// </summary>
        [DefaultValue("|null|")]
        [JsonProperty(Required = Required.Always, Order = 10, PropertyName = "netzlokationsId")]
        [JsonPropertyName("netzlokationsId")]
        [JsonPropertyOrder(10)]
        [DataCategory(DataCategory.POD)]
        [BoKey]
        [ProtoMember(4)]
        public string NetzlokationsId { get; set; }

        /// <summary>Sparte der Netzlokation, z.B. Gas oder Strom.</summary>
        [JsonProperty(Required = Required.Always, Order = 11, PropertyName = "sparte")]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("sparte")]
        [ProtoMember(5)]
        public Sparte Sparte { get; set; }

        /// <summary>
        /// Netzanschlussleistung der Netzlokation in Kilowatt
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "netzanschlussleistung")]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("netzanschlussleistung")]
        [ProtoMember(6)]
        public decimal? Netzanschlussleistung { get; set; }

        /// <summary>
        ///     Codenummer des grundzuständigen Messstellenbetreibers, der für diese
        ///     Netzlokation zuständig ist.
        /// </summary>
        [JsonProperty(PropertyName = "grundzustaendigerMSBCodeNr", Required = Required.Default, Order = 13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("grundzustaendigerMSBCodeNr")]
        [ProtoMember(7)]
        public string? GrundzustaendigerMSBCodeNr { get; set; }
    }
}
