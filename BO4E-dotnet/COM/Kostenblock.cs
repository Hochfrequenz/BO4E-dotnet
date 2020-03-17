using System.Collections.Generic;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden mehrere Kostenpositionen zusammengefasst.</summary>
    [ProtoContract]
    public class Kostenblock : COM
    {
        /// <summary>Bezeichnung für einen Kostenblock. Z.B. Netzkosten, Messkosten, Umlagen, etc.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public string kostenblockbezeichnung;
        /// <summary>Die Summe aller Kostenpositionen dieses Blocks</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public Betrag summeKostenblock;
        /// <summary>Hier sind die Details zu einer Kostenposition aufgeführt. Z.B.:Alliander Netz Heinsberg GmbH, 01.02.2018, 31.12.2018, Arbeitspreis HT, 3.660 kWh, 5,8200 ct/kWh, 213,01 €. Details <see cref="Kostenposition" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(5)]
        public List<Kostenposition> kostenpositionen;
    }
}