using System;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    ///     Abbildung einer Rechnungsposition. Über Rechnungspositionen werden Rechnungen strukturiert. In einem
    ///     Rechnungsteil wird jeweils eine in sich geschlossene Leistung abgerechnet.
    /// </summary>
    [ProtoContract]
    public class Rechnungsposition : COM
    {
        /// <summary>Fortlaufende Nummer für die Rechnungsposition.</summary>
        [JsonProperty(PropertyName = "positionsnummer", Required = Required.Always)]
        [JsonPropertyName("positionsnummer")]
        [JsonPropertyOrder(1)]
        [FieldName("invoiceItemNumber", Language.EN)]
        [ProtoMember(1)]
        public int Positionsnummer { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(2, Name = nameof(LieferungVon))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _LieferungVon
        {
            get => LieferungVon.UtcDateTime;
            set => LieferungVon = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>Start der Lieferung für die abgerechnete Leistung.</summary>
        [JsonProperty(PropertyName = "lieferungVon", Required = Required.Always)]
        [JsonPropertyName("lieferungVon")]
        [JsonPropertyOrder(2)]
        [FieldName("deliveryStart", Language.EN)]
        [ProtoIgnore]
        [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset LieferungVon { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(3, Name = nameof(LieferungBis))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _LieferungBis
        {
            get => LieferungBis.UtcDateTime;
            set => LieferungBis = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>Ende der Lieferung für die abgerechnete Leistung.</summary>
        [JsonProperty(PropertyName = "lieferungBis", Required = Required.Always)]
        [JsonPropertyName("lieferungBis")]
        [JsonPropertyOrder(3)]
        [FieldName("deliveryEnd", Language.EN)]
        [ProtoIgnore]
        [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset LieferungBis { get; set; }

        /// <summary>Bezeichnung für die abgerechnete Position.</summary>
        [JsonProperty(PropertyName = "positionstext", Required = Required.Always)]
        [JsonPropertyName("positionstext")]
        [JsonPropertyOrder(4)]
        [FieldName("invoiceItemText", Language.EN)]
        [ProtoMember(4)]
        public string Positionstext { get; set; }

        /// <summary>
        ///     Falls sich der Preis auf eine Zeit bezieht, steht hier die Einheit, z.B. JAHR. Details
        ///     <see cref="Mengeneinheit" />
        /// </summary>
        [JsonProperty(PropertyName = "zeiteinheit", Required = Required.Default)]
        [JsonPropertyName("zeiteinheit")]
        [JsonPropertyOrder(5)]
        [FieldName("unit", Language.EN)]
        [ProtoMember(5)]
        public Mengeneinheit? Zeiteinheit { get; set; }

        /// <summary>
        ///     Kennzeichnung der Rechnungsposition mit der Standard-Artikelnummer des BDEW. Details
        ///     <see cref="BDEWArtikelnummer" />
        /// </summary>
        [JsonProperty(PropertyName = "artikelnummer", Required = Required.Default)]
        [JsonPropertyName("artikelnummer")]
        [JsonPropertyOrder(6)]
        [ProtoMember(6)]
        public BDEWArtikelnummer? Artikelnummer { get; set; }

        /// <summary>Marktlokation, die zu dieser Position gehört.</summary>
        [JsonProperty(PropertyName = "lokationsId", Required = Required.Default)]
        [JsonPropertyName("lokationsId")]
        [JsonPropertyOrder(7)]
        [ProtoMember(7)]
        public string? LokationsId { get; set; }

        /// <summary>Die abgerechnete Menge mit Einheit. Z.B. 4372 kWh. Details <see cref="Menge" /></summary>
        [JsonProperty(PropertyName = "positionsMenge", Required = Required.Default)]
        [JsonPropertyName("positionsMenge")]
        [JsonPropertyOrder(8)]
        [FieldName("amount", Language.EN)]
        [ProtoMember(8)]
        public Menge? PositionsMenge { get; set; }

        /// <summary>
        ///     Eine auf die Zeiteinheit bezogene Untermenge. Z.B. bei einem Jahrespreis, 3 Monate oder 146 Tage. Basierend
        ///     darauf wird der Preis aufgeteilt. Details <see cref="Menge" />
        /// </summary>
        [JsonProperty(PropertyName = "zeitbezogeneMenge", Required = Required.Default)]
        [JsonPropertyName("zeitbezogeneMenge")]
        [JsonPropertyOrder(9)]
        [FieldName("timeBasedAmount", Language.EN)]
        [ProtoMember(9)]
        public Menge? ZeitbezogeneMenge { get; set; }

        /// <summary>Gibt ggf. einen Korrekturfaktor für die Menge an.</summary>
        [JsonProperty(PropertyName = "korrekturfaktor", Required = Required.Default, Order = 12)]
        [JsonPropertyName("korrekturfaktor")]
        [JsonPropertyOrder(10)]
        [ProtoMember(10)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public decimal? Korrekturfaktor { get; set; }

        /// <summary>Der Preis für eine Einheit der energetischen Menge. Details <see cref="Preis" /></summary>
        [JsonProperty(PropertyName = "einzelpreis", Required = Required.Always)]
        [JsonPropertyName("einzelpreis")]
        [JsonPropertyOrder(11)]
        [FieldName("unitCost", Language.EN)]
        [ProtoMember(11)]
        public Preis Einzelpreis { get; set; }

        /// <summary>
        ///     Das Ergebnis der Multiplikation aus einzelpreis * positionsMenge * (Faktor aus zeitbezogeneMenge). Z.B. 12,60€
        ///     * 120 kW * 3/12 (für 3 Monate). Details <see cref="Betrag" />
        /// </summary>
        [JsonProperty(PropertyName = "teilsummeNetto", Required = Required.Default)]
        [JsonPropertyName("teilsummeNetto")]
        [JsonPropertyOrder(12)]
        [FieldName("subtotalNet", Language.EN)]
        [ProtoMember(12)]
        public Betrag? TeilsummeNetto { get; set; }

        /// <summary>Nettobetrag für den Rabatt dieser Position. Details <see cref="Betrag" /></summary>
        [JsonProperty(PropertyName = "teilrabattNetto", Required = Required.Default)]
        [JsonPropertyName("teilrabattNetto")]
        [JsonPropertyOrder(13)]
        [FieldName("someDiscountNet", Language.EN)]
        [ProtoMember(13)]
        public Betrag? TeilrabattNetto { get; set; }

        /// <summary>
        ///     Auf die Position entfallende Steuer, bestehend aus Steuersatz und Betrag. Details <see cref="Steuerbetrag" />
        /// </summary>
        [JsonProperty(PropertyName = "teilsummeSteuer", Required = Required.Default)]
        [JsonPropertyName("teilsummeSteuer")]
        [JsonPropertyOrder(14)]
        [FieldName("subtotalTax", Language.EN)]
        [ProtoMember(14)]
        public Steuerbetrag? TeilsummeSteuer { get; set; }

        /// <summary>
        ///     Möglichkeit die Rechnungsposition einem Vertragskonto zuzuordnen, um die Rechnungsposition mittels SAP Convergent
        ///     Invoicing zu verarbeiten.
        ///     (Ergänzung von Hochfrequenz Unternehmensberatung GmbH)
        /// </summary>
        [JsonProperty(PropertyName = "vertragskontoId", Required = Required.Default)]
        [JsonPropertyName("vertragskontoId")]
        [JsonPropertyOrder(15)]
        [Obsolete("Please use vertragsId instead of vertragskontoId", false)]
        [FieldName("contractAccountId", Language.EN)]
        [ProtoMember(15)]
        public string? VertragskontoId { get; set; }

        /// <summary>
        ///     Möglichkeit die Rechnungsposition einem Vertragskonto zuzuordnen, um die Rechnungsposition mittels SAP Convergent
        ///     Invoicing zu verarbeiten.
        ///     (Ergänzung von Hochfrequenz Unternehmensberatung GmbH)
        /// </summary>
        [JsonProperty(PropertyName = "vertragsId", Required = Required.Default)]
        [JsonPropertyName("vertragsId")]
        [JsonPropertyOrder(16)]
        [ProtoMember(1017)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public string? VertragsId { get; set; }

        /// <summary>
        ///     status einer Rechnungsposition in SAP Convergent Invoicing
        ///     (Ergänzung von Hochfrequenz Unternehmensberatung GmbH)
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Default)]
        [JsonPropertyName("status")]
        [JsonPropertyOrder(17)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1018)]
        public RechnungspositionsStatus? Status { get; set; }
    }
}