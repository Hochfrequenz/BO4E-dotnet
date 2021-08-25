using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Mit diesen Kriterien können regionale Bereiche definiert werden.</summary>
    public enum Tarifregionskriterium
    {
        /// <summary>Netznummer</summary>
        [ProtoEnum(Name = nameof(Tarifregionskriterium) + "_" + nameof(NETZ_NUMMER))]
        NETZ_NUMMER,

        /// <summary>Postleitzahl</summary>
        [ProtoEnum(Name = nameof(Tarifregionskriterium) + "_" + nameof(POSTLEITZAHL))]
        POSTLEITZAHL,

        /// <summary>Ort</summary>
        [ProtoEnum(Name = nameof(Tarifregionskriterium) + "_" + nameof(ORT))]
        ORT,

        /// <summary>Nummer des Grundversorgers</summary>
        [ProtoEnum(Name = nameof(Tarifregionskriterium) + "_" + nameof(GRUNDVERSORGER_NUMMER))]
        GRUNDVERSORGER_NUMMER
    }
}