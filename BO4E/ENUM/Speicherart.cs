using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Im Falle der Speicher bei <see cref="TechnischeRessourceVerbrauchsart"/>, eine genauere Angabe über die Art der Speicher zu definieren.</summary>
    public enum Speicherart
    {
        /// <summary>ZF7: Wasserstoffspeicher</summary>
        [EnumMember(Value = "WASSERSTOFFSPEICHER")]
        WASSERSTOFFSPEICHER,

        /// <summary>ZF8: Pumpspeicher</summary>
        [EnumMember(Value = "PUMPSPEICHER")]
        PUMPSPEICHER,

        /// <summary>ZF9: Batteriespeicher</summary>
        [EnumMember(Value = "BATTERIESPEICHER")]
        BATTERIESPEICHER,

        /// <summary>ZG6: Sonstige Speicherart</summary>
        [EnumMember(Value = "SONSTIGE_SPEICHERART")]
        SONSTIGE_SPEICHERART,
    }
}