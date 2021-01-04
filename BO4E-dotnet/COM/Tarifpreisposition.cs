using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente können Tarifpreise verschiedener Typen abgebildet werden.</summary>
    [ProtoContract]
    public class Tarifpreisposition : Com
    {
        /// <summary>Angabe des Preistypes (z.B. Grundpreis) Details <see cref="ENUM.Preistyp" /></summary>
        [JsonProperty(PropertyName = "preistyp", Required = Required.Always)]
        [ProtoMember(3)]
        public Preistyp Preistyp { get; set; }

        /// <summary>Einheit des Preises (z.B. EURO) Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(PropertyName = "einheit", Required = Required.Always)]
        [ProtoMember(4)]
        public Waehrungseinheit Einheit { get; set; }

        /// <summary>Größe, auf die sich die Einheit bezieht, beispielsweise kWh, Jahr. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(PropertyName = "bezugseinheit", Required = Required.Always)]
        [ProtoMember(5)]
        public Mengeneinheit Bezugseinheit { get; set; }

        /// <summary>Gibt an, nach welcher Menge die vorgenannte Einschränkung erfolgt (z.B. Jahresstromverbrauch in kWh).Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(PropertyName = "mengeneinheitstaffel", Required = Required.Default)]
        [ProtoMember(6)]
        public Mengeneinheit? Mengeneinheitstaffel { get; set; }

        /// <summary>Hier sind die Staffeln mit ihren Preisenangaben definiert. Struktur <seealso cref="Preisstaffel" /></summary>
        [JsonProperty(PropertyName = "preisstaffeln", Required = Required.Always)]
        [ProtoMember(7)]
        public Preisstaffel Preisstaffeln { get; set; }
    }
}