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
        [JsonProperty(Required = Required.Default, Order = 4)]
        [ProtoMember(4)]
        [DataCategory(DataCategory.NAME)]
        public Anrede? anrede;

        /// <summary>
        /// Im Falle einer nicht standardisierten Anrede kann hier eine frei definierbare
        /// Anrede vorgegeben werden. Beispiel: "Sehr geehrte Frau Müller, sehr geehrter
        /// Herr Dr. Müller"
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5)]
        [ProtoMember(5)]
        [DataCategory(DataCategory.NAME)]
        public string individuelleAnrede;

        /// <summary>Möglicher Titel des Ansprechpartners</summary>
        [JsonProperty(Required = Required.Default, Order = 6)]
        [ProtoMember(6)]
        [DataCategory(DataCategory.NAME)]
        public Titel? titel;

        /// <summary>Vorname des Ansprechpartners</summary>
        [JsonProperty(Required = Required.Default, Order = 7)]
        [ProtoMember(7)]
        [DataCategory(DataCategory.NAME)]
        [BoKey]
        public string vorname;

        /// <summary>Nachname (Familienname) des Ansprechpartners</summary>
        [JsonProperty(Required = Required.Always, Order = 8)]
        [ProtoMember(8)]
        [DataCategory(DataCategory.NAME)]
        [BoKey]
        public string nachname;

        /// <summary>E-Mail Adresse</summary>
        [JsonProperty(Required = Required.Default, Order = 9)]
        [ProtoMember(9)]
        [DataCategory(DataCategory.ADDRESS)]
        public string eMailAdresse;

        /// <summary>Weitere Informationen zum Ansprechpartner</summary>
        [JsonProperty(Required = Required.Default, Order = 10)]
        [ProtoMember(10)]
        [DataCategory(DataCategory.NAME)]
        public string kommentar;

        /// <summary>Der Geschäftspartner, für den dieser Ansprechpartner modelliert wird.</summary>
        [JsonProperty(Required = Required.Always, Order = 11)]
        [ProtoMember(11)]
        [BoKey]
        public Geschaeftspartner geschaeftspartner;

        /// <summary> Adresse des Ansprechpartners, falls diese von der Adresse des Geschäftspartners abweicht.</summary>
        [JsonProperty(Required = Required.Default, Order = 12)]
        [ProtoMember(12)]
        [DataCategory(DataCategory.ADDRESS)]
        public Adresse adresse;

        /// <summary>Liste der Telefonnummern, unter denen der Ansprechpartner erreichbar ist.</summary>
        [JsonProperty(Required = Required.Default, Order = 13)]
        [ProtoMember(13)]
        [DataCategory(DataCategory.ADDRESS)]
        public List<Rufnummer> rufnummer;

        /// <summary>Liste der Abteilungen und Zuständigkeiten des Ansprechpartners.</summary>
        [JsonProperty(Required = Required.Default, Order = 14)]
        [ProtoMember(14)]
        public List<Zustaendigkeit> zustaendigkeit;

    }
}
