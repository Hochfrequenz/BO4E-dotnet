using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Sigmoidparameter</summary>
    public class Sigmoidparameter : COM
    {
        /// <summary>Briefmarke Ortsverteilnetz</summary>
        [JsonProperty(Required = Required.Always)]
        public string A;
        /// <summary>Wendepunkt für die bepreiste Menge</summary>
        [JsonProperty(Required = Required.Always)]
        public string B;
        /// <summary>Exponent</summary>
        [JsonProperty(Required = Required.Always)]
        public string C;
        /// <summary>Briefmarke Transportnetz</summary>
        [JsonProperty(Required = Required.Always)]
        public string D;
    }
}