using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    ///     Definition für eine Preisgarantie mit der Möglichkeit verschiedener Ausprägungen.
    /// </summary>
    [ProtoContract]
    //[ProtoInclude(101, typeof(RegionalePreisgarantie))] // protobuf-net doesn't support multiple levels of inheritance yet
    public class Preisgarantie : COM
    {
        /// <summary>Freitext zur Beschreibung der Preisgarantie</summary>
        [JsonProperty(PropertyName = "beschreibung", Required = Required.Default)]
        [JsonPropertyName("beschreibung")]
        [ProtoMember(3)]
        public string Beschreibung { get; set; }

        /// <summary>
        ///     Festlegung, auf welche Preisbestandteile die Garantie gewährt wird. Details
        ///     <see cref="ENUM.Preisgarantietyp" />
        /// </summary>
        [JsonProperty(PropertyName = "preisgarantietyp", Required = Required.Always)]
        [JsonPropertyName("preisgarantietyp")]
        [ProtoMember(4)]
        public Preisgarantietyp Preisgarantietyp { get; set; }

        /// <summary>
        ///     Zeitraum, bis zu dem die Preisgarantie gilt, z.B. bis zu einem absolutem / fixem Datum oder als Laufzeit in
        ///     Monaten. Details <see cref="Zeitraum" />
        /// </summary>
        [JsonProperty(PropertyName = "zeitlicheGueltigkeit", Required = Required.Always)]
        [JsonPropertyName("zeitlicheGueltigkeit")]
        [ProtoMember(5)]
        public Zeitraum ZeitlicheGueltigkeit { get; set; }
    }
}