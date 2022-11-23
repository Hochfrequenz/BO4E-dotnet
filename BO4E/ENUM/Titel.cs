using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Übersicht möglicher Titel, z.B. eines Geschäftspartners.</summary>
    public enum Titel
    {
        /// <summary>Doktor</summary>
        [EnumMember(Value = "DR")] 
        DR,

        /// <summary>Professor</summary>
        [EnumMember(Value = "PROF")] 
        PROF,

        /// <summary>Professor Dr.</summary>
        [EnumMember(Value = "PROF_DR")] 
        PROF_DR,
    }
}