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
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(3)]
        public Tarifkalkulationsmethode? berechnungsmethode;
        
        /// <summary>Zeigt an, ob der Messpreis im Grundpreis enthalten ist.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public string messpreisInGPEnthalten;

        /// <summary>Typ des Messpreises. Details <see cref="Messpreistyp" /></summary>
        [ProtoMember(5)]
        public Messpreistyp? messpreistyp;
        
        /// <summary>Im Preis bereits eingeschlossene Leistung (für Gas).</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(6)]
        public decimal? kwInklusive;
        
        /// <summary>Intervall, indem die über "kwInklusive" hinaus abgenommene Leistung kostenpflichtig wird (z.B. je 5 kW 20 EURO).</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(7)]
        public decimal? kwWeitereMengen;
        
        /// <summary>Bei der Bildung des Durchschnittspreises für die Höchst- und Mindestpreisbetrachtung wird in Abhängigkeit von diesem Flag der Messpreis mit berücksichtigt.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(9)]
        public bool? messpreisBeruecksichtigen;
        
        /// <summary>Höchstpreis für den Durchschnitts-Arbeitspreis NT. Details <see cref="Preis" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(10)]
        public Preis hoechstpreisNT;
       
        /// <summary>Höchstpreis für den Durchschnitts-Arbeitspreis HT. Details <see cref="Preis" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(11)]
        public Preis hoechstpreisHT;
        
        /// <summary>Mindestpreis für den Durchschnitts-Arbeitspreis. Details <see cref="Preis" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(12)]
        public Preis mindestpreis;
    }
}