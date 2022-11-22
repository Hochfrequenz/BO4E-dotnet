using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Mit dieser Aufzählung können arithmetische Operationen festgelegt werden.</summary>
    /// <remarks>Das wird z.B. in der UTILTS SG9+CAV Datenelement 7111 verwendet</remarks>
    public enum ArithmetischeOperation
    {
        /// <summary>Es wird addiert</summary>
        /// <remarks>UTILTS SG9 CAV Z69</remarks>
        [EnumMember(Value = "ADDITION")]
        ADDITION,

        /// <summary>Es wird subtrahiert</summary>
        /// <remarks>UTILTS SG9 CAV Z70</remarks>
        [EnumMember(Value = "SUBTRAKTION")]
        SUBTRAKTION,

        /// <summary>Es wird multipliziert</summary>
        /// <remarks>UTILTS SG9 CAV Z82</remarks>
        [EnumMember(Value = "MULTIPLIKATION")]
        MULTIPLIKATION,

        /// <summary>Es wird dividiert (Divisor)</summary>
        /// <remarks>UTILTS SG9 CAV Z80</remarks>
        [EnumMember(Value = "DIVISION")]
        DIVISION,

        /// <summary>Es wird dividiert (Divident)</summary>
        /// <remarks>UTILTS SG9 CAV Z81</remarks>
        [EnumMember(Value = "DIVIDEND")]
        DIVIDEND,

        /// <summary>Positivwert</summary>
        /// <remarks>UTILTS SG9 CAV Z83</remarks>
        [EnumMember(Value = "POSITIVWERT")]
        POSITIVWERT
    }
}
