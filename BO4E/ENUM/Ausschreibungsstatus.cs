using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Ausschreibungsstatus</summary>
    public enum Ausschreibungsstatus
    {
        /// <summary>Phase1: Teilnahmewettbewerb</summary>
        [EnumMember(Value = "PHASE1")]
        PHASE1,

        /// <summary>Phase2: Angebotsphase</summary>
        [EnumMember(Value = "PHASE2")]
        PHASE2,

        /// <summary>Phase3: Verhandlungsphase</summary>
        [EnumMember(Value = "PHASE3")]
        PHASE3,

        /// <summary>Phase4: Zuschlagserteilung</summary>
        [EnumMember(Value = "PHASE4")]
        PHASE4
    }
}