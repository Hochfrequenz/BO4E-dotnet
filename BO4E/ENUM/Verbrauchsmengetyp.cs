using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>type von Verbrauchsmenge</summary>
    public enum Verbrauchsmengetyp
    {
        /// <summary>Arbeitleistungtagesparameterabhmalo</summary>
        [EnumMember(Value = "ARBEITLEISTUNGTAGESPARAMETERABHMALO")]
        ARBEITLEISTUNGTAGESPARAMETERABHMALO,

        /// <summary>Veranschlagtejahresmenge</summary>
        [EnumMember(Value = "VERANSCHLAGTEJAHRESMENGE")]
        VERANSCHLAGTEJAHRESMENGE,

        /// <summary>TUMKundenwert</summary>
        [EnumMember(Value = "TUMKUNDENWERT")]
        TUMKUNDENWERT,
    }
}