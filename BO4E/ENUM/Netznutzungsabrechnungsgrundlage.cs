using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Netznutzungsabrechnungsgrundlage</summary>
    public enum Netznutzungsabrechnungsgrundlage
    {
        /// <summary>Z12: Lieferschein</summary>
        [EnumMember(Value = "LIEFERSCHEIN")]
        LIEFERSCHEIN,

        /// <summary>Z13: Abweichend vertraglich mit Anschlussnutzer vereinbarte Grundlage</summary>
        [EnumMember(Value = "ABWEICHENDE_GRUNDLAGE")]
        ABWEICHENDE_GRUNDLAGE,
    }
}