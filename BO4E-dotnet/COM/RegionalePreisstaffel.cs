using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Abbildung einer Preisstaffel mit regionaler Abgrenzung.</summary>
    public class RegionalePreisstaffel : Preisstaffel
    {
        /// <summary>Regionale Eingrenzung der Preisstaffel. Details <see cref="RegionaleGueltigkeit" /></summary>
        [JsonProperty(Required = Required.Always)]
        public RegionaleGueltigkeit regionaleGueltigkeit;
    }
}