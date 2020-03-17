using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Komponente zur Abbildung eines Regionskriteriums.
    /// </summary>
    [ProtoContract]
    public class Regionskriterium : COM
    {
        /// <summary>
        ///  Hier wird festgelegt, ob es sich um ein einschließendes oder ausschließendes Kriterium handelt.Details siehe <see cref="Gueltigkeitstyp"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public Gueltigkeitstyp gueltigkeitstyp;

        /// <summary>
        /// Das Kriterium gilt in der angegebenen Sparte.Details siehe <see cref="Sparte"/>
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public Sparte? sparte;

        /// <summary>
        /// Unterscheidung, wie der Wert angewendet werden soll, z.B.kleiner, größer, gleich.Details siehe <see cref="Mengenoperator"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public Mengenoperator mengenoperator;

        /// <summary>
        /// Hier wird das Kriterium selbst angegeben, z.B.Bundesland. Details siehe <see cref="Regionskriteriumtyp"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(6)]
        public Regionskriteriumtyp regionskriteriumtyp;

        /// <summary>
        /// Der Wert, den das Kriterium annehmen kann, z.B.NRW.Im Falle des Regionskriteriumstyp BUNDESWEIT spielt dieser Wert keine Rolle.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(7)]
        public string wert;
    }
}