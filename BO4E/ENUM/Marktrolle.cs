using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Diese Rollen kann ein Marktteilnehmer einnehmen.</summary>
public enum Marktrolle
{
    /// <summary>
    /// Netzbetreiber
    /// </summary>
    [EnumMember(Value = "NB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NB")]
    NB,

    /// <summary>
    /// Lieferant
    /// </summary>
    [EnumMember(Value = "LF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LF")]
    LF,

    /// <summary>
    /// Messstellenbetreiber (Wettbewerblich)
    /// </summary>
    [EnumMember(Value = "MSB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MSB")]
    MSB,

    /// <summary>
    /// Messdienstleister
    /// </summary>
    [EnumMember(Value = "MDL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MDL")]
    MDL,

    /// <summary>
    /// Dienstleister
    /// </summary>
    [EnumMember(Value = "DL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DL")]
    DL,

    /// <summary>
    /// Bilanzkreisverantwortlicher
    /// </summary>
    [EnumMember(Value = "BKV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BKV")]
    BKV,

    /// <summary>
    /// Bilanzkoordinator/Marktgebietsverantwortlicher
    /// </summary>
    [EnumMember(Value = "BIKO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BIKO")]
    BIKO,

    /// <summary>
    /// Übertragungsnetzbetreiber
    /// </summary>
    [EnumMember(Value = "UENB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UENB")]
    UENB,

    /// <summary>
    /// Kunden die NN-Entgelte selbst zahlen
    /// </summary>
    [EnumMember(Value = "KUNDE_SELBST_NN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KUNDE_SELBST_NN")]
    KUNDE_SELBST_NN,

    /// <summary>
    /// Marktgebietsverantwortlicher
    /// </summary>
    [EnumMember(Value = "MGV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MGV")]
    MGV,

    /// <summary>
    /// Einsatzverantwortlicher
    /// </summary>
    [EnumMember(Value = "EIV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EIV")]
    EIV,

    /// <summary>
    /// Registerbetreiber
    /// </summary>
    [EnumMember(Value = "RB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RB")]
    RB,

    /// <summary>
    /// Kunde
    /// </summary>
    [EnumMember(Value = "KUNDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KUNDE")]
    KUNDE,

    /// <summary>
    /// Interessent
    /// </summary>
    [EnumMember(Value = "INTERESSENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INTERESSENT")]
    INTERESSENT,

    /// <summary>
    /// Grundzuständiger Messstellenbetreiber
    /// </summary>
    [EnumMember(Value = "GMSB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GMSB")]
    GMSB,

    /// <summary>
    /// Auffangmessstellenbetreiber
    /// </summary>
    [EnumMember(Value = "AMSB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AMSB")]
    AMSB,
}
