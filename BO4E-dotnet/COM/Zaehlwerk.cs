using BO4E.ENUM;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BO4E.COM
{

    /// <summary>Mit dieser Komponente werden Zählwerke modelliert.</summary>
    public class Zaehlwerk : COM
    {
        /// <summary>Identifikation des Zählwerks (Registers) innerhalb des Zählers. Oftmals eine laufende Nummer hinter der Zählernummer. Z.B. 47110815_1</summary>
        [JsonProperty(Required = Required.Always)]
        public string zaehlwerkId;
        /// <summary>Zusätzliche Bezeichnung, z.B. Zählwerk_Wirkarbeit.</summary>
        [JsonProperty(Required = Required.Always)]
        public string bezeichnung;
        /// <summary>Die Energierichtung, Einspeisung oder Ausspeisung. Details <see cref="Energierichtung" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Energierichtung richtung;
        /// <summary>Die OBIS-Kennzahl für das Zählwerk, die festlegt, welche auf die gemessene Größe mit dem Stand gemeldet wird. Nur Zählwerkstände mit dieser OBIS-Kennzahl werden an diesem Zählwerk registriert. Beispiel:1-0:1.8.1 für elektrische Wirkarbeit.</summary>
        [JsonProperty(Required = Required.Always)]
        public string obisKennzahl;
        /// <summary>Mit diesem Faktor wird eine Zählerstandsdifferenz multipliziert, um zum eigentlichen Verbrauch im Zeitraum zu kommen.</summary>
        [JsonProperty(Required = Required.Always)]
        public decimal wandlerfaktor;
        /// <summary>Die Einheit der gemessenen Größe, z.B. kWh. Details <see cref="Mengeneinheit" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Mengeneinheit einheit;

        /// <summary>Obis kennzahl</summary>
        [JsonProperty(Required = Required.Default)]
        public string kennzahl;
        /// <summary>schwachlastfaehig</summary>
        [JsonProperty(Required = Required.Default)]
        public Schwachlastfaehig schwachlastfaehig;
        /// <summary>Verwendungungszweck der Werte Marktlokation</summary>
        [JsonProperty(Required = Required.Default)]
        public List<Verwendungszweck> Verwendungszwecke;
        /// <summary>Stromverbrauchsart/Verbrauchsart Marktlokation</summary>
        [JsonProperty(Required = Required.Default)]
        public Verbrauchsart verbrauchsart;
        /// <summary>Stromverbrauchsart/Unterbrechbarkeit Marktlokation</summary>
        [JsonProperty(Required = Required.Default)]
        public Unterbrechbarkeit unterbrechbarkeit;
        /// <summary>Stromverbrauchsart/Wärmenutzung Marktlokation</summary>
        [JsonProperty(Required = Required.Default)]
        public Waermenutzung waermenutzung;

        [JsonProperty(Required = Required.Default)]
        public Konzessionsabgabe konzessionsabgabe;

        [JsonProperty(Required = Required.Default)]
        public bool steuerbefreit;

        [JsonProperty(Required = Required.Default)]
        public string vorkommastelle;

        [JsonProperty(Required = Required.Default)]
        public string nachkommastelle;

    }
}