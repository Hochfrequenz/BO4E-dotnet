using BO4E.BO;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Text.Json.Serialization;

namespace BO4E.COM
{
    /// <summary>Produkt-daten ein BO wie Netzlokation, Marktlokation usw.</summary>
    [ProtoContract]
    public class Konfigurationsprodukt : COM
    {
        /// <summary>
        /// Die Konfigurationsprodukt-Code für das Objekt
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 1, PropertyName = "produktcode")]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("produktcode")]
        [ProtoMember(1)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public string? Produktcode { get; set; }

        /// <summary>
        /// Code der Zugeordnete Leistungskurvendefinition für das Objekt
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 2, PropertyName = "leistungskurvendefinition")]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("leistungskurvendefinition")]
        [ProtoMember(2)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public string? Leistungskurvendefinition { get; set; }

        /// <summary>
        /// Code der Zugeordnete Schaltzeitdefinition für das Objekt
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 3, PropertyName = "schaltzeitdefinition")]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("schaltzeitdefinition")]
        [ProtoMember(3)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public string? Schaltzeitdefinition { get; set; }

        /// <summary>
        /// Auftraggebender Marktpartner
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 4, PropertyName = "marktpartner")]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("marktpartner")]
        [ProtoMember(4)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public Marktteilnehmer? Marktpartner { get; set; }
    }
}
