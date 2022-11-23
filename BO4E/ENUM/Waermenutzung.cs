using ProtoBuf;

using System.Runtime.Serialization;
using System.Xml.Linq;

namespace BO4E.ENUM
{
    /// <summary>Stromverbrauchsart/Wärmenutzung Marktlokation</summary>
    public enum Waermenutzung
    {
        /// <summary>Z56: Speicherheizung</summary>
        [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(SPEICHERHEIZUNG))]
        [EnumMember(Value = "SPEICHERHEIZUNG")]
        SPEICHERHEIZUNG,

        /// <summary>Z57: Wärmepumpe</summary>
        [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(WAERMEPUMPE))]
        [EnumMember(Value = "WAERMEPUMPE")]
        WAERMEPUMPE,

        ///Z61: Direktheizung <summary>        
        /// </summary>
        [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(DIREKTHEIZUNG))]
        [EnumMember(Value = "DIREKTHEIZUNG")]
        DIREKTHEIZUNG,
    }
}