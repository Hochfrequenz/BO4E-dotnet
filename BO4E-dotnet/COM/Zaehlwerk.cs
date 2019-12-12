using BO4E.ENUM;
using Newtonsoft.Json;
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
    }
}