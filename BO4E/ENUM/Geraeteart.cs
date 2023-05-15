using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Auflistung möglicher Geraetearten. This is more broadly defined as a <see cref="Geraetetyp"></see>, so a Zaehleinrichtung as Gerateart could be a elektronischer Haushaltszähler as a Gerätetyp./></summary>
    public enum Geraeteart
    {
        /// <summary>Wandler</summary>
        [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(WANDLER))]
        [EnumMember(Value = "WANDLER")]
        WANDLER,
        /// <summary>Kommunikationseinrichtung</summary>
        [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(KOMMUNIKATIONSEINRICHTUNG))]
        [EnumMember(Value = "KOMMUNIKATIONSEINRICHTUNG")]
        KOMMUNIKATIONSEINRICHTUNG,
        /// <summary>Technische Steuereinrichtung</summary>
        [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(TECHNISCHE_STEUEREINRICHTUNG))]
        [EnumMember(Value = "TECHNISCHE_STEUEREINRICHTUNG")]
        TECHNISCHE_STEUEREINRICHTUNG,
        /// <summary>Mengenumwerter</summary>
        [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(MENGENUMWERTER))]
        [EnumMember(Value = "MENGENUMWERTER")]
        MENGENUMWERTER,
        /// <summary>Smartmeter-Gateway</summary>
        [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(SMARTMETER_GATEWAY))]
        [EnumMember(Value = "SMARTMETER_GATEWAY")]
        SMARTMETER_GATEWAY,
        /// <summary>Steuerbox</summary>
        [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(STEUERBOX))]
        [EnumMember(Value = "STEUERBOX")]
        STEUERBOX,
        /// <summary>Zaehleinrichtung</summary>
        [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(ZAEHLEINRICHTUNG))]
        [EnumMember(Value = "ZAEHLEINRICHTUNG")]
        ZAEHLEINRICHTUNG

    }
}