using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
namespace BO4E.COM
{
    /// <summary>Abbildung eines Steuerbetrages.</summary>
    public class Steuerbetrag : COM
    {
        /// <summary>Kennzeichnung des Steuersatzes, bzw. Verfahrens. Details <see cref="Steuerkennzeichen" /></summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("taxIdentifier", Language.EN)]
        public Steuerkennzeichen steuerkennzeichen;
        /// <summary>Nettobetrag für den die Steuer berechnet wurde. Z.B. 100</summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("baseValue", Language.EN)]
        public decimal basiswert;
        /// <summary>Aus dem Basiswert berechnete Steuer. Z.B. 19 (bei UST_19)</summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("taxValue", Language.EN)]
        public decimal steuerwert;
        /// <summary>Währung. Z.B. Euro. <seealso cref="Waehrungscode" /></summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("currency", Language.EN)]
        public Waehrungscode waehrung;
    }
}