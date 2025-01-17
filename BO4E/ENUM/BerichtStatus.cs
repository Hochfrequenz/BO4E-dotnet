using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Status des Statusbericht</summary>
public enum BerichtStatus
{
    /// <summary>
    /// Bericht war erfolgreich
    /// </summary>
    [ProtoEnum(Name = "BerichtStatus_ERFOLGREICH")]
    [EnumMember(Value = "ERFOLGREICH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ERFOLGREICH")]
    ERFOLGREICH,

    /// <summary>Fehler im Bericht</summary>
    [ProtoEnum(Name = "BerichtStatus_FEHLER")]
    [EnumMember(Value = "FEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FEHLER")]
    FEHLER,
}
