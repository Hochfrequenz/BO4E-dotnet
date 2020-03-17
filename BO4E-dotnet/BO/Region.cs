using System.Collections.Generic;
using BO4E.COM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Modellierung einer Region als Menge von Kriterien, die eine Region beschreiben.
    /// </summary>
    [ProtoContract]
    public class Region : BusinessObject
    {
        /// <summary>
        ///  Bezeichnung der Region.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 4)]
        [ProtoMember(4)]
        [BoKey]
        public string bezeichnung;

        /// <summary>
        /// Positivliste der Kriterien zur Definition der Region.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        public List<Regionskriterium> positivListe;

        /// <summary>
        /// Negativliste der Kriterien zur Definition der Region. 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 6)]
        [ProtoMember(6)]
        public List<Regionskriterium> negativListe;
    }
}
