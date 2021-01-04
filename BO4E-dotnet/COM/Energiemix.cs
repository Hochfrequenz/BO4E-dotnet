using System.Collections.Generic;

using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Zusammensetzung der gelieferten Energie aus den verschiedenen Primärenergieformen.</summary>
    [ProtoContract]
    public class Energiemix : Com
    {
        /// <summary>Eindeutige Nummer zur Identifizierung des Energiemixes.</summary>
        [JsonProperty(PropertyName = "energiemixnummer", Required = Required.Always)]
        [ProtoMember(3)]
        public int Energiemixnummer { get; set; }
        /// <summary>Strom oder Gas etc.. Details <see cref="Sparte" /></summary>
        [JsonProperty(PropertyName = "energieart", Required = Required.Always)]
        [ProtoMember(4)]
        public Sparte Energieart { get; set; }
        /// <summary>Bezeichnung des Energiemix.</summary>
        [JsonProperty(PropertyName = "bezeichnung", Required = Required.Always)]
        [ProtoMember(5)]
        public string Bezeichnung { get; set; }
        /// <summary>Bemerkung zum Energiemix.</summary>
        [JsonProperty(PropertyName = "bemerkung", Required = Required.Default)]
        [ProtoMember(6)]
        public string Bemerkung { get; set; }
        /// <summary>Jahr, für das der Energiemix gilt.</summary>
        [JsonProperty(PropertyName = "gueltigkeitsjahr", Required = Required.Always)]
        [ProtoMember(7)]
        public int Gueltigkeitsjahr { get; set; }
        /// <summary>Höhe des erzeugten CO2-Ausstosses in g/kWh.</summary>
        [JsonProperty(PropertyName = "cO2Emission", Required = Required.Default)]
        [ProtoMember(8)]
        public decimal? Co2Emission { get; set; }
        /// <summary>Höhe des erzeugten Atommülls in g/kWh.</summary>
        [JsonProperty(PropertyName = "atommuell", Required = Required.Default)]
        [ProtoMember(9)]
        public decimal? Atommuell { get; set; }
        /// <summary>Zertifikat für den Energiemix. Details <see cref="ENUM.Oekozertifikat" /></summary>
        [JsonProperty(PropertyName = "oekozertifikat", Required = Required.Default)]
        [ProtoMember(10)]
        public List<Oekozertifikat> Oekozertifikat { get; set; }
        /// <summary>Ökolabel für den Energiemix. Details <see cref="ENUM.Oekolabel" /></summary>
        [JsonProperty(PropertyName = "oekolabel", Required = Required.Default)]
        [ProtoMember(11)]
        public List<Oekolabel> Oekolabel { get; set; }
        /// <summary>Kennzeichen, ob der Versorger zu den Öko Top Ten gehört.</summary>
        [JsonProperty(PropertyName = "oekoTopTen", Required = Required.Default)]
        [ProtoMember(12)]
        public bool? OekoTopTen { get; set; }
        /// <summary>Internetseite, auf der die Strommixdaten veröffentlicht sind.</summary>
        [JsonProperty(PropertyName = "website", Required = Required.Default)]
        [ProtoMember(13)]
        public string Website { get; set; }
        /// <summary>Anteile der jeweiligen Erzeugungsart. Details <see cref="Energieherkunft" /></summary>
        [JsonProperty(PropertyName = "anteil", Required = Required.Always)]
        [ProtoMember(14)]
        public List<Energieherkunft> Anteil { get; set; }
    }
}