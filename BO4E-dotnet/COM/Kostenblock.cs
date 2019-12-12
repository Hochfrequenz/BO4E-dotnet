using System.Collections.Generic;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden mehrere Kostenpositionen zusammengefasst.</summary>
    public class Kostenblock : COM
    {
        /// <summary>Bezeichnung für einen Kostenblock. Z.B. Netzkosten, Messkosten, Umlagen, etc.</summary>
        [JsonProperty(Required = Required.Always)]
        public string kostenblockbezeichnung;
        /// <summary>Die Summe aller Kostenpositionen dieses Blocks</summary>
        [JsonProperty(Required = Required.Default)]
        public string summeKostenblock;
        /// <summary>Hier sind die Details zu einer Kostenposition aufgeführt. Z.B.:Alliander Netz Heinsberg GmbH, 01.02.2018, 31.12.2018, Arbeitspreis HT, 3.660 kWh, 5,8200 ct/kWh, 213,01 €. Details <see cref="Kostenposition" /></summary>
        [JsonProperty(Required = Required.Default)]
        public List<Kostenposition> kostenpositionen;
    }
}