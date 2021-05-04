using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Abbildung einer abrechenbaren Hardware.</summary>
    [ProtoContract]
    public class Hardware : COM
    {
        /// <summary>Eindeutiger Typ der Hardware. Details <see cref="ENUM.Geraetetyp" /></summary>
        [JsonProperty(PropertyName = "geraetetyp", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("geraetetyp")]
        [ProtoMember(3)]
        public Geraetetyp Geraetetyp { get; set; }
        /// <summary>Bezeichnung der Hardware.</summary>
        [JsonProperty(PropertyName = "bezeichnung", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("bezeichnung")]
        [ProtoMember(4)]
        public string Bezeichnung { get; set; }

        /// <summary>Bezeichnung der Hardware.</summary>
        [JsonProperty(PropertyName = "geraeteeigenschaften", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("geraeteeigenschaften")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1005)]
        public Geraeteeigenschaften Geraeteeigenschaften { get; set; }

        /// <summary>
        /// Gerätenummer des Wandlers
        /// </summary>
        [JsonProperty(PropertyName = "geraetenummer", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("geraetenummer")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1006)]
        public string Geraetenummer { get; set; }

        /// <summary>
        /// Referenz auf die Gerätenummer des Zählers
        /// </summary>
        [JsonProperty(PropertyName = "geraetereferenz", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("geraetereferenz")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1007)]
        public string Geraetereferenz { get; set; }
    }
}