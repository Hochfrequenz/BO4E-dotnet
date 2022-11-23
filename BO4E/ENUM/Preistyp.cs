using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Aufschlüsselung der Preistypen in Tarifen.</summary>
    public enum Preistyp
    {
        /// <summary>Arbeitspreis_ET</summary>
        [EnumMember(Value = "ARBEITSPREIS_EINTARIF")] 
        ARBEITSPREIS_EINTARIF,

        /// <summary>Arbeitspreis_HT</summary>
        [EnumMember(Value = "ARBEITSPREIS_HT")] 
        ARBEITSPREIS_HT,

        /// <summary>Arbeitspreis_NT</summary>
        [EnumMember(Value = "ARBEITSPREIS_NT")] 
        ARBEITSPREIS_NT,

        /// <summary>Leistungspreis</summary>
        [EnumMember(Value = "LEISTUNGSPREIS")] 
        LEISTUNGSPREIS,

        /// <summary>Messpreis</summary>
        [EnumMember(Value = "MESSPREIS")] 
        MESSPREIS,

        /// <summary>Entgelt fuer Ablesung</summary>
        [EnumMember(Value = "ENTGELT_ABLESUNG")] 
        ENTGELT_ABLESUNG,

        /// <summary>Entgelt fuer Abrechnung</summary>
        [EnumMember(Value = "ENTGELT_ABRECHNUNG")] 
        ENTGELT_ABRECHNUNG,

        /// <summary>Entgelt für MSB (Entgelt für Einbau, Betrieb und Wartung der Messtechnik)</summary>
        [EnumMember(Value = "ENTGELT_MSB")] 
        ENTGELT_MSB,

        /// <summary>Provision</summary>
        [EnumMember(Value = "PROVISION")] 
        PROVISION,
    }
}