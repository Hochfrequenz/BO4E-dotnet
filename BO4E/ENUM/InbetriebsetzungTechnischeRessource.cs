using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Inbetriebsetzungsdatum der verbrauchenden Technischen Ressource nach § 14a EnWG</summary>
public enum InbetriebsetzungTechnischeRessource
{
    /// <summary>ZH0: Inbetriebsetzung der TR nach 2023</summary>
    [EnumMember(Value = "NACH_2023")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NACH_2023")]
    NACH_2023,

    /// <summary>ZH1: Inbetriebsetzung der TR vor 2024</summary>
    [EnumMember(Value = "VOR_2024")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VOR_2024")]
    VOR_2024,
}
