using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Die Variante des Preisblattmodells zur Abbildung der Preise für wahlfreie Dienstleistungen.
    /// </summary>
    public class PreisblattDienstleistung : Preisblatt
    {
        /// <summary>
        /// Hier kann der Preis noch auf bestimmte Dienstleistungsbereiche eingegrenzt werden. Z.B. Sperrung/Entsperrung.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = -1)]
        public Dienstleistungstyp dienstleistungsdetails;

        /// <summary>
        /// Hier kann der Preis auf bestimmte Geräte eingegrenzt werden. Z.B. auf die Zählergröße. 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 0)]
        public Bilanzierungsmethode? geraetedetails;

        /// <summary>
        /// Der Netzbetreiber oder Messstellenbetreiber, der die Preise veröffentlicht hat. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 2)]
        public Marktteilnehmer herausgeber;
    }
}
