using System.Collections.Generic;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// generic object to retrieve values from a dummy Core Data Service View
    /// </summary>
    [ProtoContract]
    public class GenericStringStringInfo : COM
    {
        /// <summary>
        /// key (named differently because key is a reserved keyword)
        /// </summary>
        [ProtoMember(3)]
        [JsonProperty(PropertyName = "keyColumn")]
        public string KeyColumn { get; set; }
        /// <summary>
        /// value
        /// </summary>
        [ProtoMember(4)]
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// convert object to a key value pair
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<string, string> ToKeyValuePair()
        {
            return new KeyValuePair<string, string>(this.KeyColumn, this.Value);
        }
    }
}
