using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Die Variante des Preisblattmodells zur Abbildung von allgemeinen Abgaben
    /// </summary>
    public class PreisblattKonzessionsabgabe : Preisblatt
    {
        /// <summary>
        /// Sparte, auf die sich die KA bezieht.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = -1)]
        public Sparte sparte;

        /// <summary>
        /// Kundegruppe anhand derer die Höhe der Konzessionsabgabe festgelegt ist.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 0)]
        public KundengruppeKA kundengruppeKA;
    }
}
