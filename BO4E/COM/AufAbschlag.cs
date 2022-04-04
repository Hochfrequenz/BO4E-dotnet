using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    ///     Modell für die preiserhöhenden (Aufschlag) bzw. preisvermindernden (Abschlag) Zusatzvereinbarungen, die
    ///     individuell zu einem neuen oder bestehenden Liefervertrag abgeschlossen wurden.
    /// </summary>
    [ProtoContract]
    public class AufAbschlag : COM
    {
        /// <summary>Bezeichnung des Auf-/Abschlags</summary>
        [JsonProperty(PropertyName = "bezeichnung", Required = Required.Default)]
        [JsonPropertyName("bezeichnung")]
        [ProtoMember(3)]
        public string? Bezeichnung { get; set; }

        /// <summary>Beschreibung zum Auf-/Abschlag</summary>
        [JsonProperty(PropertyName = "beschreibung", Required = Required.Default)]
        [JsonPropertyName("beschreibung")]
        [ProtoMember(4)]
        public string? Beschreibung { get; set; }

        /// <summary>Typ des Aufabschlages (z.B. absolut oder prozentual). Details <see cref="ENUM.AufAbschlagstyp" /></summary>
        [JsonProperty(PropertyName = "aufAbschlagstyp", Required = Required.Default)]
        [JsonPropertyName("aufAbschlagstyp")]
        [ProtoMember(5)]
        public AufAbschlagstyp? AufAbschlagstyp { get; set; }

        /// <summary>
        ///     Diesem Preis oder den Kosten ist der Auf/Abschlag zugeordnet. Z.B. Arbeitspreis, Gesamtpreis etc.. Details
        ///     <see cref="ENUM.AufAbschlagsziel" />
        /// </summary>
        [JsonProperty(PropertyName = "aufAbschlagsziel", Required = Required.Default)]
        [JsonPropertyName("aufAbschlagsziel")]
        [ProtoMember(6)]
        public AufAbschlagsziel? AufAbschlagsziel { get; set; }

        /// <summary>
        ///     Gibt an in welcher Währungseinheit der Auf/Abschlag berechnet wird. Euro oder Ct.. (Nur im Falle absoluter
        ///     Aufschlagstypen). Details <see cref="Waehrungseinheit" />
        /// </summary>
        [JsonProperty(PropertyName = "einheit", Required = Required.Default)]
        [JsonPropertyName("einheit")]
        [ProtoMember(7)]
        public Waehrungseinheit? Einheit { get; set; }

        /// <summary>Internetseite, auf der die Informationen zum Auf-/Abschlag veröffentlicht sind.</summary>
        [JsonProperty(PropertyName = "website", Required = Required.Default)]
        [JsonPropertyName("website")]
        [ProtoMember(8)]
        public string? Website { get; set; }

        /// <summary>Zeitraum, in dem der Abschlag zur Anwendung kommen kann. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(PropertyName = "gueltigkeitszeitraum", Required = Required.Default)]
        [JsonPropertyName("gueltigkeitszeitraum")]
        [ProtoMember(9)]
        public Zeitraum? Gueltigkeitszeitraum { get; set; }

        /// <summary>Werte für die gestaffelten Auf/Abschläge. Details <see cref="Preisstaffel" /></summary>
        [JsonProperty(PropertyName = "staffeln", Required = Required.Default)]
        [JsonPropertyName("staffeln")]
        [ProtoMember(10)]
        public List<Preisstaffel>? Staffeln { get; set; }
    }
}
