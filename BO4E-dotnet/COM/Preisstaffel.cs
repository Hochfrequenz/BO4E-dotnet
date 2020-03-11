using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Gibt die Staffelgrenzen der jeweiligen Preise an.</summary>
    [ProtoContract]
    [ProtoInclude(102, typeof(RegionalePreisstaffel))]
    public class Preisstaffel : COM
    {
        /// <summary>Preis pro abgerechneter Mengeneinheit</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public decimal einheitspreis;
        /// <summary>Unterer Wert, ab dem die Staffel gilt.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public decimal staffelgrenzeVon;
        /// <summary>Oberer Wert, bis zu dem die Staffel gilt.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public decimal staffelgrenzeBis;
        /// <summary>Parameter zur Berechnung des Preises anhand der Jahresmenge und weiterer netzbezogener Parameter. <seealso cref="Sigmoidparameter" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(6)]
        public Sigmoidparameter sigmoidparameter;
    }
}