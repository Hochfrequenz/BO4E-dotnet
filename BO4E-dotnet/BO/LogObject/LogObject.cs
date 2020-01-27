using System;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO
{
    public class LogObject : BusinessObject
    {
        /// <summary>
        /// unique id of the log event
        /// </summary>
        [BoKey]
        [JsonProperty(Required = Required.Always, Order = -2)]
        public string id;

        [JsonProperty(Required = Required.Always, Order = -1)]
        public DateTime datetime;

        [JsonProperty(Required = Required.Always, Order = 0)]
        public string logMessage;
    }
}
