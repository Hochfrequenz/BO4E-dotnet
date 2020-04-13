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
        [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "id")]
        [ProtoMember(4)]
        public string Id { get; set; }

        /// <summary>
        /// date time at which the log event has been raised
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5, PropertyName = "datetime")]
        [ProtoMember(5)]
        public DateTime Datetime { get; set; }

        /// <summary>
        /// actual log message
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6, PropertyName = "logMessage")]
        [ProtoMember(6)]
        public string LogMessage { get; set; }
    }
}
