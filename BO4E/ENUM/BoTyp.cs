using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Auflistung sämtlicher existierender Geschäftsobjekte.</summary>
public enum BoTyp
{
    /// <summary>1</summary>
    [EnumMember(Value = "ANSPRECHPARTNER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANSPRECHPARTNER")]
    ANSPRECHPARTNER,

    /// <summary>1</summary>
    [EnumMember(Value = "AVIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AVIS")]
    AVIS,

    /// <summary>1</summary>
    [EnumMember(Value = "ENERGIEMENGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIEMENGE")]
    ENERGIEMENGE,

    /// <summary>1</summary>
    [EnumMember(Value = "GESCHAEFTSOBJEKT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GESCHAEFTSOBJEKT")]
    GESCHAEFTSOBJEKT,

    /// <summary>1</summary>
    [EnumMember(Value = "GESCHAEFTSPARTNER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GESCHAEFTSPARTNER")]
    GESCHAEFTSPARTNER,

    /// <summary>1</summary>
    [EnumMember(Value = "MARKTLOKATION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MARKTLOKATION")]
    MARKTLOKATION,

    /// <summary>1</summary>
    [EnumMember(Value = "MARKTTEILNEHMER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MARKTTEILNEHMER")]
    MARKTTEILNEHMER,

    /// <summary>1</summary>
    [EnumMember(Value = "MESSLOKATION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MESSLOKATION")]
    MESSLOKATION,

    /// <summary>1</summary>
    [EnumMember(Value = "ZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZAEHLER")]
    ZAEHLER,

    /// <summary>1</summary>
    [EnumMember(Value = "KOSTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KOSTEN")]
    KOSTEN,

    /// <summary>1</summary>
    [EnumMember(Value = "TARIF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TARIF")]
    TARIF,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PREISBLATT")]
    PREISBLATT,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATTNETZNUTZUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PREISBLATTNETZNUTZUNG")]
    PREISBLATTNETZNUTZUNG,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATTMESSUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PREISBLATTMESSUNG")]
    PREISBLATTMESSUNG,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATTUMLAGEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PREISBLATTUMLAGEN")]
    PREISBLATTUMLAGEN,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATTDIENSTLEISTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PREISBLATTDIENSTLEISTUNG")]
    PREISBLATTDIENSTLEISTUNG,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATTKONZESSIONSABGABE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PREISBLATTKONZESSIONSABGABE")]
    PREISBLATTKONZESSIONSABGABE,

    /// <summary>1</summary>
    [EnumMember(Value = "ZEITREIHE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZEITREIHE")]
    ZEITREIHE,

    /// <summary>1</summary>
    [EnumMember(Value = "LASTGANG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LASTGANG")]
    LASTGANG,

    /// <summary>1</summary>
    [EnumMember(Value = "HANDELSUNSTIMMIGKEIT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HANDELSUNSTIMMIGKEIT")]
    HANDELSUNSTIMMIGKEIT,

    /// <summary>1</summary>
    [EnumMember(Value = "ANFRAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANFRAGE")]
    ANFRAGE,
}
