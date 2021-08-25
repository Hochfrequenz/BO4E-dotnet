using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Aufzählung der Möglichkeiten zu Vertragsformen in Ausschreibungen.</summary>
    public enum Vertragsform
    {
        /// <summary>Online</summary>
        ONLINE,

        /// <summary>Direkt</summary>
        DIREKT,

        /// <summary>Auftragsfax</summary>
        [ProtoEnum(Name = nameof(Vertragsform) + "_" + nameof(FAX))]
        FAX
    }
}