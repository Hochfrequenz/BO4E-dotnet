using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>
/// Rolle eines Marktteilnehmers im Nachrichtenkontext.
/// </summary>
public enum Marktteilnehmerrolle
{
    /// <summary>
    /// Andere Partei - ein am Vorgang beteiligter Marktpartner.
    /// </summary>
    [ProtoEnum(Name = nameof(Marktteilnehmerrolle) + "_" + nameof(ANDERE_PARTEI))]
    [EnumMember(Value = "ANDERE_PARTEI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANDERE_PARTEI")]
    ANDERE_PARTEI,

    /// <summary>
    /// Empfaenger einer Nachricht
    /// </summary>
    [ProtoEnum(Name = nameof(Marktteilnehmerrolle) + "_" + nameof(EMPFAENGER))]
    [EnumMember(Value = "EMPFAENGER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EMPFAENGER")]
    EMPFAENGER,
}
