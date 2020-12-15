using Newtonsoft.Json;

using ProtoBuf;

using System;

namespace BO4E.ENUM
{
    /// <summary>Unterscheidung für hoch- und niedrig-kalorisches Gas.</summary>
    public enum Gasqualitaet
    {
        [Obsolete("This value is only a workaround for the proto3 syntax generation. You shouldn't actually use it")]
#pragma warning disable CS0618 // Type or member is obsolete
        [ProtoEnum(Name = nameof(Gasqualitaet) + "_" + nameof(ZERO))]
#pragma warning restore CS0618 // Type or member is obsolete
        [JsonIgnore]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        ZERO = 0,

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>High Caloric Gas</summary>
        H_GAS = 1,

        /// <summary>Low Caloric Gas</summary>
        L_GAS = 2,

        /// <inheritdoc cref="H_GAS"/>
        [JsonIgnore]
        HGAS = 1, // do not remove, they're needed as workaround for bad sap values

        /// <inheritdoc cref="L_GAS"/>
        [JsonIgnore]
        LGAS = 2// do not remove, they're needed as workaround for bad sap values
    }
}