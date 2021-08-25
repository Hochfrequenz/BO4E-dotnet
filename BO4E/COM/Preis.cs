using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Preis</summary>
    [ProtoContract]
    public class Preis : COM
    {
        /// <summary>Gibt die nomiale Höhe des Preises an.</summary>
        [JsonProperty(PropertyName = "wert", Required = Required.Always)]
        [JsonPropertyName("wert")]
        [FieldName("value", Language.EN)]
        [ProtoMember(3)]
        public decimal Wert { get; set; }

        /// <summary>Währungseinheit für den Preis, z.B. Euro oder Ct. Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(PropertyName = "einheit", Required = Required.Always)]
        [JsonPropertyName("einheit")]
        [FieldName("currency", Language.EN)]
        [ProtoMember(4)]
        public Waehrungseinheit Einheit { get; set; }

        /// <summary>Angabe, für welche Bezugsgröße der Preis gilt. Z.B. kWh. <seealso cref="Mengeneinheit" /></summary>
        [JsonProperty(PropertyName = "bezugswert", Required = Required.Always)]
        [JsonPropertyName("bezugswert")]
        [FieldName("reference", Language.EN)]
        [ProtoMember(5)]
        public Mengeneinheit Bezugswert { get; set; }

        /// <summary>
        ///     Gibt den Status des veröffentlichten Preises an
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Default)]
        [JsonPropertyName("status")]
        [ProtoMember(6)]
        public Preisstatus? Status { get; set; }
    }
}