using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Abbildung von Rufnummern.</summary>
    [ProtoContract]
    public class Rufnummer : COM
    {
        /// <summary>Ausprägung der Nummer, z.B. Zentrale, Faxnummer, Mobilnummer etc. Details <see cref="Rufnummernart" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public Rufnummernart nummerntyp;

        /// <summary>Die konkrete Nummer, z.B. 02433 5 26 01 900</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public string rufnummer;
    }
}