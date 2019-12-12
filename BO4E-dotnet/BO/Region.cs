using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.COM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Modellierung einer Region als Menge von Kriterien, die eine Region beschreiben.
    /// </summary>
    public class Region : BusinessObject
    {
        /// <summary>
        ///  Bezeichnung der Region.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = -1)]
        [BoKey]
        public string bezeichnung;

        /// <summary>
        /// Kriterien zur Definition der Region. Details siehe <see cref="Regionskriterium"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 0)] // at least one entry
        [MinLength(1)]
        public List<Regionskriterium> regionkriterien;
    }
}
