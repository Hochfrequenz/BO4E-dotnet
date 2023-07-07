using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden Messprodukte (an Melo und Malo) modelliert.</summary>
    [ProtoContract]
    public class Messprodukt : COM
    {
        /// <summary>
        ///     Identifikation des Messproduktes
        ///     Z.B. 9991000000151
        /// </summary>
        [JsonProperty(PropertyName = "messproduktId", Order = 3, Required = Required.Default)]
        [JsonPropertyName("messproduktId")]
        [ProtoMember(3)]
        [JsonPropertyOrder(3)]
        public string? MessproduktId { get; set; }

        /// <summary>Verwendungungszweck der Werte Marktlokation</summary>
        [JsonProperty(PropertyName = "verwendungszwecke", Order = 1011, Required = Required.Default)]
        [JsonPropertyName("verwendungszwecke")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1011)]
        [JsonPropertyOrder(1011)]
        public List<Verwendungszweck>? Verwendungszwecke { get; set; }

        /// <summary>Stromverbrauchsart/Verbrauchsart Marktlokation</summary>
        [JsonProperty(PropertyName = "verbrauchsart", Order = 1012, Required = Required.Default)]
        [JsonPropertyName("verbrauchsart")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1012)]
        [JsonPropertyOrder(1012)]
        public Verbrauchsart? Verbrauchsart { get; set; }

        /// <summary>Stromverbrauchsart/Unterbrechbarkeit Marktlokation</summary>
        [JsonProperty(PropertyName = "unterbrechbarkeit", Order = 1013, Required = Required.Default)]
        [JsonPropertyName("unterbrechbarkeit")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1013)]
        [JsonPropertyOrder(1013)]
        public Unterbrechbarkeit? Unterbrechbarkeit { get; set; }

        /// <summary>Stromverbrauchsart/Wärmenutzung Marktlokation</summary>
        [JsonProperty(PropertyName = "waermenutzung", Order = 1014, Required = Required.Default)]
        [JsonPropertyName("waermenutzung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1014)]
        [JsonPropertyOrder(1014)]
        public Waermenutzung? Waermenutzung { get; set; }


        /// <summary>
        /// Zählzeiten des Messproduktes
        /// </summary>
        [JsonProperty(PropertyName = "zaehlzeiten", Order = 1021, Required = Required.Default)]
        [JsonPropertyName("zaehlzeiten")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1021)]
        [JsonPropertyOrder(1021)]
        public Zaehlzeitregister? Zaehlzeiten { get; set; }


        /// <summary>
        /// zweite Messung erforderlich
        /// </summary>
        [JsonProperty(PropertyName = "zweiteMessung", Order = 1022, Required = Required.Default)]
        [JsonPropertyName("zweiteMessung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1022)]
        [JsonPropertyOrder(1022)]
        public bool? ZweiteMessung { get; set; }

        /// <summary>
        /// Werden die Werte an den Netzbetreiber übermittelt?
        /// </summary>
        [JsonProperty(PropertyName = "werteuebermittlungAnNB", Order = 1023, Required = Required.Default)]
        [JsonPropertyName("werteuebermittlungAnNB")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1023)]
        [JsonPropertyOrder(1023)]
        public bool? WerteuebermittlungAnNB { get; set; }



#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}