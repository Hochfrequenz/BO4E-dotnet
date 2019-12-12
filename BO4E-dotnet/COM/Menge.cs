using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Abbildung einer Menge mit Wert und Einheit.</summary>
    public class Menge : COM
    {
        /// <summary>Gibt den absoluten Wert der Menge an.</summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("value", Language.EN)]
        public decimal wert;
        /// <summary>Gibt die Einheit zum jeweiligen Wert an. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("unit", Language.EN)]
        public Mengeneinheit einheit;
    }
}
