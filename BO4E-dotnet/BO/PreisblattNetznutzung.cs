using BO4E.ENUM;
using Newtonsoft.Json;

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
        [JsonProperty(Required = Required.Always, Order = -1)]
        public Sparte sparte;

        /// <summary>
        /// Die Preise gelten für Marktlokationen der angegebenen Bilanzierungsmethode. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 0)]
        public Bilanzierungsmethode bilanzierungsmethode;

        /// <summary>
        /// Die Preise gelten für Marktlokationen in der angegebenen Netzebene.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 1)]
        public Netzebene netzebene;

        /// <summary>
        /// Hier wird die Kundengruppe, für die der Preis gilt mit angegeben. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 2)]
        public Kundengruppe kundengruppe;

        /// <summary>
        /// Der Netzbetreiber oder Messstellenbetreiber, der die Preise veröffentlicht hat. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 3)]
        public Marktteilnehmer herausgeber;
    }
}
