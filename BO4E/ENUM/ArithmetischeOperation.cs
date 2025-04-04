using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Mit dieser Aufzählung können arithmetische Operationen festgelegt werden.</summary>
/// <remarks>Das wird z.B. in der UTILTS SG9+CAV Datenelement 7111 verwendet</remarks>
public enum ArithmetischeOperation
{
    /// <summary>Es wird addiert</summary>
    /// <remarks>UTILTS SG9 CAV Z69</remarks>
    [EnumMember(Value = "ADDITION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ADDITION")]
    ADDITION,

    /// <summary>Es wird subtrahiert</summary>
    /// <remarks>UTILTS SG9 CAV Z70</remarks>
    [EnumMember(Value = "SUBTRAKTION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SUBTRAKTION")]
    SUBTRAKTION,

    /// <summary>Es wird multipliziert</summary>
    /// <remarks>UTILTS SG9 CAV Z82</remarks>
    [EnumMember(Value = "MULTIPLIKATION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MULTIPLIKATION")]
    MULTIPLIKATION,

    /// <summary>Es wird dividiert (Divisor)</summary>
    /// <remarks>UTILTS SG9 CAV Z80</remarks>
    [EnumMember(Value = "DIVISION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DIVISION")]
    DIVISION,

    /// <summary>Es wird dividiert (Divident)</summary>
    /// <remarks>UTILTS SG9 CAV Z81</remarks>
    [EnumMember(Value = "DIVIDEND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DIVIDEND")]
    DIVIDEND,

    /// <summary>Positivwert</summary>
    /// <remarks>UTILTS SG9 CAV Z83</remarks>
    [EnumMember(Value = "POSITIVWERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("POSITIVWERT")]
    POSITIVWERT,
}
