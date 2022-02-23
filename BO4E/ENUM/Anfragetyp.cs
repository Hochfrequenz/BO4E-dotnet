using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Typ/Art der Anfrage (ORDERS ORDRSP IMD 7081)
    /// Segment heißt entweder Produkt-/ Leistungsbeschreibung, Abonnement oder Lieferrichtung.
    /// </summary>
    [NonOfficial(NonOfficialCategory.MISSING)]
    public enum Anfragetyp
    {
        /// <summary>START_ABO</summary>
        /// <remarks>Z01</remarks>
        START_ABO,

        /// <summary>ENDE_ABO</summary>
        /// <remarks>Z02</remarks>
        ENDE_ABO,

        /// <summary>KAUF</summary>
        /// <remarks>Z07</remarks>
        KAUF,

        /// <summary>NUTZUNGSUEBERLASSUNG</summary>
        /// <remarks>Z08</remarks>
        NUTZUNGSUEBERLASSUNG,

        /// <summary>KANN_NICHT_ANGEBOTEN_WERDEN</summary>
        /// <remarks>Z09</remarks>
        KANN_NICHT_ANGEBOTEN_WERDEN,

        /// <summary>ABRECHNUNGSBRENNWERT_UND_ZUSTANDSZAHL</summary>
        /// <remarks>Z10</remarks>
        ABRECHNUNGSBRENNWERT_UND_ZUSTANDSZAHL,

        /// <summary>LASTGANGDATEN</summary>
        /// <remarks>Z11</remarks>
        LASTGANGDATEN,

        /// <summary>ZAEHLERSTAENDE</summary>
        /// <remarks>Z12</remarks>
        ZAEHLERSTAENDE,

        /// <summary>WERTEERMITTLUNG</summary>
        /// <remarks>Z13</remarks>
        WERTEERMITTLUNG,

        /// <summary>LIEFERRICHTUNG</summary>
        /// <remarks>Z14</remarks>
        LIEFERRICHTUNG,

        /// <summary>ANGEBOT_AUF_BASIS_PREISBLATT</summary>
        /// <remarks>Z33</remarks>
        ANGEBOT_AUF_BASIS_PREISBLATT,

        /// <summary>INDIVIDUELLES_ANGEBOT</summary>
        /// <remarks>Z34</remarks>
        INDIVIDUELLES_ANGEBOT,

        /// <summary>ENERGIEMENGE_EINZELWERT</summary>
        /// <remarks>Z35</remarks>
        ENERGIEMENGE_EINZELWERT,


    }
}