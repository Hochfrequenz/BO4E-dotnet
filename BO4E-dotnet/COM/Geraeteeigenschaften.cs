using System;
using System.Collections.Generic;

using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden die Eigenschaften eines Gerätes in Bezug auf den Typ und weitere Merkmale modelliert.</summary>
    [ProtoContract]
    public class Geraeteeigenschaften : COM
    {
        /// <summary>Der Typ eines Gerätes, beispielsweise Drehstromzähler. Details <see cref="ENUM.Geraetetyp" /></summary>
        [JsonProperty(PropertyName = "geraetetyp", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("geraetetyp")]
        [ProtoMember(3)]
        public Geraetetyp Geraetetyp { get; set; }

        /// <summary>Weitere Merkmale des Geräts, zum Beispiel Mehrtarif, Eintarif etc.. Details <see cref="ENUM.Geraetemerkmal" /></summary>
        [JsonProperty(PropertyName = "geraetemerkmal", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("geraetemerkmal")]
        [ProtoMember(4)]
        public Geraetemerkmal? Geraetemerkmal { get; set; }

        /// <summary>
        /// Für nicht feste Fields, bsw: 'faktor' 
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1005)]
        [Obsolete("Use the COM.UserProperties instead", true)]
        private Dictionary<string, string> Parameter { get; set; } // ToDo: add docstring
    }
}