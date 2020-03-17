using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Enthält die zeitliche Zuordnung eines Ansprechpartners zu Abteilungen und Zuständigkeiten.</summary>
    [ProtoContract]
    public class Zustaendigkeit : COM
    {
        /// <summary>Berufliche Rolle des Ansprechpartners</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(3)]
        public string jobtitel;
        /// <summary>Abteilung, in der der Ansprechpartner tätig ist</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public string abteilung;
        /// <summary>Hier kann eine thematische Zuordnung des APs angegeben werden. Details <see cref="Themengebiet" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(5)]
        public string themengebiet;
    }
}