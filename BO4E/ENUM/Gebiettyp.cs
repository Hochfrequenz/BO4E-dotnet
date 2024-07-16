using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Auflistung der möglichen Gebietstypen.</summary>
public enum Gebiettyp
{
    /// <summary>Regelzone</summary>
    [EnumMember(Value = "REGELZONE")]
    REGELZONE,

    /// <summary>Marktgebiet</summary>
    [EnumMember(Value = "MARKTGEBIET")]
    MARKTGEBIET,

    /// <summary>Bilanzierungsgebiet</summary>
    [EnumMember(Value = "BILANZIERUNGSGEBIET")]
    BILANZIERUNGSGEBIET,

    /// <summary>Verteilnetz</summary>
    [EnumMember(Value = "VERTEILNETZ")]
    VERTEILNETZ,

    /// <summary>Transportnetz</summary>
    [EnumMember(Value = "TRANSPORTNETZ")]
    TRANSPORTNETZ,

    /// <summary>Regionalnetz</summary>
    [EnumMember(Value = "REGIONALNETZ")]
    REGIONALNETZ,

    /// <summary>Arealnetz</summary>
    [EnumMember(Value = "AREALNETZ")]
    AREALNETZ,

    /// <summary>Grundversorgungsgebiet</summary>
    [EnumMember(Value = "GRUNDVERSORGUNGSGEBIET")]
    GRUNDVERSORGUNGSGEBIET,

    /// <summary>Versorgungsgebiet</summary>
    [EnumMember(Value = "VERSORGUNGSGEBIET")]
    VERSORGUNGSGEBIET
}
