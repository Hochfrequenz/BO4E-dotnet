using BO4E.meta;

using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// Represents the Status Code (MSCONS SG10 STS 4405) 
/// </summary>
[NonOfficial(NonOfficialCategory.UNSPECIFIED)]
public enum Status
{
    /// <summary> TARIF_1 </summary>
    /// <remarks>T1</remarks>
    [EnumMember(Value = "TARIF_1")]
    TARIF_1,

    /// <summary> TARIF_2 </summary>
    /// <remarks>T2</remarks>
    [EnumMember(Value = "TARIF_2")]
    TARIF_2,

    /// <summary> TARIF_3 </summary>
    /// <remarks>T3</remarks>
    [EnumMember(Value = "TARIF_3")]
    TARIF_3,

    /// <summary> TARIF_4 </summary>
    /// <remarks>T4</remarks>
    [EnumMember(Value = "TARIF_4")]
    TARIF_4,

    /// <summary> TARIF_5 </summary>
    /// <remarks>T5</remarks>
    [EnumMember(Value = "TARIF_5")]
    TARIF_5,

    /// <summary> TARIF_6 </summary>
    /// <remarks>T6</remarks>
    [EnumMember(Value = "TARIF_6")]
    TARIF_6,

    /// <summary> TARIF_7 </summary>
    /// <remarks>T7</remarks>
    [EnumMember(Value = "TARIF_7")]
    TARIF_7,

    /// <summary> TARIF_8 </summary>
    /// <remarks>T8</remarks>
    [EnumMember(Value = "TARIF_8")]
    TARIF_8,

    /// <summary> TARIF_9 </summary>
    /// <remarks>T9</remarks>
    [EnumMember(Value = "TARIF_9")]
    TARIF_9,

    /// <summary> ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT </summary>
    /// <remarks>Z36</remarks>
    [EnumMember(Value = "ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT")]
    ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT,

    /// <summary> ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT </summary>
    /// <remarks>Z37</remarks>
    [EnumMember(Value = "ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT")]
    ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_VORHANDEN_UND_KOMMUNIZIERT,

    /// <summary> ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG </summary>
    /// <remarks>Z38</remarks>
    [EnumMember(Value = "ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG")]
    ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG,

    /// <summary> ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG </summary>
    /// <remarks>Z39</remarks>
    [EnumMember(Value = "ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG")]
    ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG,

    /// <summary> KEIN_ZUGANG </summary>
    /// <remarks>Z74</remarks>
    [EnumMember(Value = "KEIN_ZUGANG")]
    KEIN_ZUGANG,

    /// <summary> KOMMUNIKATIONSSTOERUNG </summary>
    /// <remarks>Z75</remarks>
    [EnumMember(Value = "KOMMUNIKATIONSSTOERUNG")]
    KOMMUNIKATIONSSTOERUNG,

    /// <summary> NETZAUSFALL </summary>
    /// <remarks>Z76</remarks>
    [EnumMember(Value = "NETZAUSFALL")]
    NETZAUSFALL,

    /// <summary> SPANNUNGSAUSFALL </summary>
    /// <remarks>Z77</remarks>
    [EnumMember(Value = "SPANNUNGSAUSFALL")]
    SPANNUNGSAUSFALL,

    /// <summary> STATUS_GERAETEWECHSEL </summary>
    /// <remarks>Needs to have a prefix, because this is also an enum value in <see cref="Themengebiet" /></remarks>
    /// <remarks>Z78</remarks>
    [EnumMember(Value = "STATUS_GERAETEWECHSEL")]
    STATUS_GERAETEWECHSEL,

    /// <summary> KALIBRIERUNG </summary>
    /// <remarks>Z79</remarks>
    [EnumMember(Value = "KALIBRIERUNG")]
    KALIBRIERUNG,

    /// <summary> GERAET_ARBEITET_AUSSERHALB_DER_BETRIEBSBEDINGUNGEN </summary>
    /// <remarks>Z80</remarks>
    [EnumMember(Value = "GERAET_ARBEITET_AUSSERHALB_DER_BETRIEBSBEDINGUNGEN")]
    GERAET_ARBEITET_AUSSERHALB_DER_BETRIEBSBEDINGUNGEN,

    /// <summary> MESSEINRICHTUNG_GESTOERT_DEFEKT </summary>
    /// <remarks>Z81</remarks>
    [EnumMember(Value = "MESSEINRICHTUNG_GESTOERT_DEFEKT")]
    MESSEINRICHTUNG_GESTOERT_DEFEKT,

