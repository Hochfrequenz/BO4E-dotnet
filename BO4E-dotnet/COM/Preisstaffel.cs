using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Gibt die Staffelgrenzen der jeweiligen Preise an.</summary>
    public class Preisstaffel : COM
    {
        /// <summary>Preis pro abgerechneter Mengeneinheit</summary>
        [JsonProperty(Required = Required.Always)]
        public decimal einheitspreis;
        /// <summary>Unterer Wert, ab dem die Staffel gilt.</summary>
        [JsonProperty(Required = Required.Always)]
        public decimal staffelgrenzeVon;
        /// <summary>Oberer Wert, bis zu dem die Staffel gilt.</summary>
        [JsonProperty(Required = Required.Always)]
        public decimal staffelgrenzeBis;
        /// <summary>Parameter zur Berechnung des Preises anhand der Jahresmenge und weiterer netzbezogener Parameter. <seealso cref="Sigmoidparameter" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Sigmoidparameter sigmoidparameter;
    }
}