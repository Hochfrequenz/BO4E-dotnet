using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Typ eines Services (Hochfrequenz-eigene Erweiterung des BO4E-Standards.</summary>
public enum Servicetyp
{
    /// <summary>
    ///     Netzbetrieb Strom
    /// </summary>
    [EnumMember(Value = "STROM_NB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STROM_NB")]
    STROM_NB,

    /// <summary>
    ///     Messstellenbetrieb Strom
    /// </summary>
    [EnumMember(Value = "STROM_MSB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STROM_MSB")]
    STROM_MSB,

    /// <summary>
    ///     Lieferung Strom
    /// </summary>
    [EnumMember(Value = "STROM_LIEF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STROM_LIEF")]
    STROM_LIEF,

    /// <summary>
    ///     Netzbetrieb Gas
    /// </summary>
    [EnumMember(Value = "GAS_NB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GAS_NB")]
    GAS_NB,

    /// <summary>
    ///     Messstellenbetrieb Gas
    /// </summary>
    [EnumMember(Value = "GAS_MSB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GAS_MSB")]
    GAS_MSB,

    /// <summary>
    ///     Lieferung Gas
    /// </summary>
    [EnumMember(Value = "GAS_LIEF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GAS_LIEF")]
    GAS_LIEF,
}