    /// <summary> UNSICHERHEIT_MESSUNG </summary>
    /// <remarks>Z82</remarks>
    [EnumMember(Value = "UNSICHERHEIT_MESSUNG")]
    UNSICHERHEIT_MESSUNG,

    /// <summary> KUNDENSELBSTABLESUNG </summary>
    /// <remarks>Z83</remarks>
    [EnumMember(Value = "KUNDENSELBSTABLESUNG")]
    KUNDENSELBSTABLESUNG,

    /// <summary> LEERSTAND </summary>
    /// <remarks>Z84</remarks>
    [EnumMember(Value = "LEERSTAND")]
    LEERSTAND,

    /// <summary> REALER_ZAEHLERUEBERLAUF_GEPRUEFT </summary>
    /// <remarks>Z85</remarks>
    [EnumMember(Value = "REALER_ZAEHLERUEBERLAUF_GEPRUEFT")]
    REALER_ZAEHLERUEBERLAUF_GEPRUEFT,

    /// <summary> PLAUSIBEL_WG_KONTROLLABLESUNG </summary>
    /// <remarks>Z86</remarks>
    [EnumMember(Value = "PLAUSIBEL_WG_KONTROLLABLESUNG")]
    PLAUSIBEL_WG_KONTROLLABLESUNG,

    /// <summary> PLAUSIBEL_WG_KUNDENHINWEIS </summary>
    /// <remarks>Z87</remarks>
    [EnumMember(Value = "PLAUSIBEL_WG_KUNDENHINWEIS")]
    PLAUSIBEL_WG_KUNDENHINWEIS,

    /// <summary> VERGLEICHSMESSUNG_GEEICHT </summary>
    /// <remarks>Z88</remarks>
    [EnumMember(Value = "VERGLEICHSMESSUNG_GEEICHT")]
    VERGLEICHSMESSUNG_GEEICHT,

    /// <summary> VERGLEICHSMESSUNG_NICHT_GEEICHT </summary>
    /// <remarks>Z89</remarks>
    [EnumMember(Value = "VERGLEICHSMESSUNG_NICHT_GEEICHT")]
    VERGLEICHSMESSUNG_NICHT_GEEICHT,

    /// <summary> MESSWERTNACHBILDUNG_AUS_GEEICHTEN_WERTEN </summary>
    /// <remarks>Z90</remarks>
    [EnumMember(Value = "MESSWERTNACHBILDUNG_AUS_GEEICHTEN_WERTEN")]
    MESSWERTNACHBILDUNG_AUS_GEEICHTEN_WERTEN,

    /// <summary> MESSWERTNACHBILDUNG_AUS_NICHT_GEEICHTEN_WERTEN </summary>
    /// <remarks>Z91</remarks>
    [EnumMember(Value = "MESSWERTNACHBILDUNG_AUS_NICHT_GEEICHTEN_WERTEN")]
    MESSWERTNACHBILDUNG_AUS_NICHT_GEEICHTEN_WERTEN,

    /// <summary> INTERPOLATION </summary>
    /// <remarks>Z92</remarks>
    [EnumMember(Value = "INTERPOLATION")]
    INTERPOLATION,

    /// <summary> HALTEWERT </summary>
    /// <remarks>Z93</remarks>
    [EnumMember(Value = "HALTEWERT")]
    HALTEWERT,

    /// <summary> BILANZIERUNG_NETZABSCHNITT </summary>
    /// <remarks>Z94</remarks>
    [EnumMember(Value = "BILANZIERUNG_NETZABSCHNITT")]
    BILANZIERUNG_NETZABSCHNITT,

    /// <summary> HISTORISCHE_MESSWERTE </summary>
    /// <remarks>Z95</remarks>
    [EnumMember(Value = "HISTORISCHE_MESSWERTE")]
    HISTORISCHE_MESSWERTE,

    /// <summary> BERUECKSICHTIGUNG_STOERMENGENZAEHLWERK </summary>
    /// <remarks>Z98</remarks>
    [EnumMember(Value = "BERUECKSICHTIGUNG_STOERMENGENZAEHLWERK")]
    BERUECKSICHTIGUNG_STOERMENGENZAEHLWERK,

    /// <summary> MENGENUMWERTUNG_VOLLSTAENDIG </summary>
    /// <remarks>Z99</remarks>
    [EnumMember(Value = "MENGENUMWERTUNG_VOLLSTAENDIG")]
    MENGENUMWERTUNG_VOLLSTAENDIG,

