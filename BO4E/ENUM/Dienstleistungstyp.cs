using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Auflistung möglicher abzurechnender Dienstleistungen.</summary>
public enum Dienstleistungstyp
{
    /// <summary>Datenbereitstellung täglich</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(DATENBEREITSTELLUNG_TAEGLICH))]
    [EnumMember(Value = "DATENBEREITSTELLUNG_TAEGLICH")]
    DATENBEREITSTELLUNG_TAEGLICH,

    /// <summary>Datenbereitstellung wöchentlich</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(DATENBEREITSTELLUNG_WOECHENTLICH))]
    [EnumMember(Value = "DATENBEREITSTELLUNG_WOECHENTLICH")]
    DATENBEREITSTELLUNG_WOECHENTLICH,

    /// <summary>Datenbereitstellung monatlich</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(DATENBEREITSTELLUNG_MONATLICH))]
    [EnumMember(Value = "DATENBEREITSTELLUNG_MONATLICH")]
    DATENBEREITSTELLUNG_MONATLICH,

    /// <summary>Datenbereitstellung jährlich</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(DATENBEREITSTELLUNG_JAEHRLICH))]
    [EnumMember(Value = "DATENBEREITSTELLUNG_JAEHRLICH")]
    DATENBEREITSTELLUNG_JAEHRLICH,

    /// <summary>Datenbereitstellung historischer Lastgänge</summary>
    [ProtoEnum(
        Name = nameof(Dienstleistungstyp) + "_" + nameof(DATENBEREITSTELLUNG_HISTORISCHE_LG)
    )]
    [EnumMember(Value = "DATENBEREITSTELLUNG_HISTORISCHE_LG")]
    DATENBEREITSTELLUNG_HISTORISCHE_LG,

    /// <summary>Datenbereitstellung stündlich</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(DATENBEREITSTELLUNG_STUENDLICH))]
    [EnumMember(Value = "DATENBEREITSTELLUNG_STUENDLICH")]
    DATENBEREITSTELLUNG_STUENDLICH,

    /// <summary>Datenbereitstellung vierteljährlich</summary>
    [ProtoEnum(
        Name = nameof(Dienstleistungstyp) + "_" + nameof(DATENBEREITSTELLUNG_VIERTELJAEHRLICH)
    )]
    [EnumMember(Value = "DATENBEREITSTELLUNG_VIERTELJAEHRLICH")]
    DATENBEREITSTELLUNG_VIERTELJAEHRLICH,

    /// <summary>Datenbereitstellung halbjährlich</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(DATENBEREITSTELLUNG_HALBJAEHRLICH))]
    [EnumMember(Value = "DATENBEREITSTELLUNG_HALBJAEHRLICH")]
    DATENBEREITSTELLUNG_HALBJAEHRLICH,

    /// <summary>Datenbereitstellung monatlich zusätzlich</summary>
    [ProtoEnum(
        Name = nameof(Dienstleistungstyp) + "_" + nameof(DATENBEREITSTELLUNG_MONATLICH_ZUSAETZLICH)
    )]
    [EnumMember(Value = "DATENBEREITSTELLUNG_MONATLICH_ZUSAETZLICH")]
    DATENBEREITSTELLUNG_MONATLICH_ZUSAETZLICH,

    /// <summary>Datenbereitstellung einmalig</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(DATENBEREITSTELLUNG_EINMALIG))]
    [EnumMember(Value = "DATENBEREITSTELLUNG_EINMALIG")]
    DATENBEREITSTELLUNG_EINMALIG,

