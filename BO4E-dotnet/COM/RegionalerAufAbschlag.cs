using System.Collections.Generic;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{

    /// <summary>Mit dieser Komponente können Auf- und Abschläge verschiedener Typen im Zusammenhang mit regionalen Gültigkeiten abgebildet werden.</summary>
    [ProtoContract]
    public class RegionalerAufAbschlag : COM
    {
        /// <summary>Bezeichnung des Auf-/Abschlags</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public string bezeichnung;

        /// <summary>Beschreibung zum Auf-/Abschlag</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public string beschreibung;

        /// <summary>Typ des Aufabschlages (z.B. absolut oder prozentual). Details <see cref="AufAbschlagstyp" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(5)]
        public AufAbschlagstyp? aufAbschlagstyp;

        /// <summary>Diesem Preis oder den Kosten ist der Auf/Abschlag zugeordnet. Z.B. Arbeitspreis, Gesamtpreis etc.. Details <see cref="AufAbschlagsziel" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(6)]
        public AufAbschlagsziel? aufAbschlagsziel;

        /// <summary>Gibt an in welcher Währungseinheit der Auf/Abschlag berechnet wird. Euro oder Ct.. (Nur im Falle absoluter Aufschlagstypen). Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(7)]
        public Waehrungseinheit? einheit;

        /// <summary>Internetseite, auf der die Informationen zum Auf-/Abschlag veröffentlicht sind.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(8)]
        public string website;

        /// <summary>Zusatzprodukte, die nur in Kombination mit diesem AufAbschlag erhältlich sind.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(9)]
        public List<string> zusatzprodukte;

        /// <summary>Voraussetzungen, die erfüllt sein müssen, damit dieser AufAbschlag zur Anwendung kommen kann</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(10)]
        public List<string> voraussetzungen;

        /// <summary>Zeitraum, in dem der Abschlag zur Anwendung kommen kann. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(11)]
        public Zeitraum gueltigkeitszeitraum;

        /// <summary>Durch die Anwendung des Auf/Abschlags kann eine Änderung des Tarifnamens auftreten.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(12)]
        public string tarifnamensaenderungen;

        /// <summary>Der Energiemix kann sich durch einen AufAbschlag ändern (z.B. zwei Cent Aufschlag für Ökostrom: Sollte dies der Fall sein,wird hier die neue Zusammensetzung des Energiemix angegeben. Details <see cref="Energiemix" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(13)]
        public Energiemix energiemixaenderung;

        /// <summary>Änderungen in den Vertragskonditionen. Falls in dieser Komponenten angegeben, werden die Tarifparameter hiermit überschrieben. Details <see cref="Vertragskonditionen" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(14)]
        public Vertragskonditionen vertagskonditionsaenderung;

        /// <summary>Änderungen in den Garantievereinbarungen. Falls in dieser Komponenten angegeben, werden die Tarifparameter hiermit überschrieben. Details <see cref="Preisgarantie" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(15)]
        public Preisgarantie garantieaenderung;

        /// <summary>Änderungen in den Einschränkungen zum Tarif. Falls in dieser Komponenten angegeben, werden die Tarifparameter hiermit überschrieben. Details <see cref="Tarifeinschraenkung" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(16)]
        public Tarifeinschraenkung einschraenkungsaenderung;

        /// <summary>Werte für die gestaffelten Auf/Abschläge mit regionaler Eingrenzung. Details <see cref="RegionalePreisstaffel" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(17)]
        public List<RegionalePreisstaffel> staffeln;
    }
}