    /// <summary> UHRZEIT_GESTELLT_SYNCHRONISATION </summary>
    /// <remarks>ZA0</remarks>
    [EnumMember(Value = "UHRZEIT_GESTELLT_SYNCHRONISATION")]
    UHRZEIT_GESTELLT_SYNCHRONISATION,

    /// <summary> MESSWERT_UNPLAUSIBEL </summary>
    /// <remarks>ZA1</remarks>
    [EnumMember(Value = "MESSWERT_UNPLAUSIBEL")]
    MESSWERT_UNPLAUSIBEL,

    /// <summary> FALSCHER_WANDLERFAKTOR </summary>
    /// <remarks>ZA3</remarks>
    [EnumMember(Value = "FALSCHER_WANDLERFAKTOR")]
    FALSCHER_WANDLERFAKTOR,

    /// <summary> FEHLERHAFTE_ABLESUNG </summary>
    /// <remarks>ZA4</remarks>
    [EnumMember(Value = "FEHLERHAFTE_ABLESUNG")]
    FEHLERHAFTE_ABLESUNG,

    /// <summary> AENDERUNG_DER_BERECHNUNG </summary>
    /// <remarks>ZA5</remarks>
    [EnumMember(Value = "AENDERUNG_DER_BERECHNUNG")]
    AENDERUNG_DER_BERECHNUNG,

    /// <summary> UMBAU_DER_MESSLOKATION </summary>
    /// <remarks>ZA6</remarks>
    [EnumMember(Value = "UMBAU_DER_MESSLOKATION")]
    UMBAU_DER_MESSLOKATION,

    /// <summary> DATENBEARBEITUNGSFEHLER </summary>
    /// <remarks>ZA7</remarks>
    [EnumMember(Value = "DATENBEARBEITUNGSFEHLER")]
    DATENBEARBEITUNGSFEHLER,

    /// <summary> BRENNWERTKORREKTUR </summary>
    /// <remarks>ZA8</remarks>
    [EnumMember(Value = "BRENNWERTKORREKTUR")]
    BRENNWERTKORREKTUR,

    /// <summary> Z_ZAHL_KORREKTUR </summary>
    /// <remarks>ZA9</remarks>
    [EnumMember(Value = "Z_ZAHL_KORREKTUR")]
    Z_ZAHL_KORREKTUR,

    /// <summary> STOERUNG_DEFEKT_MESSEINRICHTUNG </summary>
    /// <remarks>ZB0</remarks>
    [EnumMember(Value = "STOERUNG_DEFEKT_MESSEINRICHTUNG")]
    STOERUNG_DEFEKT_MESSEINRICHTUNG,

    /// <summary> AENDERUNG_TARIFSCHALTZEITEN </summary>
    /// <remarks>ZB9</remarks>
    [EnumMember(Value = "AENDERUNG_TARIFSCHALTZEITEN")]
    AENDERUNG_TARIFSCHALTZEITEN,

    /// <summary> TARIFSCHALTGERAET_DEFEKT </summary>
    /// <remarks>ZC2</remarks>
    [EnumMember(Value = "TARIFSCHALTGERAET_DEFEKT")]
    TARIFSCHALTGERAET_DEFEKT,

    /// <summary> AUSTAUSCH_DES_ERSATZWERTES </summary>
    /// <remarks>ZC3</remarks>
    [EnumMember(Value = "AUSTAUSCH_DES_ERSATZWERTES")]
    AUSTAUSCH_DES_ERSATZWERTES,

    /// <summary> IMPULSWERTIGKEIT_NICHT_AUSREICHEND </summary>
    /// <remarks>ZC4</remarks>
    [EnumMember(Value = "IMPULSWERTIGKEIT_NICHT_AUSREICHEND")]
    IMPULSWERTIGKEIT_NICHT_AUSREICHEND,

    /// <summary> UMSTELLUNG_GASQUALITAET </summary>
    /// <remarks>ZG3</remarks>
    [EnumMember(Value = "UMSTELLUNG_GASQUALITAET")]
    UMSTELLUNG_GASQUALITAET,

    /// <summary> STATISTISCHE_METHODE </summary>
    /// <remarks>ZJ2</remarks>
    [EnumMember(Value = "STATISTISCHE_METHODE")]
    STATISTISCHE_METHODE,

