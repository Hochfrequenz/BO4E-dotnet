using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{

    /// <summary>Mit dieser Komponente können Auf- und Abschläge verschiedener Typen im Zusammenhang mit regionalen Gültigkeiten abgebildet werden.</summary>
    public class RegionalerAufAbschlag : COM
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
        /// <summary>Zusatzprodukte, die nur in Kombination mit diesem AufAbschlag erhältlich sind.</summary>
        [JsonProperty(Required = Required.Default)]
        public List<string> zusatzprodukte;
        /// <summary>Voraussetzungen, die erfüllt sein müssen, damit dieser AufAbschlag zur Anwendung kommen kann</summary>
        [JsonProperty(Required = Required.Default)]
        public List<string> voraussetzungen;
        /// <summary>Zeitraum, in dem der Abschlag zur Anwendung kommen kann. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Zeitraum gueltigkeitszeitraum;
        /// <summary>Durch die Anwendung des Auf/Abschlags kann eine Änderung des Tarifnamens auftreten.</summary>
        [JsonProperty(Required = Required.Default)]
        public string tarifnamensaenderungen;
        /// <summary>Der Energiemix kann sich durch einen AufAbschlag ändern (z.B. zwei Cent Aufschlag für Ökostrom: Sollte dies der Fall sein,wird hier die neue Zusammensetzung des Energiemix angegeben. Details <see cref="Energiemix" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Energiemix energiemixaenderung;
        /// <summary>Änderungen in den Vertragskonditionen. Falls in dieser Komponenten angegeben, werden die Tarifparameter hiermit überschrieben. Details <see cref="Vertragskonditionen" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Vertragskonditionen vertagskonditionsaenderung;
        /// <summary>Änderungen in den Garantievereinbarungen. Falls in dieser Komponenten angegeben, werden die Tarifparameter hiermit überschrieben. Details <see cref="Preisgarantie" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Preisgarantie garantieaenderung;
        /// <summary>Änderungen in den Einschränkungen zum Tarif. Falls in dieser Komponenten angegeben, werden die Tarifparameter hiermit überschrieben. Details <see cref="Tarifeinschraenkung" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Tarifeinschraenkung einschraenkungsaenderung;
        /// <summary>Werte für die gestaffelten Auf/Abschläge mit regionaler Eingrenzung. Details <see cref="RegionalePreisstaffel" /></summary>
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        public List<RegionalePreisstaffel> staffeln;
    }
}