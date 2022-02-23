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
        /// Die ID des Rechenschritt (1-99999)
        /// </summary>
        /// <remarks>UTILTS SG8 RFF 1154 / SG</remarks>
        [JsonProperty(Required = Required.Always, PropertyName = "rechenschrittId")]
        public int RechenschrittId { get; set; }

        /// <summary>
        /// Die Rechenoperation
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "operation")]
        [JsonPropertyName("operation")]
        [BoKey]
        [ProtoMember(4)]
        public ArithmetischeOperation Operation { get; set; }

        /// <summary>
        /// Verwendungszweck der Werte
        /// </summary>
        /// <remarks>SG9 CAV 7111</remarks>
        [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "verwendungszweck")]
        [JsonPropertyName("verwendungszweck")]
        public Verwendungszweck Verwendungszweck { get; set; }

        // todo: verlustfaktoren adden

    }
}
