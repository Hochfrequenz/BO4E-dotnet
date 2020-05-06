using Newtonsoft.Json;

using ProtoBuf;

using System;

namespace BO4E.ENUM
{
    /// <summary>Unterscheidung für hoch- und niedrig-kalorisches Gas.</summary>
    public enum Gasqualitaet
    {
        [Obsolete("This value is only a workaround for the proto3 syntax generation. You shouldn't actually use it")]
        [ProtoEnum(Name = nameof(Gasqualitaet) + "_" + nameof(ZERO))]
        [JsonIgnore]
        ZERO = 0,
        /// <summary>High Caloric Gas</summary>
        H_GAS = 1,
        /// <summary>Low Caloric Gas</summary>
        L_GAS = 2,
        [JsonIgnore]
        HGAS = 1, // do not remove, they're needed as workaround for bad sap values
        [JsonIgnore]
        LGAS = 2// do not remove, they're needed as workaround for bad sap values
    }
}
