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
        [JsonProperty(PropertyName = "postleitzahl", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("postleitzahl")]
        [FieldName("zipCode", Language.EN)]
        [ProtoMember(3)]
        public string Postleitzahl { get; set; }
        /// <summary>Bezeichnung der Stadt. Beispiel Hückelhoven</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(PropertyName = "ort", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("ort")]
        [FieldName("city", Language.EN)]
        [ProtoMember(4)]
        public string Ort { get; set; }
        /// <summary>Bezeichnung der Straße. Beispiel: Weserstraße</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(PropertyName = "strasse", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("strasse")]
        [FieldName("street", Language.EN)]
        [ProtoMember(5)]
        public string Strasse { get; set; }
        /// <summary>Hausnummer inkl. Zusatz. Beispiel. 3, 4a etc.</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(PropertyName = "hausnummer", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("hausnummer")]
        [FieldName("houseNumber", Language.EN)]
        [ProtoMember(6)]
        public string Hausnummer { get; set; }
        ///<summary>
        /// Im Falle einer Postfachadresse das Postfach. Damit werden Straße und
        /// Hausnummer nicht berücksichtigt.Beispiel: Postfach 4711
        /// </summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(PropertyName = "postfach", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("postfach")]
        [ProtoMember(7)]
        public string Postfach { get; set; }
        /// <summary>Zusatzhinweis zum Auffinden der Adresse, z.B. "3. Stock linke Wohnung"</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(PropertyName = "adresszusatz", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("adresszusatz")]
        [ProtoMember(8)]
        public string Adresszusatz { get; set; }
        ///<summary> Im Falle einer c/o-Adresse steht in diesem Attribut die Anrede. Z.B. c/o
        /// Veronica Hauptmieterin.In diesem Fall enthält die folgende Adresse die Daten
        ///der in c/o adressierten Person oder Firma.</summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(PropertyName = "coErgaenzung", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("coErgaenzung")]
        [ProtoMember(9)]
        public string CoErgaenzung { get; set; }
        /// <summary>Offizieller ISO-Landescode. Z.B. NL, Details <see cref="ENUM.Landescode" /></summary>
        [DataCategory(DataCategory.ADDRESS)]
        [JsonProperty(PropertyName = "landescode", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("landescode")]
        [FieldName("countryCode", Language.EN)]
        [ProtoMember(10)]
        public Landescode? Landescode { get; set; }
    }
}
