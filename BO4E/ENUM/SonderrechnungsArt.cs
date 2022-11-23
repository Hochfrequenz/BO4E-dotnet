using ProtoBuf;

using System.Runtime.Serialization;
using System.Xml.Linq;

namespace BO4E.ENUM
{
    /// <summary> </summary>
    public enum Sonderrechnungsart
    {
        /// <summary>
        ///  Konzessionsabgabe (Testat)
        /// </summary>
        [EnumMember(Value = "KONZESSIONSABGABE_TESTAT")]
        KONZESSIONSABGABE_TESTAT,
        /// <summary>
        /// Individuelle Vereinbarung für atypische und energieintensive Netznutzung
        /// </summary>
        [EnumMember(Value = "INDIVIDUELL_ATYPISCH")]
        INDIVIDUELL_ATYPISCH,
        /// <summary>
        /// Individuelle Vereinbarung für singuläre Netznutzung
        /// </summary>
        [EnumMember(Value = "INDIVIDUELL_SINGULAER")]
        INDIVIDUELL_SINGULAER,
        /// <summary>
        /// KWKG-Umlage
        /// </summary>
        [EnumMember(Value = "KWKG_UMLAGE")]
        KWKG_UMLAGE,
        /// <summary>
        /// Offshore-Netzumlage
        /// </summary>
        [ProtoEnum(Name = nameof(Sonderrechnungsart) + "_" + nameof(OFFSHORE_UMLAGE))]
        [EnumMember(Value = "OFFSHORE_UMLAGE")]
        OFFSHORE_UMLAGE,
        /// <summary>
        /// § 19 StromNEV-Umlage
        /// </summary>
        [EnumMember(Value = "P19_STROM_NEV_UMLAGE")]
        P19_STROM_NEV_UMLAGE,
        /// <summary>
        /// §18 AbLaV
        /// </summary>
        [EnumMember(Value = "P18_ABLAV")]
        P18_ABLAV,
        /// <summary>
        /// Konzessionsabgabe (Wechsel auf Lastgangmessung)
        /// </summary>
        [EnumMember(Value = "KONZESSIONSABGABE_WECHSEL_RLM")]
        KONZESSIONSABGABE_WECHSEL_RLM,

    }
}