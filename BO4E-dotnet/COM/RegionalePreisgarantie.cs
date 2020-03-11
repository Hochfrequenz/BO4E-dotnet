using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Abbildung einer Preisgarantie mit regionaler Abgrenzung.</summary>
    [ProtoContract]
    public class RegionalePreisgarantie : Preisgarantie
    {
        /// <summary>Regionale Eingrenzung der Preisgarantie. Details <see cref="RegionaleGueltigkeit" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(6)]
        public RegionaleGueltigkeit regionaleGueltigkeit;
    }
}