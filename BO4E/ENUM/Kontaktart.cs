using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Art des Kontaktes zwischen Geschäftspartnern.</summary>
    public enum Kontaktart
    {
        /// <summary>Anschreiben</summary>
        [EnumMember(Value = "ANSCHREIBEN")]
        ANSCHREIBEN,

        /// <summary>Telefonat</summary>
        [EnumMember(Value = "TELEFONAT")]
        TELEFONAT,

        /// <summary>Fax</summary>
        [EnumMember(Value = "FAX")]
        FAX,

        /// <summary>E-Mail</summary>
        [EnumMember(Value = "E_MAIL")]
        E_MAIL,

        /// <summary>SMS</summary>
        [EnumMember(Value = "SMS")]
        SMS,
    }
}