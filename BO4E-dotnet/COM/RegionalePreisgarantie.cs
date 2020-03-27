using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Abbildung einer Preisgarantie mit regionaler Abgrenzung.</summary>
    //[ProtoContract]
    public class RegionalePreisgarantie : Preisgarantie
    {
        /// <summary>Regionale Eingrenzung der Preisgarantie. Details <see cref="BO4E.COM.RegionaleGueltigkeit" /></summary>
        [JsonProperty(PropertyName = "regionaleGueltigkeit", Required = Required.Always)]
        //[ProtoMember(6)]
        public RegionaleGueltigkeit RegionaleGueltigkeit { get; set; }
    }
}