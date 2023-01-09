using BO4E.meta;

using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    /// Der Sperrstatus beschreibt, ob ein Zähler gesperrt ist oder nicht.
    /// </summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Sperrstatus
    {
        /// <summary>
        /// Der Zähler ist nicht gesperrt
        /// </summary>
        [ProtoEnum(Name = nameof(Sperrstatus) + "_" + nameof(ENTSPERRT))]
        [EnumMember(Value = "ENTSPERRT")]
        ENTSPERRT,

        /// <summary>
        /// Der Zähler ist gesperrt
        /// </summary>
        [ProtoEnum(Name = nameof(Sperrstatus) + "_" + nameof(GESPERRT))]
        [EnumMember(Value = "GESPERRT")]
        GESPERRT,
    }
}