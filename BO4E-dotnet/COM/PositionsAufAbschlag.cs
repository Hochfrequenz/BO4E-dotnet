using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Differenzierung der zu betrachtenden Produkte anhand der preiserhöhenden (Aufschlag) bzw. preisvermindernden (Abschlag) Zusatzvereinbarungen, die individuell zu einem neuen oder bestehenden Liefervertrag abgeschlossen werden können. Es können mehrere Auf-/Abschläge gleichzeitig ausgewählt werden.</summary>
    [ProtoContract]
    public class PositionsAufAbschlag : COM
    {
        /// <summary>Bezeichnung des Auf-/Abschlags</summary>
        [JsonProperty(PropertyName = "bezeichnung", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("bezeichnung")]
        [ProtoMember(3)]
        public string Bezeichnung { get; set; }
        /// <summary>Beschreibung zum Auf-/Abschlag</summary>
        [JsonProperty(PropertyName = "beschreibung", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("beschreibung")]
        [ProtoMember(4)]
        public string Beschreibung { get; set; }
        /// <summary>Typ des AufAbschlages. Details <see cref="ENUM.AufAbschlagstyp" /></summary>
        [JsonProperty(PropertyName = "aufAbschlagstyp", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("aufAbschlagstyp")]
        [ProtoMember(5)]
        public AufAbschlagstyp AufAbschlagstyp { get; set; }
        /// <summary>Höhe des Auf-/Abschlages</summary>
        [JsonProperty(PropertyName = "aufAbschlagswert", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("aufAbschlagswert")]
        [ProtoMember(6)]
        public decimal AufAbschlagswert { get; set; }
        /// <summary>Einheit, in der der Auf-/Abschlag angegeben ist (z.B. ct/kWh). Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(PropertyName = "aufAbschlagswaehrung", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("aufAbschlagswaehrung")]
        [ProtoMember(7)]
        public Waehrungseinheit AufAbschlagswaehrung { get; set; }
    }
}