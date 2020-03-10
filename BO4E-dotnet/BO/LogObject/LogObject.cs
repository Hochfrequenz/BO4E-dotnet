using System;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    public class LogObject : BusinessObject
    {
        /// <summary>
        /// unique id of the log event
        /// </summary>
        [BoKey]
        [JsonProperty(Required = Required.Always, Order = 6)]
        [ProtoMember(-2)]
        public string id;

        [JsonProperty(Required = Required.Always, Order = 7)]

        [ProtoMember(-1)]
        public DateTime datetime;

        [JsonProperty(Required = Required.Always, Order = 8)]

        [ProtoMember(99)]
        public string logMessage;
    }
}
