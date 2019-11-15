using Newtonsoft.Json;
namespace BO4E.COM
{
    /// <summary>Abbildung einer Preisgarantie mit regionaler Abgrenzung.</summary>
    public class RegionalePreisgarantie : Preisgarantie
    {
        /// <summary>Regionale Eingrenzung der Preisgarantie. Details <see cref="RegionaleGueltigkeit" /></summary>
        [JsonProperty(Required = Required.Always)]
        public RegionaleGueltigkeit regionaleGueltigkeit;
    }
}