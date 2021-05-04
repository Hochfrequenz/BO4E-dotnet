using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>SchwachlastfaehigEdi Marktlokation</summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum SchwachlastfaehigEdi
    {
        /// <summary>Z59: Nicht-Schwachlastfähig</summary>
        [Mapping(Schwachlastfaehig.NICHT_SCHWACHLASTFAEHIG)]
        Z59,
        /// <summary>Z60: Schwachlast fähig</summary>
        [Mapping(Schwachlastfaehig.SCHWACHLASTFAEHIG)]
        Z60
    }
}