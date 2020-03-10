using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// Kriterien zur Definition der Region. Details siehe <see cref="Regionskriterium"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5)] // at least one entry
        [ProtoMember(5)]
        [MinLength(1)]
        public List<Regionskriterium> regionkriterien;
    }
}
