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
        /// code von Marktrolle
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string code;

        /// <summary>
        /// List of Marktrolle. Details siehe <see cref="ENUM.Marktrolle"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)] 
        public ENUM.Marktrolle marktrolle;
    }
}
