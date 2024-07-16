using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Messpreistyp</summary>
public enum Messpreistyp
{
    /// <summary>Messpreis_G4</summary>
    [EnumMember(Value = "MESSPREIS_G4")]
    MESSPREIS_G4,

    /// <summary>Messpreis_G6</summary>
    [EnumMember(Value = "MESSPREIS_G6")]
    MESSPREIS_G6,

    /// <summary>Messpreis_G10</summary>
    [EnumMember(Value = "MESSPREIS_G10")]
    MESSPREIS_G10,

    /// <summary>Messpreis_G16</summary>
    [EnumMember(Value = "MESSPREIS_G16")]
    MESSPREIS_G16,

    /// <summary>Messpreis_G25</summary>
    [EnumMember(Value = "MESSPREIS_G25")]
    MESSPREIS_G25,

    /// <summary>Messpreis_G40</summary>
    [EnumMember(Value = "MESSPREIS_G40")]
    MESSPREIS_G40,

    /// <summary>elektronischer_Aufsatz</summary>
    [EnumMember(Value = "ELEKTRONISCHER_AUFSATZ")]
    ELEKTRONISCHER_AUFSATZ,

    /// <summary>Smart_Meter_Messpreis</summary>
    [EnumMember(Value = "SMART_METER_MESSPREIS_G2_5")]
    SMART_METER_MESSPREIS_G2_5,

    /// <summary>Smart_Meter_Messpreis_G4</summary>
    [EnumMember(Value = "SMART_METER_MESSPREIS_G4")]
    SMART_METER_MESSPREIS_G4,

    /// <summary>Smart_Meter_Messpreis_G6</summary>
    [EnumMember(Value = "SMART_METER_MESSPREIS_G6")]
    SMART_METER_MESSPREIS_G6,

    /// <summary>Smart_Meter_Messpreis_G10</summary>
    [EnumMember(Value = "SMART_METER_MESSPREIS_G10")]
    SMART_METER_MESSPREIS_G10,

    /// <summary>Smart_Meter_Messpreis_G16</summary>
    [EnumMember(Value = "SMART_METER_MESSPREIS_G16")]
    SMART_METER_MESSPREIS_G16,

    /// <summary>Smart_Meter_Messpreis_G25</summary>
    [EnumMember(Value = "SMART_METER_MESSPREIS_G25")]
    SMART_METER_MESSPREIS_G25,

    /// <summary>Smart_Meter_Messpreis_G40</summary>
    [EnumMember(Value = "SMART_METER_MESSPREIS_G40")]
    SMART_METER_MESSPREIS_G40,

    /// <summary>Verrechnungspreis_ET_Wechsel</summary>
    [EnumMember(Value = "VERRECHNUNGSPREIS_ET_WECHSEL")]
    VERRECHNUNGSPREIS_ET_WECHSEL,

    /// <summary>Verrechnungspreis_ET_Dreh</summary>
    [EnumMember(Value = "VERRECHNUNGSPREIS_ET_DREH")]
    VERRECHNUNGSPREIS_ET_DREH,

    /// <summary>Verrechnungspreis_ZT_Wechsel</summary>
    [EnumMember(Value = "VERRECHNUNGSPREIS_ZT_WECHSEL")]
    VERRECHNUNGSPREIS_ZT_WECHSEL,

    /// <summary>Verrechnungspreis_ZT_Dreh</summary>
    [EnumMember(Value = "VERRECHNUNGSPREIS_ZT_DREH")]
    VERRECHNUNGSPREIS_ZT_DREH,

    /// <summary>Verrechnungspreis_L_ET</summary>
    [EnumMember(Value = "VERRECHNUNGSPREIS_L_ET")]
    VERRECHNUNGSPREIS_L_ET,

    /// <summary>Verrechnungspreis_L_ZT</summary>
    [EnumMember(Value = "VERRECHNUNGSPREIS_L_ZT")]
    VERRECHNUNGSPREIS_L_ZT,

    /// <summary>Verrechnungspreis_SM</summary>
    [EnumMember(Value = "VERRECHNUNGSPREIS_SM")]
    VERRECHNUNGSPREIS_SM,

    /// <summary>AufschlagWandler</summary>
    [EnumMember(Value = "AUFSCHLAG_WANDLER")]
    AUFSCHLAG_WANDLER,

    /// <summary>AufschlagTarifschaltung</summary>
    [EnumMember(Value = "AUFSCHLAG_TARIFSCHALTUNG")]
    AUFSCHLAG_TARIFSCHALTUNG,
}
