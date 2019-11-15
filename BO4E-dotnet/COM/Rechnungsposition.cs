using System;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Abbildung einer Rechnungsposition. Über Rechnungspositionen werden Rechnungen strukturiert. In einem Rechnungsteil wird jeweils eine in sich geschlossene Leistung abgerechnet.</summary>
    public class Rechnungsposition : COM
    {
        /// <summary>Fortlaufende Nummer für die Rechnungsposition.</summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("invoiceItemNumber", Language.EN)]
        public int positionsnummer;
        /// <summary>Start der Lieferung für die abgerechnete Leistung.</summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("deliveryStart", Language.EN)]
        public DateTime lieferungVon;
        /// <summary>Ende der Lieferung für die abgerechnete Leistung.</summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("deliveryEnd", Language.EN)]
        public DateTime lieferungBis;
        /// <summary>Bezeichnung für die abgerechnete Position.</summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("invoiceItemText", Language.EN)]
        public string positionstext;
        /// <summary>Falls sich der Preis auf eine Zeit bezieht, steht hier die Einheit, z.B. JAHR. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("unit", Language.EN)]
        public Mengeneinheit? zeiteinheit;
        /// <summary>Kennzeichnung der Rechnungsposition mit der Standard-Artikelnummer des BDEW. Details <see cref="BDEWArtikelnummer" /></summary>
        [JsonProperty(Required = Required.Default)]
        public BDEWArtikelnummer? artikelnummer;
        /// <summary>Marktlokation, die zu dieser Position gehört.</summary>
        [JsonProperty(Required = Required.Default)]
        public string lokationsId;
        /// <summary>Die abgerechnete Menge mit Einheit. Z.B. 4372 kWh. Details <see cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("amount", Language.EN)]
        public Menge positionsMenge;
        /// <summary>Eine auf die Zeiteinheit bezogene Untermenge. Z.B. bei einem Jahrespreis, 3 Monate oder 146 Tage. Basierend darauf wird der Preis aufgeteilt. Details <see cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("timeBasedAmount", Language.EN)]
        public Menge zeitbezogeneMenge;
        /// <summary>Der Preis für eine Einheit der energetischen Menge. Details <see cref="Preis" /></summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("unitCost", Language.EN)]
        public Preis einzelpreis;
        /// <summary>Das Ergebnis der Multiplikation aus einzelpreis * positionsMenge * (Faktor aus zeitbezogeneMenge). Z.B. 12,60€ * 120 kW * 3/12 (für 3 Monate). Details <see cref="Betrag" /></summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("subtotalNet", Language.EN)]
        public Betrag teilsummeNetto;
        /// <summary>Nettobetrag für den Rabatt dieser Position. Details <see cref="Betrag" /></summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("someDiscountNet", Language.EN)]
        public Betrag teilrabattNetto;
        /// <summary>Auf die Position entfallende Steuer, bestehend aus Steuersatz und Betrag. Details <see cref="Steuerbetrag" /></summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("subtotalTax", Language.EN)]
        public Steuerbetrag teilsummeSteuer;

        /// <summary>
        /// Möglichkeit die Rechnungsposition einem Vertragskonto zuzuordnen, um die Rechnungsposition mittels SAP Convergent Invoicing zu verarbeiten.
        /// (Ergänzung von Hochfrequenz Unternehmensberatung GmbH)
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [Obsolete("Please use vertragsId instead of vertragskontoId", false)]
        [FieldName("contractAccountId", Language.EN)]
        public string vertragskontoId;

        /// <summary>
        /// Möglichkeit die Rechnungsposition einem Vertragskonto zuzuordnen, um die Rechnungsposition mittels SAP Convergent Invoicing zu verarbeiten.
        /// (Ergänzung von Hochfrequenz Unternehmensberatung GmbH)
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string vertragsId;

        /// <summary>
        /// status einer Rechnungsposition in SAP Convergent Invoicing
        /// (Ergänzung von Hochfrequenz Unternehmensberatung GmbH)
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public RechnungspositionsStatus? status;

    }
}