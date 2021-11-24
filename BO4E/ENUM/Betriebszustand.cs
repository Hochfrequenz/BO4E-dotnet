using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Betriebszustand der Messlokation</summary>
    public enum Betriebszustand
    {

        /// <summary>ZC1</summary>
        [ProtoEnum(Name = nameof(Betriebszustand) + "_" + nameof(GESPERRT_NICHT_ENTSPERREN))]
        GESPERRT_NICHT_ENTSPERREN,

        /// <summary>ZC2</summary>
        [ProtoEnum(Name = nameof(Betriebszustand) + "_" + nameof(GESPERRT))]
        GESPERRT,

        /// <summary>ZC3</summary>
        [ProtoEnum(Name = nameof(Betriebszustand) + "_" + nameof(REGELBETRIEB))]
        REGELBETRIEB
    }
}