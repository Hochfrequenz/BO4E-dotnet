using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Modell für die preiserhöhenden (Aufschlag) bzw. preisvermindernden (Abschlag) Zusatzvereinbarungen, die individuell zu einem neuen oder bestehenden Liefervertrag abgeschlossen wurden.</summary>
    public class AufAbschlag : COM
    {
        /// <summary>Bezeichnung des Auf-/Abschlags</summary>
        [JsonProperty(Required = Required.Always)]
        public string bezeichnung;
        /// <summary>Beschreibung zum Auf-/Abschlag</summary>
        [JsonProperty(Required = Required.Default)]
        public string beschreibung;
        /// <summary>Typ des Aufabschlages (z.B. absolut oder prozentual). Details <see cref="AufAbschlagstyp" /></summary>
        [JsonProperty(Required = Required.Default)]
        public AufAbschlagstyp? aufAbschlagstyp;
        /// <summary>Diesem Preis oder den Kosten ist der Auf/Abschlag zugeordnet. Z.B. Arbeitspreis, Gesamtpreis etc.. Details <see cref="AufAbschlagsziel" /></summary>
        [JsonProperty(Required = Required.Default)]
        public AufAbschlagsziel? aufAbschlagsziel;
        /// <summary>Gibt an in welcher Währungseinheit der Auf/Abschlag berechnet wird. Euro oder Ct.. (Nur im Falle absoluter Aufschlagstypen). Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Waehrungseinheit? einheit;
        /// <summary>Internetseite, auf der die Informationen zum Auf-/Abschlag veröffentlicht sind.</summary>
        [JsonProperty(Required = Required.Default)]
        public string website;
        /// <summary>Zeitraum, in dem der Abschlag zur Anwendung kommen kann. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Zeitraum gueltigkeitszeitraum;
        /// <summary>Werte für die gestaffelten Auf/Abschläge. Details <see cref="Preisstaffel" /></summary>
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        public List<Preisstaffel> staffeln;
    }
}