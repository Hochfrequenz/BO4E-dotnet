using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Preis</summary>
    public class Preis : COM
    {
        /// <summary>Gibt die nomiale Höhe des Preises an.</summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("value", Language.EN)]
        public decimal wert;
        /// <summary>Währungseinheit für den Preis, z.B. Euro oder Ct. Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("currency", Language.EN)]
        public Waehrungseinheit einheit;
        /// <summary>Angabe, für welche Bezugsgröße der Preis gilt. Z.B. kWh. <seealso cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("reference", Language.EN)]
        public Mengeneinheit bezugswert;

        /// <summary>
        /// Gibt den Status des veröffentlichten Preises an
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public Preisstatus status;
    }
}