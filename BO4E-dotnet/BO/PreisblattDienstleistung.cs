using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Die Variante des Preisblattmodells zur Abbildung der Preise für wahlfreie Dienstleistungen.
    /// </summary>
    //[ProtoContract]
    public class PreisblattDienstleistung : Preisblatt
    {
        /// <summary>
        /// Hier kann der Preis noch auf bestimmte Dienstleistungsbereiche eingegrenzt werden. Z.B. Sperrung/Entsperrung.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7)]
        //[ProtoMember(7)]
        public Dienstleistungstyp dienstleistungsdetails;

        /// <summary>
        /// Hier kann der Preis auf bestimmte Geräte eingegrenzt werden. Z.B. auf die Zählergröße. 
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 8)]
        //[ProtoMember(8)]
        public Bilanzierungsmethode? geraetedetails;

        /// <summary>
        /// Der Netzbetreiber oder Messstellenbetreiber, der die Preise veröffentlicht hat. 
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 9)]
        //[ProtoMember(9)]
        public Marktteilnehmer herausgeber;
    }
}
