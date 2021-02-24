using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Collections.Generic;

namespace BO4E.BO
{
    /// <summary>
    /// Modellierung eines Ansprechpartners für einen bestimmten Geschäftspartner.
    /// </summary>
    [ProtoContract]
    public class Ansprechpartner : BusinessObject
    {
        /// <summary>
        /// Mögliche Anrede des Ansprechpartners
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 4, PropertyName = "anrede")]

        [System.Text.Json.Serialization.JsonPropertyName("anrede")]
        [ProtoMember(4)]
        [DataCategory(DataCategory.NAME)]
        public Anrede? Anrede { get; set; }

        /// <summary>
        /// Im Falle einer nicht standardisierten Anrede kann hier eine frei definierbare
        /// Anrede vorgegeben werden. Beispiel: "Sehr geehrte Frau Müller, sehr geehrter
        /// Herr Dr. Müller"
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5, PropertyName = "inviduelleAnrede")]
        [System.Text.Json.Serialization.JsonPropertyName("inviduelleAnrede")]
        [ProtoMember(5)]
        [DataCategory(DataCategory.NAME)]
        public string IndividuelleAnrede { get; set; }

        /// <summary>Möglicher Titel des Ansprechpartners</summary>
        [JsonProperty(Required = Required.Default, Order = 6, PropertyName = "titel")]

        [System.Text.Json.Serialization.JsonPropertyName("titel")]
        [ProtoMember(6)]
        [DataCategory(DataCategory.NAME)]
        public Titel? Titel { get; set; }

        /// <summary>Vorname des Ansprechpartners</summary>
        [JsonProperty(Required = Required.Default, Order = 7, PropertyName = "vorname")]

        [System.Text.Json.Serialization.JsonPropertyName("vorname")]
        [ProtoMember(7)]
        [DataCategory(DataCategory.NAME)]
        [BoKey]
        public string Vorname { get; set; }

        /// <summary>Nachname (Familienname) des Ansprechpartners</summary>
        [JsonProperty(Required = Required.Always, Order = 8, PropertyName = "nachname")]

        [System.Text.Json.Serialization.JsonPropertyName("nachname")]
        [ProtoMember(8)]
        [DataCategory(DataCategory.NAME)]
        [BoKey]
        public string Nachname { get; set; }

        /// <summary>E-Mail Adresse</summary>
        [JsonProperty(Required = Required.Default, Order = 9, PropertyName = "eMailAdresse")]

        [System.Text.Json.Serialization.JsonPropertyName("eMailAdresse")]
        [ProtoMember(9)]
        [DataCategory(DataCategory.ADDRESS)]
        public string EMailAdresse { get; set; }

        /// <summary>Weitere Informationen zum Ansprechpartner</summary>
        [JsonProperty(Required = Required.Default, Order = 10, PropertyName = "kommentar")]

        [System.Text.Json.Serialization.JsonPropertyName("kommentar")]
        [ProtoMember(10)]
        [DataCategory(DataCategory.NAME)]
        public string Kommentar { get; set; }

        /// <summary>Der Geschäftspartner, für den dieser Ansprechpartner modelliert wird.</summary>
        [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "geschaeftspartner")]

        [System.Text.Json.Serialization.JsonPropertyName("geschaeftspartner")]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)] // it's always required in BO4E, changed it to default 2020-08-31 KK
        [ProtoMember(11)]
        [BoKey]
        public Geschaeftspartner Geschaeftspartner { get; set; }

        /// <summary> Adresse des Ansprechpartners, falls diese von der Adresse des Geschäftspartners abweicht.</summary>
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "adresse")]

        [System.Text.Json.Serialization.JsonPropertyName("adresse")]
        [ProtoMember(12)]
        [DataCategory(DataCategory.ADDRESS)]
        public Adresse Adresse { get; set; }

        /// <summary>Liste der Telefonnummern, unter denen der Ansprechpartner erreichbar ist.</summary>
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)] //  We suggest to name it "rufnummern" instead of "rufnummer" because it's a list")]
        [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "rufnummern")]

        [System.Text.Json.Serialization.JsonPropertyName("rufnummern")]
        [ProtoMember(13)]
        [DataCategory(DataCategory.ADDRESS)]
        public List<Rufnummer> Rufnummern { get; set; }

        /// <summary>Liste der Abteilungen und Zuständigkeiten des Ansprechpartners.</summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "zustaendigkeit")]

        [System.Text.Json.Serialization.JsonPropertyName("zustaendigkeit")]
        [ProtoMember(14)]
        public List<Zustaendigkeit> Zustaendigkeit { get; set; }

    }
}
