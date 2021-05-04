using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary> </summary>
    public enum Tarifmerkmal
    {
        /// <summary>Vorkassenprodukt</summary>
        [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(VORKASSE))]
        VORKASSE,

        /// <summary>Paketpreisprodukt</summary>
        [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(PAKET))]
        PAKET,

        /// <summary>Kombiprodukt</summary>
        [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(KOMBI))]
        KOMBI,

        /// <summary>Festpreisprodukt</summary>
        [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(FESTPREIS))]
        FESTPREIS,

        /// <summary>Baustromprodukt</summary>
        [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(BAUSTROM))]
        BAUSTROM,

        /// <summary>Hauslichtprodukt</summary>
        [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(HAUSLICHT))]
        HAUSLICHT,

        /// <summary>Heizstromprodukt</summary>
        [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(HEIZSTROM))]
        HEIZSTROM
    }
}