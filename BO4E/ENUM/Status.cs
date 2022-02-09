using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Represents the Status Code (MSCONS SG10 STS 4405) 
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

        /// <summary> ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG </summary>
        /// <remarks>Z38</remarks>
        ZAEHLERSTAND_ZUM_BEGINN_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA,

        /// <summary> ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG </summary>
        /// <remarks>Z39</remarks>
        ZAEHLERSTAND_ZUM_ENDE_DER_ANGEGEBENEN_ENERGIEMENGE_NICHT_VORHANDEN_DA_MENGENABGRENZUNG,

        /// <summary> KEIN_ZUGANG </summary>
        /// <remarks>Z74</remarks>
        KEIN_ZUGANG,

        /// <summary> KOMMUNIKATIONSSTOERUNG </summary>
        /// <remarks>Z75</remarks>
        KOMMUNIKATIONSSTOERUNG,

        /// <summary> NETZAUSFALL </summary>
        /// <remarks>Z76</remarks>
        NETZAUSFALL,

        /// <summary> SPANNUNGSAUSFALL </summary>
        /// <remarks>Z77</remarks>
        SPANNUNGSAUSFALL,

        /// <summary> STATUS_GERAETEWECHSEL </summary>
        /// <remarks>Needs to have a prefix, because this is also an enum value in <see cref="Themengebiet" /></remarks>
        /// <remarks>Z78</remarks>
        STATUS_GERAETEWECHSEL,

        /// <summary> KALIBRIERUNG </summary>
        /// <remarks>Z79</remarks>
        KALIBRIERUNG,

        /// <summary> GERAET_ARBEITET_AUSSERHALB_DER_BETRIEBSBEDINGUNGEN </summary>
        /// <remarks>Z80</remarks>
        GERAET_ARBEITET_AUSSERHALB_DER_BETRIEBSBEDINGUNGEN,

        /// <summary> MESSEINRICHTUNG_GESTOERT_DEFEKT </summary>
        /// <remarks>Z81</remarks>
        MESSEINRICHTUNG_GESTOERT_DEFEKT,

        /// <summary> UNSICHERHEIT_MESSUNG </summary>
        /// <remarks>Z82</remarks>
        UNSICHERHEIT_MESSUNG,

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

        /// <summary> VERGLEICHSMESSUNG_GEEICHT </summary>
        /// <remarks>Z88</remarks>
        VERGLEICHSMESSUNG_GEEICHT,

        /// <summary> VERGLEICHSMESSUNG_NICHT_GEEICHT </summary>
        /// <remarks>Z89</remarks>
        VERGLEICHSMESSUNG_NICHT_GEEICHT,

        /// <summary> MESSWERTNACHBILDUNG_AUS_GEEICHTEN_WERTEN </summary>
        /// <remarks>Z90</remarks>
        MESSWERTNACHBILDUNG_AUS_GEEICHTEN_WERTEN,

        /// <summary> MESSWERTNACHBILDUNG_AUS_NICHT_GEEICHTEN_WERTEN </summary>
        /// <remarks>Z91</remarks>
        MESSWERTNACHBILDUNG_AUS_NICHT_GEEICHTEN_WERTEN,

        /// <summary> INTERPOLATION </summary>
        /// <remarks>Z92</remarks>
        INTERPOLATION,

        /// <summary> HALTEWERT </summary>
        /// <remarks>Z93</remarks>
        HALTEWERT,

        /// <summary> BILANZIERUNG_NETZABSCHNITT </summary>
        /// <remarks>Z94</remarks>
        BILANZIERUNG_NETZABSCHNITT,

        /// <summary> HISTORISCHE_MESSWERTE </summary>
        /// <remarks>Z95</remarks>
        HISTORISCHE_MESSWERTE,

        /// <summary> BERUECKSICHTIGUNG_STOERMENGENZAEHLWERK </summary>
        /// <remarks>Z98</remarks>
        BERUECKSICHTIGUNG_STOERMENGENZAEHLWERK,

        /// <summary> MENGENUMWERTUNG_VOLLSTAENDIG </summary>
        /// <remarks>Z99</remarks>
        MENGENUMWERTUNG_VOLLSTAENDIG,

        /// <summary> UHRZEIT_GESTELLT_SYNCHRONISATION </summary>
        /// <remarks>ZA0</remarks>
        UHRZEIT_GESTELLT_SYNCHRONISATION,

        /// <summary> MESSWERT_UNPLAUSIBEL </summary>
        /// <remarks>ZA1</remarks>
        MESSWERT_UNPLAUSIBEL,

        /// <summary> FALSCHER_WANDLERFAKTOR </summary>
        /// <remarks>ZA3</remarks>
        FALSCHER_WANDLERFAKTOR,

        /// <summary> FEHLERHAFTE_ABLESUNG </summary>
        /// <remarks>ZA4</remarks>
        FEHLERHAFTE_ABLESUNG,

        /// <summary> AENDERUNG_DER_BERECHNUNG </summary>
        /// <remarks>ZA5</remarks>
        AENDERUNG_DER_BERECHNUNG,

        /// <summary> UMBAU_DER_MESSLOKATION </summary>
        /// <remarks>ZA6</remarks>
        UMBAU_DER_MESSLOKATION,

        /// <summary> DATENBEARBEITUNGSFEHLER </summary>
        /// <remarks>ZA7</remarks>
        DATENBEARBEITUNGSFEHLER,

        /// <summary> BRENNWERTKORREKTUR </summary>
        /// <remarks>ZA8</remarks>
        BRENNWERTKORREKTUR,

        /// <summary> Z_ZAHL_KORREKTUR </summary>
        /// <remarks>ZA9</remarks>
        Z_ZAHL_KORREKTUR,

        /// <summary> STOERUNG_DEFEKT_MESSEINRICHTUNG </summary>
        /// <remarks>ZB0</remarks>
        STOERUNG_DEFEKT_MESSEINRICHTUNG,

        /// <summary> AENDERUNG_TARIFSCHALTZEITEN </summary>
        /// <remarks>ZB9</remarks>
        AENDERUNG_TARIFSCHALTZEITEN,

        /// <summary> TARIFSCHALTGERAET_DEFEKT </summary>
        /// <remarks>ZC2</remarks>
        TARIFSCHALTGERAET_DEFEKT,

        /// <summary> AUSTAUSCH_DES_ERSATZWERTES </summary>
        /// <remarks>ZC3</remarks>
        AUSTAUSCH_DES_ERSATZWERTES,

        /// <summary> IMPULSWERTIGKEIT_NICHT_AUSREICHEND </summary>
        /// <remarks>ZC4</remarks>
        IMPULSWERTIGKEIT_NICHT_AUSREICHEND,

        /// <summary> UMSTELLUNG_GASQUALITAET </summary>
        /// <remarks>ZG3</remarks>
        UMSTELLUNG_GASQUALITAET,

        /// <summary> STATISTISCHE_METHODE </summary>
        /// <remarks>ZJ2</remarks>
        STATISTISCHE_METHODE,

        /// <summary> ENERGIEMENGE_IN_UNGEMESSENEM_ZEITINTERVALL </summary>
        /// <remarks>ZJ8</remarks>
        ENERGIEMENGE_IN_UNGEMESSENEM_ZEITINTERVALL,

        /// <summary> ENERGIEMENGE_AUS_DEM_UNGEPAIRTEN_ZEITINTERVALL </summary>
        /// <remarks>ZJ9</remarks>
        ENERGIEMENGE_AUS_DEM_UNGEPAIRTEN_ZEITINTERVALL,

        /// <summary> AUFTEILUNG </summary>
        /// <remarks>ZQ8</remarks>
        AUFTEILUNG,

        /// <summary> VERWENDUNG_VON_WERTEN_DES_STOERMENGENZAEHLWERKS </summary>
        /// <remarks>ZQ9</remarks>
        VERWENDUNG_VON_WERTEN_DES_STOERMENGENZAEHLWERKS,

        /// <summary> UMGANGS_UND_KORREKTURMENGEN </summary>
        /// <remarks>ZR0</remarks>
        UMGANGS_UND_KORREKTURMENGEN,

        /// <summary> WARTUNGSARBEITEN_AN_GEEICHTEM_MESSGERAET </summary>
        /// <remarks>ZR1</remarks>
        WARTUNGSARBEITEN_AN_GEEICHTEM_MESSGERAET,

        /// <summary> GESTOERTE_WERTE </summary>
        /// <remarks>ZR2</remarks>
        GESTOERTE_WERTE,

        /// <summary> WARTUNGSARBEITEN_AN_EICHRECHTSKONFORMEN_MESSGERAETEN </summary>
        /// <remarks>ZR3</remarks>
        WARTUNGSARBEITEN_AN_EICHRECHTSKONFORMEN_MESSGERAETEN,

        /// <summary> KONSISTENZ_UND_SYNCHRONPRUEFUNG </summary>
        /// <remarks>ZR4</remarks>
        KONSISTENZ_UND_SYNCHRONPRUEFUNG,

        /// <summary> RECHENWERT </summary>
        /// <remarks>ZR5</remarks>
        RECHENWERT,
    }
}