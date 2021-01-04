using System.Collections.Generic;

using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente können Tarifpreise verschiedener Typen im Zusammenhang mit regionalen Gültigkeiten abgebildet werden.</summary>
    [ProtoContract]
    public class RegionaleTarifpreisposition : Com
    {
        /// <summary>Angabe des Preistyps (z.B. Grundpreis) Details <see cref="ENUM.Preistyp" /></summary>
        [JsonProperty(PropertyName = "preistyp", Required = Required.Always)]
        [ProtoMember(3)]
        public Preistyp Preistyp { get; set; }
        /// <summary>Einheit des Preises (z.B. EURO) Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(PropertyName = "einheit", Required = Required.Always)]
        [ProtoMember(4)]
        public string Einheit { get; set; }
        /// <summary>Größe, auf die sich die Einheit bezieht, beispielsweise kWh, Jahr. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(PropertyName = "bezugseinheit", Required = Required.Always)]
        [ProtoMember(5)]
        public Mengeneinheit Bezugseinheit { get; set; }
        /// <summary>Gibt an, nach welcher Menge die vorgenannte Einschränkung erfolgt (z.B. Jahresstromverbrauch in kWh).Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(PropertyName = "mengeneinheitstaffel", Required = Required.Default)]
        [ProtoMember(6)]
        public Mengeneinheit? Mengeneinheitstaffel { get; set; }
        /// <summary>Hier sind die Staffeln mit ihren Preisangaben und regionalen Gültigkeiten definiert. Struktur <seealso cref="RegionalePreisstaffel" /></summary>
        [JsonProperty(PropertyName = "preisstaffeln", Required = Required.Default)]
        [ProtoMember(7)]
        public List<RegionalePreisstaffel> Preisstaffeln { get; set; }
    }
}