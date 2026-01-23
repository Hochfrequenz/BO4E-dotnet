using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>type von Verbrauchsmenge</summary>
public enum Verbrauchsmengetyp
{
    /// <summary>Arbeitleistungtagesparameterabhmalo</summary>
    [EnumMember(Value = "ARBEITLEISTUNGTAGESPARAMETERABHMALO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ARBEITLEISTUNGTAGESPARAMETERABHMALO")]
    ARBEITLEISTUNGTAGESPARAMETERABHMALO,

    /// <summary>Veranschlagtejahresmenge</summary>
    [EnumMember(Value = "VERANSCHLAGTEJAHRESMENGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERANSCHLAGTEJAHRESMENGE")]
    VERANSCHLAGTEJAHRESMENGE,

    /// <summary>TUMKundenwert</summary>
    [EnumMember(Value = "TUMKUNDENWERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TUMKUNDENWERT")]
    TUMKUNDENWERT,
}
