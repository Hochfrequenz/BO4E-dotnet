using BO4E.meta;

namespace BO4E.ENUM.EDI
{    /// <summary>
     /// EDIFACT values of <see cref="Zaehlerauspraegung"/>
     /// </summary>
     /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum ZaehlerauspraegungEdi
    {
        /// <summary>Einrichtungszähler</summary>
        [Mapping(Zaehlerauspraegung.EINRICHTUNGSZAEHLER)]
        ERZ,
        /// <summary>Zweirichtungszähler</summary>
        [Mapping(Zaehlerauspraegung.ZWEIRICHTUNGSZAEHLER)]
        ZRZ
    }
}