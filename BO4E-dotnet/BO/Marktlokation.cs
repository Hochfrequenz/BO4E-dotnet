using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO
{

    // The key order is actually relevant for the online validation. WTF!
    // https://github.com/Hochfrequenz/energy-service-hub/issues/11
    //@JsonPropertyOrder({ "versionStruktur", "boTyp", "marktlokationsId", "sparte", "energierichtung",
    //        "bilanzierungsmethode", "verbrauchsart", "unterbrechbar", "netzebene", "netzbetreiberCodeNr", "gebietTyp",
    //        "netzgebietNr", "bilanzierungsgebiet", "grundversorgerCodeNr", "gasqualitaet", "endkunde", "lokationsadresse",
    //        "geoadresse", "katasterinformation", "zugehoerigeMesslokationen" })
    /// <summary>
    /// Objekt zur Aufnahme der Informationen zu einer Marktlokation
    /// </summary>
    public class Marktlokation : BusinessObject
    {
        /// <summary>
        /// Identifikationsnummer einer Marktlokation, an der Energie entweder
        /// verbraucht, oder erzeugt wird
        /// </summary>
        [DefaultValue("|null|")]
        [JsonProperty(Required = Required.Always, Order = -1)]
        [DataCategory(DataCategory.POD)]
        [BoKey]
        public string marktlokationsId;
        /// <summary>Sparte der Messlokation, z.B. Gas oder Strom.</summary>
        [JsonProperty(Required = Required.Always, Order = 0)]
        public Sparte sparte;

        /// <summary>Kennzeichnung, ob Energie eingespeist oder entnommen (ausgespeist) wird.</summary>
        [JsonProperty(Required = Required.Always, Order = 1)]
        public Energierichtung energierichtung;

        /// <summary>Kennzeichnung, ob Energie eingespeist oder entnommen (ausgespeist) wird.</summary>
        [JsonProperty(Required = Required.Always, Order = 2)]
        public Bilanzierungsmethode bilanzierungsmethode;

        /// <summary>Verbrauchsart der Marktlokation</summary>
        [JsonProperty(Required = Required.Default, Order = 3)]
        public Verbrauchsart? verbrauchsart;

        /// <summary>Gibt an, ob es sich um eine unterbrechbare Belieferung handelt.</summary>
        [JsonProperty(Required = Required.Default, Order = 4)]
        public Boolean unterbrechbar;

        ///<summary>
        /// Netzebene, in der der Bezug der Energie erfolgt. Bei Strom Spannungsebene der
        /// Lieferung, bei Gas Druckstufe. Beispiel Strom: Niederspannung Beispiel Gas:
        /// Niederdruck.
        /// <seealso cref="Netzebene" /></summary> 
        [JsonProperty(Required = Required.Always, Order = 5)]
        public Netzebene netzebene;

        /// <summary>
        /// Codenummer des Netzbetreibers, an dessen Netz diese Marktlokation
        /// angeschlossen ist.
        /// </summary>
        [JsonProperty(PropertyName = "netzbetreiberCodeNr", Required = Required.Default, Order = 6)]
        public string netzbetreibercodenr;

        /// <summary>Typ des Netzgebietes,z.B.Verteilnetz.</summary>
        /// https://github.com/Hochfrequenz/energy-service-hub/issues/11
        [JsonProperty(PropertyName = "gebietTyp", Order = 7, Required = Required.Default)]
        public Gebiettyp? gebiettyp;

        /// <summary>Die Nummer des Netzgebietes in der ene't-Datenbank.</summary>
        [JsonProperty(PropertyName = "netzgebietNr", Order = 8, Required = Required.Default)]
        public string netzgebietnr;

        /// <summary>Bilanzierungsgebiet, dem das Netzgebiet zugeordnet ist - im Falle eines Strom Netzes.</summary>
        [JsonProperty(Required = Required.Default, Order = 9)]
        public string bilanzierungsgebiet;

        /// <summary>CodeNummer des Grundversorgers, der für diese Marktlokation zuständig ist.</summary>
        [JsonProperty(PropertyName = "grundversorgerCodeNr", Order = 10, Required = Required.Default)]
        public string grundversorgercodenr;

        ///<summary>Die Gasqualität in diesem Netzgebiet. H-Gas oder L-Gas. Im Falle eines Gas-Netzes.<seealso cref="Gasqualitaet" /></summary> */
        [JsonProperty(Required = Required.Default, Order = 11)]
        public Gasqualitaet? gasqualitaet;

        /// <summary>Link zum Geschäftspartner, dem diese Marktlokation gehört.</summary>
        [JsonProperty(Required = Required.Default, Order = 12)]
        public Geschaeftspartner endkunde;

        /// <summary>Die Adresse, an der die Energie-Lieferung oder -Einspeisung erfolgt. <seealso cref="Adresse" /></summary> */
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default, Order = 13)]
        public Adresse lokationsadresse;

        /// <summary>Alternativ zu einer postalischen Adresse kann hier ein Ort mittels Geokoordinaten angegeben werden (z.B. zur Identifikation von Sendemasten).<seealso cref="Geokoordinaten" /></summary> */
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default, Order = 14)]
        public Geokoordinaten geoadresse;

        /// <summary>Alternativ zu einer postalischen Adresse und Geokoordinaten kann hier eine  Ortsangabe mittels Gemarkung und Flurstück erfolgen. <seealso cref="Katasteradresse" /></summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default, Order = 15)]
        public Katasteradresse katasterinformation;

        [JsonProperty(Required = Required.Default, Order = 16)]
        public List<Marktrolle> marktrollen;

        [JsonProperty(Required = Required.Default, Order = 17)]
        public string regelzone; 

        [JsonProperty(Required = Required.Default, Order = 18)]
        public string marktgebiet;

        [JsonProperty(Required = Required.Default, Order = 19)]
        public Zeiteinheit zeitreihentyp;

        [JsonProperty(Required = Required.Default, Order = 20)]
        public List<Zaehlwerk> zaehlwerke;


        /// <summary>Aufzählung der Messlokationen, die zu dieser Marktlokation gehören.</summary>
        /// Es können 3 verschiedene Konstrukte auftreten:
        /// <ol>
        /// <li>Beziehung 1 : 0 : Hier handelt es sich um Pauschalanlagen ohne Messung.
        /// D.h. die Verbrauchsdaten sind direkt über die Marktlokation abgreifbar.</li>
        /// <li>Beziehung 1 : 1 : Das ist die Standard-Beziehung für die meisten Fälle.
        /// In diesem Fall gibt es zu einer Marktlokation genau eine Messlokation.</li>
        /// <li>Beziehung 1 : N : Hier liegt beispielsweise eine Untermessung vor. Der
        /// Verbrauch einer Marklokation berechnet sich hier aus mehreren Messungen.</li>
        /// </ol>
        ///
        /// Es gibt praktisch auch noch die Beziehung N : 1, beispielsweise bei einer
        /// Zweirichtungsmessung bei der durch eine Messeinrichtung die Messung sowohl
        /// für die Einspreiseseite als auch für die Aussspeiseseite erfolgt. Da
        /// Abrechnung und Bilanzierung jedoch für beide Marktlokationen getrennt
        /// erfolgt, werden nie beide Marktlokationen gemeinsam betrachtet. Daher lässt
        /// sich dieses Konstrukt auf zwei 1:1-Beziehung zurückführen, wobei die
        /// Messlokation in beiden Fällen die gleiche ist.
        ///
        /// In den Zuordnungen sind ist die arithmetische Operation mit der der Verbrauch
        /// einer Messlokation zum Verbrauch einer Marktlokation beitrögt mit aufgeführt.
        /// Der Standard ist hier die Addition.
        [DataCategory(DataCategory.POD)]
        [JsonProperty(Required = Required.Default, Order = 16)]
        public List<Messlokationszuordnung> zugehoerigeMesslokationen;


        /// <summary>
        /// Regular Expression used to validate 11 digit MarktlokationId
        /// </summary>
        [JsonIgnore]
        protected static readonly Regex REGEX_VALIDATE = new Regex(@"^[1-9][\d]{10}$", RegexOptions.Compiled);
        /// <summary>
        /// Regular Expression to check if a string consists only of numbers (is numeric)
        /// </summary>
        [JsonIgnore]
        protected static readonly Regex REGEX_NUMERIC_STRING = new Regex(@"^\d+$", RegexOptions.Compiled);

        /// <summary>
        /// Test if a <paramref name="id"/> is a valid Marktlokations ID.
        /// </summary>
        /// <param name="id">id to test</param>
        /// <returns></returns>
        public static bool ValidateId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }
            if (!REGEX_VALIDATE.IsMatch(id))
            {
                return false;
            }
            string expectedChecksum = GetChecksum(id);
            string actualChecksum = id.Substring(10, 1);
            return actualChecksum == expectedChecksum;
        }

        /// <summary>
        /// Get the checksum of a marklokationsId:
        /// a) Quersumme aller Ziffern in ungerader Position
        /// b) Quersumme aller Ziffern
        /// auf gerader Position multipliziert mit 2 c) Summe von a) und b) d) Differenz
        /// von c) zum nächsten Vielfachen von 10 (ergibt sich hier 10, wird die
        /// Prüfziffer 0 genommen)
        /// https://bdew-codes.de/Content/Files/MaLo/2017-04-28-BDEW-Anwendungshilfe-MaLo-ID_Version1.0_FINAL.PDF
        /// </summary>
        /// <returns>expected checksum</returns>
        public static string GetChecksum(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"Input '{nameof(input)}' must not be empty but was '{input}'");
            }
            if (input.Length < 10 || input.Length > 11)
            {
                throw new ArgumentException($"Input '{nameof(input)}' must be a string with length 10 (to generate the checksum) or 11 (to validate the checksum).");
            }
            if (!REGEX_NUMERIC_STRING.IsMatch(input))
            {
                throw new ArgumentException($"Input '{nameof(input)}' must be numeric was '{input}'");
            }
            int oddChecksum = 0;
            int evenChecksum = 0;

            // start counting at 1 to be consistent with the above description of "even" and  "odd" but stop at tenth digit.
            for (int i = 1; i < 11; i++)
            {
                string s = input.Substring(i - 1, 1);
                if (i % 2 == 0)
                {
                    evenChecksum += 2 * Int32.Parse(s);
                }
                else
                {
                    oddChecksum += Int32.Parse(s);
                }
            }
            int result = (10 - ((evenChecksum + oddChecksum) % 10)) % 10;
            return result.ToString();
        }

        /// <summary>
        /// Test if the <see cref="marktlokationsId"/> is valid.
        /// </summary>
        /// <returns>if marktlokaionsId matches the expected format</returns>
        public bool HasValidId()
        {
            return ValidateId(this.marktlokationsId);
        }

        /// <summary>
        /// same as <see cref="BusinessObject.IsValid()" /> if <paramref name="checkId"/> is false but by default additionally checks if the <see cref="marktlokationsId"/> is valid using <see cref="HasValidId"/>.
        /// </summary>
        /// <param name="checkId">validate the <see cref="marktlokationsId"/>, too</param>
        /// <returns>true if the marktlokation is valid</returns>
        public bool IsValid(bool checkId = true)
        {
            return base.IsValid() && (!checkId || HasValidId());
        }
    }
}