    /// <summary> ENERGIEMENGE_IN_UNGEMESSENEM_ZEITINTERVALL </summary>
    /// <remarks>ZJ8</remarks>
    [EnumMember(Value = "ENERGIEMENGE_IN_UNGEMESSENEM_ZEITINTERVALL")]
    ENERGIEMENGE_IN_UNGEMESSENEM_ZEITINTERVALL,

    /// <summary> ENERGIEMENGE_AUS_DEM_UNGEPAIRTEN_ZEITINTERVALL </summary>
    /// <remarks>ZJ9</remarks>
    [EnumMember(Value = "ENERGIEMENGE_AUS_DEM_UNGEPAIRTEN_ZEITINTERVALL")]
    ENERGIEMENGE_AUS_DEM_UNGEPAIRTEN_ZEITINTERVALL,

    /// <summary> AUFTEILUNG </summary>
    /// <remarks>ZQ8</remarks>
    [EnumMember(Value = "AUFTEILUNG")]
    AUFTEILUNG,

    /// <summary> VERWENDUNG_VON_WERTEN_DES_STOERMENGENZAEHLWERKS </summary>
    /// <remarks>ZQ9</remarks>
    [EnumMember(Value = "VERWENDUNG_VON_WERTEN_DES_STOERMENGENZAEHLWERKS")]
    VERWENDUNG_VON_WERTEN_DES_STOERMENGENZAEHLWERKS,

    /// <summary> UMGANGS_UND_KORREKTURMENGEN </summary>
    /// <remarks>ZR0</remarks>
    [EnumMember(Value = "UMGANGS_UND_KORREKTURMENGEN")]
    UMGANGS_UND_KORREKTURMENGEN,

    /// <summary> WARTUNGSARBEITEN_AN_GEEICHTEM_MESSGERAET </summary>
    /// <remarks>ZR1</remarks>
    [EnumMember(Value = "WARTUNGSARBEITEN_AN_GEEICHTEM_MESSGERAET")]
    WARTUNGSARBEITEN_AN_GEEICHTEM_MESSGERAET,

    /// <summary> GESTOERTE_WERTE </summary>
    /// <remarks>ZR2</remarks>
    [EnumMember(Value = "GESTOERTE_WERTE")]
    GESTOERTE_WERTE,

    /// <summary> WARTUNGSARBEITEN_AN_EICHRECHTSKONFORMEN_MESSGERAETEN </summary>
    /// <remarks>ZR3</remarks>
    [EnumMember(Value = "WARTUNGSARBEITEN_AN_EICHRECHTSKONFORMEN_MESSGERAETEN")]
    WARTUNGSARBEITEN_AN_EICHRECHTSKONFORMEN_MESSGERAETEN,

    /// <summary> KONSISTENZ_UND_SYNCHRONPRUEFUNG </summary>
    /// <remarks>ZR4</remarks>
    [EnumMember(Value = "KONSISTENZ_UND_SYNCHRONPRUEFUNG")]
    KONSISTENZ_UND_SYNCHRONPRUEFUNG,

    /// <summary> RECHENWERT </summary>
    /// <remarks>ZR5</remarks>
    [EnumMember(Value = "RECHENWERT")]
    RECHENWERT,

    /// <summary> ANGABEN_MESSLOKATION </summary>
    /// <remarks>ZS0</remarks>
    [EnumMember(Value = "ANGABEN_MESSLOKATION")]
    ANGABEN_MESSLOKATION,
    /// <summary> BASIS_MME </summary>
    /// <remarks>ZS2</remarks>
    [EnumMember(Value = "BASIS_MME")]
    BASIS_MME,
    /// <summary> GRUND_ANGABEN_MESSLOKATION </summary>
    /// <remarks>ZS9</remarks>
    [EnumMember(Value = "GRUND_ANGABEN_MESSLOKATION")]
    GRUND_ANGABEN_MESSLOKATION,
    /// <summary> ANFORDERUNG_IN_DIE_VERGANGENHEIT_ZUM_ANGEFORDERTEN_ZEITPUNKT_LIEGT_KEIN_WERT_VOR </summary>
    /// <remarks>ZT8</remarks>
    [EnumMember(Value = "ANFORDERUNG_IN_DIE_VERGANGENHEIT_ZUM_ANGEFORDERTEN_ZEITPUNKT_LIEGT_KEIN_WERT_VOR")]
    ANFORDERUNG_IN_DIE_VERGANGENHEIT_ZUM_ANGEFORDERTEN_ZEITPUNKT_LIEGT_KEIN_WERT_VOR,

}
