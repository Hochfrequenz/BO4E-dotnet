using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Mit dieser Komponente können Kriterien und deren Werte definiert werden.
    /// </summary>
    [ProtoContract]
    public class KriteriumsWert : COM
    {
        /// <summary>
        /// Hier steht, für welches Kriterium der Wert gilt. Z.B. Postleitzahlen.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public Tarifregionskriterium kriterium;

        /// <summary>
        /// Ein Wert, passend zum Kriterium. Z.B. eine Postleitzahl.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public string wert;
    }
}
