using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Text.Json.Serialization;

namespace BO4E.COM
{
    /// <summary>Abbildung eines Steuerbetrages.</summary>
    [ProtoContract]
    public class Steuerbetrag : COM
    {
        /// <summary>Kennzeichnung des Steuersatzes, bzw. Verfahrens. Details <see cref="ENUM.Steuerkennzeichen" /></summary>
        [JsonProperty(PropertyName = "steuerkennzeichen", Required = Required.Always)]
        [JsonPropertyName("steuerkennzeichen")]
        [FieldName("taxIdentifier", Language.EN)]
        [ProtoMember(3)]
        public Steuerkennzeichen Steuerkennzeichen { get; set; }

        /// <summary>
        /// Wert eines besonderen Steuersatzes, wenn <see cref="ENUM.Steuerkennzeichen" />
        /// den Wert <see cref="BO4E.ENUM.Steuerkennzeichen.UST_SONDER" /> hat
        /// </summary>
        [JsonProperty(PropertyName = "ustSonder", Required = Required.AllowNull)]
        [JsonPropertyName("ustSonder")]
        [FieldName("customTax", Language.EN)]
        [ProtoMember(9)]
        public decimal Sondersteuersatz { get; set; }

        /// <summary>Nettobetrag für den die Steuer berechnet wurde. Z.B. 200</summary>
        [JsonProperty(PropertyName = "basiswert", Required = Required.Always)]
        [JsonPropertyName("basiswert")]
        [FieldName("baseValue", Language.EN)]
        [ProtoMember(4)]
        public decimal Basiswert { get; set; }

        /// <summary>Aus dem Basiswert berechnete Steuer. Z.B. 38 (bei UST_19), falls <see cref="Basiswert"/> 200 ist.</summary>
        [JsonProperty(PropertyName = "steuerwert", Required = Required.Always)]
        [JsonPropertyName("steuerwert")]
        [FieldName("taxValue", Language.EN)]
        [ProtoMember(5)]
        public decimal Steuerwert { get; set; }

        /// <summary>Währung. Z.B. Euro. <seealso cref="Waehrungscode" /></summary>
        [JsonProperty(PropertyName = "waehrung", Required = Required.Always)]
        [JsonPropertyName("waehrung")]
        [FieldName("currency", Language.EN)]
        [ProtoMember(6)]
        public Waehrungscode Waehrung { get; set; }

        /// <summary>Nettobetrag (vorausgezahlt) für den die Steuer berechnet wurde. Z.B. 200</summary>
        [JsonProperty(PropertyName = "basiswertVorausgezahlt", Required = Required.Default)]
        [JsonPropertyName("basiswertVorausgezahlt")]
        [FieldName("baseValuePrepaid", Language.EN)]
        [ProtoMember(7)]
        public decimal? BasiswertVorausgezahlt { get; set; }

        /// <summary>Aus dem Basiswert (vorausgezahlt) berechnete Steuer. Z.B. 38 (bei UST_19), wenn <see cref="BasiswertVorausgezahlt"/> 200 ist</summary>
        [JsonProperty(PropertyName = "steuerwertVorausgezahlt", Required = Required.Default)]
        [JsonPropertyName("steuerwertVorausgezahlt")]
        [FieldName("taxValuePrepaid", Language.EN)]
        [ProtoMember(8)]
        public decimal? SteuerwertVorausgezahlt { get; set; }
    }
}
