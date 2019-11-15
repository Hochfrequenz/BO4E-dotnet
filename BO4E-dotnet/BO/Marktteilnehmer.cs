using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO
{
    // Ordering is defined in Geschaeftspartner
    /// <summary>
    /// Objekt zur Kommunikation von Marktteilnehmern jeglicher Art.
    /// </summary>
    public class Marktteilnehmer : Geschaeftspartner
    {
        /// <summary>Gibt im Klartext die Bezeichnung der Marktrolle an.</summary>
        [JsonProperty(Required = Required.Always, Order = 20)]
        public Marktrolle marktrolle;

        /// <summary>Gibt die Codenummer der Marktrolle an.</summary>
        [BoKey(true)]
        [JsonProperty(Required = Required.Always, Order = 21)]
        public string rollencodenummer;

        /// <summary>Gibt den Typ des Codes an.</summary>
        [JsonProperty(Required = Required.Always, Order = 22)]
        public Rollencodetyp rollencodetyp;

        /// <summary>
        /// Die 1:1-Kommunikationsadresse des Marktteilnehmers. Diese wird in der
        /// Marktkommunikation verwendet.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 23)]
        public string makoadresse;
    }
}