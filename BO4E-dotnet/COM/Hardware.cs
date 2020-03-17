using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Abbildung einer abrechenbaren Hardware.</summary>
    [ProtoContract]
    public class Hardware : COM
    {
        /// <summary>Eindeutiger Typ der Hardware. Details <see cref="Geraetetyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public Geraetetyp geraetetyp;
        /// <summary>Bezeichnung der Hardware.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public string bezeichnung;

        /// <summary>Bezeichnung der Hardware.</summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1005)]
        public Geraeteeigenschaften geraeteeigenschaften;

        /// <summary>
        /// Gerätenummer des Wandlers
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1006)]
        public string geraetenummer;

        /// <summary>
        /// Referenz auf die Gerätenummer des Zählers
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1007)]
        public string geraetereferenz;
    }
}