using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    // Ordering is defined in Geschaeftspartner
    /// <summary>
    /// Objekt zur Kommunikation von Marktteilnehmern jeglicher Art.
    /// </summary>
    [ProtoContract]
    public class Marktteilnehmer : Geschaeftspartner
    {
        /// <summary>Gibt im Klartext die Bezeichnung der Marktrolle an.</summary>
        [JsonProperty(Required = Required.Always, Order = 19)]
        [ProtoMember(19)]
        public Marktrolle marktrolle;

        /// <summary>Gibt die Codenummer der Marktrolle an.</summary>
        [BoKey(true)]
        [JsonProperty(Required = Required.Always, Order = 20)]
        [ProtoMember(20)]
        public string rollencodenummer;

        /// <summary>Gibt den Typ des Codes an.</summary>
        [JsonProperty(Required = Required.Always, Order = 21)]
        [ProtoMember(21)]
        public Rollencodetyp rollencodetyp;

        /// <summary>
        /// Die 1:1-Kommunikationsadresse des Marktteilnehmers. Diese wird in der
        /// Marktkommunikation verwendet.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 22)]
        [ProtoMember(22)]
        public string makoadresse;

        /// <summary>
        /// Ansprechpartner as in EDIFACT NAD+MS, that includes e.g. the email address of a natural person.
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [JsonProperty(Required = Required.Default, Order = 23)]
        [ProtoMember(23)]
        public Ansprechpartner ansprechpartner;
    }
}