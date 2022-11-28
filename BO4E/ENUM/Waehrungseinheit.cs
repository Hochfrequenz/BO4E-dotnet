using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    ///     In diesem Enum werden die Währungen und ihre Untereinheiten definiert, beispielsweise für die Verwendung in
    ///     Preisen.
    /// </summary>
    public enum Waehrungseinheit
    {
        /// <summary>Euro</summary>
        [ProtoEnum(Name = nameof(Waehrungseinheit) + "_" + nameof(EUR))]
        [EnumMember(Value = "EUR")]
        EUR,

        /// <summary>Eurocent</summary>
        [EnumMember(Value = "CT")]
        CT,
    }
}