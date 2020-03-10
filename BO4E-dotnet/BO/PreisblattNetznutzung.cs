using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Die Variante des Preisblattmodells zur Abbildung der Netznutzungspreise.
    /// </summary>
    public class PreisblattNetznutzung : Preisblatt
    {
        /// <summary>
        /// Preisblatt gilt für angegebene Sparte. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6)]
        [ProtoMember(2)]
        public Sparte sparte;

        /// <summary>
        /// Die Preise gelten für Marktlokationen der angegebenen Bilanzierungsmethode. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7)]
        [ProtoMember(3)]
        public Bilanzierungsmethode bilanzierungsmethode;

        /// <summary>
        /// Die Preise gelten für Marktlokationen in der angegebenen Netzebene.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8)]
        [ProtoMember(4)]
        public Netzebene netzebene;

        /// <summary>
        /// Hier wird die Kundengruppe, für die der Preis gilt mit angegeben. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        public Kundengruppe kundengruppe;

        /// <summary>
        /// Der Netzbetreiber oder Messstellenbetreiber, der die Preise veröffentlicht hat. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6)]
        [ProtoMember(6)]
        public Marktteilnehmer herausgeber;
    }
}
