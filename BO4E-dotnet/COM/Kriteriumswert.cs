using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>
    /// Mit dieser Komponente können Kriterien und deren Werte definiert werden.
    /// </summary>
    public class KriteriumsWert : COM
    {
        /// <summary>
        /// Hier steht, für welches Kriterium der Wert gilt. Z.B. Postleitzahlen.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Tarifregionskriterium kriterium;

        /// <summary>
        /// Ein Wert, passend zum Kriterium. Z.B. eine Postleitzahl.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string wert;
    }
}
