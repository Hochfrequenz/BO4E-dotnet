using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    ///     Die Komponente wird dazu verwendet Summebeträge - beispielsweise in Angeboten und Rechnungen - als Geldbeträge
    ///     abzubilden. Die Einheit ist dabei immer die Hauptwährung also Euro, Dollar etc..
    /// </summary>
    [ProtoContract]
    public class Betrag : COM
    {
        /// <summary>Gibt den Betrag des Preises an.</summary>
        [JsonProperty(PropertyName = "wert", Required = Required.Always)]
        [JsonPropertyName("wert")]
        [FieldName("value", Language.EN)]
        [ProtoMember(3)]
        public decimal Wert { get; set; }

        /// <summary>
        ///     <seealso cref="Waehrungscode" />
        /// </summary>
        [JsonProperty(PropertyName = "waehrung", Required = Required.Always)]
        [JsonPropertyName("waehrung")]
        [FieldName("currency", Language.EN)]
        [ProtoMember(4)]
        public Waehrungscode Waehrung { get; set; }
    }
}