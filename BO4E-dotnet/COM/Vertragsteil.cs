using System;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>
    /// Abbildung für einen Vertragsteil. Der Vertragsteil wird dazu verwendet, eine vertragliche Leistung in Bezug zu einer Lokation (Markt- oder Messlokation) festzulegen.
    /// https://www.bo4e.de/dokumentation/komponenten/com-vertragsteil
    /// </summary>
    public class Vertragsteil : COM
    {
        /// <summary>
        /// Start der Gültigkeit des Vertragsteils.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public DateTime vertragsteilbeginn;

        /// <summary>
        /// Ende der Gültigkeit des Vertragsteils.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public DateTime vertragsteilende;

        /// <summary>
        /// Der Identifier für diejenigen Markt- oder Messlokation, die zu diesem Vertragsteil gehören.
        /// Verträge für mehrere Lokationen werden mit mehreren Vertragsteilen abgebildet.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string lokation;

        /// <summary>
        /// Für die Lokation festgeschriebene Abnahmemenge. Siehe COM Menge
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public Menge vertraglichFixierteMenge;

        /// <summary>
        /// Für die Lokation festgelegte Mindestabnahmemenge. Siehe COM Menge
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public Menge minimaleAbnahmemenge;

        /// <summary>
        /// Für die Lokation festgelegte maximale Abnahmemenge. Siehe COM Menge
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public Menge maximaleAbnahmemenge;

        [JsonProperty(Required = Required.Default)]
        public Menge jahresverbrauchsprognose;

        [JsonProperty(Required = Required.Default)]
        public Menge kundenwert;

        [JsonProperty(Required = Required.Default)]
        public string verbrauchsaufteilung;
    }
}
