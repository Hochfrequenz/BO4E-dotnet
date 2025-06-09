using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>
/// Art der erzeugenden Marktlokation
/// </summary>
[ProtoContract]
public enum ArtDerErzeugendenMarktlokation
{
    /// <summary>EEG-Marktlokation ohne DV-Pflicht</summary>
    /// <remarks>Z33</remarks>
    [ProtoEnum(
        Name = nameof(ArtDerErzeugendenMarktlokation) + "_" + nameof(EEG_MALO_OHNE_DV_PFLICHT)
    )]
    [EnumMember(Value = "EEG_MALO_OHNE_DV_PFLICHT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EEG_MALO_OHNE_DV_PFLICHT")]
    EEG_MALO_OHNE_DV_PFLICHT,

    /// <summary>KWKG-Marktlokation ohne DV-Pflicht</summary>
    /// <remarks>Z34</remarks>
    [ProtoEnum(
        Name = nameof(ArtDerErzeugendenMarktlokation) + "_" + nameof(KWKG_MALO_OHNE_DV_PFLICHT)
    )]
    [EnumMember(Value = "KWKG_MALO_OHNE_DV_PFLICHT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KWKG_MALO_OHNE_DV_PFLICHT")]
    KWKG_MALO_OHNE_DV_PFLICHT,

    /// <summary>Sonstige Marktlokation</summary>
    /// <remarks>Z35</remarks>
    [ProtoEnum(Name = nameof(ArtDerErzeugendenMarktlokation) + "_" + nameof(SONSTIGE_MALO))]
    [EnumMember(Value = "SONSTIGE_MALO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONSTIGE_MALO")]
    SONSTIGE_MALO,

    /// <summary>EEG-Marktlokation mit DV-Pflicht</summary>
    /// <remarks>Z37</remarks>
    [ProtoEnum(
        Name = nameof(ArtDerErzeugendenMarktlokation) + "_" + nameof(EEG_MALO_MIT_DV_PFLICHT)
    )]
    [EnumMember(Value = "EEG_MALO_MIT_DV_PFLICHT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EEG_MALO_MIT_DV_PFLICHT")]
    EEG_MALO_MIT_DV_PFLICHT,

    /// <summary>KWKG-Marktlokation mit DV-Pflicht</summary>
    /// <remarks>Z46</remarks>
    [ProtoEnum(
        Name = nameof(ArtDerErzeugendenMarktlokation) + "_" + nameof(KWKG_MALO_MIT_DV_PFLICHT)
    )]
    [EnumMember(Value = "KWKG_MALO_MIT_DV_PFLICHT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KWKG_MALO_MIT_DV_PFLICHT")]
    KWKG_MALO_MIT_DV_PFLICHT,
}
