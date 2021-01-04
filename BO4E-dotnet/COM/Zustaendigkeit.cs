using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Enthält die zeitliche Zuordnung eines Ansprechpartners zu Abteilungen und Zuständigkeiten.</summary>
    [ProtoContract]
    public class Zustaendigkeit : COM
    {
        /// <summary>Berufliche Rolle des Ansprechpartners</summary>
        [JsonProperty(PropertyName = "jobtitel", Required = Required.Default)]
        [ProtoMember(3)]
        public string Jobtitel { get; set; }
        /// <summary>Abteilung, in der der Ansprechpartner tätig ist</summary>
        [JsonProperty(PropertyName = "abteilung", Required = Required.Default)]
        [ProtoMember(4)]
        public string Abteilung { get; set; }
        /// <summary>Hier kann eine thematische Zuordnung des APs angegeben werden. Details <see cref="ENUM.Themengebiet" /></summary>
        [JsonProperty(PropertyName = "themengebiet", Required = Required.Default)]
        [ProtoMember(5)]
        public string Themengebiet { get; set; }
    }
}