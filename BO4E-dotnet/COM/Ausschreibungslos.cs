using System.Collections.Generic;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Eine Komponente zur Abbildung einzelner Lose einer Ausschreibung.</summary>
    public class Ausschreibungslos : COM
    {
        /// <summary>Laufende Nummer des Loses</summary>
        [JsonProperty(Required = Required.Always)]
        public string losnummer;
        /// <summary>Bezeichnung der Ausschreibung</summary>
        [JsonProperty(Required = Required.Always)]
        public string bezeichung;
        /// <summary>Bemerkung des Kunden zur Ausschreibung</summary>
        [JsonProperty(Required = Required.Default)]
        public string bemerkung;
        /// <summary>Bezeichnung der Preismodelle in Ausschreibungen für die Energielieferung. Details <see cref="Preismodell" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Preismodell preismodell;
        /// <summary>Unterscheidungsmöglichkeiten für die Sparte. Details <see cref="Sparte" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Sparte energieart;
        /// <summary>Aufzählung der Möglichkeiten zur Rechnungslegung in Ausschreibungen. Details <see cref="Rechnungslegung" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Rechnungslegung wunschRechnungslegung;
        /// <summary>Aufzählung der Möglichkeiten zu Vertragsformen in Ausschreibungen. Details <see cref="Vertragsform" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Vertragsform wunschVertragsform;
        /// <summary>Name des Lizenzpartners</summary>
        [JsonProperty(Required = Required.Always)]
        public string betreutDurch;
        /// <summary>Anzahl der Lieferstellen in dieser Ausschreibung</summary>
        [JsonProperty(Required = Required.Always)]
        public int anzahlLieferstellen; // does this make sense? lieferstellen.Size()?
        /// <summary>Die ausgeschriebenen Lieferstellen. Details <see cref="Ausschreibungsdetail" /></summary>
        [JsonProperty(Required = Required.Always)]
        public List<Ausschreibungsdetail> lieferstellen;
        /// <summary>Gibt den Gesamtjahresverbrauch (z.B. in kWh) aller in diesem Los enthaltenen Lieferstellen an.</summary> <see cref="Menge"/>
        [JsonProperty(Required = Required.Default)]
        public Menge gesamtmenge;
        /// <summary>Mindestmenge Toleranzband (kWh, %)</summary> <see cref="Menge"/> 
        [JsonProperty(Required = Required.Default)]
        public Menge wunschMindestmenge;
        /// <summary>Maximalmenge Toleranzband (kWh, %)</summary> <see cref="Menge"/> 
        [JsonProperty(Required = Required.Default)]
        public Menge wunschMaximalmenge;
        /// <summary>Angabe, in welchem Intervall die Angebotsabgabe wiederholt werden darf. Angabe nur gesetzt für die 2. Phase bei öffentlich-rechtlichen Ausschreibungen, ansonsten NULL</summary> <see cref="Zeitraum" />
        [JsonProperty(Required = Required.Default)]
        public Zeitraum wiederholungsintervall;
        /// <summary>Zeitraum, für den die in diesem Los enthaltenen Lieferstellen beliefert werden sollen</summary> <see cref="Zeitraum" />
        [JsonProperty(Required = Required.Default)]
        public Zeitraum lieferzeitraum;
        /// <summary>Kundenwunsch zur Kündigungsfrist in der Ausschreibung.</summary> <see cref="Zeitraum" />
        [JsonProperty(Required = Required.Default)]
        public Zeitraum wunschKuendingungsfrist;
        /// <summary>Kundenwunsch zum Zahlungsziel in der Ausschreibung.</summary> <see cref="Zeitraum" />
        [JsonProperty(Required = Required.Default)]
        public Zeitraum wunschZahlungsziel;
    }
}