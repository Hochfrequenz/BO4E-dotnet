using BO4E.ENUM;
using Newtonsoft.Json;
namespace BO4E.COM
{
    /// <summary>In dieser Komponente sind die Berechnungsparameter für die Ermittlung der Tarifkosten zusammengefasst.</summary>
    public class Tarifberechnungsparameter : COM
    {
        /// <summary>Gibt an, wie die Einzelpreise des Tarifes zu verarbeiten sind. Details <see cref="Tarifkalkulationsmethode" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Tarifkalkulationsmethode? berechnungsmethode;
        /// <summary>Zeigt an, ob der Messpreis im Grundpreis enthalten ist.</summary>
        [JsonProperty(Required = Required.Default)]
        public string messpreisInGPEnthalten;
        /// <summary>Typ des Messpreises. Details <see cref="Messpreistyp" /></summary>
        public Messpreistyp? messpreistyp;
        /// <summary>Im Preis bereits eingeschlossene Leistung (für Gas).</summary>
        [JsonProperty(Required = Required.Default)]
        public string kwInklusive;
        /// <summary>Intervall, indem die über "kwInklusive" hinaus abgenommene Leistung kostenpflichtig wird (z.B. je 5 kW 20 EURO).</summary>
        [JsonProperty(Required = Required.Default)]
        public string kwWeitereMengen;
        /// <summary>Bei der Bildung des Durchschnittspreises für die Höchst- und Mindestpreisbetrachtung wird in Abhängigkeit von diesem Flag der Messpreis mit berücksichtigt.</summary>
        [JsonProperty(Required = Required.Default)]
        public string messpreisBeruecksichtigen;
        /// <summary>Höchstpreis für den Durchschnitts-Arbeitspreis NT. Details <see cref="Preis" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Preis hoechstpreisNT;
        /// <summary>Höchstpreis für den Durchschnitts-Arbeitspreis HT. Details <see cref="Preis" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Preis hoechstpreisHT;
        /// <summary>Mindestpreis für den Durchschnitts-Arbeitspreis. Details <see cref="Preis" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Preis mindestpreis;
    }
}