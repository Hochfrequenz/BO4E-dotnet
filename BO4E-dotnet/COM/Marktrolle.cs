using System.Collections.Generic;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>
    /// Marktrolle 
    /// </summary>
    public class Marktrolle : COM
    {
        /// <summary>
        /// rollencodenummer von Marktrolle
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string rollencodenummer;

        /// <summary>
        /// List of Marktrolle. Details siehe <see cref="ENUM.Marktrolle"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)] 
        public ENUM.Marktrolle marktrolle;

        [JsonProperty(Required = Required.Default)]
        public ENUM.Netzebene netzebenemessung;

        [JsonProperty(Required = Required.Default)]
        public ENUM.Gasqualitaet gasqualitaet;

        [JsonProperty(Required = Required.Default)]
        public string verlustfaktor;
    }
}
