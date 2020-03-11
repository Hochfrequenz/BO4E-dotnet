using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;
using System.Collections.Generic;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden die Eigenschaften eines Gerätes in Bezug auf den Typ und weitere Merkmale modelliert.</summary>
    [ProtoContract]
    public class Geraeteeigenschaften : COM
    {
        /// <summary>Der Typ eines Gerätes, beispielsweise Drehstromzähler. Details <see cref="Geraetetyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public Geraetetyp geraetetyp;

        /// <summary>Weitere Merkmale des Geräts, zum Beispiel Mehrtarif, Eintarif etc.. Details <see cref="Geraetemerkmal" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public Geraetemerkmal? geraetemerkmal;

        /// <summary>
        /// Für nicht feste Fields, bsw: 'faktor' 
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(5)]
        public Dictionary<string, string> parameter; // ToDo: add docstring
    }
}