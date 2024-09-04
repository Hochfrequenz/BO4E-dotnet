using System;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Diese Klasse ist der <see cref="Rechnungsposition" /> nachempfunden und dieser ähnlich.
///     Jedoch enthält sie weniger Daten und v.a. in einem flachen Format, das mit den beschränkten SAP
///     Bordmitteln leichter als Entitätstyp für die Verarbeitung in einer OData-Schnittstelle abgebildet werden kann.
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
public class RechnungspositionFlat : COM
{
    /// <summary>
    ///     Kind of a copy constructor that moves data from a <see cref="Rechnungsposition" />
    ///     to the flat structure of the RechnungspositionFlat
    /// </summary>
    /// <param name="rp">Rechnungsposition</param>
    public RechnungspositionFlat(Rechnungsposition rp)
    {
        // todo: make this reflection based. this is pita.
        Positionsnummer = rp.Positionsnummer;
        LieferungVon = rp.LieferungVon;
        LieferungBis = rp.LieferungBis;
        Positionstext = rp.Positionstext;
        LokationsId = rp.LokationsId;
        VertragsId = rp.VertragsId;
#pragma warning disable CS0618 // Type or member is obsolete
        VertragskontoId = rp.VertragskontoId;
#pragma warning restore CS0618 // Type or member is obsolete
        if (rp.Einzelpreis != null)
        {
            PreisWert = rp.Einzelpreis.Wert;
            PreisEinheit = rp.Einzelpreis.Einheit;
            PreisBezugswert = rp.Einzelpreis.Bezugswert;
            PreisStatus = rp.Einzelpreis.Status;
        }

        if (rp.PositionsMenge != null)
        {
            PositionsMengeEinheit = rp.PositionsMenge.Einheit;
            PositionsMengeWert = rp.PositionsMenge.Wert;
        }
        else
        {
            PositionsMengeEinheit = null;
            PositionsMengeWert = null;
        }

        Guid = rp.Guid;
        Status = rp.Status;
    }

    /// <summary>
    ///     empty constructor for serialization
    /// </summary>
    public RechnungspositionFlat()
    {
    }

