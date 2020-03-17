using System.Collections.Generic;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente können Tarifpreise verschiedener Typen im Zusammenhang mit regionalen Gültigkeiten abgebildet werden.</summary>
    [ProtoContract]
    public class RegionaleTarifpreisposition : COM
    {
        /// <summary>Angabe des Preistyps (z.B. Grundpreis) Details <see cref="Preistyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public Preistyp preistyp;
        /// <summary>Einheit des Preises (z.B. EURO) Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public string einheit;
        /// <summary>Größe, auf die sich die Einheit bezieht, beispielsweise kWh, Jahr. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public Mengeneinheit bezugseinheit;
        /// <summary>Gibt an, nach welcher Menge die vorgenannte Einschränkung erfolgt (z.B. Jahresstromverbrauch in kWh).Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(6)]
        public Mengeneinheit? mengeneinheitstaffel;
        /// <summary>Hier sind die Staffeln mit ihren Preisangaben und regionalen Gültigkeiten definiert. Struktur <seealso cref="RegionalePreisstaffel" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(7)]
        public List<RegionalePreisstaffel> preisstaffeln;
    }
}