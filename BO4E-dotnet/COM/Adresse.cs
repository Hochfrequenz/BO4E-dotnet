using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Enthält eine Adresse, die für die meisten Zwecke verwendbar ist.</summary>
    [ProtoContract]
    public class Adresse : COM
    {
        /// <summary>Die Postleitzahl. Beispiel: 41836</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Always)]
        [FieldName("zipCode", Language.EN)]
        [ProtoMember(3)]
        public string postleitzahl;
        /// <summary>Bezeichnung der Stadt. Beispiel Hückelhoven</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Always)]
        [FieldName("city", Language.EN)]
        [ProtoMember(4)]
        public string ort;
        /// <summary>Bezeichnung der Straße. Beispiel: Weserstraße</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        [FieldName("street", Language.EN)]
        [ProtoMember(5)]
        public string strasse;
        /// <summary>Hausnummer inkl. Zusatz. Beispiel. 3, 4a etc.</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        [FieldName("houseNumber", Language.EN)]
        [ProtoMember(6)]
        public string hausnummer;
        ///<summary>
        /// Im Falle einer Postfachadresse das Postfach. Damit werden Straße und
        /// Hausnummer nicht berücksichtigt.Beispiel: Postfach 4711
        /// </summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(7)]
        public string postfach;
        /// <summary>Zusatzhinweis zum Auffinden der Adresse, z.B. "3. Stock linke Wohnung"</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(8)]
        public string adresszusatz;
        ///<summary> Im Falle einer c/o-Adresse steht in diesem Attribut die Anrede. Z.B. c/o
        /// Veronica Hauptmieterin.In diesem Fall enthält die folgende Adresse die Daten
        ///der in c/o adressierten Person oder Firma.</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(9)]
        public string coErgaenzung;
        /// <summary>Offizieller ISO-Landescode. Z.B. NL, Details <see cref="Landescode" /></summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(Required = Required.Default)]
        [FieldName("countryCode", Language.EN)]
        [ProtoMember(10)]
        public Landescode? landescode;
    }
}
