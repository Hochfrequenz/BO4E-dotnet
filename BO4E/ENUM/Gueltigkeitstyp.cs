using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Übersicht der verschiedenen Gültigkeiten zur Umsetzung von Positiv- bzw. Negativlisten.</summary>
    public enum Gueltigkeitstyp
    {
        /// <summary>Ein so eingeschränktes Merkmal gilt nicht mit den angegebenen Werten</summary>
        [EnumMember(Value = "NICHT_IN")]
        NICHT_IN
    }
}