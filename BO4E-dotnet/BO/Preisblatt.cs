using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.COM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Das allgemeine Modell zur Abbildung von Preisen. Davon abgeleitet können, über die Zuordnung identifizierender Merkmale, spezielle Preisblatt-Varianten modelliert werden.
    /// Die jeweiligen Sätze von Merkmalen sind in der Grafik ergänzt worden und stellen jeweils eine Ausprägung für die verschiedenen Anwendungsfälle der Preisblätter dar.
    /// </summary>
    public class Preisblatt : BusinessObject
    {
        /// <summary>
        /// Eine Bezeichnung für das Preisblatt.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = -1)]
        [DataCategory(DataCategory.FINANCE)]
        [BoKey]
        public string bezeichnung;

        /// <summary>
        /// Der Zeitraum für den der Preis festgelegt ist. Details siehe <see cref="Zeitraum"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 0)]
        [DataCategory(DataCategory.FINANCE)]
        public Zeitraum gueltigkeit;

        /// <summary>
        /// Die einzelnen Positionen, die mit dem Preisblatt abgerechnet werden können. Z.B. Arbeitspreis, Grundpreis etc. Details siehe <see cref="Preisposition"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 1)] // at least one entry
        [DataCategory(DataCategory.FINANCE)]
        [MinLength(1)]
        public List<Preisposition> preispositionen;

        /*/// <summary>
        /// Staffelgrenzen der jeweiligen Preise. Details siehe <see cref="Preisstaffel"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 2)] // at least 1 entry
        [DataCategory(DataCategory.FINANCE)]
        public List<Preisstaffel> preisstaffeln;*/
        // https://github.com/Hochfrequenz/energy-service-hub/issues/11
    }
}
