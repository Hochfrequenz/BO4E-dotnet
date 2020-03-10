using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Dieses BO wird zur Übertagung von hierarchischen Kostenstrukturen verwendet. Die Kosten werden dabei in Kostenblöcke und diese wiederum in Kostenpositionen strukturiert.
    /// </summary>
    [ProtoContract]
    public class Kosten : BusinessObject
    {
        /// <summary>
        /// Klasse der Kosten, beispielsweise Fremdkosten. Details siehe <see cref="Kostenklasse"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 4)]
        [ProtoMember(4)]
        [DataCategory(DataCategory.FINANCE)]
        public Kostenklasse kostenklasse;

        /// <summary>
        /// Für diesen Zeitraum wurden die Kosten ermittelt. Details siehe <see cref="Zeitraum"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        [DataCategory(DataCategory.FINANCE)]
        public Zeitraum gueltigkeit;

        /// <summary>
        /// Die Gesamtsumme über alle Kostenblöcke und -positionen. Details siehe <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 6)]
        [ProtoMember(6)]
        [DataCategory(DataCategory.FINANCE)]
        // ToDo: handle this as DateTime object that serializes without the "time" in "DateTime"
        public List<Betrag> summeKosten;

        /// <summary>
        /// Eine Liste mit Kostenblöcken. In Kostenblöcken werden Kostenpositionen zusammengefasst. Beispiele: Netzkosten, Umlagen, Steuern etc. Details siehe <see cref="Kostenblock"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7)] // at least 1 entry
        [ProtoMember(7)]
        [MinLength(1)]
        public List<Kostenblock> kostenbloecke;

        /// <summary>
        /// Hier sind die Details zu einer Kostenposition aufgeführt. Z.B.:
        /// Alliander Netz Heinsberg GmbH, 01.02.2018, 31.12.2018, Arbeitspreis HT, 3.660 kWh, 5,8200 ct/kWh, 213,01 €. Details siehe COM Kostenposition
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 8)]
        [ProtoMember(8)]
        [DataCategory(DataCategory.FINANCE)]
        public List<Kostenposition> kostenpositionen;
    }
}
