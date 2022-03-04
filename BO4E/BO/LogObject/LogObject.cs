using System;
using System.Text.Json.Serialization;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO.LogObject
{
    /// <summary>
    ///     a log objects allows to log things
    /// </summary>
    [ProtoContract]
    public class LogObject : BusinessObject
    {
        /// <summary>
        ///     unique id of the log event
        /// </summary>
        [BoKey]
        [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "id")]
        [JsonPropertyName("id")]
        [ProtoMember(4)]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(5, Name = nameof(DateTime))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _DateTime
        {
            get => DateTime.UtcDateTime;
            set => DateTime = System.DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>
        ///     date time at which the log event has been raised
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5, PropertyName = "DateTime")]
        [JsonPropertyName("DateTime")]
        [ProtoIgnore]
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        ///     actual log message
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6, PropertyName = "logMessage")]
        [JsonPropertyName("logMessage")]
        [ProtoMember(6)]
        public string LogMessage { get; set; }
    }
}