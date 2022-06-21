using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Preisposition</summary>
    [ProtoContract]
    public class Preisposition : COM
    {
        /// <summary>Das Modell, das der Preisbildung zugrunde liegt. Details <see cref="Kalkulationsmethode" /></summary>
        [JsonProperty(PropertyName = "berechnungsmethode", Required = Required.Always)]
        [JsonPropertyName("berechnungsmethode")]
        [ProtoMember(3)]
        public Kalkulationsmethode Berechnungsmethode { get; set; }

        /// <summary>
        ///     Standardisierte Bezeichnung für die abgerechnete Leistungserbringung. Details <see cref="ENUM.Leistungstyp" />
        /// </summary>
        [JsonProperty(PropertyName = "leistungstyp", Required = Required.Always)]
        [JsonPropertyName("leistungstyp")]
        [ProtoMember(4)]
        public Leistungstyp Leistungstyp { get; set; }

        /// <summary>Bezeichnung für die in der Position abgebildete Leistungserbringung</summary>
        [JsonProperty(PropertyName = "leistungsbezeichnung", Required = Required.Always)]
        [JsonPropertyName("leistungsbezeichnung")]
        [ProtoMember(5)]
        public string Leistungsbezeichnung { get; set; }

        /// <summary>
        ///     Festlegung, mit welcher Preiseinheit abgerechnet wird, z.B. Ct. oder €. Details
        ///     <see cref="Waehrungseinheit" />
        /// </summary>
        [JsonProperty(PropertyName = "preiseinheit", Required = Required.Always)]
        [JsonPropertyName("preiseinheit")]
        [ProtoMember(6)]
        public Waehrungseinheit Preiseinheit { get; set; }

        /// <summary>
        ///     Hier wird festgelegt, auf welche Bezugsgröße sich der Preis bezieht, z.B. kWh oder Stück. Details
        ///     <see cref="Mengeneinheit" />
        /// </summary>
        [JsonProperty(PropertyName = "bezugsgroesse", Required = Required.Always)]
        [JsonPropertyName("bezugsgroesse")]
        [ProtoMember(7)]
        public Mengeneinheit Bezugsgroesse { get; set; }

        /// <summary>
        ///     Die Zeit(dauer) auf die sich der Preis bezieht. Z.B. ein Jahr für einen Leistungspreis der in €/kW/Jahr
        ///     ausgegeben wird.
        /// </summary>
        [JsonProperty(PropertyName = "zeitbasis", Required = Required.Default)]
        [JsonPropertyName("zeitbasis")]
        [ProtoMember(8)]
        public Zeiteinheit? Zeitbasis { get; set; }

        /// <summary>Festlegung, für welche Tarifzeit der Preis hier festgelegt ist. <seealso cref="ENUM.Tarifzeit" /></summary>
        [JsonProperty(PropertyName = "tarifzeit", Required = Required.Default)]
        [JsonPropertyName("tarifzeit")]
        [ProtoMember(9)]
        public Tarifzeit? Tarifzeit { get; set; }

        /// <summary>
        ///     Eine vom BDEW standardisierte Bezeichnung für die abgerechnete Leistungserbringung. Diese Artikelnummer wird
        ///     auch im Rechnungsteil der INVOIC verwendet. <seealso cref="BDEWArtikelnummer" />
        /// </summary>
        [JsonProperty(PropertyName = "bdewArtikelnummer", Required = Required.Default)]
        [JsonPropertyName("bdewArtikelnummer")]
        [ProtoMember(10)]
        public BDEWArtikelnummer? BdewArtikelnummer { get; set; }

        /// <summary>
        ///     Mit der Menge der hier angegebenen Größe wird die Staffelung/Zonung durchgeführt. Z.B. Vollbenutzungsstunden.
        ///     <seealso cref="Bemessungsgroesse" />
        /// </summary>
        [JsonProperty(PropertyName = "zonungsgroesse", Required = Required.Default)]
        [JsonPropertyName("zonungsgroesse")]
        [ProtoMember(11)]
        public Bemessungsgroesse? Zonungsgroesse { get; set; }

        /// <summary>Zuschläge oder Abschläge auf die Position. <seealso cref="PositionsAufAbschlag" /></summary>
        [JsonProperty(PropertyName = "zu_abschlaege", Required = Required.Default)]
        [JsonPropertyName("zu_abschlaege")]
        [ProtoMember(12)]
        public PositionsAufAbschlag? ZuAbschlaege { get; set; }

        /// <summary>Preisstaffeln, die zu dieser Preisposition gehören. Details <see cref="Preisstaffel" /></summary>
        [JsonProperty(PropertyName = "preisstaffeln", Required = Required.Always)]
        [JsonPropertyName("preisstaffeln")]
        [ProtoMember(13)]
        public List<Preisstaffel> Preisstaffeln { get; set; }

        /// <summary>Preisschlüsselstamm></summary>
        [JsonProperty(PropertyName = "preisschluesselstamm", Required = Required.Default)]
        [JsonPropertyName("preisschluesselstamm")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(14)]
        public string? Preisschluesselstamm { get; set; }

        /// <summary>Fortlaufende Nummer für die Preisposition</summary>
        [JsonProperty(PropertyName = "positionsnummer", Required = Required.Default, Order = 15)]
        [JsonPropertyName("positionsnummer")]
        [JsonPropertyOrder(15)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(15)]
        public int? Positionsnummer { get; set; }

        /// <summary>Vgl. PRICAT IMD 7009</summary>
        [JsonProperty(Required = Required.Default, Order = 16, PropertyName = "spannungsebene")]
        [JsonPropertyName("spannungsebene")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(16)]
        public Spannungsebene? Spannungsebene { get; set; }

        /// <summary>
        ///     Produkt-/Leistungsbeschreibung, wenn IMD+X vorhanden Vgl. PRICAT IMD 7008
        /// </summary>
        [JsonProperty(PropertyName = "beschreibung", Required = Required.Default, Order = 17)]
        [JsonPropertyName("beschreibung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(17)]
        public string? Beschreibung { get; set; }
    }
}