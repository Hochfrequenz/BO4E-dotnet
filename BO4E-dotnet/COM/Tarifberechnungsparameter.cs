using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>In dieser Komponente sind die Berechnungsparameter für die Ermittlung der Tarifkosten zusammengefasst.</summary>
    [ProtoContract]
    public class Tarifberechnungsparameter : COM
    {
        /// <summary>Gibt an, wie die Einzelpreise des Tarifes zu verarbeiten sind. Details <see cref="Tarifkalkulationsmethode" /></summary>
        [JsonProperty(PropertyName = "berechnungsmethode", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("berechnungsmethode")]
        [ProtoMember(3)]
        public Tarifkalkulationsmethode? Berechnungsmethode { get; set; }

        /// <summary>Zeigt an, ob der Messpreis im Grundpreis enthalten ist.</summary>
        [JsonProperty(PropertyName = "messpreisInGPEnthalten", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("messpreisInGPEnthalten")]
        [ProtoMember(4)]
        public string MesspreisInGPEnthalten { get; set; }

        /// <summary>Typ des Messpreises. Details <see cref="ENUM.Messpreistyp" /></summary>
        [ProtoMember(5)]
        [JsonProperty(PropertyName = "messpreistyp", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("messpreistyp")]
        public Messpreistyp? Messpreistyp { get; set; }

        /// <summary>Im Preis bereits eingeschlossene Leistung (für Gas).</summary>
        [JsonProperty(PropertyName = "kwInklusive", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("kwInklusive")]
        [ProtoMember(6)]
        public decimal? KwInklusive { get; set; }

        /// <summary>Intervall, indem die über "kwInklusive" hinaus abgenommene Leistung kostenpflichtig wird (z.B. je 5 kW 20 EURO).</summary>
        [JsonProperty(PropertyName = "kwWeitereMengen", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("kwWeitereMengen")]
        [ProtoMember(7)]
        public decimal? KwWeitereMengen { get; set; }

        /// <summary>Bei der Bildung des Durchschnittspreises für die Höchst- und Mindestpreisbetrachtung wird in Abhängigkeit von diesem Flag der Messpreis mit berücksichtigt.</summary>
        [JsonProperty(PropertyName = "messpreisBeruecksichtigen", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("messpreisBeruecksichtigen")]
        [ProtoMember(9)]
        public bool? MesspreisBeruecksichtigen { get; set; }

        /// <summary>Höchstpreis für den Durchschnitts-Arbeitspreis NT. Details <see cref="Preis" /></summary>
        [JsonProperty(PropertyName = "hoechstpreisNT", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("hoechstpreisNT")]
        [ProtoMember(10)]
        // ReSharper disable once InconsistentNaming
        public Preis HoechstpreisNT { get; set; }

        /// <summary>Höchstpreis für den Durchschnitts-Arbeitspreis HT. Details <see cref="Preis" /></summary>
        [JsonProperty(PropertyName = "hoechstpreisHT", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("hoechstpreisHT")]
        [ProtoMember(11)]
        // ReSharper disable once InconsistentNaming
        public Preis HoechstpreisHT { get; set; }

        /// <summary>Mindestpreis für den Durchschnitts-Arbeitspreis. Details <see cref="Preis" /></summary>
        [JsonProperty(PropertyName = "mindestpreis", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("mindestpreis")]
        [ProtoMember(12)]
        public Preis Mindestpreis { get; set; }
    }
}