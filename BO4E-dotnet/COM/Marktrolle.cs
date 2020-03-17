using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Marktrolle 
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    public class Marktrolle : COM
    {
        /// <summary>
        /// rollencodenummer von Marktrolle
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(3)]
        public string rollencodenummer;

        /// <summary>
        /// code von Marktrolle
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [ProtoMember(4)]
        public string code;

        /// <summary>
        /// List of Marktrolle. Details siehe <see cref="ENUM.Marktrolle"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public ENUM.Marktrolle marktrolle;
    }
}
