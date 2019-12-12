using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Preisposition</summary>
    public class Preisposition : COM
    {
        /// <summary>Das Modell, das der Preisbildung zugrunde liegt. Details <see cref="Kalkulationsmethode" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Kalkulationsmethode berechnungsmethode;
        /// <summary>Standardisierte Bezeichnung für die abgerechnete Leistungserbringung. Details <see cref="Leistungstyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Leistungstyp leistungstyp;
        /// <summary>Bezeichnung für die in der Position abgebildete Leistungserbringung</summary>
        [JsonProperty(Required = Required.Always)]
        public string leistungsbezeichung;
        /// <summary>Festlegung, mit welcher Preiseinheit abgerechnet wird, z.B. Ct. oder €. Details <see cref="Waehrungseinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Waehrungseinheit preiseinheit;
        /// <summary>Hier wird festgelegt, auf welche Bezugsgröße sich der Preis bezieht, z.B. kWh oder Stück. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Mengeneinheit bezugsgroesse;
        /// <summary>Die Zeit(dauer) auf die sich der Preis bezieht. Z.B. ein Jahr für einen Leistungspreis der in €/kW/Jahr ausgegeben wird.</summary>
        [JsonProperty(Required = Required.Default)]
        public Zeiteinheit? zeitbasis;
        /// <summary>Festlegung, für welche Tarifzeit der Preis hier festgelegt ist. <seealso cref="Tarifzeit" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Tarifzeit? tarifzeit;
        /// <summary>Eine vom BDEW standardisierte Bezeichnung für die abgerechnete Leistungserbringung. Diese Artikelnummer wird auch im Rechnungsteil der INVOIC verwendet. <seealso cref="BDEWArtikelnummer" /></summary>
        [JsonProperty(Required = Required.Default)]
        public BDEWArtikelnummer? bdewArtikelnummer;
        /// <summary>Mit der Menge der hier angegebenen Größe wird die Staffelung/Zonung durchgeführt. Z.B. Vollbenutzungsstunden. <seealso cref="Bemessungsgroesse" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Bemessungsgroesse? zonungsgroesse;
        /// <summary>Zuschläge oder Abschläge auf die Position. <seealso cref="PositionsAufAbschlag" /></summary>
        [JsonProperty(Required = Required.Default)]
        public PositionsAufAbschlag zu_abschlaege;
        /// <summary>Preisstaffeln, die zu dieser Preisposition gehören. Details <see cref="Preisstaffel" /></summary>
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        public List<Preisstaffel> preisstaffeln;
    }
}