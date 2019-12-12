using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// EDIFACT values of <see cref="Geraetetyp"/>
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum GeraetetypEdi
    {
        /// <summary>Analoger Haushaltszähler (Drehstrom)</summary>
        [Mapping(Geraetetyp.DREHSTROMZAEHLER)]
        AHZ,
        /// <summary>analoger Wechselstromzähler</summary>
        [Mapping(Geraetetyp.WECHSELSTROMZAEHLER)]
        WSZ,
        /// <summary>Lastgangzähler</summary>
        [Mapping(Geraetetyp.VIER_QUADRANTEN_LASTGANGZAEHLER)]
        LAZ,
        /// <summary>Maximumzähler</summary>
        [Mapping(Geraetetyp.MAXIMUMZAEHLER)]
        MAZ,
        /// <summary>moderne Messeinrichtung nach MsbG</summary>
        [Mapping(Geraetetyp.MODERNE_MESSEINRICHTUNG)]
        MME,
        /// <summary>Drehkolbengaszähler</summary>
        [Mapping(Geraetetyp.DREHKOLBENGASZAEHLER)]
        DKZ,
        /// <summary>Balgengaszähler</summary>
        [Mapping(Geraetetyp.BALGENGASZAEHLER)]
        BGZ,
        /// <summary>Turbinenradgaszähler</summary>
        [Mapping(Geraetetyp.TURBINENRADGASZAEHLER)]
        TRZ,
        /// <summary>Ultraschallgaszähler</summary>
        [Mapping(Geraetetyp.ULTRASCHALLZAEHLER)]
        UGZ,
        /// <summary>Wirbelgaszähler</summary>
        [Mapping(Geraetetyp.WIRBELGASZAEHLER)]
        WGZ,
        /// <summary>Messdatenregistriergerät</summary>
        MRG,
        /// <summary>Elektronischer Haushalszähler</summary>
        [Mapping(Geraetetyp.ELEKTRONISCHER_HAUSHALTSZAEHLER)]
        EHZ,
        /// <summary>Individuelle Abstimmung (Sonderausstattung)</summary>
        IVA
    }
}