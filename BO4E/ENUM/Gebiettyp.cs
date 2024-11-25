using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Auflistung der möglichen Gebietstypen.</summary>
public enum Gebiettyp
{
    /// <summary>Regelzone</summary>
    [EnumMember(Value = "REGELZONE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REGELZONE")]
    REGELZONE,

    /// <summary>Marktgebiet</summary>
    [EnumMember(Value = "MARKTGEBIET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MARKTGEBIET")]
    MARKTGEBIET,

    /// <summary>Bilanzierungsgebiet</summary>
    [EnumMember(Value = "BILANZIERUNGSGEBIET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZIERUNGSGEBIET")]
    BILANZIERUNGSGEBIET,

    /// <summary>Verteilnetz</summary>
    [EnumMember(Value = "VERTEILNETZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERTEILNETZ")]
    VERTEILNETZ,

    /// <summary>Transportnetz</summary>
    [EnumMember(Value = "TRANSPORTNETZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TRANSPORTNETZ")]
    TRANSPORTNETZ,

    /// <summary>Regionalnetz</summary>
    [EnumMember(Value = "REGIONALNETZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REGIONALNETZ")]
    REGIONALNETZ,

    /// <summary>Arealnetz</summary>
    [EnumMember(Value = "AREALNETZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AREALNETZ")]
    AREALNETZ,

    /// <summary>Grundversorgungsgebiet</summary>
    [EnumMember(Value = "GRUNDVERSORGUNGSGEBIET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUNDVERSORGUNGSGEBIET")]
    GRUNDVERSORGUNGSGEBIET,

    /// <summary>Versorgungsgebiet</summary>
    [EnumMember(Value = "VERSORGUNGSGEBIET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERSORGUNGSGEBIET")]
    VERSORGUNGSGEBIET,
}
