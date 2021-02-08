using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Mit dieser Komponente können Kriterien und deren Werte definiert werden.
    /// </summary>
    [ProtoContract]
    public class KriteriumsWert : COM
    {
        /// <summary>
        /// Hier steht, für welches Kriterium der Wert gilt. Z.B. Postleitzahlen.
        /// </summary>
        [JsonProperty(PropertyName = "kriterium", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("kriterium")]
        [ProtoMember(3)]
        public Tarifregionskriterium Kriterium { get; set; }

        /// <summary>
        /// Ein Wert, passend zum Kriterium. Z.B. eine Postleitzahl.
        /// </summary>
        [JsonProperty(PropertyName = "wert", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("wert")]
        [ProtoMember(4)]
        public string Wert { get; set; }
    }
}
