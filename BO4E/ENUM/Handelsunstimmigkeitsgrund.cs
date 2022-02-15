using BO4E.meta;

namespace BO4E.ENUM
{
  /// <summary>
  /// Begründung der Korrektheit der Rechnung oder des Lieferscheins(COMDIS SG3 AJT 4465)
  /// </summary>
  [NonOfficial(NonOfficialCategory.MISSING)]
  public enum Handelsunstimmigkeitsgrund
  {
    /// <summary> ANMDELDUNG_BESTAETIGT</summary>
    /// <remarks>Z58</remarks>
    ANMDELDUNG_BESTAETIGT,

    /// <summary> ABRECHNUNGSBEGINN_GLECIH_BESTAETIGTEM_VERTRAGSBEGINN</summary>
    /// <remarks>Z59</remarks>
    ABRECHNUNGSBEGINN_GLECIH_BESTAETIGTEM_VERTRAGSBEGINN,

    /// <summary> ABRECHNUNGSENDE_GLECIH_BESTAETIGTEM_VERTRAGSBEGINN</summary>
    /// <remarks>Z60</remarks>
    ABRECHNUNGSENDE_GLECIH_BESTAETIGTEM_VERTRAGSBEGINN,

    /// <summary> NN_MSCONS_UEBERSENDET</summary>
    /// <remarks>Z61</remarks>
    NN_MSCONS_UEBERSENDET,

    /// <summary> RICHTIGE_MESSWERTE_ENERGIEMENGEN_UEBERSENDET </summary>
    /// <remarks>Z62</remarks>
    RICHTIGE_MESSWERTE_ENERGIEMENGEN_UEBERSENDET,

    /// <summary> SONSTIGES_SIEHE_FTX </summary>
    /// <remarks>28</remarks>
    SONSTIGES_SIEHE_FTX,
  }
}