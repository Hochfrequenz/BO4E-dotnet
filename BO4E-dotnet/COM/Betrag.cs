using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Die Komponente wird dazu verwendet Summebeträge - beispielsweise in Angeboten und Rechnungen - als Geldbeträge abzubilden. Die Einheit ist dabei immer die Hauptwährung also Euro, Dollar etc..</summary>
    public class Betrag : COM
    {
        /// <summary>Gibt den Betrag des Preises an.</summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("value", Language.EN)]
        public decimal wert;
        /// <summary><seealso cref="Waehrungscode" /></summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("currency", Language.EN)]
        public Waehrungscode waehrung;
    }
}