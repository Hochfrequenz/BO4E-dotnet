using System.Collections.Generic;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Eine Komponente zur Abbildung einzelner Lose einer Ausschreibung.</summary>
    [ProtoContract]
    public class Ausschreibungslos : COM
    {
        /// <summary>Laufende Nummer des Loses</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public string losnummer;
        /// <summary>Bezeichnung der Ausschreibung</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public string bezeichung;
        /// <summary>Bemerkung des Kunden zur Ausschreibung</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(5)]
        public string bemerkung;
        /// <summary>Bezeichnung der Preismodelle in Ausschreibungen für die Energielieferung. Details <see cref="Preismodell" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(6)]
        public Preismodell preismodell;
        /// <summary>Unterscheidungsmöglichkeiten für die Sparte. Details <see cref="Sparte" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(7)]
        public Sparte energieart;
        /// <summary>Aufzählung der Möglichkeiten zur Rechnungslegung in Ausschreibungen. Details <see cref="Rechnungslegung" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(8)]
        public Rechnungslegung wunschRechnungslegung;
        /// <summary>Aufzählung der Möglichkeiten zu Vertragsformen in Ausschreibungen. Details <see cref="Vertragsform" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(9)]
        public Vertragsform wunschVertragsform;
        /// <summary>Name des Lizenzpartners</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(10)]
        public string betreutDurch;
        /// <summary>Anzahl der Lieferstellen in dieser Ausschreibung</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(11)]
        public int anzahlLieferstellen; // does this make sense? lieferstellen.Size()?
        /// <summary>Die ausgeschriebenen Lieferstellen. Details <see cref="Ausschreibungsdetail" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(12)]
        public List<Ausschreibungsdetail> lieferstellen;
        /// <summary>Gibt den Gesamtjahresverbrauch (z.B. in kWh) aller in diesem Los enthaltenen Lieferstellen an.</summary> <see cref="Menge"/>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(13)]
        public Menge gesamtmenge;
        /// <summary>Mindestmenge Toleranzband (kWh, %)</summary> <see cref="Menge"/> 
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(14)]
        public Menge wunschMindestmenge;
        /// <summary>Maximalmenge Toleranzband (kWh, %)</summary> <see cref="Menge"/> 
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(15)]
        public Menge wunschMaximalmenge;
        /// <summary>Angabe, in welchem Intervall die Angebotsabgabe wiederholt werden darf. Angabe nur gesetzt für die 2. Phase bei öffentlich-rechtlichen Ausschreibungen, ansonsten NULL</summary> <see cref="Zeitraum" />
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(16)]
        public Zeitraum wiederholungsintervall;
        /// <summary>Zeitraum, für den die in diesem Los enthaltenen Lieferstellen beliefert werden sollen</summary> <see cref="Zeitraum" />
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(17)]
        public Zeitraum lieferzeitraum;
        /// <summary>Kundenwunsch zur Kündigungsfrist in der Ausschreibung.</summary> <see cref="Zeitraum" />
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(18)]
        public Zeitraum wunschKuendingungsfrist;
        /// <summary>Kundenwunsch zum Zahlungsziel in der Ausschreibung.</summary> <see cref="Zeitraum" />
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(19)]
        public Zeitraum wunschZahlungsziel;
    }
}