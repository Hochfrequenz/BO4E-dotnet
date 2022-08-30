using ProtoBuf;

using System.Xml.Linq;

namespace BO4E.ENUM
{
    /// <summary>Stromverbrauchsart/Wärmenutzung Marktlokation</summary>
    public enum Waermenutzung
    {
        /// <summary>Z56: Speicherheizung</summary>
        [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(SPEICHERHEIZUNG))]
        SPEICHERHEIZUNG,

        /// <summary>Z57: Wärmepumpe</summary>
        [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(WAERMEPUMPE))]
        WAERMEPUMPE,

        ///Z61: Direktheizung <summary>        
        /// </summary>
        [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(DIREKTHEIZUNG))]
        DIREKTHEIZUNG
    }
}