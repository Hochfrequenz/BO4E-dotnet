using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Abbildung einer abrechenbaren Dienstleistung.</summary>
    public class Dienstleistung : COM
    {
        /// <summary>Eindeutige Nummer der Dienstleistung. Details <see cref="Dienstleistungstyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Dienstleistungstyp dienstleistungstyp;
        /// <summary>Bezeichnung der Dienstleistung.</summary>
        [JsonProperty(Required = Required.Always)]
        public string bezeichnung;
    }
}