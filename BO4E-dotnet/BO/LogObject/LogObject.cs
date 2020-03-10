using System;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    [ProtoContract]
    public class LogObject : BusinessObject
    {
        /// <summary>
        /// unique id of the log event
        /// </summary>
        [BoKey]
        [JsonProperty(Required = Required.Always, Order = 4)]
        [ProtoMember(4)]
        public string id;

        /// <summary>
        /// date time at which the log event has been raised
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        public DateTime datetime;

        /// <summary>
        /// actual log message
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6)]
        [ProtoMember(6)]
        public string logMessage;
    }
}
