using BO4E.meta;

using Newtonsoft.Json.Linq;
using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Unterscheidung zwischen ArtikelId und GruppenArtikelId</summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum ArtikelIdTyp
    {
        /// <summary>Übertragungsnetzbetreiber</summary>
        [ProtoEnum(Name = nameof(ArtikelIdTyp) + "_" + nameof(ARTIKELID))]
        [EnumMember(Value = "ARTIKELID")]
        ARTIKELID,

        /// <summary>Netzbetreiber</summary>
        [ProtoEnum(Name = nameof(ArtikelIdTyp) + "_" + nameof(GRUPPENARTIKELID))]
        [EnumMember(Value = "GRUPPENARTIKELID")]
        GRUPPENARTIKELID
    }
}