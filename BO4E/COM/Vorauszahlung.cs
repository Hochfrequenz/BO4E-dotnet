using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System;
using System.Text.Json.Serialization;

namespace BO4E.COM
{
    /// <summary>
    ///     Die Komponente wird dazu verwendet Vorauszahlungen einer Rechnung abzubilden (inkl. Referenz auf die bezahlte Rechnung)
    /// </summary>
    [ProtoContract]
    public class Vorauszahlung : COM
    {
        /// <summary>Gibt den Betrag des Preises an.</summary>
        [JsonProperty(PropertyName = "betrag", Required = Required.Always, Order = 3)]
        [JsonPropertyName("betrag")]
        [FieldName("value", Language.EN)]
        [ProtoMember(3)]
        [JsonPropertyOrder(3)]
        public Betrag Betrag { get; set; }


        /// <summary>
        ///     Referenz auf die Rechnungsnummer, die durch diesen Betrag bezahlt wurde
        /// </summary>
        [ProtoMember(4)]
        [JsonProperty(Required = Required.Default, Order = 4, PropertyName = "referenz")]
        [JsonPropertyName("referenz")]
        [JsonPropertyOrder(4)]
        public string? Referenz { get; set; }

        /// <summary>
        ///     Referenz auf das Datum der Rechnung, die durch diesen Betrag bezahlt wurde
        /// </summary>
        [ProtoIgnore]
        [JsonProperty(Required = Required.Default, Order = 5, PropertyName = "referenzDatum")]
        [JsonPropertyName("referenzDatum")]
        [JsonPropertyOrder(5)]
        public DateTimeOffset? ReferenzDatum { get; set; }

        /// <summary>
        ///  Referenz auf das Datum der Rechnung, die durch diesen Betrag bezahlt wurde
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(1005, Name = nameof(ReferenzDatum))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _ReferenzDatum
        {
            get => ReferenzDatum?.UtcDateTime ?? DateTime.MinValue;
            set => ReferenzDatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
    }
}