using BO4E.ENUM;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        /// <summary>Bezeichnung der Hardware.</summary>
        [JsonProperty(Required = Required.Always)]
        public Geraeteeigenschaften geraeteeigenschaften;

        /// <summary>
        /// Gerätenummer des Wandlers
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string[] geraetenummer;

        /// <summary>
        /// Referenz auf die Gerätenummer des Zählers
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string geraetereferenz;
    }
}