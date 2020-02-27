using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// EDIFACT values of <see cref="NetznutzungsVertrag"/>
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum NetznutzungsvertragEdi
    {
        /// <summary>Z08: Direkter Vertrag zwischen Kunden und NB</summary>
        [Mapping(NetznutzungsVertrag.KUNDEN_NB)]
        Z08,

        /// <summary>Z09: Vertrag zwischen Lieferanten und NB</summary>
        [Mapping(NetznutzungsVertrag.KUNDEN_NB)]
        Z09,
    }
}
