using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Art und Nutzung der Technischen Ressource</summary>
    public enum TechnischeRessourceNutzung
    {
        /// <summary>Z17: Stromverbrauchsart</summary>
        [EnumMember(Value = "STROMVERBRAUCHSART")]
        STROMVERBRAUCHSART,

        /// <summary>Z50: Stromerzeugungsart</summary>
        [EnumMember(Value = "STROMERZEUGUNGSART")]
        STROMERZEUGUNGSART,

        /// <summary>Z56: Speicher</summary>
        [EnumMember(Value = "SPEICHER")]
        SPEICHER
    }
}
