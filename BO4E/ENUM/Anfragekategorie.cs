using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Kategorie der Anfrage (ORDERS ORDRSP BGM 1001)
    /// </summary>
    [NonOfficial(NonOfficialCategory.MISSING)]
    public enum Anfragekategorie
    {
        /// <summary>PROZESSDATENBERICHT</summary>
        /// <remarks>7</remarks>
        PROZESSDATENBERICHT,


        /// <summary>GERAETEUEBERNAHME</summary>
        /// <remarks>Z10</remarks>
        GERAETEUEBERNAHME,

        /// <summary>WEITERVERPFLICHTUNG_BETRIEB_MELO</summary>
        /// <remarks>Z11</remarks>
        WEITERVERPFLICHTUNG_BETRIEB_MELO,


        /// <summary>AENDERUNG_MELO</summary>
        /// <remarks>Z12</remarks>
        AENDERUNG_MELO,

        /// <summary>STAMMDATEN_MALO_ODER_MELO</summary>
        /// <remarks>Z14</remarks>
        STAMMDATEN_MALO_ODER_MELO,

        /// <summary>BILANZIERTE_MENGE_MEHR_MINDER_MENGEN</summary>
        /// <remarks>Z23</remarks>
        BILANZIERTE_MENGE_MEHR_MINDER_MENGEN,

        /// <summary>ALLOKATIONSLISTE_MEHR_MINDER_MENGEN</summary>
        /// <remarks>Z24</remarks>
        ALLOKATIONSLISTE_MEHR_MINDER_MENGEN,

        /// <summary>ENERGIEMENGE_UND_LEISTUNGSMAXIMUM</summary>
        /// <remarks>Z28</remarks>
        ENERGIEMENGE_UND_LEISTUNGSMAXIMUM,

        /// <summary>ABRECHNUNG_MESSSTELLENBETRIEB_MSB_AN_LF</summary>
        /// <remarks>Z29</remarks>
        ABRECHNUNG_MESSSTELLENBETRIEB_MSB_AN_LF,

        /// <summary> AENDERUNG_PROGNOSEGRUNDLAGE_GERAETEKONFIGURATION</summary>
        /// <remarks>Z30</remarks>
        AENDERUNG_PROGNOSEGRUNDLAGE_GERAETEKONFIGURATION,

        /// <summary> AENDERUNG_GERAETEKONFIGURATION</summary>
        /// <remarks>Z31</remarks>
        AENDERUNG_GERAETEKONFIGURATION,

        /// <summary> REKLAMATION_VON_WERTEN</summary>
        /// <remarks>Z34</remarks>
        REKLAMATION_VON_WERTEN,

        /// <summary>LASTGANG_MALO_TRANCHE</summary>
        /// <remarks>Z48</remarks>
        LASTGANG_MALO_TRANCHE,

        /// <summary>SPERRUNG</summary>
        /// <remarks>Z51</remarks>
        SPERRUNG,

        /// <summary>ENTSPERRUNG</summary>
        /// <remarks>Z52</remarks>
        ENTSPERRUNG

    }
}