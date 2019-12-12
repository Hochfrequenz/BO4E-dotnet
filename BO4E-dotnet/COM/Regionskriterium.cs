using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>
    /// Komponente zur Abbildung eines Regionskriteriums.
    /// </summary>
    public class Regionskriterium : COM
    {
        /// <summary>
        ///  Hier wird festgelegt, ob es sich um ein einschließendes oder ausschließendes Kriterium handelt.Details siehe <see cref="Gueltigkeitstyp"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Gueltigkeitstyp gueltigkeitstyp;

        /// <summary>
        /// Das Kriterium gilt in der angegebenen Sparte.Details siehe <see cref="Sparte"/>
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public Sparte? sparte;

        /// <summary>
        /// Unterscheidung, wie der Wert angewendet werden soll, z.B.kleiner, größer, gleich.Details siehe <see cref="Mengenoperator"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Mengenoperator mengenoperator;

        /// <summary>
        /// Hier wird das Kriterium selbst angegeben, z.B.Bundesland. Details siehe <see cref="Regionskriteriumtyp"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Regionskriteriumtyp regionskriteriumtyp;

        /// <summary>
        /// Der Wert, den das Kriterium annehmen kann, z.B.NRW.Im Falle des Regionskriteriumstyp BUNDESWEIT spielt dieser Wert keine Rolle.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string wert;
    }
}