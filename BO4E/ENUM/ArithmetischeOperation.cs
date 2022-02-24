namespace BO4E.ENUM
{
    /// <summary>Mit dieser Aufzählung können arithmetische Operationen festgelegt werden.</summary>
    /// <remarks>Das wird z.B. in der UTILTS SG9+CAV Datenelement 7111 verwendet</remarks>
    public enum ArithmetischeOperation
    {
        /// <summary>Es wird addiert</summary>
        /// <remarks>UTILTS SG9 CAV Z69</remarks>
        ADDITION,

        /// <summary>Es wird subtrahiert</summary>
        /// <remarks>UTILTS SG9 CAV Z70</remarks>
        SUBTRAKTION,

        /// <summary>Es wird multipliziert</summary>
        /// <remarks>UTILTS SG9 CAV Z82</remarks>
        MULTIPLIKATION,

        /// <summary>Es wird dividiert (Divisor)</summary>
        /// <remarks>UTILTS SG9 CAV Z80</remarks>
        DIVISION,

        /// <summary>Es wird dividiert (Divident)</summary>
        /// <remarks>UTILTS SG9 CAV Z81</remarks>
        DIVIDEND,

        /// <summary>Positivwert</summary>
        /// <remarks>UTILTS SG9 CAV Z83</remarks>
        POSITIVWERT
    }
}
