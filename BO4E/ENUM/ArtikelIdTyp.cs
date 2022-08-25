using BO4E.meta;

using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Unterscheidung zwischen ArtikelId und GruppenArtikelId</summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum ArtikelIdTyp
    {
        /// <summary>Übertragungsnetzbetreiber</summary>
        [ProtoEnum(Name = nameof(ArtikelIdTyp) + "_" + nameof(ARTIKELID))]
        ARTIKELID,

        /// <summary>Netzbetreiber</summary>
        [ProtoEnum(Name = nameof(ArtikelIdTyp) + "_" + nameof(GRUPPENARTIKELID))]
        GRUPPENARTIKELID
    }
}