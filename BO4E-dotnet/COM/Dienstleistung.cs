using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Abbildung einer abrechenbaren Dienstleistung.</summary>
    [ProtoContract]
    public class Dienstleistung : COM
    {
        /// <summary>Eindeutige Nummer der Dienstleistung. Details <see cref="Dienstleistungstyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public Dienstleistungstyp dienstleistungstyp;
        /// <summary>Bezeichnung der Dienstleistung.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public string bezeichnung;
    }
}