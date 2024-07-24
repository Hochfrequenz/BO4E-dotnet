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
        [ProtoEnum(Name = nameof(EEGVermarktungsform) + "_" + nameof(Z90_AUSFALLVERGUETUNG))]
        [EnumMember(Value = "Z90_AUSFALLVERGUETUNG")]
        Z90_AUSFALLVERGUETUNG,

        /// <summary>Marktprämie für die geförderte Direktvermarktung</summary>
        [ProtoEnum(Name = nameof(EEGVermarktungsform) + "_" + nameof(Z91_MARKTPRAEMIE))]
        [EnumMember(Value = "Z91_MARKTPRAEMIE")]
        Z91_MARKTPRAEMIE,

        /// <summary>Sonstige Vermarktungsformen ohne gesetzliche Vergütung</summary>
        [ProtoEnum(Name = nameof(EEGVermarktungsform) + "_" + nameof(Z92_SONSTIGE))]
        [EnumMember(Value = "Z92_SONSTIGE")]
        Z92_SONSTIGE,

        /// <summary>Vergütung nach dem Kraft-Wärme-Kopplungsgesetz (KWKG)</summary>
        [ProtoEnum(Name = nameof(EEGVermarktungsform) + "_" + nameof(Z94_KWKG_VERGUETUNG))]
        [EnumMember(Value = "Z94_KWKG_VERGUETUNG")]
        Z94_KWKG_VERGUETUNG
    }
}
