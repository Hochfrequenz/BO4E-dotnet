using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using BO4E.COM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Ein Auftrag beschreibt einen Vorgang, der von einem anderen Marktpartner auszuführen ist. 
    /// </summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    [ProtoContract]
    public abstract class Auftrag : BusinessObject
    {
        /// <summary>
        /// workaround
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(4, Name = nameof(Ausfuehrungsdatum))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        protected DateTime _Ausfuehrungsdatum
        {
            get => Ausfuehrungsdatum.UtcDateTime;
            set => Ausfuehrungsdatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        /// <summary>
        /// Das Ausführungsdatum beschreibt zu welchem Zeitpunkt ein Auftrag ausgeführt werden soll.
        /// </summary>
        [JsonProperty("ausfuehrungsdatum", Required = Required.Always)]
        [JsonPropertyName("ausfuehrungsdatum")]
        [ProtoIgnore]
        public DateTimeOffset Ausfuehrungsdatum { get; set; }

        /// <summary>
        /// workaround
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(5, Name = nameof(Fertigstellungsdatum))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        protected DateTime _Fertigstellungsdatum
        {
            get => Fertigstellungsdatum?.UtcDateTime ?? DateTime.MinValue;
            set => Fertigstellungsdatum = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        /// <summary>
        /// Das Fertigstellungsdatum beschreibt zu welchem Zeitpunkt ein Auftrag ausgeführt wurde/wird.
        /// </summary>
        [JsonProperty("fertigstellungsdatum", Required = Required.Default)]
        [JsonPropertyName("fertigstellungsdatum")]
        [ProtoIgnore]
        public DateTimeOffset? Fertigstellungsdatum { get; set; }

        /// <summary>
        /// Die Sparte in der der Auftrag relevant ist
        /// </summary>
        [JsonProperty("sparte", Required = Required.Default)]
        [JsonPropertyName("sparte")]
        public ENUM.Sparte? Sparte { get; set; }

        /// <summary>
        /// Die Adresse, die sich in Belieferung befindet.
        /// </summary>
        [JsonProperty("lieferanschrift", Required = Required.Default)]
        [JsonPropertyName("lieferanschrift")]
        [ProtoMember(6)]
        public Adresse? Lieferanschrift { get; set; }

        /// <summary>
        /// Die ID der Marktlokation der der zu sperrende Zähler zugeordnet ist.
        /// </summary>
        [JsonProperty("marktlokationsId", Required = Required.Always)]
        [JsonPropertyName("marktlokationsId")]
        [ProtoMember(7)]
        public string MarktlokationsId { get; set; }

        /// <summary>
        /// Ein zusätzlicher Freitext
        /// </summary>
        [JsonProperty("bemerkungen", Required = Required.Default)]
        [JsonPropertyName("bemerkungen")]
        [ProtoMember(11)]
        public List<string>? Bemerkungen { get; set; }

        /// <summary>
        /// Die Mindestpreis eines Auftrags (z.B. für eine Sperrung)
        /// </summary>
        [JsonProperty("mindestkosten", Required = Required.Default)]
        [JsonPropertyName("mindestkosten")]
        [ProtoMember(9)]
        public Preis? Mindestpreis { get; set; }

        /// <summary>
        /// Die Höchstkosten eines Auftrags (z.B. für eine Sperrung)
        /// </summary>
        [JsonProperty("hoechstkosten", Required = Required.Default)]
        [JsonPropertyName("hoechstkosten")]
        [ProtoMember(10)]
        public Preis? Hoechstpreis { get; set; }
    }
}