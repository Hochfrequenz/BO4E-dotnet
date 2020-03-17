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
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public string zaehlwerkId;

        /// <summary>Zusätzliche Bezeichnung, z.B. Zählwerk_Wirkarbeit.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public string bezeichnung;

        /// <summary>Die Energierichtung, Einspeisung oder Ausspeisung. Details <see cref="Energierichtung" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public Energierichtung richtung;

        /// <summary>Die OBIS-Kennzahl für das Zählwerk, die festlegt, welche auf die gemessene Größe mit dem Stand gemeldet wird. Nur Zählwerkstände mit dieser OBIS-Kennzahl werden an diesem Zählwerk registriert. Beispiel:1-0:1.8.1 für elektrische Wirkarbeit.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(6)]
        public string obisKennzahl;

        /// <summary>Mit diesem Faktor wird eine Zählerstandsdifferenz multipliziert, um zum eigentlichen Verbrauch im Zeitraum zu kommen.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(7)]
        public decimal wandlerfaktor;

        /// <summary>Die Einheit der gemessenen Größe, z.B. kWh. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(8)]
        public Mengeneinheit einheit;

        /// <summary>Obis kennzahl</summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [Obsolete("Use existing obisKennzahl instead.", true)]
        [ProtoMember(1009)]
        public string kennzahl;

        /// <summary>schwachlastfaehig</summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1010)]
        public Schwachlastfaehig? schwachlastfaehig;

        /// <summary>Verwendungungszweck der Werte Marktlokation</summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1011)]
        public List<Verwendungszweck> verwendungszwecke;

        /// <summary>Stromverbrauchsart/Verbrauchsart Marktlokation</summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1012)]
        public Verbrauchsart? verbrauchsart;

        /// <summary>Stromverbrauchsart/Unterbrechbarkeit Marktlokation</summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1013)]
        public Unterbrechbarkeit? unterbrechbarkeit;

        /// <summary>Stromverbrauchsart/Wärmenutzung Marktlokation</summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1014)]
        public Waermenutzung? waermenutzung;

        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1015)]
        public Konzessionsabgabe konzessionsabgabe;

        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1016)]
        public bool? steuerbefreit;

        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1017)]
        public int? vorkommastelle;

        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1018)]
        public int? nachkommastelle;

    }
}