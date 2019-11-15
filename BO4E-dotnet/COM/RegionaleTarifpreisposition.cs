using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente können Tarifpreise verschiedener Typen im Zusammenhang mit regionalen Gültigkeiten abgebildet werden.</summary>
    public class RegionaleTarifpreisposition : COM
    {
        /// <summary>Angabe des Preistyps (z.B. Grundpreis) Details <see cref="Preistyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Preistyp preistyp;
        /// <summary>Einheit des Preises (z.B. EURO) Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        public string einheit;
        /// <summary>Größe, auf die sich die Einheit bezieht, beispielsweise kWh, Jahr. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Mengeneinheit bezugseinheit;
        /// <summary>Gibt an, nach welcher Menge die vorgenannte Einschränkung erfolgt (z.B. Jahresstromverbrauch in kWh).Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Mengeneinheit? mengeneinheitstaffel;
        /// <summary>Hier sind die Staffeln mit ihren Preisangaben und regionalen Gültigkeiten definiert. Struktur <seealso cref="RegionalePreisstaffel" /></summary>
        [JsonProperty(Required = Required.Default)]
        [MinLength(1)]
        public List<RegionalePreisstaffel> preisstaffeln;
    }
}