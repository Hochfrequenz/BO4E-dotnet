using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Abbildung einer Preisstaffel mit regionaler Abgrenzung.</summary>
    //[ProtoContract]
    public class RegionalePreisstaffel : Preisstaffel
    {
        /// <summary>Regionale Eingrenzung der Preisstaffel. Details <see cref="RegionaleGueltigkeit" /></summary>
        [JsonProperty(Required = Required.Always)]
        //[ProtoMember(8)]
        public RegionaleGueltigkeit regionaleGueltigkeit;
    }
}