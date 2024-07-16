using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Messtechnische Einordnung</summary>
public enum MesstechnischeEinordnung
{
    /// <summary>Z52: IMS</summary>
    [EnumMember(Value = "IMS")]
    IMS,

    /// <summary>Z53: KME_MME</summary>
    [EnumMember(Value = "KME_MME")]
    KME_MME,

    /// <summary>
    ///     Z68: KEINE_MESSUNG
    /// </summary>
    [EnumMember(Value = "KEINE_MESSUNG")]
    KEINE_MESSUNG,
}