using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Abbildung eines Steuerbetrages.</summary>
    [ProtoContract]
    public class Steuerbetrag : COM
    {
        /// <summary>Kennzeichnung des Steuersatzes, bzw. Verfahrens. Details <see cref="ENUM.Steuerkennzeichen" /></summary>
        [JsonProperty(PropertyName = "steuerkennzeichen", Required = Required.Always)]
        [FieldName("taxIdentifier", Language.EN)]
        [ProtoMember(3)]
        public Steuerkennzeichen Steuerkennzeichen { get; set; }

        /// <summary>Nettobetrag für den die Steuer berechnet wurde. Z.B. 100</summary>
        [JsonProperty(PropertyName = "basiswert", Required = Required.Always)]
        [FieldName("baseValue", Language.EN)]
        [ProtoMember(4)]
        public decimal Basiswert { get; set; }

        /// <summary>Aus dem Basiswert berechnete Steuer. Z.B. 19 (bei UST_19)</summary>
        [JsonProperty(PropertyName = "steuerwert", Required = Required.Always)]
        [FieldName("taxValue", Language.EN)]
        [ProtoMember(5)]
        public decimal Steuerwert { get; set; }

        /// <summary>Währung. Z.B. Euro. <seealso cref="Waehrungscode" /></summary>
        [JsonProperty(PropertyName = "waehrung", Required = Required.Always)]
        [FieldName("currency", Language.EN)]
        [ProtoMember(6)]
        public Waehrungscode Waehrung { get; set; }
    }
}