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
        [JsonProperty(PropertyName = "berechnungsmethode", Order = 10, Required = Required.Always)]
        [JsonPropertyName("berechnungsmethode")]
        [ProtoMember(3)]
        [JsonPropertyOrder(10)]
        public Kalkulationsmethode Berechnungsmethode { get; set; }

        /// <summary>
        ///     Standardisierte Bezeichnung für die abgerechnete Leistungserbringung. Details <see cref="ENUM.Leistungstyp" />
        /// </summary>
        [JsonProperty(PropertyName = "leistungstyp", Order = 11, Required = Required.Always)]
        [JsonPropertyName("leistungstyp")]
        [ProtoMember(4)]
        [JsonPropertyOrder(11)]
        public Leistungstyp Leistungstyp { get; set; }

        /// <summary>Bezeichnung für die in der Position abgebildete Leistungserbringung</summary>
        [JsonProperty(PropertyName = "leistungsbezeichnung", Order = 12, Required = Required.Always)]
        [JsonPropertyName("leistungsbezeichnung")]
        [ProtoMember(5)]
        [JsonPropertyOrder(12)]
        public string Leistungsbezeichnung { get; set; }

        /// <summary>
        ///     Festlegung, mit welcher Preiseinheit abgerechnet wird, z.B. Ct. oder €. Details
        ///     <see cref="Waehrungseinheit" />
        /// </summary>
        [JsonProperty(PropertyName = "preiseinheit", Order = 13, Required = Required.Always)]
        [JsonPropertyName("preiseinheit")]
        [ProtoMember(6)]
        [JsonPropertyOrder(13)]
        public Waehrungseinheit Preiseinheit { get; set; }

        /// <summary>
        ///     Hier wird festgelegt, auf welche Bezugsgröße sich der Preis bezieht, z.B. kWh oder Stück. Details
        ///     <see cref="Mengeneinheit" />
        /// </summary>
        [JsonProperty(PropertyName = "bezugsgroesse", Order = 14, Required = Required.Default)]
        [JsonPropertyName("bezugsgroesse")]
        [ProtoMember(7)]
        [JsonPropertyOrder(14)]
        public Mengeneinheit? Bezugsgroesse { get; set; }

        /// <summary>
        ///     Die Zeit(dauer) auf die sich der Preis bezieht. Z.B. ein Jahr für einen Leistungspreis der in €/kW/Jahr
        ///     ausgegeben wird.
        /// </summary>
        [JsonProperty(PropertyName = "zeitbasis", Order = 15, Required = Required.Default)]
        [JsonPropertyName("zeitbasis")]
        [ProtoMember(8)]
        [JsonPropertyOrder(15)]
        public Zeiteinheit? Zeitbasis { get; set; }

        /// <summary>Festlegung, für welche Tarifzeit der Preis hier festgelegt ist. <seealso cref="ENUM.Tarifzeit" /></summary>
        [JsonProperty(PropertyName = "tarifzeit", Order = 16, Required = Required.Default)]
        [JsonPropertyName("tarifzeit")]
        [ProtoMember(9)]
        [JsonPropertyOrder(16)]
        public Tarifzeit? Tarifzeit { get; set; }

        /// <summary>
        ///     Eine vom BDEW standardisierte Bezeichnung für die abgerechnete Leistungserbringung. Diese Artikelnummer wird
        ///     auch im Rechnungsteil der INVOIC verwendet. <seealso cref="BDEWArtikelnummer" />
        /// </summary>
        [JsonProperty(PropertyName = "bdewArtikelnummer", Order = 17, Required = Required.Default)]
        [JsonPropertyName("bdewArtikelnummer")]
        [ProtoMember(10)]
        [JsonPropertyOrder(17)]
        public BDEWArtikelnummer? BdewArtikelnummer { get; set; }

        /// <summary>
        ///     Mit der Menge der hier angegebenen Größe wird die Staffelung/Zonung durchgeführt. Z.B. Vollbenutzungsstunden.
        ///     <seealso cref="Bemessungsgroesse" />
        /// </summary>
        [JsonProperty(PropertyName = "zonungsgroesse", Order = 18, Required = Required.Default)]
        [JsonPropertyName("zonungsgroesse")]
        [ProtoMember(11)]
        [JsonPropertyOrder(18)]
        public Bemessungsgroesse? Zonungsgroesse { get; set; }

        /// <summary>Zuschläge oder Abschläge auf die Position. <seealso cref="PositionsAufAbschlag" /></summary>
        [JsonProperty(PropertyName = "zu_abschlaege", Order = 19, Required = Required.Default)]
        [JsonPropertyName("zu_abschlaege")]
        [ProtoMember(12)]
        [JsonPropertyOrder(19)]
        public PositionsAufAbschlag? ZuAbschlaege { get; set; }

        /// <summary>Preisstaffeln, die zu dieser Preisposition gehören. Details <see cref="Preisstaffel" /></summary>
        [JsonProperty(PropertyName = "preisstaffeln", Order = 20, Required = Required.Always)]
        [JsonPropertyName("preisstaffeln")]
        [ProtoMember(13)]
        [JsonPropertyOrder(20)]
        public List<Preisstaffel> Preisstaffeln { get; set; }

        /// <summary>Preisschlüsselstamm></summary>
        [JsonProperty(PropertyName = "preisschluesselstamm", Order = 21, Required = Required.Default)]
        [JsonPropertyName("preisschluesselstamm")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(14)]
        [JsonPropertyOrder(21)]
        public string? Preisschluesselstamm { get; set; }

        /// <summary>Fortlaufende Nummer für die Preisposition</summary>
        [JsonProperty(PropertyName = "positionsnummer", Required = Required.Default, Order = 22)]
        [JsonPropertyName("positionsnummer")]
        [JsonPropertyOrder(22)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(15)]
        public int? Positionsnummer { get; set; }

        /// <summary>Vgl. PRICAT IMD 7009</summary>
        [JsonProperty(Required = Required.Default, Order = 23, PropertyName = "messebene")]
        [JsonPropertyName("messebene")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(16)]
        [JsonPropertyOrder(23)]
        public Netzebene? Messebene { get; set; }

        /// <summary>
        ///     Produkt-/Leistungsbeschreibung, wenn IMD+X vorhanden Vgl. PRICAT IMD 7008
        /// </summary>
        [JsonProperty(PropertyName = "beschreibung", Required = Required.Default, Order = 24)]
        [JsonPropertyName("beschreibung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(17)]
        [JsonPropertyOrder(24)]
        public string? Beschreibung { get; set; }

        /// <summary>
        /// Verarbeitungszeitraum. Details <see cref="Zeitraum" />
        /// </summary>
        [JsonProperty(PropertyName = "Verarbeitungszeitraum", Required = Required.Default, Order = 25)]
        [JsonPropertyName("Verarbeitungszeitraum")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(18)]
        [JsonPropertyOrder(25)]
        public Zeitraum? Verarbeitungszeitraum { get; set; }

        /// <summary>
        ///  Die genauen Bedeutungen der einzelnen Artikel-IDs sind in der EDI@Energy Codeliste der Artikelnummern 
        /// und Artikel-IDs zu finden, die in der Spalte "PRICAT Codeverwendung" ein X haben
        /// </summary>
        [JsonProperty(PropertyName = "ArtikelID", Order = 26, Required = Required.Default)]
        [JsonPropertyName("ArtikelID")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [JsonPropertyOrder(26)]
        public string? ArtikelID { get; set; }
    }
}
