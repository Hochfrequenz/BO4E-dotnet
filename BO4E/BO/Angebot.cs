using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

//[module: CompatibilityLevel(CompatibilityLevel.Level300)]
namespace BO4E.BO
{
    /// <summary>
    ///     Mit diesem BO kann ein Versorgungsangebot zur Strom- oder Gasversorgung oder die Teilnahme an einer Ausschreibung
    ///     übertragen werden.Es können verschiedene Varianten enthalten sein (z.B.ein- und mehrjährige Laufzeit). Innerhalb
    ///     jeder Variante können Teile enthalten sein, die jeweils für eine oder mehrere Marktlokationen erstellt werden.
    /// </summary>
    [ProtoContract]
    public class Angebot : BusinessObject
    {
        /// <summary>
        ///     Eindeutige Nummer des Angebotes.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "angebotsnummer")]
        [JsonPropertyName("angebotsnummer")]
        [ProtoMember(4)]
        [DataCategory(DataCategory.FINANCE)]
        [BoKey]
        public string Angebotsnummer { get; set; }

        /// <summary>
        ///     Referenz auf eine Anfrage oder Ausschreibung.Kann dem Empfänger des Angebotes bei Zuordnung des Angebotes zur
        ///     Anfrage bzw.Ausschreibung helfen.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5, PropertyName = "anfragereferenz")]
        [JsonPropertyName("anfragereferenz")]
        [ProtoMember(5)]
        [DataCategory(DataCategory.FINANCE)]
        public string Anfragereferenz { get; set; }

        /// <summary>
        ///     Erstellungsdatum des Angebots,
        /// </summary>
        /// <example>
        ///     2017-12-24
        /// </example>
        [JsonProperty(Required = Required.Always, Order = 6, PropertyName = "angebotsdatum")]
        [JsonPropertyName("angebotsdatum")]
        [ProtoMember(6)]
        [DataCategory(DataCategory.FINANCE)]
        public DateTimeOffset Angebotsdatum { get; set; }

        /// <summary>
        ///     Sparte, für die das Angebot abgegeben wird (Strom/Gas).
        /// </summary>
        /// <see cref="Sparte" />
        [JsonProperty(Required = Required.Always, Order = 7, PropertyName = "sparte")]
        [JsonPropertyName("sparte")]
        [ProtoMember(7)]
        public Sparte Sparte { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(8, Name = nameof(Bindefrist))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _Bindefrist
        {
            get => Bindefrist?.UtcDateTime ?? default;
            set => Bindefrist = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>
        ///     Bis zu diesem Zeitpunkt(Tag/Uhrzeit) inklusive gilt das Angebot
        /// </summary>
        /// <example>
        ///     2017-12-31 17:00:00
        /// </example>
        [JsonProperty(Required = Required.Default, Order = 8, PropertyName = "bindefrist")]
        [JsonPropertyName("bindefrist")]
        [ProtoIgnore]
        [DataCategory(DataCategory.FINANCE)]
        public DateTimeOffset? Bindefrist { get; set; }

        /// <summary>
        ///     Link auf den Ersteller des Angebots.
        /// </summary>
        /// <see cref="Geschaeftspartner" />
        [JsonProperty(Required = Required.Always, Order = 9, PropertyName = "angebotgeber")]
        [JsonPropertyName("angebotgeber")]
        [ProtoMember(9)]
        [DataCategory(DataCategory.FINANCE)]
        public Geschaeftspartner Angebotgeber { get; set; }

        /// <summary>
        ///     Link auf den Empfänger des Angebots.
        /// </summary>
        /// <see cref="Geschaeftspartner" />
        [JsonProperty(Required = Required.Always, Order = 10, PropertyName = "angebotnehmer")]
        [JsonPropertyName("angebotnehmer")]
        [ProtoMember(10)]
        [DataCategory(DataCategory.FINANCE)]
        public Geschaeftspartner Angebotnehmer { get; set; }

        /// <summary>
        ///     Link auf die Person, die als Angebotsnehmer das Angebot angenommen hat.
        /// </summary>
        /// <see cref="Ansprechpartner" />
        [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "unterzeichnerAngebotsnehmer")]
        [JsonPropertyName("unterzeichnerAngebotsnehmer")]
        [ProtoMember(11)]
        [DataCategory(DataCategory.NAME)]
        public Ansprechpartner UnterzeichnerAngebotsnehmer { get; set; }

        /// <summary>
        ///     Link auf die Person, die als Angebotsgeber das Angebots ausgestellt hat.
        /// </summary>
        /// <see cref="Ansprechpartner" />
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "unterzeichnerAngebotsgeber")]
        [JsonPropertyName("unterzeichnerAngebotsgeber")]
        [ProtoMember(12)]
        [DataCategory(DataCategory.NAME)]
        public Ansprechpartner UnterzeichnerAngebotsgeber { get; set; }

        /// <summary>
        ///     Eine oder mehrere Varianten des Angebots mit den Angebotsteilen. Ein Angebot besteht mindestens aus einer Variante.
        /// </summary>
        /// <see cref="Angebotsvariante" />
        [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "varianten")]
        [JsonPropertyName("varianten")]
        [ProtoMember(13)]
        [DataCategory(DataCategory.FINANCE)]
        [MinLength(1)]
        public List<Angebotsvariante> Varianten { get; set; }
    }
}