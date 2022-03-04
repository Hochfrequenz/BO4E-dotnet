using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Gründe aus denen ein <see cref="BO.Sperrauftrag"/> abgelehnt werden kann.
    /// </summary>
    /// <remarks>Diese Information kann in der EDIFACT-Nachricht des Typs 19117 verwendet werden</remarks>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Sperrauftragsablehngrund
    {
        /// <summary>
        /// Sperrauftrag für Marktlokation liegt bereits vor bzw. ist bereits gesperrt.
        /// </summary>
        /// <remarks>EBD 0470 A01</remarks>
        DUPLIKAT,

        /// <summary>
        /// An mindestens einer Messlokation ist ein anderer MSB zugeordnet als an der Marktlokation. 
        /// </summary>
        /// <remarks>EBD 0470 A02</remarks>
        FALSCHER_MSB,

        /// <summary>
        /// Marktlokation ist bspw. nicht <see cref="Netzebene.NSP"/>
        /// </summary>
        /// <remarks>EBD 0470 A03</remarks>
        FALSCHE_SPANNUNGSEBENE,

        /// <summary>
        /// Mindestens eine weitere Marktlokation ist von der Sperrung betroffen. 
        /// </summary>
        /// <remarks>EBD 0470 A04</remarks>
        WEITERE_MALO_BETROFFEN,

        /// <summary>
        /// Ein Verhinderungsgrund liegt vor und wird in <see cref="BO.Auftrag.Bemerkung"/> genauer spezifiziert.
        /// </summary>
        /// <remarks>EBD 0470 A05</remarks>
        ANDERER_ABLEHNGRUND,

        /// <summary>
        /// Fristverletzung bei einem termingebundenen Sperrauftrag
        /// </summary>
        /// <remarks>EBD 0470 A06</remarks>
        FRISTVERLETZUNG_TERMINGEBUNDEN,

        /// <summary>
        /// Fristverletzung bei einem nicht termingebundenen Sperrauftrag
        /// </summary>
        /// <remarks>EBD 0470 A07</remarks>
        FRISTVERLETZUNG_NICHT_TERMINGEBUNDEN,

        /// <summary>
        /// Ein Fehler liegt vor und wird in <see cref="BO.Auftrag.Bemerkung"/> genauer spezifiziert.
        /// </summary>
        /// <remarks>EBD 0470 A99</remarks>
        ANDERER_FEHLER
    }
}