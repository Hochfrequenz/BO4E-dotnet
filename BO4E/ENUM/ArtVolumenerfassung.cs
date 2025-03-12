using System;
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Auflistung möglicher Arten der Volumenerfassung (bzgl. Mengenumwerter)</summary>
public enum ArtVolumenerfassung
{
    /// <summary>Kennlinienunterdrückung</summary>
    [ProtoEnum(Name = nameof(ArtVolumenerfassung) + "_" + nameof(KENNLINIENKORREKTUR))]
    [EnumMember(Value = "KENNLINIENKORREKTUR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KENNLINIENKORREKTUR")]
    KENNLINIENKORREKTUR,

    /// <summary>Schleichmengenunterdrückung</summary>
    [ProtoEnum(Name = nameof(ArtVolumenerfassung) + "_" + nameof(SCHLEICHMENGENUNTERDRÜCKUNG))]
    [EnumMember(Value = "SCHLEICHMENGENUNTERDRÜCKUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SCHLEICHMENGENUNTERDRÜCKUNG")]
    SCHLEICHMENGENUNTERDRÜCKUNG,

}