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
        [JsonProperty(Required = Required.Always, Order = 6)]
        public string id;

        [JsonProperty(Required = Required.Always, Order = 7)]
        public DateTime datetime;

        [JsonProperty(Required = Required.Always, Order = 8)]
        public string logMessage;
    }
}
