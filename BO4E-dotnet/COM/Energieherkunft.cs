using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Energieherkunft</summary>
    public class Energieherkunft : COM
    {
        /// <summary>Art der Erzeugung der Energie. Details <see cref="Erzeugungsart" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Erzeugungsart erzeugungsart;
        /// <summary>Prozentualer Anteil der jeweiligen Erzeugungsart.</summary>
        [JsonProperty(Required = Required.Always)]
        public decimal anteilProzent;
    }
}