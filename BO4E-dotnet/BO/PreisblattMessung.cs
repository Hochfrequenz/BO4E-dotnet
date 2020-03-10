using System.Collections.Generic;
using BO4E.COM;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

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
        /// Die Preise gelten für Messlokationen in der angegebenen Netzebene.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8)]
        [ProtoMember(4)]
        public Netzebene messebene;

        /// <summary>
        /// Im Preis sind die hier angegebenen Dienstleistungen enthalten. Z.B. Jährliche Ablesung. 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5)]
        [ProtoMember(5)]
        public List<Dienstleistungstyp> inklusiveDienstleistung;

        /// <summary>
        /// Der Preis betrifft das hier angegebene Geräte, z.B. einen Drehstromzähler.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6)]
        [ProtoMember(6)]
        public Geraeteeigenschaften basisgeraet;

        /// <summary>
        /// Im Preis sind die hier angegebenen Geräte mit enthalten, z.B. ein Wandler.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 7)]
        [ProtoMember(7)]
        public List<Geraeteeigenschaften> inklusiveGeraete;

        /// <summary>
        /// Der Netzbetreiber oder Messstellenbetreiber, der die Preise veröffentlicht hat.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8)]
        [ProtoMember(8)]
        public Marktteilnehmer herausgeber;
    }
}
