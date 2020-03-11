using System.Collections.Generic;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Modell für die preiserhöhenden (Aufschlag) bzw. preisvermindernden (Abschlag) Zusatzvereinbarungen, die individuell zu einem neuen oder bestehenden Liefervertrag abgeschlossen wurden.</summary>
    [ProtoContract]
    public class AufAbschlag : COM
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
        /// <summary>Zeitraum, in dem der Abschlag zur Anwendung kommen kann. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(9)]
        public Zeitraum gueltigkeitszeitraum;
        /// <summary>Werte für die gestaffelten Auf/Abschläge. Details <see cref="Preisstaffel" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(10)]
        public List<Preisstaffel> staffeln;
    }
}