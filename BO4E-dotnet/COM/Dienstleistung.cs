using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Abbildung einer abrechenbaren Dienstleistung.</summary>
    [ProtoContract]
    public class Dienstleistung : COM
    {
        /// <summary>Eindeutige Nummer der Dienstleistung. Details <see cref="ENUM.Dienstleistungstyp" /></summary>
        [JsonProperty(PropertyName = "dienstleistungstyp", Required = Required.Always)]
        [ProtoMember(3)]
        public Dienstleistungstyp Dienstleistungstyp { get; set; }
        /// <summary>Bezeichnung der Dienstleistung.</summary>
        [JsonProperty(PropertyName = "bezeichnung", Required = Required.Always)]
        [ProtoMember(4)]
        public string Bezeichnung { get; set; }
    }
}