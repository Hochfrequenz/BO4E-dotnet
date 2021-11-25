using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Represents the Type of Wert (SG10 STS 9013)
    /// </summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    public enum WertStatusanlass
    {
        /// <summary> Z83 </summary>
        KUNDENSELBSTABLESUNG,

        /// <summary> Z84 </summary>
        LEERSTAND,

        /// <summary> Z85 </summary>
        REALER_ZAEHLERUEBERLAUF_GEPRUEFT,

        /// <summary> Z86 </summary>
        PLAUSIBEL_WG_KONTROLLABLESUNG,

        /// <summary> Z87 </summary>
        PLAUSIBEL_WG_KUNDENHINWIES,

        /// <summary>ZC3 </summary>
        AUSTAUSCH_DES_ERSATZWERTES,
    }
}