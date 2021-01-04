using System.Collections.Generic;

using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente können regionale Gültigkeiten, z.B. für Tarife, Zu- und Abschläge und Preise definiert werden.</summary>
    [ProtoContract]
    public class RegionaleGueltigkeit : Com
    {
        /// <summary>Unterscheidung ob Positivliste oder Negativliste übertragen wird. Details <see cref="ENUM.Gueltigkeitstyp" /></summary>
        [JsonProperty(PropertyName = "gueltigkeitstyp", Required = Required.Always)]
        [ProtoMember(3)]
        public Gueltigkeitstyp Gueltigkeitstyp { get; set; }
        /// <summary>Hier steht, für welches Kriterium die Liste gilt. Z.B. Postleitzahlen. Details <see cref="Tarifregionskriterium" /></summary>
        [JsonProperty(PropertyName = "kriteriumsWerte", Required = Required.Always)]
        [ProtoMember(4)]
        public List<KriteriumsWert> KriteriumsWerte { get; set; }
    }
}