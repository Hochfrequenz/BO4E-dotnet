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
        [JsonProperty(PropertyName = "nummerntyp", Required = Required.Always)]
        [ProtoMember(3)]
        public Rufnummernart Nummerntyp { get; set; }

        /// <summary>Die konkrete Nummer, z.B. 02433 5 26 01 900</summary>
        [JsonProperty(PropertyName = "rufnummer", Required = Required.Always)]
        [ProtoMember(4)]
        public string Rufnummer { get; set; }
    }
}