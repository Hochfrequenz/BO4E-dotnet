using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System;
using System.Collections.Generic;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden Zählwerke modelliert.</summary>
    [ProtoContract]
    public class Zaehlwerk : COM
    {
        /// <summary>Identifikation des Zählwerks (Registers) innerhalb des Zählers. Oftmals eine laufende Nummer hinter der Zählernummer. Z.B. 47110815_1</summary>
        [JsonProperty(PropertyName = "zaehlwerkId", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("zaehlwerkId")]
        [ProtoMember(3)]
        public string ZaehlwerkId { get; set; }

        /// <summary>Zusätzliche Bezeichnung, z.B. Zählwerk_Wirkarbeit.</summary>
        [JsonProperty(PropertyName = "bezeichnung", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("bezeichnung")]
        [ProtoMember(4)]
        public string Bezeichnung { get; set; }

        /// <summary>Die Energierichtung, Einspeisung oder Ausspeisung. Details <see cref="Energierichtung" /></summary>
        [JsonProperty(PropertyName = "richtung", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("richtung")]
        [ProtoMember(5)]
        public Energierichtung Richtung { get; set; }

        /// <summary>Die OBIS-Kennzahl für das Zählwerk, die festlegt, welche auf die gemessene Größe mit dem Stand gemeldet wird. Nur Zählwerkstände mit dieser OBIS-Kennzahl werden an diesem Zählwerk registriert. Beispiel:1-0:1.8.1 für elektrische Wirkarbeit.</summary>
        [JsonProperty(PropertyName = "obisKennzahl", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("obisKennzahl")]
        [ProtoMember(6)]
        public string ObisKennzahl { get; set; }

        /// <summary>Mit diesem Faktor wird eine Zählerstandsdifferenz multipliziert, um zum eigentlichen Verbrauch im Zeitraum zu kommen.</summary>
        [JsonProperty(PropertyName = "wandlerfaktor", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("wandlerfaktor")]
        [ProtoMember(7)]
        public decimal Wandlerfaktor { get; set; }

        /// <summary>Die Einheit der gemessenen Größe, z.B. kWh. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(PropertyName = "einheit", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("einheit")]
        [ProtoMember(8)]
        public Mengeneinheit Einheit { get; set; }

        /// <summary>Obis kennzahl</summary>
        [JsonProperty(PropertyName = "kennzahl", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("kennzahl")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [Obsolete("Use existing obisKennzahl instead.", true)]
        [ProtoMember(1009)]
        public string Kennzahl { get; set; }

        /// <summary>schwachlastfaehig</summary>
        [JsonProperty(PropertyName = "schwachlastfaehig", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("schwachlastfaehig")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1010)]
        public Schwachlastfaehig? Schwachlastfaehig { get; set; }

        /// <summary>Verwendungungszweck der Werte Marktlokation</summary>
        [JsonProperty(PropertyName = "verwendungszwecke", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("verwendungszwecke")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1011)]
        public List<Verwendungszweck> Verwendungszwecke { get; set; }

        /// <summary>Stromverbrauchsart/Verbrauchsart Marktlokation</summary>
        [JsonProperty(PropertyName = "verbrauchsart", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("verbrauchsart")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1012)]
        public Verbrauchsart? Verbrauchsart { get; set; }

        /// <summary>Stromverbrauchsart/Unterbrechbarkeit Marktlokation</summary>
        [JsonProperty(PropertyName = "unterbrechbarkeit", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("unterbrechbarkeit")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1013)]
        public Unterbrechbarkeit? Unterbrechbarkeit { get; set; }

        /// <summary>Stromverbrauchsart/Wärmenutzung Marktlokation</summary>
        [JsonProperty(PropertyName = "waermenutzung", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("waermenutzung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1014)]
        public Waermenutzung? Waermenutzung { get; set; }

        [JsonProperty(PropertyName = "konzessionsabgabe", Required = Required.Default)]


        [System.Text.Json.Serialization.JsonPropertyName("konzessionsabgabe")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1015)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        // Todo @hamid: add a docstring
        public Konzessionsabgabe Konzessionsabgabe { get; set; }

        [JsonProperty(PropertyName = "steuerbefreit", Required = Required.Default)]


        [System.Text.Json.Serialization.JsonPropertyName("steuerbefreit")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1016)]
        // Todo @hamid: add a docstring
        public bool? Steuerbefreit { get; set; }

        [JsonProperty(PropertyName = "vorkommastelle", Required = Required.Default)]


        [System.Text.Json.Serialization.JsonPropertyName("vorkommastelle")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1017)]
        // Todo @hamid: add a docstring
        public int? Vorkommastelle { get; set; }

        [JsonProperty(PropertyName = "nachkommastelle", Required = Required.Default)]


        [System.Text.Json.Serialization.JsonPropertyName("nachkommastelle")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1018)]
        // Todo @hamid: add a docstring
        public int? Nachkommastelle { get; set; }

        [JsonProperty(PropertyName = "abrechnungsrelevant", Required = Required.Default)]


        [System.Text.Json.Serialization.JsonPropertyName("abrechnungsrelevant")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1019)]
        // Todo @hamid: add a docstring
        public bool? Abrechnungsrelevant { get; set; }

        /// <summary>Relevant für Marktrollen</summary>
        [JsonProperty(PropertyName = "marktrollen", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("marktrollen")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1020)]
        public List<BO4E.ENUM.Marktrolle> Marktrollen { get; set; }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}