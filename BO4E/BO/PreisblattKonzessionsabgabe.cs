using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    ///     Die Variante des Preisblattmodells zur Abbildung von allgemeinen Abgaben
    /// </summary>
    //[ProtoContract]
    public class PreisblattKonzessionsabgabe : Preisblatt
    {
        /// <summary>
        ///     Sparte, auf die sich die KA bezieht.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7, PropertyName = "sparte")]
        [JsonPropertyName("sparte")]
        //[ProtoMember(7)]
        public Sparte Sparte { get; set; }

        /// <summary>
        ///     Kundegruppe anhand derer die Höhe der Konzessionsabgabe festgelegt ist.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8, PropertyName = "kundengruppeKA")]
        [JsonPropertyName("kundengruppeKA")]
        //[ProtoMember(8)]
        public KundengruppeKA KundengruppeKA { get; set; }
    }
}