using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Zusammensetzung der gelieferten Energie aus den verschiedenen Primärenergieformen.</summary>
    public class Energiemix : COM
    {
        /// <summary>Eindeutige Nummer zur Identifizierung des Energiemixes.</summary>
        [JsonProperty(Required = Required.Always)]
        public int energiemixnummer;
        /// <summary>Strom oder Gas etc.. Details <see cref="Sparte" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Sparte energieart;
        /// <summary>Bezeichnung des Energiemix.</summary>
        [JsonProperty(Required = Required.Always)]
        public string bezeichnung;
        /// <summary>Bemerkung zum Energiemix.</summary>
        [JsonProperty(Required = Required.Default)]
        public string bemerkung;
        /// <summary>Jahr, für das der Energiemix gilt.</summary>
        [JsonProperty(Required = Required.Always)]
        public int gueltigkeitsjahr;
        /// <summary>Höhe des erzeugten CO2-Ausstosses in g/kWh.</summary>
        [JsonProperty(Required = Required.Default)]
        public decimal cO2Emission;
        /// <summary>Höhe des erzeugten Atommülls in g/kWh.</summary>
        [JsonProperty(Required = Required.Default)]
        public decimal atommuell;
        /// <summary>Zertifikat für den Energiemix. Details <see cref="Oekozertifikat" /></summary>
        [JsonProperty(Required = Required.Default)]
        public List<Oekozertifikat> oekozertifikat;
        /// <summary>Ökolabel für den Energiemix. Details <see cref="Oekolabel" /></summary>
        [JsonProperty(Required = Required.Default)]
        public List<Oekolabel> oekolabel;
        /// <summary>Kennzeichen, ob der Versorger zu den Öko Top Ten gehört.</summary>
        [JsonProperty(Required = Required.Default)]
        public bool? oekoTopTen;
        /// <summary>Internetseite, auf der die Strommixdaten veröffentlicht sind.</summary>
        [JsonProperty(Required = Required.Default)]
        public string website;
        /// <summary>Anteile der jeweiligen Erzeugungsart. Details <see cref="Energieherkunft" /></summary>
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        public List<Energieherkunft> anteil;
    }
}