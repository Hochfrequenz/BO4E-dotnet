using System.Runtime.Serialization;

using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>
    /// Verschiedenen Vermarktungsformen gemäß dem Erneuerbare-Energien-Gesetz (EEG).
    /// </summary>
    [ProtoContract]
    public enum EEGVermarktungsform
    {
        /// <summary>Ausfallvergütung für den Fall, dass andere Vermarktungsmethoden nicht verfügbar sind</summary>
        /// <remarks>Z90</remarks>
        [ProtoEnum(Name = nameof(EEGVermarktungsform) + "_" + nameof(AUSFALLVERGUETUNG))]
        [EnumMember(Value = "AUSFALLVERGUETUNG")]
        AUSFALLVERGUETUNG,

        /// <summary>Marktprämie für die geförderte Direktvermarktung</summary>
        /// <remarks>Z91</remarks>
        [ProtoEnum(Name = nameof(EEGVermarktungsform) + "_" + nameof(MARKTPRAEMIE))]
        [EnumMember(Value = "MARKTPRAEMIE")]
        MARKTPRAEMIE,

        /// <summary>Sonstige Vermarktungsformen ohne gesetzliche Vergütung</summary>
        /// <remarks>Z92</remarks>
        [ProtoEnum(Name = nameof(EEGVermarktungsform) + "_" + nameof(SONSTIGE))]
        [EnumMember(Value = "SONSTIGE")]
        SONSTIGE,

        /// <summary>Vergütung nach dem Kraft-Wärme-Kopplungsgesetz (KWKG)</summary>
        /// <remarks>Z94</remarks>
        [ProtoEnum(Name = nameof(EEGVermarktungsform) + "_" + nameof(KWKG_VERGUETUNG))]
        [EnumMember(Value = "KWKG_VERGUETUNG")]
        KWKG_VERGUETUNG
    }
}
