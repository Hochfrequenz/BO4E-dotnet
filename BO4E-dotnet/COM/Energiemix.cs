using System.Collections.Generic;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Zusammensetzung der gelieferten Energie aus den verschiedenen Primärenergieformen.</summary>
    [ProtoContract]
    public class Energiemix : COM
    {
        /// <summary>Eindeutige Nummer zur Identifizierung des Energiemixes.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public int energiemixnummer;
        /// <summary>Strom oder Gas etc.. Details <see cref="Sparte" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public Sparte energieart;
        /// <summary>Bezeichnung des Energiemix.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public string bezeichnung;
        /// <summary>Bemerkung zum Energiemix.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(6)]
        public string bemerkung;
        /// <summary>Jahr, für das der Energiemix gilt.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(7)]
        public int gueltigkeitsjahr;
        /// <summary>Höhe des erzeugten CO2-Ausstosses in g/kWh.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(8)]
        public decimal? cO2Emission;
        /// <summary>Höhe des erzeugten Atommülls in g/kWh.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(9)]
        public decimal? atommuell;
        /// <summary>Zertifikat für den Energiemix. Details <see cref="Oekozertifikat" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(10)]
        public List<Oekozertifikat> oekozertifikat;
        /// <summary>Ökolabel für den Energiemix. Details <see cref="Oekolabel" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(11)]
        public List<Oekolabel> oekolabel;
        /// <summary>Kennzeichen, ob der Versorger zu den Öko Top Ten gehört.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(12)]
        public bool? oekoTopTen;
        /// <summary>Internetseite, auf der die Strommixdaten veröffentlicht sind.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(13)]
        public string website;
        /// <summary>Anteile der jeweiligen Erzeugungsart. Details <see cref="Energieherkunft" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(14)]
        public List<Energieherkunft> anteil;
    }
}