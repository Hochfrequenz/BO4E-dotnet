using System.Collections.Generic;

using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

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
        [ProtoMember(4)]
        [DataCategory(DataCategory.NAME)]
        public Anrede? Anrede { get; set; }

        /// <summary>
        /// Im Falle einer nicht standardisierten Anrede kann hier eine frei definierbare
        /// Anrede vorgegeben werden. Beispiel: "Sehr geehrte Frau Müller, sehr geehrter
        /// Herr Dr. Müller"
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5, PropertyName = "inviduelleAnrede")]
        [ProtoMember(5)]
        [DataCategory(DataCategory.NAME)]
        public string IndividuelleAnrede { get; set; }

        /// <summary>Möglicher Titel des Ansprechpartners</summary>
        [JsonProperty(Required = Required.Default, Order = 6, PropertyName = "titel")]
        [ProtoMember(6)]
        [DataCategory(DataCategory.NAME)]
        public Titel? Titel;

        /// <summary>Vorname des Ansprechpartners</summary>
        [JsonProperty(Required = Required.Default, Order = 7, PropertyName = "vorname")]
        [ProtoMember(7)]
        [DataCategory(DataCategory.NAME)]
        [BoKey]
        public string Vorname { get; set; }

        /// <summary>Nachname (Familienname) des Ansprechpartners</summary>
        [JsonProperty(Required = Required.Always, Order = 8, PropertyName = "nachname")]
        [ProtoMember(8)]
        [DataCategory(DataCategory.NAME)]
        [BoKey]
        public string Nachname { get; set; }

        /// <summary>E-Mail Adresse</summary>
        [JsonProperty(Required = Required.Default, Order = 9, PropertyName = "eMailAdresse")]
        [ProtoMember(9)]
        [DataCategory(DataCategory.ADDRESS)]
        public string EMailAdresse { get; set; }

        /// <summary>Weitere Informationen zum Ansprechpartner</summary>
        [JsonProperty(Required = Required.Default, Order = 10, PropertyName = "kommentar")]
        [ProtoMember(10)]
        [DataCategory(DataCategory.NAME)]
        public string Kommentar { get; set; }

        /// <summary>Der Geschäftspartner, für den dieser Ansprechpartner modelliert wird.</summary>
        [JsonProperty(Required = Required.Always, Order = 11, PropertyName = "geschaeftspartner")]
        [ProtoMember(11)]
        [BoKey]
        public Geschaeftspartner Geschaeftspartner { get; set; }

        /// <summary> Adresse des Ansprechpartners, falls diese von der Adresse des Geschäftspartners abweicht.</summary>
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "adresse")]
        [ProtoMember(12)]
        [DataCategory(DataCategory.ADDRESS)]
        public Adresse Adresse { get; set; }

        /// <summary>Liste der Telefonnummern, unter denen der Ansprechpartner erreichbar ist.</summary>
        [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "rufnummer")]
        [ProtoMember(13)]
        [DataCategory(DataCategory.ADDRESS)]
        public List<Rufnummer> Rufnummer;

        /// <summary>Liste der Abteilungen und Zuständigkeiten des Ansprechpartners.</summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "zustaendigkeit")]
        [ProtoMember(14)]
        public List<Zustaendigkeit> Zustaendigkeit;

    }
}
