using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// EDIFACT values of <see cref="Zaehlertyp"/>
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum ZaehlertypEdi
    {
        /// <summary>Analoger Haushaltszähler (Drehstrom)</summary>
        [Mapping(Zaehlertyp.DREHSTROMZAEHLER)]
        AHZ,
        /// <summary>analoger Wechselstromzähler</summary>
        WSZ,
        /// <summary>Lastgangzähler</summary>
        LAZ,
        /// <summary>Maximumzähler</summary>
        [Mapping(Zaehlertyp.MAXIMUMZAEHLER)]
        MAZ,
        /// <summary>moderne Messeinrichtung nach MsbG</summary>
        MME,
        /// <summary>Drehkolbengaszähler</summary>
        [Mapping(Zaehlertyp.DREHKOLBENZAEHLER)]
        DKZ,
        /// <summary>Balgengaszähler</summary>
        [Mapping(Zaehlertyp.BALGENGASZAEHLER)]
        BGZ,
        /// <summary>Turbinenradgaszähler</summary>
        [Mapping(Zaehlertyp.TURBINENRADGASZAEHLER)]
        TRZ,
        /// <summary>Ultraschallgaszähler</summary>
        [Mapping(Zaehlertyp.ULTRASCHALLGASZAEHLER)]
        UGZ,
        /// <summary>Wirbelgaszähler</summary>
        WGZ,
        /// <summary>Messdatenregistriergerät</summary>
        MRG,
        /// <summary>Elektronischer Haushalszähler</summary>
        EHZ,
        /// <summary>Individuelle Abstimmung (Sonderausstattung)</summary>
        IVA
    }
}