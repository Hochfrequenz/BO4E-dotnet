using System;
using System.Text.Json.Serialization;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Die Positionen eines Avis.
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.MISSING)]
    public class Avisposition : COM
    {
        /// <summary>
        /// Die Rechnungsnummer der Rechnung, auf die sich das Avis bezieht.
        /// </summary>
        [JsonProperty(PropertyName = "rechnungsNummer", Required = Required.Always, Order = 1)]
        [JsonPropertyName("rechnungsNummer")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1)]
        public string RechnungsNummer { get; set; }

        /// <summary>
        /// workaround
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(2, Name = nameof(RechnungsDatum))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        protected DateTime _RechnungsDatum
        {
            get => RechnungsDatum.UtcDateTime;
            set => RechnungsDatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>
        /// Das Rechnungsdatum der Rechnung, auf die sich das Avis bezieht.
        /// </summary>
        [JsonProperty(PropertyName = "RechnungsDatum", Required = Required.Always, Order = 2)]
        [JsonPropertyName("avisRechnungsDatum")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoIgnore]
        public DateTimeOffset RechnungsDatum { get; set; }

        /// <summary>
        /// Kennzeichnung, ob es sich bei der Rechnung auf die sich das Avis bezieht, um eine Stornorechnung handelt.
        /// </summary>
        [JsonProperty(PropertyName = "storno", Required = Required.Always, Order = 3)]
        [JsonPropertyName("storno")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(3)]
        public bool Storno { get; set; }

        /// <summary>
        /// Überweisungsbetrag
        /// </summary>
        [JsonProperty(PropertyName = "gesamtBrutto", Required = Required.Always, Order = 4)]
        [JsonPropertyName("gesamtBrutto")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(4)]
        public Betrag GesamtBrutto { get; set; }

        /// <summary>
        /// Geforderter Rechnungsbetrag
        /// </summary>
        [JsonProperty(PropertyName = "zuZahlen", Required = Required.Always, Order = 5)]
        [JsonPropertyName("zuZahlen")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(5)]
        public Betrag ZuZahlen { get; set; }

        /// <summary>
        /// Abweichung bei Ablehnung einer COMDIS
        /// </summary>
        /// <see cref="Abweichung" />
        [JsonProperty(PropertyName = "abweichung", Required = Required.Default, Order = 6)]
        [JsonPropertyName("abweichung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(6)]
        public Abweichung Abweichung { get; set; }
    }
}