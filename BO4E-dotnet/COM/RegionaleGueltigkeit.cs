using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente können regionale Gültigkeiten, z.B. für Tarife, Zu- und Abschläge und Preise definiert werden.</summary>
    public class RegionaleGueltigkeit : COM
    {
        /// <summary>Unterscheidung ob Positivliste oder Negativliste übertragen wird. Details <see cref="Gueltigkeitstyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Gueltigkeitstyp gueltigkeitstyp;
        /// <summary>Hier steht, für welches Kriterium die Liste gilt. Z.B. Postleitzahlen. Details <see cref="Tarifregionskriterium" /></summary>
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        public List<KriteriumsWert> kriteriumsWerte;
    }
}