using BO4E.meta;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    /// In IFTSTA 21035 "Rückmeldung auf Lieferschein" (IFTSTA SG16 QTY 6063) 
    /// </summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]

    public enum Tarifstufe
    {
        /// <summary> TARIFSTUFE_0 </summary>
        /// <remarks>Z20</remarks>
        [EnumMember(Value = "TARIFSTUFE_0")]
        TARIFSTUFE_0,

        /// <summary> TARIFSTUFE_1 </summary>
        /// <remarks>Z21</remarks>
        [EnumMember(Value = "TARIFSTUFE_1")]
        TARIFSTUFE_1,

        /// <summary> TARIFSTUFE_2 </summary>
        /// <remarks>Z22</remarks>
        [EnumMember(Value = "TARIFSTUFE_2")]
        TARIFSTUFE_2,

        /// <summary> TARIFSTUFE_3 </summary>
        /// <remarks>Z23</remarks>
        [EnumMember(Value = "TARIFSTUFE_3")]
        TARIFSTUFE_3,
        /// <summary> TARIFSTUFE_4 </summary>
        /// <remarks>Z24</remarks>
        [EnumMember(Value = "TARIFSTUFE_4")]
        TARIFSTUFE_4,
        /// <summary> TARIFSTUFE_5 </summary>
        /// <remarks>Z25</remarks>
        [EnumMember(Value = "TARIFSTUFE_5")]
        TARIFSTUFE_5,

        /// <summary> TARIFSTUFE_6 </summary>
        /// <remarks>Z26</remarks>
        [EnumMember(Value = "TARIFSTUFE_6")]
        TARIFSTUFE_6,

        /// <summary> TARIFSTUFE_7 </summary>
        /// <remarks>Z27</remarks>
        [EnumMember(Value = "TARIFSTUFE_7")]
        TARIFSTUFE_7,

        /// <summary> TARIFSTUFE_8 </summary>
        /// <remarks>Z28</remarks>
        [EnumMember(Value = "TARIFSTUFE_8")]
        TARIFSTUFE_8,

        /// <summary> TARIFSTUFE_9 </summary>
        /// <remarks>Z29</remarks>
        [EnumMember(Value = "TARIFSTUFE_9")]
        TARIFSTUFE_9,
    }
}