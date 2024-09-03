using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Auflistung sämtlicher existierender Geschäftsobjekte.</summary>
public enum BoTyp
{
    /// <summary>1</summary>
    [EnumMember(Value = "ANSPRECHPARTNER")]
    ANSPRECHPARTNER,

    /// <summary>1</summary>
    [EnumMember(Value = "AVIS")]
    AVIS,

    /// <summary>1</summary>
    [EnumMember(Value = "ENERGIEMENGE")]
    ENERGIEMENGE,

    /// <summary>1</summary>
    [EnumMember(Value = "GESCHAEFTSOBJEKT")]
    GESCHAEFTSOBJEKT,

    /// <summary>1</summary>
    [EnumMember(Value = "GESCHAEFTSPARTNER")]
    GESCHAEFTSPARTNER,

    /// <summary>1</summary>
    [EnumMember(Value = "MARKTLOKATION")]
    MARKTLOKATION,

    /// <summary>1</summary>
    [EnumMember(Value = "MARKTTEILNEHMER")]
    MARKTTEILNEHMER,

    /// <summary>1</summary>
    [EnumMember(Value = "MESSLOKATION")]
    MESSLOKATION,

    /// <summary>1</summary>
    [EnumMember(Value = "ZAEHLER")]
    ZAEHLER,

    /// <summary>1</summary>
    [EnumMember(Value = "KOSTEN")]
    KOSTEN,

    /// <summary>1</summary>
    [EnumMember(Value = "TARIF")]
    TARIF,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATT")]
    PREISBLATT,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATTNETZNUTZUNG")]
    PREISBLATTNETZNUTZUNG,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATTMESSUNG")]
    PREISBLATTMESSUNG,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATTUMLAGEN")]
    PREISBLATTUMLAGEN,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATTDIENSTLEISTUNG")]
    PREISBLATTDIENSTLEISTUNG,

    /// <summary>1</summary>
    [EnumMember(Value = "PREISBLATTKONZESSIONSABGABE")]
    PREISBLATTKONZESSIONSABGABE,

    /// <summary>1</summary>
    [EnumMember(Value = "ZEITREIHE")]
    ZEITREIHE,

    /// <summary>1</summary>
    [EnumMember(Value = "LASTGANG")]
    LASTGANG,

    /// <summary>1</summary>
    [EnumMember(Value = "HANDELSUNSTIMMIGKEIT")]
    HANDELSUNSTIMMIGKEIT,

    /// <summary>1</summary>
    [EnumMember(Value = "ANFRAGE")]
    ANFRAGE
}