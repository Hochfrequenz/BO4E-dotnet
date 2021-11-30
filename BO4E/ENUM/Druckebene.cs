using System;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Druckebene der Messlokation</summary>
    /// UTILMD SG10 CAV Druckebene der Marktlokation
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Druckebene
    {
        /// <summary>Hochdruck</summary>
        Y01,

        /// <summary>Mitteldruck</summary>
        Y02,

        /// <summary>Niederdruck</summary>
        Y03
    }
}