    /// <inheritdoc cref="Rechnungsposition.Positionsnummer" />
    [JsonProperty(PropertyName = "positionsnummer", Required = Required.Always)]
    [JsonPropertyName("positionsnummer")]
    [ProtoMember(3)]
    public int Positionsnummer { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(4, Name = nameof(LieferungVon))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _LieferungVon
    {
        get => LieferungVon?.UtcDateTime ?? DateTime.MinValue;
        set => LieferungVon = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    /// <inheritdoc cref="Rechnungsposition.LieferungVon" />
    [JsonProperty(PropertyName = "lieferungVon", Required = Required.Default)]
    [JsonPropertyName("lieferungVon")]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? LieferungVon { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(5, Name = nameof(LieferungBis))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _LieferungBis
    {
        get => LieferungBis?.UtcDateTime ?? DateTime.MinValue;
        set => LieferungBis = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    /// <inheritdoc cref="Rechnungsposition.LieferungBis" />
    [JsonProperty(PropertyName = "lieferungBis", Required = Required.Default)]
    [JsonPropertyName("lieferungBis")]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? LieferungBis { get; set; }

    /// <summary>
    ///     Der Positionstext entspricht dem SAP CI Teilprozess bzw. der GCN Categoy
    ///     <seealso cref="Rechnungsposition.Positionstext" />
    /// </summary>
    [JsonProperty(PropertyName = "positionstext", Required = Required.Always)]
    [JsonPropertyName("positionstext")]
    [ProtoMember(6)]
    public string Positionstext { get; set; }

    /// <inheritdoc cref="Rechnungsposition.LokationsId" />
    /// >
    [JsonProperty(PropertyName = "lokationsId", Required = Required.Always)]
    [JsonPropertyName("lokationsId")]
    [ProtoMember(7)]
    public string LokationsId { get; set; }

    /// <inheritdoc cref="Rechnungsposition.VertragskontoId" />
    /// >
    [JsonProperty(PropertyName = "vertragskontoId", Required = Required.Always)]
    [JsonPropertyName("vertragskontoId")]
    [ProtoMember(8)]
    public string VertragskontoId { get; set; }

    /// <summary>
    ///     <see cref="Rechnungsposition.Einzelpreis" /> and <see cref="Preis.Wert" />
    /// </summary>
    [JsonProperty(PropertyName = "preisWert", Required = Required.Always)]
    [JsonPropertyName("preisWert")]
    [ProtoMember(9)]
    public decimal? PreisWert { get; set; }

    /// <summary>
    ///     <see cref="Rechnungsposition.Einzelpreis" /> and <see cref="Preis.Einheit" />
    /// </summary>
    [JsonProperty(PropertyName = "preisEinheit", Required = Required.Always)]
    [JsonPropertyName("preisEinheit")]
    [ProtoMember(10)]
    public Waehrungseinheit? PreisEinheit { get; set; }

    /// <summary>
    ///     <see cref="Rechnungsposition.Einzelpreis" /> and <see cref="Preis.Bezugswert" />
    /// </summary>
    [JsonProperty(PropertyName = "preisBezugswert", Required = Required.Always)]
    [JsonPropertyName("preisBezugswert")]
    [ProtoMember(11)]
    public Mengeneinheit? PreisBezugswert { get; set; }

    /// <summary>
    ///     <see cref="Rechnungsposition.Einzelpreis" /> and <see cref="Preis.Status" />
    /// </summary>
    [JsonProperty(PropertyName = "preisStatus", Required = Required.Default)]
    [JsonPropertyName("preisStatus")]
    [ProtoMember(12)]
    public Preisstatus? PreisStatus { get; set; }

    /// <summary>
    ///     GCN mediated value value
    ///     <see cref="Rechnungsposition.PositionsMenge" /> and <see cref="Menge.Wert" />
    /// </summary>
    [JsonProperty(PropertyName = "positionsMengeWert", Required = Required.Always)]
    [JsonPropertyName("positionsMengeWert")]
    [ProtoMember(13)]
    public decimal? PositionsMengeWert { get; set; }

    /// <summary>
    ///     GCN mediated value unit
    ///     <see cref="Rechnungsposition.PositionsMenge" /> and <see cref="Menge.Einheit" />
    /// </summary>
    [JsonProperty(PropertyName = "positionsMengeEinheit", Required = Required.Always)]
    [JsonPropertyName("positionsMengeEinheit")]
    [ProtoMember(14)]
    public Mengeneinheit? PositionsMengeEinheit { get; set; }

    /// <inheritdoc cref="Rechnungsposition.VertragsId" />
    [JsonProperty(PropertyName = "vertragsId", Required = Required.Default)]
    [JsonPropertyName("vertragsId")]
    [ProtoMember(15)]
    public string? VertragsId { get; set; }

    /// <summary>
    ///     status einer Rechnungsposition in SAP Convergent Invoicing
    ///     (Ergänzung von Hochfrequenz Unternehmensberatung GmbH)
    /// </summary>
    [JsonProperty(PropertyName = "status", Required = Required.Default)]
    [JsonPropertyName("status")]
    [ProtoMember(16)]
    public RechnungspositionsStatus? Status { get; set; }

    /// <summary>
    ///     converts a <see cref="RechnungspositionFlat" /> as returned from SAP OData service into a BO4E
    ///     <see cref="Rechnungsposition" />. Basically reverts <seealso cref="RechnungspositionFlat(Rechnungsposition)" />.
    /// </summary>
    /// <returns>Rechnungsposition</returns>
    public Rechnungsposition ToRechnungsposition()
    {
        // todo: make this reflection based. this is pure pita. in fact the whole process of the flat structure is pita for sap
        var result = new Rechnungsposition
        {
            Positionsnummer = Positionsnummer,
            LieferungVon = LieferungVon,
            LieferungBis = LieferungBis,
            Positionstext = Positionstext,
            LokationsId = LokationsId,
            VertragsId = VertragsId,
#pragma warning disable CS0618 // Type or member is obsolete
            VertragskontoId = VertragskontoId,
#pragma warning restore CS0618 // Type or member is obsolete
            Einzelpreis = new Preis
            {
                Wert = PreisWert,
                Einheit = PreisEinheit,
                Bezugswert = PreisBezugswert,
                Status = PreisStatus ?? Preisstatus.VORLAEUFIG // poor default choice
            },
            PositionsMenge = new Menge
            {
                Einheit = PositionsMengeEinheit ?? Mengeneinheit.KWH, // poor default choice
                Wert = PositionsMengeWert ?? 0.0M // poor default choice
            },
            Guid = Guid,
            Status = Status
        };
        return result;
    }
}