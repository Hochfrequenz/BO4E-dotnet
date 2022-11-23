using BO4E.meta;
using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    /// Typ/Art der Anfrage (ORDERS/ORDRSP/QUOTES IMD 7081)
    /// Segment heißt entweder Produkt-/ Leistungsbeschreibung, Abonnement oder Lieferrichtung.
    /// </summary>
    [NonOfficial(NonOfficialCategory.MISSING)]
    public enum Anfragetyp
    {
        /// <summary>START_ABO</summary>
        /// <remarks>Z01</remarks>
        [EnumMember(Value = "START_ABO")]
        START_ABO,

        /// <summary>ENDE_ABO</summary>
        /// <remarks>Z02</remarks>
        [EnumMember(Value = "ENDE_ABO")]
        ENDE_ABO,

        /// <summary>KAUF</summary>
        /// <remarks>Z07</remarks>
        [EnumMember(Value = "KAUF")]
        KAUF,

        /// <summary>NUTZUNGSUEBERLASSUNG</summary>
        /// <remarks>Z08</remarks>
        [EnumMember(Value = "NUTZUNGSUEBERLASSUNG")]
        NUTZUNGSUEBERLASSUNG,

        /// <summary>KANN_NICHT_ANGEBOTEN_WERDEN</summary>
        /// <remarks>Z09</remarks>
        [EnumMember(Value = "KANN_NICHT_ANGEBOTEN_WERDEN")]
        KANN_NICHT_ANGEBOTEN_WERDEN,

        /// <summary>ABRECHNUNGSBRENNWERT_UND_ZUSTANDSZAHL</summary>
        /// <remarks>Z10</remarks>
        [EnumMember(Value = "ABRECHNUNGSBRENNWERT_UND_ZUSTANDSZAHL")]
        ABRECHNUNGSBRENNWERT_UND_ZUSTANDSZAHL,

        /// <summary>LASTGANGDATEN</summary>
        /// <remarks>Z11</remarks>
        [EnumMember(Value = "LASTGANGDATEN")]
        LASTGANGDATEN,

        /// <summary>ZAEHLERSTAENDE</summary>
        /// <remarks>Z12</remarks>
        [EnumMember(Value = "ZAEHLERSTAENDE")]
        ZAEHLERSTAENDE,

        /// <summary>WERTEERMITTLUNG</summary>
        /// <remarks>Z13</remarks>
        [EnumMember(Value = "WERTEERMITTLUNG")]
        WERTEERMITTLUNG,

        /// <summary>LIEFERRICHTUNG</summary>
        /// <remarks>Z14</remarks>
        [EnumMember(Value = "LIEFERRICHTUNG")]
        LIEFERRICHTUNG,

        /// <summary>ANGEBOT_AUF_BASIS_PREISBLATT</summary>
        /// <remarks>Z33</remarks>
        [EnumMember(Value = "ANGEBOT_AUF_BASIS_PREISBLATT")]
        ANGEBOT_AUF_BASIS_PREISBLATT,

        /// <summary>INDIVIDUELLES_ANGEBOT</summary>
        /// <remarks>Z34</remarks>
        [EnumMember(Value = "INDIVIDUELLES_ANGEBOT")]
        INDIVIDUELLES_ANGEBOT,

        /// <summary>ENERGIEMENGE_EINZELWERT</summary>
        /// <remarks>Z35</remarks>
        [EnumMember(Value = "ENERGIEMENGE_EINZELWERT")]
        ENERGIEMENGE_EINZELWERT,


    }
}