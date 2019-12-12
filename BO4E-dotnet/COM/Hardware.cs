using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Abbildung einer abrechenbaren Hardware.</summary>
    public class Hardware : COM
    {
        /// <summary>Eindeutiger Typ der Hardware. Details <see cref="Geraetetyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Geraetetyp geraetetyp;
        /// <summary>Bezeichnung der Hardware.</summary>
        [JsonProperty(Required = Required.Always)]
        public string bezeichnung;
    }
}