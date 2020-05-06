using Newtonsoft.Json;
using ProtoBuf;

using System;

namespace BO4E.ENUM
{
    /// <summary>Gibt den Codetyp einer Rolle, beispielsweise einer Marktrolle, an.</summary>
    public enum Rollencodetyp
    {
        [Obsolete("This value is only a workaround for the proto3 syntax generation. You shouldn't actually use it")]
        [ProtoEnum(Name = nameof(Rollencodetyp) + "_" + nameof(ZERO))]
        [JsonIgnore]
        ZERO,
        /// <summary>Bundesverband der Energie- u. Wasserwirtschaft</summary>
        BDEW = 293,
        /// <summary>Deutscher Verein des Gas- und Wasserfaches</summary>
        DVGW = 332,
        /// <summary>Global Location Number</summary>
        GLN = 9
    }
}
