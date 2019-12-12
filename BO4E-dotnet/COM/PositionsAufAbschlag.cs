using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Differenzierung der zu betrachtenden Produkte anhand der preiserhöhenden (Aufschlag) bzw. preisvermindernden (Abschlag) Zusatzvereinbarungen, die individuell zu einem neuen oder bestehenden Liefervertrag abgeschlossen werden können. Es können mehrere Auf-/Abschläge gleichzeitig ausgewählt werden.</summary>
    public class PositionsAufAbschlag : COM
    {
        /// <summary>Bezeichnung des Auf-/Abschlags</summary>
        [JsonProperty(Required = Required.Always)]
        public string bezeichnung;
        /// <summary>Beschreibung zum Auf-/Abschlag</summary>
        [JsonProperty(Required = Required.Always)]
        public string beschreibung;
        /// <summary>Typ des AufAbschlages. Details <see cref="AufAbschlagstyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        public AufAbschlagstyp aufAbschlagstyp;
        /// <summary>Höhe des Auf-/Abschlages</summary>
        [JsonProperty(Required = Required.Always)]
        public decimal aufAbschlagswert;
        /// <summary>Einheit, in der der Auf-/Abschlag angegeben ist (z.B. ct/kWh). Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Waehrungseinheit aufAbschlagswaehrung;
    }
}