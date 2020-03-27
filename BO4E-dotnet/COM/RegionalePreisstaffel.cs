using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Abbildung einer Preisstaffel mit regionaler Abgrenzung.</summary>
    //[ProtoContract]
    public class RegionalePreisstaffel : Preisstaffel
    {
        /// <summary>Regionale Eingrenzung der Preisstaffel. Details <see cref="BO4E.COM.RegionaleGueltigkeit" /></summary>
        [JsonProperty(PropertyName = "regionaleGueltigkeit", Required = Required.Always)]
        //[ProtoMember(8)]
        public RegionaleGueltigkeit RegionaleGueltigkeit { get; set; }
    }
}