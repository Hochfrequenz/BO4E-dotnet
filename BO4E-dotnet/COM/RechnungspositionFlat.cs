using System;
using BO4E.ENUM;
using BO4E.meta;
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
        /// <inheritdoc cref="Rechnungsposition.positionsnummer"/>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public int positionsnummer;

        /// <inheritdoc cref="Rechnungsposition.lieferungVon"/>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public DateTime lieferungVon;

        /// <inheritdoc cref="Rechnungsposition.lieferungBis"/>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public DateTime lieferungBis;

        /// <summary>
        /// Der Positionstext entspricht dem SAP CI Teilprozess bzw. der GCN Categoy
        /// <seealso cref="Rechnungsposition.positionstext"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(6)]
        public string positionstext;

        /// <inheritdoc cref="Rechnungsposition.lokationsId"/>>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(7)]
        public string lokationsId;

        /// <inheritdoc cref="Rechnungsposition.vertragskontoId"/>>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(8)]
        public string vertragskontoId;

        /// <summary>
        /// <see cref="Rechnungsposition.einzelpreis"/> and <see cref="Preis.wert"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(9)]
        public decimal preisWert;

        /// <summary>
        /// <see cref="Rechnungsposition.einzelpreis"/> and <see cref="Preis.einheit"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(10)]
        public Waehrungseinheit preisEinheit;

        /// <summary>
        /// <see cref="Rechnungsposition.einzelpreis"/> and <see cref="Preis.bezugswert"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(11)]
        public Mengeneinheit preisBezugswert;

        /// <summary>
        /// <see cref="Rechnungsposition.einzelpreis"/> and <see cref="Preis.status"/>
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(12)]
        public Preisstatus? preisStatus;

        /// <summary>
        /// GCN mediated value value
        /// <see cref="Rechnungsposition.positionsMenge"/> and <see cref="Menge.wert"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(13)]
        public decimal? positionsMengeWert;


        /// <summary>
        /// GCN mediated value unit
        /// <see cref="Rechnungsposition.positionsMenge"/> and <see cref="Menge.einheit"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(14)]
        public Mengeneinheit? positionsMengeEinheit;

        /// <inheritdoc cref="Rechnungsposition.vertragsId"/>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(15)]
        public string vertragsId;

        /// <summary>
        /// status einer Rechnungsposition in SAP Convergent Invoicing
        /// (Ergänzung von Hochfrequenz Unternehmensberatung GmbH)
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(16)]
        public RechnungspositionsStatus? status;

        /// <summary>
        /// Kind of a copy constructor that moves data from a <see cref="Rechnungsposition"/>
        /// to the flat structure of the RechnungspositionFlat
        /// </summary>
        /// <param name="rp">Rechnungsposition</param>
        public RechnungspositionFlat(Rechnungsposition rp)
        {
            // todo: make this reflection based. this is pita.
            this.positionsnummer = rp.positionsnummer;
            this.lieferungVon = rp.lieferungVon;
            this.lieferungBis = rp.lieferungBis;
            this.positionstext = rp.positionstext;
            this.lokationsId = rp.lokationsId;
            this.vertragsId = rp.vertragsId;
            this.vertragskontoId = rp.vertragskontoId;
            if (rp.einzelpreis != null)
            {
                this.preisWert = rp.einzelpreis.wert;
                this.preisEinheit = rp.einzelpreis.einheit;
                this.preisBezugswert = rp.einzelpreis.bezugswert;
                this.preisStatus = rp.einzelpreis.status;
            }
            if (rp.positionsMenge != null)
            {
                this.positionsMengeEinheit = rp.positionsMenge.einheit;
                this.positionsMengeWert = rp.positionsMenge.wert;
            }
            else
            {
                this.positionsMengeEinheit = null;
                this.positionsMengeWert = null;
            }
            this.guid = rp.guid;
            this.status = rp.status;
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
                positionsnummer = positionsnummer,
                lieferungVon = lieferungVon,
                lieferungBis = lieferungBis,
                positionstext = positionstext,
                lokationsId = lokationsId,
                vertragsId = vertragsId,
                vertragskontoId = vertragskontoId,
                einzelpreis = new Preis()
                {
                    wert = preisWert,
                    einheit = preisEinheit,
                    bezugswert = preisBezugswert,
                    status = preisStatus ?? Preisstatus.VORLAEUFIG // poor default choice
                },
                positionsMenge = new Menge()
                {
                    einheit = positionsMengeEinheit ?? Mengeneinheit.KWH, // poor default choice
                    wert = positionsMengeWert ?? 0.0M, // poor default choice
                },
                guid = guid,
                status = status
            };
            return result;
        }

        /// <summary>
        /// empty constructor for serialization
        /// </summary>
        public RechnungspositionFlat() { }
    }
}