using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Diese Rollen kann ein Marktteilnehmer einnehmen.</summary>
    public enum Marktrolle
    {
        /// <summary>
        /// Netzbetreiber
        /// </summary>
        [EnumMember(Value = "NB")]
        NB,

        /// <summary>
        /// Lieferant
        /// </summary>
        [EnumMember(Value = "LF")]
        LF,

        /// <summary>
        /// Messstellenbetreiber (Wettbewerblich)
        /// </summary>
        [EnumMember(Value = "MSB")]
        MSB,

        /// <summary>
        /// Messdienstleister
        /// </summary>
        [EnumMember(Value = "MDL")]
        MDL,

        /// <summary>
        /// Dienstleister
        /// </summary>
        [EnumMember(Value = "DL")]
        DL,

        /// <summary>
        /// Bilanzkreisverantwortlicher
        /// </summary>
        [EnumMember(Value = "BKV")]
        BKV,

        /// <summary>
        /// Bilanzkoordinator/Marktgebietsverantwortlicher
        /// </summary>
        [EnumMember(Value = "BIKO")]
        BIKO,

        /// <summary>
        /// Übertragungsnetzbetreiber
        /// </summary>
        [EnumMember(Value = "UENB")]
        UENB,

        /// <summary>
        /// Kunden die NN-Entgelte selbst zahlen
        /// </summary>
        [EnumMember(Value = "KUNDE_SELBST_NN")]
        KUNDE_SELBST_NN,

        /// <summary>
        /// Marktgebietsverantwortlicher
        /// </summary>
        [EnumMember(Value = "MGV")]
        MGV,

        /// <summary>
        /// Einsatzverantwortlicher
        /// </summary>
        [EnumMember(Value = "EIV")]
        EIV,

        /// <summary>
        /// Registerbetreiber
        /// </summary>
        [EnumMember(Value = "RB")]
        RB,

        /// <summary>
        /// Kunde
        /// </summary>
        [EnumMember(Value = "KUNDE")]
        KUNDE,

        /// <summary>
        /// Interessent
        /// </summary>
        [EnumMember(Value = "INTERESSENT")]
        INTERESSENT,

        /// <summary>
        /// Grundzuständiger Messstellenbetreiber
        /// </summary>
        [EnumMember(Value = "GMSB")]
        GMSB,

        /// <summary>
        /// Auffangmessstellenbetreiber
        /// </summary>
        [EnumMember(Value = "AMSB")]
        AMSB,
    }
}