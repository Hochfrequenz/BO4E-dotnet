using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Abbildung von Rufnummern.</summary>
    public class Rufnummer : COM
    {
        /// <summary>Ausprägung der Nummer, z.B. Zentrale, Faxnummer, Mobilnummer etc. Details <see cref="Rufnummernart" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Rufnummernart nummerntyp;
        /// <summary>Die konkrete Nummer, z.B. 02433 5 26 01 900</summary>
        [JsonProperty(Required = Required.Always)]
        public string rufnummer;
    }
}