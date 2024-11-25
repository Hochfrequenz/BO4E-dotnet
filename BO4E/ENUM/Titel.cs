using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Übersicht möglicher Titel, z.B. eines Geschäftspartners.</summary>
public enum Titel
{
    /// <summary>Doktor</summary>
    [EnumMember(Value = "DR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DR")]
    DR,

    /// <summary>Professor</summary>
    [EnumMember(Value = "PROF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PROF")]
    PROF,

    /// <summary>Professor Dr.</summary>
    [EnumMember(Value = "PROF_DR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PROF_DR")]
    PROF_DR,
}
