using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>SchwachlastfaehigEdi Marktlokation</summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum SchwachlastfaehigEdi
    {
        /// <summary>Z59: Nicht-Schwachlastfähig</summary>
        [Mapping(Schwachlastfaehig.Nicht_Schwachlastfähig)]
        Z59,
        /// <summary>Z60: Schwachlast fähig</summary>
        [Mapping(Schwachlastfaehig.Schwachlastfähig)]
        Z60,       
    }
}