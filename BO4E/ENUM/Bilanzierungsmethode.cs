using Newtonsoft.Json.Linq;
using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Mit dieser Aufzählung kann zwischen den Bilanzierungsmethoden bzw. -Grundlagen unterschieden werden.</summary>
    public enum Bilanzierungsmethode
    {
        /// <summary>Registrierende Leistungsmessung</summary>
        [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(RLM))]
        [EnumMember(Value = "RLM")]
        RLM,

        /// <summary>Standard Lastprofil</summary>
        [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(SLP))]
        [EnumMember(Value = "SLP")]
        SLP,

        /// <summary>TLP gemeinsame Messung</summary>
        [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(TLP_GEMEINSAM))]
        [EnumMember(Value = "TLP_GEMEINSAM")]
        TLP_GEMEINSAM,

        /// <summary>TLP getrennte Messung</summary>
        [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(TLP_GETRENNT))]
        [EnumMember(Value = "TLP_GETRENNT")]
        TLP_GETRENNT,

        /// <summary>Pauschale Betrachtung (Band)</summary>
        [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(PAUSCHAL))]
        [EnumMember(Value = "PAUSCHAL")]
        PAUSCHAL,

        /// <summary>
        ///     intelligentes Messsystem / Smart Meter
        /// </summary>
        [ProtoEnum(Name = nameof(Bilanzierungsmethode) + "_" + nameof(IMS))]
        [EnumMember(Value = "IMS")]
        IMS
    }
}