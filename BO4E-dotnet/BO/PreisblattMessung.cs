using System.Collections.Generic;
using BO4E.COM;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Die Variante des Preisblattmodells zur Abbildung der Preise für den Messstellenbetrieb und damit verbundene Leistungen.
    /// </summary>
    public class PreisblattMessung : Preisblatt
    {
        /// <summary>
        /// Preisblatt gilt für die angegebene Sparte.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = -1)]
        public Sparte sparte;

        /// <summary>
        /// Die Preise gelten für Marktlokationen der angegebenen Bilanzierungsmethode. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 0)]
        public Bilanzierungsmethode bilanzierungsmethode;

        /// <summary>
        /// Die Preise gelten für Messlokationen in der angegebenen Netzebene.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 1)]
        public Netzebene messebene;

        /// <summary>
        /// Im Preis sind die hier angegebenen Dienstleistungen enthalten. Z.B. Jährliche Ablesung. 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 2)]
        public List<Dienstleistungstyp> inklusiveDienstleistung;

        /// <summary>
        /// Der Preis betrifft das hier angegebene Geräte, z.B. einen Drehstromzähler.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 3)]
        public Geraeteeigenschaften basisgeraet;

        /// <summary>
        /// Im Preis sind die hier angegebenen Geräte mit enthalten, z.B. ein Wandler.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 4)]
        public List<Geraeteeigenschaften> inklusiveGeraete;

        /// <summary>
        /// Der Netzbetreiber oder Messstellenbetreiber, der die Preise veröffentlicht hat.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        public Marktteilnehmer herausgeber;
    }
}
