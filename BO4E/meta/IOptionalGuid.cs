using System;

namespace BO4E.meta
{
    /// <summary>
    /// Our BO and COM objects all come with a nullable Guid <code>Guid?</code>.
    /// This interface allows to define extensions methods namely for Entity Framework that use this Guid as key.
    /// </summary>
    public interface IOptionalGuid
    {
        /// <summary>
        /// a nullable Guid that may be used as key in database tables.
        /// </summary>
        Guid? Guid { get; set; }
    }
}