    /// <summary>Auslesung 2x täglich mittels Fernauslesung</summary>
    [ProtoEnum(
        Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_2X_TAEGLICH_FERNAUSLESUNG)
    )]
    [EnumMember(Value = "AUSLESUNG_2X_TAEGLICH_FERNAUSLESUNG")]
    AUSLESUNG_2X_TAEGLICH_FERNAUSLESUNG,

    /// <summary>Auslesung täglich mittels Fernauslesung</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_TAEGLICH_FERNAUSLESUNG))]
    [EnumMember(Value = "AUSLESUNG_TAEGLICH_FERNAUSLESUNG")]
    AUSLESUNG_TAEGLICH_FERNAUSLESUNG,

    /// <summary>Auslesung Manuell vom Messstellenbetreiber vorgenommen</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_LGK_MANUELL_MSB))]
    [EnumMember(Value = "AUSLESUNG_LGK_MANUELL_MSB")]
    AUSLESUNG_LGK_MANUELL_MSB,

    /// <summary>Auslesung monatlich bei SLP mittels Fernauslesung</summary>
    [ProtoEnum(
        Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_MONATLICH_SLP_FERNAUSLESUNG)
    )]
    [EnumMember(Value = "AUSLESUNG_MONATLICH_SLP_FERNAUSLESUNG")]
    AUSLESUNG_MONATLICH_SLP_FERNAUSLESUNG,

    /// <summary>Auslesung jährlich bei SLP mittels Fernauslesung</summary>
    [ProtoEnum(
        Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_JAEHRLICH_SLP_FERNAUSLESUNG)
    )]
    [EnumMember(Value = "AUSLESUNG_JAEHRLICH_SLP_FERNAUSLESUNG")]
    AUSLESUNG_JAEHRLICH_SLP_FERNAUSLESUNG,

    /// <summary>Auslesung mit mobiler Daten Erfassung (MDE) SLP</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_MDE_SLP))]
    [EnumMember(Value = "AUSLESUNG_MDE_SLP")]
    AUSLESUNG_MDE_SLP,

    /// <summary>Ablesung monatlich SLP</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(ABLESUNG_MONATLICH_SLP))]
    [EnumMember(Value = "ABLESUNG_MONATLICH_SLP")]
    ABLESUNG_MONATLICH_SLP,

    /// <summary>Ablesung vierteljährlich SLP</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(ABLESUNG_VIERTELJAEHRLICH_SLP))]
    [EnumMember(Value = "ABLESUNG_VIERTELJAEHRLICH_SLP")]
    ABLESUNG_VIERTELJAEHRLICH_SLP,

    /// <summary>Ablesung halbjährlich SLP</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(ABLESUNG_HALBJAEHRLICH_SLP))]
    [EnumMember(Value = "ABLESUNG_HALBJAEHRLICH_SLP")]
    ABLESUNG_HALBJAEHRLICH_SLP,

    /// <summary>Ablesung jährlich SLP</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(ABLESUNG_JAEHRLICH_SLP))]
    [EnumMember(Value = "ABLESUNG_JAEHRLICH_SLP")]
    ABLESUNG_JAEHRLICH_SLP,

    /// <summary>Auslesung bei SLP mittels Fernauslesung</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_SLP_FERNAUSLESUNG))]
    [EnumMember(Value = "AUSLESUNG_SLP_FERNAUSLESUNG")]
    AUSLESUNG_SLP_FERNAUSLESUNG,

    /// <summary>Ablesung  zusätzlich vom Messstellenbetreiber vorgenommen</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(ABLESUNG_SLP_ZUSAETZLICH_MSB))]
    [EnumMember(Value = "ABLESUNG_SLP_ZUSAETZLICH_MSB")]
    ABLESUNG_SLP_ZUSAETZLICH_MSB,

    /// <summary>Ablesung zusätzlich vom Kunden vorgenommen</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(ABLESUNG_SLP_ZUSAETZLICH_KUNDE))]
    [EnumMember(Value = "ABLESUNG_SLP_ZUSAETZLICH_KUNDE")]
    ABLESUNG_SLP_ZUSAETZLICH_KUNDE,

    /// <summary>Auslesung mittels Fernauslesung, zusätzlich vom Messstellenbetreiber vorgenommen</summary>
    [ProtoEnum(
        Name = nameof(Dienstleistungstyp)
            + "_"
            + nameof(AUSLESUNG_LGK_FERNAUSLESUNG_ZUSAETZLICH_MSB)
    )]
    [EnumMember(Value = "AUSLESUNG_LGK_FERNAUSLESUNG_ZUSAETZLICH_MSB")]
    AUSLESUNG_LGK_FERNAUSLESUNG_ZUSAETZLICH_MSB,

    /// <summary>Auslesung monatlich mittels Fernauslesung</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_MOATLICH_FERNAUSLESUNG))]
    [EnumMember(Value = "AUSLESUNG_MOATLICH_FERNAUSLESUNG")]
    AUSLESUNG_MOATLICH_FERNAUSLESUNG,

    /// <summary>Auslesung stündlich mittels Fernauslesung</summary>
    [ProtoEnum(
        Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_STUENDLICH_FERNAUSLESUNG)
    )]
    [EnumMember(Value = "AUSLESUNG_STUENDLICH_FERNAUSLESUNG")]
    AUSLESUNG_STUENDLICH_FERNAUSLESUNG,

    /// <summary>Ablesung monatlich LGK</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(ABLESUNG_MONATLICH_LGK))]
    [EnumMember(Value = "ABLESUNG_MONATLICH_LGK")]
    ABLESUNG_MONATLICH_LGK,

    /// <summary>Auslesung Temperaturmengenumwerter</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_TEMERATURMENGENUMWERTER))]
    [EnumMember(Value = "AUSLESUNG_TEMERATURMENGENUMWERTER")]
    AUSLESUNG_TEMERATURMENGENUMWERTER,

    /// <summary>Auslesung Zustandsmengenumwerter</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_ZUSTANDSMENGENUMWERTER))]
    [EnumMember(Value = "AUSLESUNG_ZUSTANDSMENGENUMWERTER")]
    AUSLESUNG_ZUSTANDSMENGENUMWERTER,

    /// <summary>Auslesung Systemmengenumwerter</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_SYSTEMMENGENUMWERTER))]
    [EnumMember(Value = "AUSLESUNG_SYSTEMMENGENUMWERTER")]
    AUSLESUNG_SYSTEMMENGENUMWERTER,

    /// <summary>Auslesung je Vorgang SLP</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_VORGANG_SLP))]
    [EnumMember(Value = "AUSLESUNG_VORGANG_SLP")]
    AUSLESUNG_VORGANG_SLP,

    /// <summary>Auslesung Kompaktmengenumwerter</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUUNG_KOMPAKTMENGENUMWERTER))]
    [EnumMember(Value = "AUSLESUUNG_KOMPAKTMENGENUMWERTER")]
    AUSLESUUNG_KOMPAKTMENGENUMWERTER,

    /// <summary>Auslesung mit mobiler Daten Erfassung (MDE) LGK</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(AUSLESUNG_MDE_LGK))]
    [EnumMember(Value = "AUSLESUNG_MDE_LGK")]
    AUSLESUNG_MDE_LGK,

    /// <summary>Sperrung einer SLP-Abnahmestelle</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(SPERRUNG_SLP))]
    [EnumMember(Value = "SPERRUNG_SLP")]
    SPERRUNG_SLP,

    /// <summary>Entsperrung einer SLP-Abnahmestelle</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(ENTSPERRUNG_SLP))]
    [EnumMember(Value = "ENTSPERRUNG_SLP")]
    ENTSPERRUNG_SLP,

    /// <summary>Sperrung einer RLM-Abnahmestelle</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(SPERRUNG_RLM))]
    [EnumMember(Value = "SPERRUNG_RLM")]
    SPERRUNG_RLM,

    /// <summary>Entsperrung einer RLM-Abnahmestelle</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(ENTSPERRUNG_RLM))]
    [EnumMember(Value = "ENTSPERRUNG_RLM")]
    ENTSPERRUNG_RLM,

    /// <summary>Mahnkosten</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(MAHNKOSTEN))]
    [EnumMember(Value = "MAHNKOSTEN")]
    MAHNKOSTEN,

    /// <summary>Inkassokosten</summary>
    [ProtoEnum(Name = nameof(Dienstleistungstyp) + "_" + nameof(INKASSOKOSTEN))]
    [EnumMember(Value = "INKASSOKOSTEN")]
    INKASSOKOSTEN,
}
