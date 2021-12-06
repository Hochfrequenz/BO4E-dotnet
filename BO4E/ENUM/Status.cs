using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Represents the Status Code (SG10 STS 4405) 
    /// </summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    public enum Status
    {
        /// <summary> T1 </summary>
        TARIF_1,

        /// <summary> T2 </summary>
        TARIF_2,

        /// <summary> T3 </summary>
        TARIF_3,

        /// <summary> T4 </summary>
        TARIF_4,

        /// <summary> T5 </summary>
        TARIF_5,

        /// <summary> T6 </summary>
        TARIF_6,

        /// <summary> T7 </summary>
        TARIF_7,

        /// <summary> T8 </summary>
        TARIF_8,

        /// <summary> T9 </summary>
        TARIF_9,

        /// <summary> Z36 </summary>
        ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT,

        /// <summary> Z37 </summary>
        ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT,

        /// <summary> Z38 </summary>
        ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA,

        /// <summary> Z39 </summary>
        ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG,

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