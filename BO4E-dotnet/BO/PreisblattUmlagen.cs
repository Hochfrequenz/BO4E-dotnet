using BO4E.ENUM;

using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Die Variante des Preisblattmodells zur Abbildung von allgemeinen Abgaben.
    /// </summary>
    //[ProtoContract]
    public class PreisblattUmlagen : Preisblatt
    {
        /// <summary>
        /// Sparte, auf die sich die Umlage bezieht. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7, PropertyName = "sparte")]

        [System.Text.Json.Serialization.JsonPropertyName("sparte")]
        //[ProtoMember(7)]
        public Sparte Sparte { get; set; }
    }
}