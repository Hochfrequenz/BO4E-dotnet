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
    [ProtoEnum(Name = nameof(Marktteilnehmerrolle) + "_" + nameof(anderepartei))]
    [EnumMember(Value = "anderepartei")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("anderepartei")]
    anderepartei, // sorry for the lowercase. just for legacy support
}
