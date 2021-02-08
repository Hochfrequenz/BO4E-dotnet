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
        [JsonProperty(PropertyName = "kostenblockbezeichnung", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("kostenblockbezeichnung")]
        [ProtoMember(3)]
        public string Kostenblockbezeichnung { get; set; }
        /// <summary>Die Summe aller Kostenpositionen dieses Blocks</summary>
        [JsonProperty(PropertyName = "summeKostenblock", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("summeKostenblock")]
        [ProtoMember(4)]
        public Betrag SummeKostenblock { get; set; }
        /// <summary>Hier sind die Details zu einer Kostenposition aufgeführt. Z.B.:Alliander Netz Heinsberg GmbH, 01.02.2018, 31.12.2018, Arbeitspreis HT, 3.660 kWh, 5,8200 ct/kWh, 213,01 €. Details <see cref="Kostenposition" /></summary>
        [JsonProperty(PropertyName = "kostenpositionen", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("kostenpositionen")]
        [ProtoMember(5)]
        public List<Kostenposition> Kostenpositionen { get; set; }
    }
}