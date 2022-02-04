using BO4E.COM;
using BO4E.EnergyIdentificationCodes;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BO4E.BO
{
    /// <summary>
    /// Reklamations BO
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.MISSING)]
    public class Reklamation : BusinessObject
    {
        /// <summary>
        /// OBIS-Kennzahl
        /// </summary>
        /// <example>
        ///     1-0:1.8.1
        /// </example>
        [JsonProperty(PropertyName = "obiskennzahl", Required = Required.Always)]
        [JsonPropertyName("obiskennzahl")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1000)]
        [BoKey]
        public string Obiskennzahl { get; set; }

        /// <summary>
        /// Sollablesetermin / Zeitangabe für Messwertanfrage
        /// Verarbeitung, Beginndatum/-zeit
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(1002, Name = nameof(Startdatum))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _Startdatum
        {
            get => Startdatum?.UtcDateTime ?? DateTime.MinValue;
            set => Startdatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>
        /// Sollablesetermin / Zeitangabe für Messwertanfrage
        /// Verarbeitung, Beginndatum/-zeit
        /// </summary>
        [JsonProperty(PropertyName = "startdatum", Required = Required.Default)]
        [JsonPropertyName("startdatum")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoIgnore]
        public DateTimeOffset? Startdatum { get; set; }


        /// <summary>
        /// Sollablesetermin / Zeitangabe für Messwertanfrage
        /// Verarbeitung, Endedatum/-zeit
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(1003, Name = nameof(Enddatum))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _Enddatum
        {
            get => Enddatum?.UtcDateTime ?? DateTime.MinValue;
            set => Enddatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>
        /// Sollablesetermin / Zeitangabe für Messwertanfrage
        /// Verarbeitung, Endedatum/-zeit
        /// </summary>
        [JsonProperty(PropertyName = "enddatum", Required = Required.Default)]
        [JsonPropertyName("enddatum")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoIgnore]
        public DateTimeOffset? Enddatum { get; set; }

        /// <summary>
        /// Hier wird für die Reklamation von Werten der Reklamationsgrund angegeben.
        /// </summary>
        [JsonProperty(PropertyName = "reklamationsgrund", Required = Required.Always)]
        [JsonPropertyName("reklamationsgrund")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1004)]
        [BoKey]
        public Reklamationsgrund Reklamationsgrund { get; set; }

        /// <summary>
        /// Freitext für eine weitere Beschreibung des Reklamationsgrunds
        /// </summary>
        [JsonProperty(PropertyName = "reklamationsgrundBemerkung", Required = Required.Default)]
        [JsonPropertyName("reklamationsgrundBemerkung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1005)]
        public string ReklamationsgrundBemerkung { get; set; }
    }
}