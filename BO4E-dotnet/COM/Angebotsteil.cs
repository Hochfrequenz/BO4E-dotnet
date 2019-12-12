using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.BO;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente wird ein Teil einer Angebotsvariante abgebildet. Hier werden alle Angebotspositionen aggregiert.</summary>
    public class Angebotsteil : COM
    {
        /// <summary>Identifizierung eines Subkapitels einer Anfrage, beispielsweise das Los einer Ausschreibung.</summary>
        [JsonProperty(Required = Required.Default)]
        public string anfrageSubreferenz;

        /// <summary>Marktlokationen, für die dieses Angebotsteil gilt, falls vorhanden. Durch die Marktlokation ist auch die Lieferadresse festgelegt. Details <see cref="Marktlokation" /></summary>
        [JsonProperty(Required = Required.Default)]
        public List<Marktlokation> lieferstellenangebotsteil;

        /// <summary>Summe der Verbräuche aller in diesem Angebotsteil eingeschlossenen Lieferstellen. Details <see cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Menge gesamtmengeangebotsteil;

        /// <summary>Summe der Jahresenergiekosten aller in diesem Angebotsteil enthaltenen Lieferstellen. Details <see cref="Betrag" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Betrag gesamtkostenangebotsteil;

        /// <summary>Einzelne Positionen, die zu diesem Angebotsteil gehören. Details <see cref="Angebotsposition" /></summary>
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        public List<Angebotsposition> positionen;
    }
}
