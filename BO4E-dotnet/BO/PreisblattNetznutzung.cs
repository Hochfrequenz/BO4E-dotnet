using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Die Variante des Preisblattmodells zur Abbildung der Netznutzungspreise.
    /// </summary>
    //[ProtoContract]
    public class PreisblattNetznutzung : Preisblatt
    {
        /// <summary>
        /// Preisblatt gilt für angegebene Sparte. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7, PropertyName="sparte")]

        [System.Text.Json.Serialization.JsonPropertyName("sparte")]
        //[ProtoMember(7)]
        public Sparte Sparte { get;set; }

        /// <summary>
        /// Die Preise gelten für Marktlokationen der angegebenen Bilanzierungsmethode. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8, PropertyName="bilanzierungsmethode")]

        [System.Text.Json.Serialization.JsonPropertyName("bilanzierungsmethode")]
        //[ProtoMember(8)]
        public Bilanzierungsmethode Bilanzierungsmethode { get;set; }

        /// <summary>
        /// Die Preise gelten für Marktlokationen in der angegebenen Netzebene.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 9, PropertyName= "netzebene")]

        [System.Text.Json.Serialization.JsonPropertyName("netzebene")]
        //[ProtoMember(9)]
        public Netzebene Netzebene { get;set; }

        /// <summary>
        /// Hier wird die Kundengruppe, für die der Preis gilt mit angegeben. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 10, PropertyName="kundengruppe")]

        [System.Text.Json.Serialization.JsonPropertyName("kundengruppe")]
        //[ProtoMember(10)]
        public Kundengruppe Kundengruppe { get;set; }

        /// <summary>
        /// Der Netzbetreiber oder Messstellenbetreiber, der die Preise veröffentlicht hat. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 11, PropertyName="herausgeber")]

        [System.Text.Json.Serialization.JsonPropertyName("herausgeber")]
        //[ProtoMember(11)]
        public Marktteilnehmer Herausgeber { get;set; }
    }
}
