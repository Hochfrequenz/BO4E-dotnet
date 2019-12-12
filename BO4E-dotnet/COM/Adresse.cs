using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Enthält eine Adresse, die für die meisten Zwecke verwendbar ist.</summary>
    public class Adresse : COM
    {
        /// <summary>Die Postleitzahl. Beispiel: 41836</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Always)]
        [FieldName("zipCode", Language.EN)]
        public string postleitzahl;
        /// <summary>Bezeichnung der Stadt. Beispiel Hückelhoven</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Always)]
        [FieldName("city", Language.EN)]
        public string ort;
        /// <summary>Bezeichnung der Straße. Beispiel: Weserstraße</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        [FieldName("street", Language.EN)]
        public string strasse;
        /// <summary>Hausnummer inkl. Zusatz. Beispiel. 3, 4a etc.</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        [FieldName("houseNumber", Language.EN)]
        public string hausnummer;
        ///<summary>
        /// Im Falle einer Postfachadresse das Postfach. Damit werden Straße und
        /// Hausnummer nicht berücksichtigt.Beispiel: Postfach 4711
        /// </summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        public string postfach;
        /// <summary>Zusatzhinweis zum Auffinden der Adresse, z.B. "3. Stock linke Wohnung"</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        public string adresszusatz;
        ///<summary> Im Falle einer c/o-Adresse steht in diesem Attribut die Anrede. Z.B. c/o
        /// Veronica Hauptmieterin.In diesem Fall enthält die folgende Adresse die Daten
        ///der in c/o adressierten Person oder Firma.</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        public string coErgaenzung;
        /// <summary>Offizieller ISO-Landescode. Z.B. NL, Details <see cref="Landescode" /></summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        [FieldName("countryCode", Language.EN)]
        public Landescode? landescode;
    }
}
