using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Represents the Status Code (SG10 STS 4405) 
    /// </summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    public enum Status
    {
        /// <summary> TARIF_1 </summary>
        /// <remarks>T1</remarks>
        TARIF_1,

        /// <summary> TARIF_2 </summary>
        /// <remarks>T2</remarks>
        TARIF_2,

        /// <summary> TARIF_3 </summary>
        /// <remarks>T3</remarks>
        TARIF_3,

        /// <summary> TARIF_4 </summary>
        /// <remarks>T4</remarks>
        TARIF_4,

        /// <summary> TARIF_5 </summary>
        /// <remarks>T5</remarks>
        TARIF_5,

        /// <summary> TARIF_6 </summary>
        /// <remarks>T6</remarks>
        TARIF_6,

        /// <summary> TARIF_7 </summary>
        /// <remarks>T7</remarks>
        TARIF_7,

        /// <summary> TARIF_8 </summary>
        /// <remarks>T8</remarks>
        TARIF_8,

        /// <summary> TARIF_9 </summary>
        /// <remarks>T9</remarks>
        TARIF_9,

        /// <summary> ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT </summary>
        /// <remarks>Z36</remarks>
        ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT,

        /// <summary> ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT </summary>
        /// <remarks>Z37</remarks>
        ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT,

        /// <summary> ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA </summary>
        /// <remarks>Z38</remarks>
        ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA,

        /// <summary> ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG </summary>
        /// <remarks>Z39</remarks>
        ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG,

        /// <summary> KUNDENSELBSTABLESUNG </summary>
        /// <remarks>Z83</remarks>
        KUNDENSELBSTABLESUNG,

        /// <summary> LEERSTAND </summary>
        /// <remarks>Z84</remarks>
        LEERSTAND,

        /// <summary> REALER_ZAEHLERUEBERLAUF_GEPRUEFT </summary>
        /// <remarks>Z85</remarks>
        REALER_ZAEHLERUEBERLAUF_GEPRUEFT,

        /// <summary> PLAUSIBEL_WG_KONTROLLABLESUNG </summary>
        /// <remarks>Z86</remarks>
        PLAUSIBEL_WG_KONTROLLABLESUNG,

        /// <summary> PLAUSIBEL_WG_KUNDENHINWIES </summary>
        /// <remarks>Z87</remarks>
        PLAUSIBEL_WG_KUNDENHINWIES,

        /// <summary> AUSTAUSCH_DES_ERSATZWERTES </summary>
        /// <remarks>ZC3</remarks>
        AUSTAUSCH_DES_ERSATZWERTES,
    }
}