using Newtonsoft.Json;

using ProtoBuf;

using System;

namespace BO4E.ENUM
{
    /// <summary>Kostenklassen bilden die oberste Ebene der verschiedenen Kosten. In der Regel werden die Gesamtkosten einer Kostenklasse in einer App berechnet.</summary>
    public enum Kostenklasse
    {
        [Obsolete("This value is only a workaround for the proto3 syntax generation. You shouldn't actually use it")]
        [ProtoEnum(Name = nameof(Kostenklasse) + "_" + nameof(ZERO))]
        [JsonIgnore]
        ZERO,
    }
}
