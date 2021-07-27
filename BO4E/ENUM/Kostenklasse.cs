using System;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.ENUM
{
        /// <summary>
        ///     Kostenklassen bilden die oberste Ebene der verschiedenen Kosten. In der Regel werden die Gesamtkosten einer
        ///     Kostenklasse in einer App berechnet.
        /// </summary>
        public enum Kostenklasse
    {
        [Obsolete("This value is only a workaround for the proto3 syntax generation. You shouldn't actually use it")]
#pragma warning disable CS0618 // Type or member is obsolete
        [ProtoEnum(Name = nameof(Kostenklasse) + "_" + nameof(ZERO))]
#pragma warning restore CS0618 // Type or member is obsolete
        [JsonIgnore]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        ZERO,

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}