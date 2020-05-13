using System;

using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Diese Klasse ist der <see cref="Rechnungsposition"/> nachempfunden und dieser ähnlich.
    /// Jedoch enthält sie weniger Daten und v.a. in einem flachen Format, das mit den beschränkten SAP
    /// Bordmitteln leichter als Entitätstyp für die Verarbeitung in einer OData-Schnittstelle abgebildet werden kann.
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public class RechnungspositionFlat : COM
    {
        /// <inheritdoc cref="Rechnungsposition.Positionsnummer"/>
        [JsonProperty(PropertyName = "positionsnummer", Required = Required.Always)]
        [ProtoMember(3)]
        public int Positionsnummer { get; set; }

        /// <inheritdoc cref="Rechnungsposition.LieferungVon"/>
        [JsonProperty(PropertyName = "lieferungVon", Required = Required.Always)]
        [ProtoMember(4, DataFormat = DataFormat.WellKnown)]
        [JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset LieferungVon { get; set; }

        /// <inheritdoc cref="Rechnungsposition.LieferungBis"/>
        [JsonProperty(PropertyName = "lieferungBis", Required = Required.Always)]
        [ProtoMember(5, DataFormat = DataFormat.WellKnown)]
        [JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset LieferungBis { get; set; }

        /// <summary>
        /// Der Positionstext entspricht dem SAP CI Teilprozess bzw. der GCN Categoy
        /// <seealso cref="Rechnungsposition.Positionstext"/>
        /// </summary>
        [JsonProperty(PropertyName = "positionstext", Required = Required.Always)]
        [ProtoMember(6)]
        public string Positionstext { get; set; }

        /// <inheritdoc cref="Rechnungsposition.LokationsId"/>>
        [JsonProperty(PropertyName = "lokationsId", Required = Required.Always)]
        [ProtoMember(7)]
        public string LokationsId { get; set; }

        /// <inheritdoc cref="Rechnungsposition.VertragskontoId"/>>
        [JsonProperty(PropertyName = "vertragskontoId", Required = Required.Always)]
        [ProtoMember(8)]
        public string VertragskontoId { get; set; }

        /// <summary>
        /// <see cref="Rechnungsposition.Einzelpreis"/> and <see cref="Preis.Wert"/>
        /// </summary>
        [JsonProperty(PropertyName = "preisWert", Required = Required.Always)]
        [ProtoMember(9)]
        public decimal PreisWert { get; set; }

        /// <summary>
        /// <see cref="Rechnungsposition.Einzelpreis"/> and <see cref="Preis.Einheit"/>
        /// </summary>
        [JsonProperty(PropertyName = "preisEinheit", Required = Required.Always)]
        [ProtoMember(10)]
        public Waehrungseinheit PreisEinheit { get; set; }

        /// <summary>
        /// <see cref="Rechnungsposition.Einzelpreis"/> and <see cref="Preis.Bezugswert"/>
        /// </summary>
        [JsonProperty(PropertyName = "preisBezugswert", Required = Required.Always)]
        [ProtoMember(11)]
        public Mengeneinheit PreisBezugswert { get; set; }

        /// <summary>
        /// <see cref="Rechnungsposition.Einzelpreis"/> and <see cref="Preis.Status"/>
        /// </summary>
        [JsonProperty(PropertyName = "preisStatus", Required = Required.Default)]
        [ProtoMember(12)]
        public Preisstatus? PreisStatus { get; set; }

        /// <summary>
        /// GCN mediated value value
        /// <see cref="Rechnungsposition.PositionsMenge"/> and <see cref="Menge.Wert"/>
        /// </summary>
        [JsonProperty(PropertyName = "positionsMengeWert", Required = Required.Always)]
        [ProtoMember(13)]
        public decimal? PositionsMengeWert { get; set; }


        /// <summary>
        /// GCN mediated value unit
        /// <see cref="Rechnungsposition.PositionsMenge"/> and <see cref="Menge.Einheit"/>
        /// </summary>
        [JsonProperty(PropertyName = "positionsMengeEinheit", Required = Required.Always)]
        [ProtoMember(14)]
        public Mengeneinheit? PositionsMengeEinheit { get; set; }

        /// <inheritdoc cref="Rechnungsposition.VertragsId"/>
        [JsonProperty(PropertyName = "vertragsId", Required = Required.Default)]
        [ProtoMember(15)]
        public string VertragsId { get; set; }

        /// <summary>
        /// status einer Rechnungsposition in SAP Convergent Invoicing
        /// (Ergänzung von Hochfrequenz Unternehmensberatung GmbH)
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Default)]
        [ProtoMember(16)]
        public RechnungspositionsStatus? Status { get; set; }

        /// <summary>
        /// Kind of a copy constructor that moves data from a <see cref="Rechnungsposition"/>
        /// to the flat structure of the RechnungspositionFlat
        /// </summary>
        /// <param name="rp">Rechnungsposition</param>
        public RechnungspositionFlat(Rechnungsposition rp)
        {
            // todo: make this reflection based. this is pita.
            this.Positionsnummer = rp.Positionsnummer;
            this.LieferungVon = rp.LieferungVon;
            this.LieferungBis = rp.LieferungBis;
            this.Positionstext = rp.Positionstext;
            this.LokationsId = rp.LokationsId;
            this.VertragsId = rp.VertragsId;
            this.VertragskontoId = rp.VertragskontoId;
            if (rp.Einzelpreis != null)
            {
                this.PreisWert = rp.Einzelpreis.Wert;
                this.PreisEinheit = rp.Einzelpreis.Einheit;
                this.PreisBezugswert = rp.Einzelpreis.Bezugswert;
                this.PreisStatus = rp.Einzelpreis.Status;
            }
            if (rp.PositionsMenge != null)
            {
                this.PositionsMengeEinheit = rp.PositionsMenge.Einheit;
                this.PositionsMengeWert = rp.PositionsMenge.Wert;
            }
            else
            {
                this.PositionsMengeEinheit = null;
                this.PositionsMengeWert = null;
            }
            this.Guid = rp.Guid;
            this.Status = rp.Status;
        }

        /// <summary>
        /// converts a <see cref="RechnungspositionFlat"/> as returned from SAP OData service into a BO4E <see cref="Rechnungsposition"/>. Basically reverts <seealso cref="RechnungspositionFlat(Rechnungsposition)"/>.
        /// </summary>
        /// <returns>Rechnungsposition</returns>
        public Rechnungsposition ToRechnungsposition()
        {
            // todo: make this reflection based. this is pure pita. in fact the whole process of the flat structure is pita for sap
            Rechnungsposition result = new Rechnungsposition()
            {
                Positionsnummer = Positionsnummer,
                LieferungVon = LieferungVon,
                LieferungBis = LieferungBis,
                Positionstext = Positionstext,
                LokationsId = LokationsId,
                VertragsId = VertragsId,
                VertragskontoId = VertragskontoId,
                Einzelpreis = new Preis()
                {
                    Wert = PreisWert,
                    Einheit = PreisEinheit,
                    Bezugswert = PreisBezugswert,
                    Status = PreisStatus ?? Preisstatus.VORLAEUFIG // poor default choice
                },
                PositionsMenge = new Menge()
                {
                    Einheit = PositionsMengeEinheit ?? Mengeneinheit.KWH, // poor default choice
                    Wert = PositionsMengeWert ?? 0.0M, // poor default choice
                },
                Guid = Guid,
                Status = Status
            };
            return result;
        }

        /// <summary>
        /// empty constructor for serialization
        /// </summary>
        public RechnungspositionFlat() { }
    }
}