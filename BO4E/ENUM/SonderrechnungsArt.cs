using ProtoBuf;

using System.Xml.Linq;

namespace BO4E.ENUM
{
    /// <summary> </summary>
    public enum Sonderrechnungsart
    {
        /// <summary>
        ///  Konzessionsabgabe (Testat)
        /// </summary>
        KONZESSIONSABGABE_TESTAT,
        /// <summary>
        /// Individuelle Vereinbarung für atypische und energieintensive Netznutzung
        /// </summary>
        INDIVIDUELL_ATYPISCH,
        /// <summary>
        /// Individuelle Vereinbarung für singuläre Netznutzung
        /// </summary>
        INDIVIDUELL_SINGULAER,
        /// <summary>
        /// KWKG-Umlage
        /// </summary>
        KWKG_UMLAGE,
        /// <summary>
        /// Offshore-Netzumlage
        /// </summary>
        [ProtoEnum(Name = nameof(Sonderrechnungsart) + "_" + nameof(OFFSHORE_UMLAGE))]
        OFFSHORE_UMLAGE,
        /// <summary>
        /// § 19 StromNEV-Umlage
        /// </summary>
        P19_STROM_NEV_UMLAGE,
        /// <summary>
        /// §18 AbLaV
        /// </summary>
        P18_ABLAV,
        /// <summary>
        /// Konzessionsabgabe (Wechsel auf Lastgangmessung)
        /// </summary>
        KONZESSIONSABGABE_WECHSEL_RLM

    }
}